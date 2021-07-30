using System;

using System.Collections;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Net;

using System.Reflection;

using System.Text;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API.Logger;

using Com.Zoho.Crm.API.Record;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class processes the API response object to the POJO object and POJO object to a JSON object.
    /// </summary>
    public class JSONConverter : Converter
    {
        public JSONConverter(CommonAPIHandler commonAPIHandler) : base(commonAPIHandler) { }

        private Dictionary<string, List<object>> uniqueValuesMap = new Dictionary<string, List<object>>();

        public override void AppendToRequest(HttpWebRequest requestBase, object requestObject)
        {
            string dataString = requestObject.ToString();

            var data = Encoding.UTF8.GetBytes(dataString);

            int dataLength = data.Length;

            requestBase.ContentLength = dataLength;

            using (var writer = requestBase.GetRequestStream())
            {
                writer.Write(data, 0, dataLength);
            }
        }

        public override object FormRequest(object requestInstance, string pack, int? instanceNumber, JObject memberDetail)
        {
            JObject classDetail = (JObject)Initializer.jsonDetails.GetValue(pack); // JSONdetails of class

            if (classDetail.ContainsKey(Constants.INTERFACE) && (bool)classDetail.GetValue(Constants.INTERFACE))
            {
                JArray classes = (JArray)classDetail[Constants.CLASSES];

                string requestObjectClassName = requestInstance.GetType().FullName;

                foreach (object className in classes)
                {
                    if (((string)className).Equals(requestObjectClassName, StringComparison.OrdinalIgnoreCase))
                    {
                        classDetail = (JObject)Initializer.jsonDetails.GetValue(requestObjectClassName);

                        break;
                    }
                }
            }

            if (requestInstance is Record.Record)
            {
                string moduleAPIName = this.commonAPIHandler.ModuleAPIName;

                JObject requestJSON = IsRecordRequest(requestInstance, classDetail, instanceNumber, memberDetail);

                this.commonAPIHandler.ModuleAPIName = moduleAPIName;

                return requestJSON;
            }
            else
            {
                return IsNotRecordRequest(requestInstance, classDetail, instanceNumber, memberDetail);
            }
        }

        private JObject IsNotRecordRequest(object requestInstance, JObject classDetail, int? instanceNumber, JObject classMemberDetail)
        {
            bool lookUp = false;

            bool skipMandatory = false;

            string classMemberName = null;

            if (classMemberDetail != null)
            {
                lookUp = classMemberDetail.ContainsKey(Constants.LOOKUP) ? (bool)classMemberDetail[Constants.LOOKUP] : false;

                skipMandatory = classMemberDetail.ContainsKey(Constants.SKIP_MANDATORY) ? (bool)classMemberDetail[Constants.SKIP_MANDATORY] : false;

                string name = classMemberDetail.ContainsKey(Constants.NAME) ? classMemberDetail[Constants.NAME].ToString() : "";

                classMemberName = BuildName(name);
            }

            JObject requestJSON = new JObject();

            Dictionary<string, bool> requiredKeys = new Dictionary<string, bool>();

            Dictionary<string, bool> primaryKeys = new Dictionary<string, bool>();

            Dictionary<string, bool> requiredInUpdateKeys = new Dictionary<string, bool>();

            foreach (KeyValuePair<string, JToken> data in classDetail) // all members
            {
                string memberName = data.Key;

                JObject memberDetail = (JObject)data.Value;

                object modification = null;

                if ((memberDetail.ContainsKey(Constants.READ_ONLY) && (bool)memberDetail.GetValue(Constants.READ_ONLY)) || !memberDetail.ContainsKey(Constants.NAME))
                {
                    continue;
                }

                string keyName = (string)memberDetail[Constants.NAME];

                try
                {
                    MethodInfo isKeyModified = requestInstance.GetType().GetMethod(Constants.IS_KEY_MODIFIED);

                    object[] param = new object[1];

                    param[0] = memberDetail.GetValue(Constants.NAME).ToString();

                    modification = isKeyModified.Invoke(requestInstance, param);
                }
                catch (Exception ex)
                {
                    throw new SDKException(Constants.EXCEPTION_IS_KEY_MODIFIED, ex);
                }

                bool required = memberDetail.ContainsKey(Constants.REQUIRED) ? (bool)memberDetail[Constants.REQUIRED] : false;

                if (memberDetail.ContainsKey(Constants.REQUIRED) && required)
                {
                    requiredKeys.Add(keyName, true);
                }

                bool requiredInUpdate = memberDetail.ContainsKey(Constants.REQUIRED_IN_UPDATE) ? (bool)memberDetail[Constants.REQUIRED_IN_UPDATE] : false;

                if (requiredInUpdate)
                {
                    requiredInUpdateKeys.Add(keyName, true);
                }

                bool primary = memberDetail.ContainsKey(Constants.PRIMARY) ? (bool)memberDetail[Constants.PRIMARY] : false;

                if (memberDetail.ContainsKey(Constants.PRIMARY) && primary && (!memberDetail.ContainsKey(Constants.REQUIRED_IN_UPDATE) || (bool)memberDetail[Constants.REQUIRED_IN_UPDATE]))
                {
                    primaryKeys.Add(keyName, true);
                }

                object fieldValue = null;

                if (modification != null && (int)modification != 0)
                {
                    FieldInfo field = GetPrivateFieldInfo(requestInstance.GetType(), memberName);

                    fieldValue = field.GetValue(requestInstance);// value of the member

                    if (this.ValueChecker(requestInstance.GetType().FullName, memberName, memberDetail, fieldValue, uniqueValuesMap, instanceNumber) == true)// set if not null
                    {
                        if (fieldValue != null)
                        {
                            requiredKeys.Remove(keyName);

                            primaryKeys.Remove(keyName);

                            requiredInUpdateKeys.Remove(keyName);
                        }

                        if (requestInstance is FileDetails)
                        {
                            requestJSON.Add(keyName.ToLower(), fieldValue != null ? JToken.FromObject(fieldValue) : JValue.CreateNull());
                        }
                        else
                        {
                            object recordData = SetData(memberDetail, fieldValue);

                            requestJSON.Add((string)memberDetail.GetValue(Constants.NAME), recordData != null ? JToken.FromObject(recordData) : JValue.CreateNull());
                        }
                    }
                }
            }

            if (skipMandatory || CheckException(classMemberName, requestInstance, instanceNumber, lookUp, requiredKeys, primaryKeys, requiredInUpdateKeys))
            {
                return requestJSON;
            }

            return requestJSON;
        }

        private bool CheckException(string memberName, object requestInstance, int? instanceNumber, bool lookUp, Dictionary<string, bool> requiredKeys, Dictionary<string, bool> primaryKeys, Dictionary<string, bool> requiredInUpdateKeys)
        {
            if (requiredInUpdateKeys.Count() > 0 && this.commonAPIHandler.CategoryMethod.Equals(Constants.REQUEST_CATEGORY_UPDATE, StringComparison.OrdinalIgnoreCase))
            {
                JObject error = new JObject();

                error.Add(Constants.FIELD, memberName);

                error.Add(Constants.TYPE, requestInstance.GetType().FullName);

                error.Add(Constants.KEYS, string.Join(",", requiredInUpdateKeys.Keys));

                if (instanceNumber != null)
                {
                    error.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                }

                throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.MANDATORY_KEY_ERROR, error, null);
            }

            if (commonAPIHandler.MandatoryChecker)
            {
                if (this.commonAPIHandler.CategoryMethod.Equals(Constants.REQUEST_CATEGORY_CREATE, StringComparison.OrdinalIgnoreCase))
                {
                    if (lookUp)
                    {
                        if (primaryKeys.Count > 0)
                        {
                            JObject error = new JObject();

                            error.Add(Constants.FIELD, memberName);

                            error.Add(Constants.TYPE, requestInstance.GetType().FullName);

                            error.Add(Constants.KEYS, string.Join(",", primaryKeys.Keys));

                            if (instanceNumber != null)
                            {
                                error.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                            }

                            throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.PRIMARY_KEY_ERROR, error, null);
                        }
                    }
                    else if (requiredKeys.Count > 0)
                    {
                        JObject error = new JObject();

                        error.Add(Constants.FIELD, memberName);

                        error.Add(Constants.TYPE, requestInstance.GetType().FullName);

                        error.Add(Constants.KEYS, string.Join(",", requiredKeys.Keys));

                        if (instanceNumber != null)
                        {
                            error.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                        }

                        throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.MANDATORY_KEY_ERROR, error, null);
                    }
                }

                if (this.commonAPIHandler.CategoryMethod.Equals(Constants.REQUEST_CATEGORY_UPDATE, StringComparison.OrdinalIgnoreCase) && primaryKeys.Count > 0)
                {
                    JObject error = new JObject();

                    error.Add(Constants.FIELD, memberName);

                    error.Add(Constants.TYPE, requestInstance.GetType().FullName);

                    error.Add(Constants.KEYS, string.Join(",", primaryKeys.Keys));

                    if (instanceNumber != null)
                    {
                        error.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                    }

                    throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.PRIMARY_KEY_ERROR, error, null);
                }
            }
            else if (lookUp && this.commonAPIHandler.CategoryMethod.Equals(Constants.REQUEST_CATEGORY_UPDATE, StringComparison.OrdinalIgnoreCase))
            {
                if (primaryKeys.Count > 0)
                {
                    JObject error = new JObject();

                    error.Add(Constants.FIELD, memberName);

                    error.Add(Constants.TYPE, requestInstance.GetType().FullName);

                    error.Add(Constants.KEYS, string.Join(",", primaryKeys.Keys));

                    if(instanceNumber != null)
                    {
                        error.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                    }

                    throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.PRIMARY_KEY_ERROR, error, null);
                }
            }

            return true;
        }

        private JObject IsRecordRequest(object recordInstance, JObject classDetail, int? instanceNumber, JObject memberDetail)
        {
            bool lookUp = false;

            bool skipMandatory = false;

            string classMemberName = null;

            if (memberDetail != null)
            {
                lookUp = memberDetail.ContainsKey(Constants.LOOKUP) ? (bool)memberDetail[Constants.LOOKUP] : false;

                skipMandatory = memberDetail.ContainsKey(Constants.SKIP_MANDATORY) ? (bool)memberDetail[Constants.SKIP_MANDATORY] : false;

                classMemberName = memberDetail.ContainsKey(Constants.NAME) ? memberDetail[Constants.NAME].ToString() : "";
            }

            JObject requestJSON = new JObject();

            JObject moduleDetail = new JObject();

            string moduleAPIName = this.commonAPIHandler.ModuleAPIName;

            if (moduleAPIName != null)// entry
            {
                this.commonAPIHandler.ModuleAPIName = null;

                JObject fullDetail = Utility.SearchJSONDetails(moduleAPIName);// to get correct moduleapiname in proper format

                if (fullDetail != null)// from Jsondetails
                {
                    moduleDetail = (JObject)fullDetail[Constants.MODULEDETAILS];
                }
                else// from user spec
                {
                    moduleDetail = GetModuleDetailFromUserSpecJSON(moduleAPIName);
                }
            }
            else// inner case
            {
                moduleDetail = classDetail;

                classDetail = (JObject)Initializer.jsonDetails[Constants.RECORD_NAMESPACE];
            } // class detail must contain record structure at this point

            Type cl = recordInstance.GetType();

            Type scl = cl.BaseType;

            if (scl.FullName.Equals(Constants.RECORD_NAMESPACE))
            {
                cl = scl;
            }

            FieldInfo keyValueField = GetPrivateFieldInfo(cl, Constants.KEY_VALUES);

            FieldInfo keyModifiedField = GetPrivateFieldInfo(cl, Constants.KEY_MODIFIED);

            Dictionary<string, object> keyValues = (Dictionary<string, object>)keyValueField.GetValue(recordInstance);

            Dictionary<string, int?> keyModified = (Dictionary<string, int?>)keyModifiedField.GetValue(recordInstance);

            Dictionary<string, bool> requiredKeys = new Dictionary<string, bool>();

            Dictionary<string, bool> primaryKeys = new Dictionary<string, bool>();

            if (!skipMandatory)
            {
                foreach (KeyValuePair<string,JToken> keyDetail in moduleDetail)
                {
                    JObject keyDetails = (JObject)keyDetail.Value;

                    string name = (string)keyDetails[Constants.NAME];

                    if (keyDetails.ContainsKey(Constants.REQUIRED) && (bool)keyDetails[Constants.REQUIRED])
                    {
                        requiredKeys[name] = true;
                    }

                    if (keyDetails.ContainsKey(Constants.PRIMARY) && (bool)keyDetails[Constants.PRIMARY])
                    {
                        primaryKeys[name] = true;
                    }
                }

                foreach (KeyValuePair<string, JToken> keyDetail in classDetail)
                {
                    JObject keyDetails = (JObject)keyDetail.Value;

                    string name = keyDetail.Key;

                    if (keyDetails.ContainsKey(Constants.REQUIRED) && (bool)keyDetails[Constants.REQUIRED])
                    {
                        requiredKeys[name] = true;
                    }

                    if (keyDetails.ContainsKey(Constants.PRIMARY) && (bool)keyDetails[Constants.PRIMARY])
                    {
                        primaryKeys[name] = true;
                    }
                }
            }

            foreach (KeyValuePair<string, int?> keyDetail in keyModified)
            {
                string keyName = keyDetail.Key;

                if (keyDetail.Value != null && keyDetail.Value != 1)
                {
                    continue;
                }

                JObject keyDetails = new JObject();

                object keyValue = keyValues.ContainsKey(keyName) ? keyValues[keyName] : null;

                object jsonValue = null;

                string memberName = BuildName(keyName);

                if (moduleDetail.Count > 0 && (moduleDetail.ContainsKey(keyName) || moduleDetail.ContainsKey(memberName)))
                {
                    if (moduleDetail.ContainsKey(keyName))
                    {
                        keyDetails = (JObject)moduleDetail[keyName];// incase of user spec json
                    }
                    else
                    {
                        keyDetails = (JObject)moduleDetail[memberName];// json details
                    }
                }
                else if (classDetail.ContainsKey(memberName))
                {
                    keyDetails = (JObject)classDetail[memberName];
                }

                if (keyDetails.Count > 0)
                {
                    if ((keyDetails.ContainsKey(Constants.READ_ONLY) && (bool)keyDetails[Constants.READ_ONLY]) || !keyDetails.ContainsKey(Constants.NAME))// read only or no keyName
                    {
                        continue;
                    }

                    if (this.ValueChecker(cl.GetType().FullName, memberName, keyDetails, keyValue, uniqueValuesMap, instanceNumber) == true)
                    {
                        jsonValue = SetData(keyDetails, keyValue);
                    }
                }
                else
                {
                    jsonValue = RedirectorForObjectToJSON(keyValue);
                }

                if (keyValue != null)
                {
                    requiredKeys.Remove(keyName);

                    primaryKeys.Remove(keyName);
                }

                requestJSON.Add(keyName, jsonValue != null ? JToken.FromObject(jsonValue) : JValue.CreateNull());
            }

            if (skipMandatory || CheckException(classMemberName, recordInstance, instanceNumber, lookUp, requiredKeys, primaryKeys, new Dictionary<string, bool>()))
            {
                return requestJSON;
            }

            return requestJSON;
        }

        private object SetData(JObject memberDetail, object fieldValue)
        {
            if (fieldValue != null)
            {
                string type = (string)memberDetail[Constants.TYPE];

                if (type.Equals(Constants.LIST_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                {
                    return SetJSONArray(fieldValue, memberDetail);
                }
                else if (type.Equals(Constants.MAP_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                {
                    return SetJSONObject(fieldValue, memberDetail);
                }
                else if (type.Equals(Constants.CHOICE_NAMESPACE) || (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) && ((string)memberDetail[Constants.STRUCTURE_NAME]).Equals(Constants.CHOICE_NAMESPACE)))
                {
                    Type t = fieldValue.GetType();

                    PropertyInfo prop = t.GetProperty("Value");

                    return prop.GetValue(fieldValue);
                }
                else if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) && memberDetail.ContainsKey(Constants.MODULE))
                {
                    return IsRecordRequest(fieldValue, GetModuleDetailFromUserSpecJSON((string)memberDetail[Constants.MODULE]), null, memberDetail);
                }
                else if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME))
                {
                    return FormRequest(fieldValue, (string)memberDetail[Constants.STRUCTURE_NAME], null, memberDetail);
                }
                else
                {
                    Type t = Type.GetType(Constants.DATATYPECONVERTER.Replace(Constants._TYPE, type));

                    MethodInfo method = t.GetMethod(Constants.POST_CONVERT);

                    return method.Invoke(null, new object[] { fieldValue, type });
                }
            }

            return JValue.CreateNull();
        }

        private JObject SetJSONObject(object fieldValue, JObject memberDetail)
        {
            JObject jsonObject = new JObject();

            IDictionary requestObject = (IDictionary)fieldValue;

            if (requestObject.Count > 0)
            {
                if (memberDetail == null || (memberDetail != null && !memberDetail.ContainsKey(Constants.KEYS)))
                {
                    foreach (var key in requestObject.Keys)
                    {
                        object data = RedirectorForObjectToJSON(requestObject[key]);
                        
                        jsonObject.Add((string)key, data != null ? JToken.FromObject(data) : JValue.CreateNull());
                    }
                }
                else
                {
                    if (memberDetail.ContainsKey(Constants.KEYS))
                    {
                        JArray keysDetail = (JArray)memberDetail.GetValue(Constants.KEYS);

                        for (int keyIndex = 0; keyIndex < keysDetail.Count; keyIndex++)
                        {
                            JObject keyDetail = (JObject)keysDetail[keyIndex];

                            string keyName = (string)keyDetail.GetValue(Constants.NAME);

                            object keyValue = null;

                            if (requestObject.Contains(keyName) && requestObject[keyName] != null)
                            {
                                keyValue = SetData(keyDetail, requestObject[keyName]);

                                jsonObject.Add(keyName, keyValue != null ? JToken.FromObject(keyValue) : JValue.CreateNull());
                            }
                        }
                    }
                }
            }

            return jsonObject;
        }

        private JArray SetJSONArray(object fieldValue, JObject memberDetail)
        {
            JArray jsonArray = new JArray();

            IList requestObjects = (IList)fieldValue;

            if (requestObjects.Count > 0)
            {
                if (memberDetail == null || (memberDetail != null && !memberDetail.ContainsKey(Constants.STRUCTURE_NAME)))
                {
                    foreach (object request in requestObjects)
                    {
                        jsonArray.Add(RedirectorForObjectToJSON(request));
                    }
                }
                else
                {
                    string pack = (string)memberDetail.GetValue(Constants.STRUCTURE_NAME);

                    if (pack.Equals(Constants.CHOICE_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (object request in requestObjects)
                        {
                            FieldInfo field = GetPrivateFieldInfo(request.GetType(), "value");

                            jsonArray.Add(field.GetValue(request));
                        }
                    }
                    else if (memberDetail.ContainsKey(Constants.MODULE) && memberDetail[Constants.MODULE] != null)
                    {
                        int instanceCount = 0;

                        foreach (object request in requestObjects)
                        {
                            jsonArray.Add(IsRecordRequest(request, GetModuleDetailFromUserSpecJSON((string)memberDetail[Constants.MODULE]), instanceCount, memberDetail));

                            instanceCount++;
                        }
                    }
                    else
                    {
                        int instanceCount = 0;

                        foreach (object request in requestObjects)
                        {
                            jsonArray.Add(FormRequest(request, pack, instanceCount, memberDetail));

                            instanceCount++;
                        }
                    }
                }
            }

            return jsonArray;
        }

        private object RedirectorForObjectToJSON(object request)
        {
            if (request is IList)
            {
                return SetJSONArray(request, null);
            }
            else if (request is IDictionary)
            {
                return SetJSONObject(request, null);
            }
            else
            {
                return request;
            }
        }

        public override object GetWrappedResponse(object response, string pack)
        {
            HttpWebResponse responseEntity = ((HttpWebResponse)response);

            string responseString = new StreamReader(responseEntity.GetResponseStream()).ReadToEnd();

            responseEntity.Close();

            if (responseString != null && !string.IsNullOrEmpty(responseString) && !string.IsNullOrWhiteSpace(responseString))
            {
                // convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(responseString);

                MemoryStream stream = new MemoryStream(byteArray);

                JsonTextReader responseStream = new JsonTextReader(new StreamReader(stream));

                JsonSerializer serializer = new JsonSerializer
                {
                    DateParseHandling = DateParseHandling.None
                };

                JObject responseJson = serializer.Deserialize<JObject>(responseStream);

                return GetResponse(responseJson, pack);
            }

            return null;
        }

        public override object GetResponse(object response, string packageName)
        {
            JObject classDetail = (JObject)Initializer.jsonDetails.GetValue(packageName); // JSONdetails of class

            JValue value = response is JValue ? (JValue)response : null;

            if (response == null || response.ToString().Equals("null") || (response.ToString().Trim()).Length == 0 || (value != null && value.Value == null))
            {
                return null;
            }

            JObject responseJson = (JObject)response;

            object instance = null;

            if (classDetail.ContainsKey(Constants.INTERFACE) && (bool)classDetail[Constants.INTERFACE])// if interface
            {
                JArray classes = (JArray)classDetail[Constants.CLASSES];

                instance = FindMatch(classes, responseJson);// find match returns instance(calls getresponse() recursively)
            }
            else
            {
                try
                {
                    // create an instance of that type
                    instance = Activator.CreateInstance(Type.GetType(packageName));
                }
                catch (MissingMethodException) //when there is no public constructor- invoke the private constructor
                {
                    instance = Activator.CreateInstance(Type.GetType(packageName), true);
                }

                if (instance is Record.Record)
                {
                    string moduleAPIName = this.commonAPIHandler.ModuleAPIName;

                    instance = IsRecordResponse(responseJson, classDetail, packageName);

                    this.commonAPIHandler.ModuleAPIName = moduleAPIName;
                }
                else
                {
                    instance = NotRecordResponse(instance, responseJson, classDetail);// based on json details data will be assigned
                }
            }

            return instance;
        }

        private object NotRecordResponse(object instance, JObject responseJson, JObject classDetail)
        {
            foreach (KeyValuePair<string, JToken> member in classDetail)
            {
                string memberName = member.Key;

                JObject keyDetail = (JObject)classDetail[memberName];// JSONdetails of the member

                string keyName = keyDetail.ContainsKey(Constants.NAME) ? (string)keyDetail[Constants.NAME] : null;// api-name of the member

                if ((keyName != null && !string.IsNullOrEmpty(keyName) && !string.IsNullOrWhiteSpace(keyName)) && responseJson.ContainsKey(keyName) && responseJson[keyName] != null)
                {
                    object keyData = responseJson[keyName];

                    FieldInfo field = GetPrivateFieldInfo(instance.GetType(), memberName);

                    object memberValue = GetData(keyData, keyDetail);

                    field.SetValue(instance, memberValue);
                }
            }

            return instance;
        }

        private object IsRecordResponse(JObject responseJSON, JObject classDetail, String pack)
        {
            object recordInstance = Activator.CreateInstance(Type.GetType(pack));

            string moduleAPIName = this.commonAPIHandler.ModuleAPIName;

            JObject moduleDetail = new JObject();

            if (moduleAPIName != null)// entry
            {
                this.commonAPIHandler.ModuleAPIName = null;

                JObject fullDetail = Utility.SearchJSONDetails(moduleAPIName);// to get correct moduleapiname in proper format

                if (fullDetail != null)// from Jsondetails
                {
                    moduleDetail = (JObject)fullDetail[Constants.MODULEDETAILS];

                    recordInstance = Activator.CreateInstance(Type.GetType((string)fullDetail[Constants.MODULEPACKAGENAME]));
                }
                else// from user spec
                {
                    moduleDetail = GetModuleDetailFromUserSpecJSON(moduleAPIName);
                }
            }

            moduleDetail.Merge(classDetail, new JsonMergeSettings
            {
                // union array values together to avoid duplicates
                MergeArrayHandling = MergeArrayHandling.Union
            });

            JObject recordDetail = (JObject)Initializer.jsonDetails[Constants.RECORD_NAMESPACE];

            // after above steps, recordDetail must always contain record structure detail,module detail could be any,entry case pack detail is record

            Type cl = recordInstance.GetType();

            Type scl = cl.BaseType;

            if (scl.FullName.Equals(Constants.RECORD_NAMESPACE))
            {
                cl = scl;
            }

            FieldInfo field = GetPrivateFieldInfo(cl, Constants.KEY_VALUES);

            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            foreach (KeyValuePair<string, JToken> member in responseJSON)
            {
                string keyName = member.Key;

                string memberName = BuildName(keyName);

                JObject keyDetail = new JObject();

                if (moduleDetail.Count > 0 && (moduleDetail.ContainsKey(keyName) || moduleDetail.ContainsKey(memberName)))
                {
                    if (moduleDetail.ContainsKey(keyName))
                    {
                        keyDetail = (JObject)moduleDetail[keyName];// incase of user spec json
                    }
                    else
                    {
                        keyDetail = (JObject)moduleDetail[memberName];// json details
                    }
                }
                else if (recordDetail.ContainsKey(memberName))
                {
                    keyDetail = (JObject)recordDetail[memberName];
                }

                object keyValue = null;

                object keyData = member.Value;

                if (keyDetail.Count > 0)
                {
                    keyName = (string)keyDetail[Constants.NAME];
                    
                    keyValue = GetData(keyData, keyDetail);
                }
                else// if not key detail
                {
                    keyValue = RedirectorForJSONToObject(keyData);
                }

                keyValues.Add(keyName, keyValue);
            }

            field.SetValue(recordInstance, keyValues);

            return recordInstance;
        }

        private object GetData(object keyData, JObject memberDetail)
        {
            object memberValue = null;

            if (keyData != null)
            {
                if ((keyData is JValue && ((JValue)keyData).Value == null) || keyData.ToString() == Constants.NULL_VALUE)
                {
                    return memberValue;
                }

                string type = (string)memberDetail[Constants.TYPE];

                if (type.Equals(Constants.LIST_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                {
                    memberValue = GetCollectionsData((JArray)keyData, memberDetail);
                }
                else if (type.Equals(Constants.MAP_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                {
                    memberValue = GetMapData((JObject)keyData, memberDetail);
                }
                else if (type.Equals(Constants.CHOICE_NAMESPACE) || (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) && ((string)memberDetail[Constants.STRUCTURE_NAME]).Equals(Constants.CHOICE_NAMESPACE)))
                {
                    string valueType = ((JValue)keyData).Value.GetType().FullName;

                    Type t = Type.GetType(Constants.CHOICE.Replace(Constants._TYPE, valueType));

                    memberValue = Activator.CreateInstance(t, ((JValue)keyData).Value);
                }
                else if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) && memberDetail.ContainsKey(Constants.MODULE))
                {
                    memberValue = IsRecordResponse((JObject)keyData, GetModuleDetailFromUserSpecJSON((string)memberDetail[Constants.MODULE]), (string)memberDetail[Constants.STRUCTURE_NAME]);
                }
                else if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME))
                {
                    memberValue = GetResponse(keyData, (string)memberDetail[Constants.STRUCTURE_NAME]);
                }
                else
                {
                    Type t = Type.GetType(Constants.DATATYPECONVERTER.Replace(Constants._TYPE, type));

                    MethodInfo method = t.GetMethod(Constants.PRE_CONVERT);

                    memberValue = method.Invoke(null, new object[] { keyData, type });
                }
            }

            return memberValue;
        }

        private object GetMapData(JObject response, JObject memberDetail)
        {
            Dictionary<string, object> mapInstance = new Dictionary<string, object>();

            if (response.Count > 0)
            {
                if (memberDetail == null || (memberDetail != null && !memberDetail.ContainsKey(Constants.KEYS)))
                {
                    foreach (KeyValuePair<string, JToken> responseData in response)
                    {
                        mapInstance.Add(responseData.Key, RedirectorForJSONToObject(responseData.Value));
                    }
                }
                else
                {
                    if (memberDetail.ContainsKey(Constants.KEYS))
                    {
                        JArray keysDetail = (JArray)memberDetail[Constants.KEYS];

                        for (int keyIndex = 0; keyIndex < keysDetail.Count; keyIndex++)
                        {
                            JObject keyDetail = (JObject)keysDetail[keyIndex];

                            string keyName = (string)keyDetail[Constants.NAME];

                            object keyValue = null;

                            if (response.ContainsKey(keyName) && response[keyName] != null)
                            {
                                keyValue = GetData(response[keyName], keyDetail);

                                mapInstance.Add(keyName, keyValue);
                            }
                        }
                    }
                }
            }

            return mapInstance;
        }

        private object GetCollectionsData(JArray responses, JObject memberDetail)
        {
            List<object> values = new List<object>();

            if (responses.Count > 0)
            {
                if (memberDetail == null || (memberDetail != null && !memberDetail.ContainsKey(Constants.STRUCTURE_NAME)))
                {
                    foreach (object response in responses)
                    {
                        values.Add(RedirectorForJSONToObject(response));
                    }
                }
                else// need to have structure Name in memberDetail
                {
                    string pack = (string)memberDetail[Constants.STRUCTURE_NAME];

                    if (pack.Equals(Constants.CHOICE_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (object response in responses)
                        {
                            JToken keyData = (JToken)response;

                            JTokenType tokenType = keyData.Type;

                            if (response.GetType().Name.Equals("JValue", StringComparison.OrdinalIgnoreCase))
                            {
                                Type type = Type.GetType(Constants.CHOICE.Replace(Constants._TYPE, GetType(tokenType)));

                                values.Add(Activator.CreateInstance(type, ((JValue)response).Value));
                            }
                            else
                            {
                                Type type = Type.GetType(Constants.CHOICE.Replace(Constants._TYPE, GetType(tokenType)));

                                values.Add(Activator.CreateInstance(type, ((JValue)response).Value));
                            }
                        }
                    }
                    else if (memberDetail.ContainsKey(Constants.MODULE) && memberDetail[Constants.MODULE] != null)
                    {
                        foreach (object response in responses)
                        {
                            values.Add(IsRecordResponse((JObject)response, GetModuleDetailFromUserSpecJSON((string)memberDetail[Constants.MODULE]), pack));
                        }
                    }
                    else
                    {
                        foreach (Object response in responses)
                        {
                            values.Add(GetResponse(response, pack));
                        }
                    }
                }
            }

            IList list = null;

            if (values is List<Object> && memberDetail != null)
            {
                List<Object> list1 = (List<Object>)values;

                string listTypeName = memberDetail[Constants.TYPE] + "[" + memberDetail[Constants.STRUCTURE_NAME] + "]";

                string type = list1.Count > 0 ? list1[0].GetType().FullName : null;

                string type1 = type;

                if (type != null && (type.Contains("JValue") || (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) && memberDetail[Constants.STRUCTURE_NAME].ToString().Equals(Constants.CHOICE_NAMESPACE, StringComparison.OrdinalIgnoreCase))))
                {
                    type1 = type;

                    if (type.Contains("JValue"))
                    {
                        JToken keyData = (JToken)list1[0];

                        JTokenType tokenType = keyData.Type;

                        if(memberDetail[Constants.TYPE].Contains("Choice"))
                        {
                            type1 = Constants.CHOICE.Replace(Constants._TYPE, GetType(tokenType));
                        }
                        else
                        {
                            type1 = GetType(tokenType);
                        }
                    }
                    
                    listTypeName = memberDetail[Constants.TYPE] + "[" + type1 + "]";
                }

                Type t = Type.GetType(listTypeName);

                if (list == null && t != null && (memberDetail.ContainsKey(Constants.STRUCTURE_NAME) || type1 != null))
                {
                    list = (IList)Activator.CreateInstance(t);
                }

                foreach (Object record in list1)
                {
                    JValue value = record is JValue ? (JValue)record : null;

                    if (record != null && (value != null && value.Value == null) && record.GetType().Name.Equals("JValue"))
                    {
                        JToken keyData = (JToken)list1[0];

                        JTokenType tokenType = keyData.Type;

                        if (record.GetType().Name.Equals("JValue", StringComparison.OrdinalIgnoreCase))
                        {
                            t = Type.GetType(Constants.CHOICE.Replace(Constants._TYPE, GetType(tokenType)));

                            list.Add(Activator.CreateInstance(t, ((JValue)record).Value));
                        }
                        else
                        {
                            t = Type.GetType(Constants.CHOICE.Replace(Constants._TYPE, GetType(tokenType)));

                            list.Add(Activator.CreateInstance(t, ((JValue)record).Value));
                        }
                    }
                    else
                    {
                        if(!memberDetail.ContainsKey(Constants.STRUCTURE_NAME))
                        {
                            Type dataTypeConverter = Type.GetType(Constants.DATATYPECONVERTER.Replace(Constants._TYPE, type1));

                            MethodInfo method = dataTypeConverter.GetMethod(Constants.PRE_CONVERT);

                            list.Add(method.Invoke(null, new Object[] { record, type }));
                        }
                        else
                        {
                            list.Add(record);
                        }
                    }
                }

                return list;
            }

            return values;
        }

        private JObject GetModuleDetailFromUserSpecJSON(string module)
        {
            JObject moduleDetail = new JObject();

            string recordFieldDetailsPath = Initializer.GetInitializer().ResourcePath + Path.DirectorySeparatorChar + Constants.FIELD_DETAILS_DIRECTORY + Path.DirectorySeparatorChar + GetEncodedFileName();

            moduleDetail = Utility.GetJSONObject(Initializer.GetJSON((recordFieldDetailsPath)), module);

            return moduleDetail;
        }

        private object RedirectorForJSONToObject(object keyData)
        {
            if (keyData is JObject)
            {
                return GetMapData((JObject)keyData, null);
            }
            else if (keyData is JArray)
            {
                return GetCollectionsData((JArray)keyData, null);
            }
            else
            {
                return keyData;
            }
        }

        private object FindMatch(JArray classes, JObject responseJson)
        {
            string pack = "";

            float ratio = 0;

            foreach (string className in classes)
            {
                float matchRatio = FindRatio(className, responseJson);

                if (matchRatio == 1.0)
                {
                    pack = (string)className;

                    ratio = 1;

                    break;
                }
                else if (matchRatio > ratio)
                {
                    ratio = matchRatio;

                    pack = (string)className;
                }
            }

            return GetResponse(responseJson, pack);
        }

        private float FindRatio(string className, JObject responseJson)
        {
            JObject classDetail = (JObject)Initializer.jsonDetails.GetValue(className); // JSONdetails of class

            float totalPoints = classDetail.Count;

            float matches = 0;

            if (totalPoints == 0)
            {
                return 0;
            }
            else
            {
                foreach (KeyValuePair<string, JToken> memberName in classDetail)
                {
                    JObject memberDetail = (JObject)memberName.Value;

                    string keyName = memberDetail.ContainsKey(Constants.NAME) ? (string)memberDetail[Constants.NAME] : null;

                    if ((keyName != null && !string.IsNullOrEmpty(keyName) && !string.IsNullOrWhiteSpace(keyName)) && responseJson.ContainsKey(keyName) && responseJson[keyName] != null)
                    {// key not empty
                        JToken keyData = responseJson[keyName];

                        JTokenType tokenType = keyData.Type;

                        string structureName = memberDetail.ContainsKey(Constants.STRUCTURE_NAME) ? (string)memberDetail[Constants.STRUCTURE_NAME] : null;

                        string type = GetType(tokenType);

                        if (type.Equals((string)memberDetail[Constants.TYPE]))
                        {
                            matches++;
                        }
                        else if (((string)memberDetail[Constants.TYPE]).Equals(Constants.CHOICE_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                        {
                            JArray values = (JArray)memberDetail[Constants.VALUES];

                            foreach (object value in values)
                            {
                                if (value.Equals(keyData))
                                {
                                    matches++;

                                    break;
                                }
                            }
                        }

                        if ((structureName != null && !string.IsNullOrEmpty(structureName) && !string.IsNullOrWhiteSpace(structureName)) && structureName.Equals((string)memberDetail[Constants.TYPE]))
                        {
                            if (memberDetail.ContainsKey(Constants.VALUES))
                            {
                                JArray values = (JArray)memberDetail[Constants.VALUES];

                                foreach (object value in values)
                                {
                                    if (value.Equals(keyData))
                                    {
                                        matches++;

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                matches++;
                            }
                        }
                    }
                }
            }
            return matches / totalPoints;
        }

        public static string BuildName(string memberName)
        {
            List<string> name = memberName.Split('_').ToList();

            string sdkName = "";

            int index;


            if (name.Count <= 0)
            {
                index = 1;
            }

            sdkName = string.Concat(name[0].Substring(0, 1).ToLower(), name[0].Substring(1));

            index = 1;

            for (int nameIndex = index; nameIndex < name.Count; nameIndex++)
            {
                string firstLetterUppercase = "";

                if (name[nameIndex].Length > 0)
                {
                    firstLetterUppercase = string.Concat(name[nameIndex].Substring(0, 1).ToUpper(), name[nameIndex].Substring(1));
                }

                sdkName = string.Concat(sdkName, firstLetterUppercase);
            }

            return sdkName;
        }

        public static string GetProperMethodName(string methodName)
        {
            string method = "";

            if (!string.IsNullOrEmpty(methodName))
            {
                if (methodName[0].Equals("_"))
                {
                    method = char.ToUpper(methodName[1]) + methodName.Substring(2);
                }
                else if (methodName.Contains("_"))
                {
                    string[] splits = methodName.Split('_');

                    for (int i = 0; i < splits.Length; i++)
                    {
                        method += char.ToUpper(splits[i][0]) + splits[i].Substring(1);
                    }
                }
                else
                {
                    method += char.ToUpper(methodName[0]) + methodName.Substring(1);
                }
            }
            return method;
        }

        public static object ConvertList(List<object> value, Type type)
        {
            IList list = (IList)Activator.CreateInstance(type);

            foreach (var item in value)
            {
                list.Add(item);
            }
            return list;
        }
    }
}

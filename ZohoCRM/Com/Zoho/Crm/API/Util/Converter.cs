using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Reflection;

using System.Text;

using System.Text.RegularExpressions;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API.Logger;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This abstract class is to construct API request and response.
    /// </summary>
    public abstract class Converter
    {
        protected CommonAPIHandler commonAPIHandler;

        /// <summary>
        /// Creates a Converter class instance with no parameters.
        /// </summary>
        public Converter()
        {
        }

        /// <summary>
        /// Creates a Converter class instance with the CommonAPIHandler class instance.
        /// </summary>
        /// <param name="commonAPIHandler">A CommonAPIHandler class instance.</param>
        public Converter(CommonAPIHandler commonAPIHandler)
        {
            this.commonAPIHandler = commonAPIHandler;
        }

        /// <summary>
        /// This abstract method is to process the API response.
        /// </summary>
        /// <param name="response">A object containing the API response contents or response. </param>
        /// <param name="pack">A string containing the expected method return type.</param>
        /// <returns>A object representing the POJO class instance.</returns>
        public abstract object GetResponse(object response, string pack);

        /// <summary>
        /// This abstract method is to construct the API request.
        /// </summary>
        /// <param name="requestObject">A object containing the POJO class instance.</param>
        /// <param name="pack">A string containing the expected method return type.</param>
        /// <param name="instanceNumber">An int containing the POJO class instance list number.</param>
        /// <param name="memberDetail">An JObject containing the member properties</param>
        /// <returns>A object representing the API request body object.</returns>
        public abstract object FormRequest(object requestInstance, string pack, int? instanceNumber, JObject memberDetail);

        /// <summary>
        /// This abstract method is to construct the API request body.
        /// </summary>
        /// <param name="requestBase">A HttpWebRequest class instance.</param>
        /// <param name="requestObject">A object containing the API request body object.</param>
        public abstract void AppendToRequest(HttpWebRequest requestBase, object requestObject);

        /// <summary>
        /// This abstract method is to process the API response.
        /// </summary>
        /// <param name="response">A object containing the HttpResponse class instance.</param>
        /// <param name="pack">A string containing the expected method return type.</param>
        /// <returns>A object representing the POJO class instance.</returns>
        public abstract object GetWrappedResponse(object response, string pack);

        /// <summary>
        /// This method is to validate if the input values satisfy the constraints for the respective fields.
        /// </summary>
        /// <param name="className"> A string containing the class name.</param>
        /// <param name="memberName">A string containing the member name.</param>
        /// <param name="keyDetails">A JObject containing the key JSON details.</param>
        /// <param name="value">A object containing the key value.</param>
        /// <param name="uniqueValuesMap">A Dictionary&lt;string,List&lt;object&gt;&gt; containing the construct objects.</param>
        /// <param name="instanceNumber">An int containing the POJO class instance list number.</param>
        /// <returns>A bool representing the key value is expected pattern, unique, length, and values.</returns>
        public bool ValueChecker(string className, string memberName, JObject keyDetails, object value, Dictionary<string, List<object>> uniqueValuesMap, int? instanceNumber)
        {
            JObject detailsJO = new JObject();

            string name = keyDetails.GetValue(Constants.NAME).ToString();

            string type = keyDetails.GetValue(Constants.TYPE).ToString();

            string varType = null;

            bool check = true;

            if (value != null)
            {
                var valueType = value.GetType();

                if(value is IList)
                {
                    varType = valueType.Namespace + "." + valueType.Name;
                }
                else
                {
                    varType = valueType.Namespace + "." + valueType.Name.Replace("`1","");
                }

                check = varType.Equals(type, StringComparison.OrdinalIgnoreCase);
            }

            if (value is IList)
		    {
                bool expectedListType = true;

                if (keyDetails.ContainsKey(Constants.STRUCTURE_NAME))
                {
                    string structureName = keyDetails.GetValue(Constants.STRUCTURE_NAME).ToString();

                    int index = 0;

                    IList listValue = (IList)value;

                    foreach (object data in listValue)
                    {
                        var dataType = data.GetType();

                        if (data is IList)
                        {
                            className = dataType.Namespace + "." + dataType.Name;
                        }
                        else
                        {
                            className = dataType.Namespace + "." + dataType.Name.Replace("`1", "");
                        }

                        if (!className.Equals(structureName, StringComparison.OrdinalIgnoreCase))
                        {
                            instanceNumber = index;

                            type = Constants.LIST_NAMESPACE + "(" + structureName + ")";

                            varType = Constants.LIST_NAMESPACE + "(" + className + ")";

                            expectedListType = false;

                            check = false;

                            break;
                        }

                        index++;
                    }
                }

                if (expectedListType)
                {
                    check = varType.Equals(type, StringComparison.OrdinalIgnoreCase) ? true : varType.Equals(Constants.LIST_NAMESPACE);
                }
            }

            else if (value is IDictionary)
		    {
                check = varType.Equals(type) ? true : varType.Equals(Constants.MAP_NAMESPACE, StringComparison.OrdinalIgnoreCase);
            }

            if (!check && !type.Equals(Constants.CSHARP_OBJECT_NAME, StringComparison.OrdinalIgnoreCase))
            {
                detailsJO.Add(Constants.FIELD, memberName);

                detailsJO.Add(Constants.CLASS, className);

                detailsJO.Add(Constants.INDEX, instanceNumber);

                detailsJO.Add(Constants.EXPECTED_TYPE, type);

                detailsJO.Add(Constants.GIVEN_TYPE, varType);

                throw new SDKException(Constants.TYPE_ERROR, detailsJO);
            }

            if (keyDetails.ContainsKey(Constants.VALUES) && (!keyDetails.ContainsKey(Constants.PICKLIST) || ((bool)keyDetails[Constants.PICKLIST] && Initializer.GetInitializer().SDKConfig.PickListValidation)))
            {
                JArray valuesJArray = (JArray)keyDetails.GetValue(Constants.VALUES);

                string[] valuesJA = valuesJArray.ToObject<string[]>();

                if (value.GetType().FullName.Contains(Constants.CHOICE_NAME))
                {
                    value = GetChoiceValue(value);
                }

                if (!valuesJA.Contains(value))
                {
                    detailsJO.Add(Constants.FIELD, memberName);

                    detailsJO.Add(Constants.CLASS, className);

                    if (instanceNumber != null)
                    {
                        detailsJO.Add(Constants.INDEX, instanceNumber);
                    }

                    detailsJO.Add(Constants.GIVEN_VALUE, JsonConvert.SerializeObject(value));

                    detailsJO.Add(Constants.ACCEPTED_VALUES, valuesJArray);

                    throw new SDKException(Constants.UNACCEPTED_VALUES_ERROR, detailsJO);
                }
            }

            if (keyDetails.ContainsKey(Constants.UNIQUE))
            {
                List<object> valuesArray = uniqueValuesMap.ContainsKey(name)? uniqueValuesMap[name] : null;

                if (valuesArray != null && valuesArray.Contains(value))
                {
                    detailsJO.Add(Constants.FIELD, memberName);

                    detailsJO.Add(Constants.CLASS, className);

                    detailsJO.Add(Constants.FIRST_INDEX, valuesArray.IndexOf(value));

                    if (instanceNumber != null)
                    {
                        detailsJO.Add(Constants.NEXT_INDEX, instanceNumber);
                    }

                    throw new SDKException(Constants.UNIQUE_KEY_ERROR, detailsJO);
                }
                else
                {
                    if (valuesArray == null)
                    {
                        valuesArray = new List<object>();
                    }

                    valuesArray.Add(value);

                    uniqueValuesMap[name] = valuesArray;
                }
            }

            if (keyDetails.ContainsKey(Constants.MIN_LENGTH) || keyDetails.ContainsKey(Constants.MAX_LENGTH))
            {
                int count = value.ToString().Length;

                if (value is IList)
                {
                    count = ((IList)value).Count;
                }

                if (keyDetails.ContainsKey(Constants.MAX_LENGTH) && count > (int)keyDetails.GetValue(Constants.MAX_LENGTH))
                {
                    detailsJO.Add(Constants.FIELD, memberName);

                    detailsJO.Add(Constants.CLASS, className);

                    detailsJO.Add(Constants.GIVEN_LENGTH, count);

                    detailsJO.Add(Constants.MAXIMUM_LENGTH, keyDetails.GetValue(Constants.MAX_LENGTH));

                    throw new SDKException(Constants.MAXIMUM_LENGTH_ERROR, detailsJO);
                }

                if (keyDetails.ContainsKey(Constants.MIN_LENGTH) && count < (int)keyDetails.GetValue(Constants.MIN_LENGTH))
                {
                    detailsJO.Add(Constants.FIELD, memberName);

                    detailsJO.Add(Constants.CLASS, className);

                    detailsJO.Add(Constants.GIVEN_LENGTH, count);

                    detailsJO.Add(Constants.MINIMUM_LENGTH, keyDetails.GetValue(Constants.MIN_LENGTH));

                    throw new SDKException(Constants.MINIMUM_LENGTH_ERROR, detailsJO);
                }
            }

            if (keyDetails.ContainsKey(Constants.REGEX))
            {
                Match match = Regex.Match(value.ToString(),(string) keyDetails.GetValue(Constants.REGEX));

                if (!match.Success)
                {
                    detailsJO.Add(Constants.FIELD, memberName);

                    detailsJO.Add(Constants.CLASS, className);

                    if (instanceNumber != null)
                    {
                        detailsJO.Add(Constants.INSTANCE_NUMBER, instanceNumber);
                    }

                    throw new SDKException(Constants.REGEX_MISMATCH_ERROR, detailsJO);
                }
            }

            return true;
        }

        /// <summary>
        /// This method to get the module field JSON details file path.
        /// </summary>
        /// <returns>A string representing the module field JSON details file path.</returns>
        public string GetEncodedFileName()
        {
            string fileName = Initializer.GetInitializer().User.Email;

            fileName = fileName.Substring(0, fileName.IndexOf("@")) + Initializer.GetInitializer().Environment.GetUrl();

            byte[] input = Encoding.UTF8.GetBytes(fileName);

            string str = Convert.ToBase64String(input);

            return str + ".json";
        }

        private object GetChoiceValue(object value)
        {
            Type type = value.GetType();

            PropertyInfo prop = type.GetProperty("Value");

            return prop.GetValue(value);
        }

        public static FieldInfo GetPrivateFieldInfo(Type type, string fieldName)
        {
            BindingFlags Flags = BindingFlags.Instance
                                            | BindingFlags.GetProperty
                                            | BindingFlags.SetProperty
                                            | BindingFlags.GetField
                                            | BindingFlags.SetField
                                            | BindingFlags.NonPublic
                                            | BindingFlags.Public;

            FieldInfo[] fields = type.GetFields(Flags);

            return fields.FirstOrDefault(fieldInfo => fieldInfo.Name == fieldName);
        }

        public static string GetType(JTokenType tokenType)
        {
            string type = "";

            if (tokenType == JTokenType.Object)
            {
                type = Constants.MAP_NAMESPACE;
            }
            else if (tokenType == JTokenType.Array)
            {
                type = Constants.LIST_NAMESPACE;
            }
            else if (tokenType == JTokenType.String)
            {
                type = Constants.CSHARP_STRING_NAME;
            }
            else if (tokenType == JTokenType.Boolean)
            {
                type = Constants.CSHARP_BOOLEAN_NAME;
            }
            else if (tokenType == JTokenType.Float)
            {
                type = Constants.CSHARP_DOUBLE_NAME;
            }
            else if (tokenType == JTokenType.Integer)
            {
                type = Constants.CSHARP_INT_NAME;
            }

            return type;
        }
    }
}

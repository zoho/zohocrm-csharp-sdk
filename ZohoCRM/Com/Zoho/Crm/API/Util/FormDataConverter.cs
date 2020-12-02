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

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class is to process the upload file and stream.
    /// </summary>
    public class FormDataConverter : Converter
    {
        public FormDataConverter(CommonAPIHandler commonAPIHandler) : base(commonAPIHandler) {}

        private Dictionary<string, List<object>> uniqueValuesMap = new Dictionary<string, List<object>>();

        public override object FormRequest(object requestInstance, string pack, int? instanceNumber, JObject classMemberDetail)
        {
            JObject classDetail = (JObject)Initializer.jsonDetails.GetValue(pack); // JSONdetails of class

            Dictionary<string, object> request = new Dictionary<string, object>();

            foreach (KeyValuePair<string, JToken> data in classDetail) // all members
            {
                object modification = null;

                string memberName = data.Key;

                MethodInfo method = null;

                JObject memberDetail = (JObject)classDetail.GetValue(memberName);

                if ((memberDetail.ContainsKey(Constants.READ_ONLY) && (bool)memberDetail.GetValue(Constants.READ_ONLY)) || !memberDetail.ContainsKey(Constants.NAME))
                {
                    continue;
                }

                try
                {
                    method = requestInstance.GetType().GetMethod(Constants.IS_KEY_MODIFIED);

                    object[] param = new object[1];

                    param[0] = memberDetail.GetValue(Constants.NAME).ToString();

                    modification = method.Invoke(requestInstance, param);
                }
                catch (Exception ex)
                {
                    throw new SDKException(Constants.EXCEPTION_IS_KEY_MODIFIED , ex);
                }

                // check required
                if ((modification == null || (int)modification == 0) && memberDetail.ContainsKey(Constants.REQUIRED) && (bool)memberDetail.GetValue(Constants.REQUIRED))
                {
                    throw new SDKException(Constants.MANDATORY_VALUE_ERROR, Constants.MANDATORY_KEY_ERROR + memberName);
                }

                FieldInfo field = GetPrivateFieldInfo(requestInstance.GetType(), memberName);

                if (field != null)
                {
                    object fieldValue = field.GetValue(requestInstance);// value of the member

                    if (modification != null && (int)modification != 0 && this.ValueChecker(requestInstance.GetType().FullName, memberName, memberDetail, fieldValue, uniqueValuesMap, instanceNumber) == true)
                    {
                        string keyName = (string)memberDetail.GetValue(Constants.NAME);

                        string type = (string)memberDetail.GetValue(Constants.TYPE);

                        if (type.Equals(Constants.LIST_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                        {
                            request.Add(keyName, SetJSONArray(fieldValue, memberDetail));
                        }
                        else if (type.Equals(Constants.MAP_NAMESPACE, StringComparison.OrdinalIgnoreCase))
                        {
                            request.Add(keyName, SetJSONObject(fieldValue, memberDetail));
                        }
                        else if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME))
                        {
                            object fieldData = FormRequest(fieldValue, (string)memberDetail.GetValue(Constants.STRUCTURE_NAME), 1, memberDetail);

                            request.Add(keyName, fieldData != null ? JToken.FromObject(fieldData) : JValue.CreateNull());
                        }
                        else
                        {
                            request.Add(keyName, fieldValue);
                        }
                    }
                }
            }

            return request;
        }

        public override void AppendToRequest(HttpWebRequest requestBase, object requestObject)
        {
            string boundary = "----FILEBOUNDARY----";

            requestBase.ContentType = "multipart/form-data; boundary=" + boundary;

            Stream fileDataStream = new MemoryStream();

            var boundarybytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");

            var endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--");

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + "Content-Type: application/octet-stream\r\n\r\n";

            if (requestObject is IDictionary)
            {
                this.AddFileBody(requestObject, fileDataStream, boundarybytes, endBoundaryBytes, headerTemplate);
            }

            fileDataStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);

            requestBase.ContentLength = fileDataStream.Length;

            using (Stream requestStream = requestBase.GetRequestStream())
            {
                fileDataStream.Position = 0;

                byte[] tempBuffer = new byte[fileDataStream.Length];

                fileDataStream.Read(tempBuffer, 0, tempBuffer.Length);

                fileDataStream.Close();

                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            }
        }

        private void AddFileBody(object requestObject, Stream fileDataStream, byte[] boundarybytes, byte[] endBoundaryBytes, string headerTemplate)
        {
            Dictionary<string, object> requestObjectMap = (Dictionary<string, object>)requestObject;

            foreach (KeyValuePair<string, object> requestData in requestObjectMap)
            {
                if (requestData.Value is IList)
                {
                    IList keysDetail = (IList)requestData.Value;

                    foreach (object fileObject in keysDetail)
                    {
                        if (fileObject is StreamWrapper)
                        {
                            StreamWrapper streamWrapper = (StreamWrapper)fileObject;

                            fileDataStream.Write(boundarybytes, 0, boundarybytes.Length);

                            var header = string.Format(headerTemplate, requestData.Key, streamWrapper.Name);

                            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                            fileDataStream.Write(headerbytes, 0, headerbytes.Length);

                            var buffer = new byte[1024];

                            var bytesRead = 0;

                            while ((bytesRead = streamWrapper.Stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                fileDataStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                else if (requestData.Value is StreamWrapper)
                {
                    StreamWrapper streamWrapper = (StreamWrapper)requestData.Value;

                    fileDataStream.Write(boundarybytes, 0, boundarybytes.Length);

                    var header = string.Format(headerTemplate, requestData.Key, streamWrapper.Name);

                    var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                    fileDataStream.Write(headerbytes, 0, headerbytes.Length);

                    var buffer = new byte[1024];

                    var bytesRead = 0;

                    while ((bytesRead = streamWrapper.Stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        fileDataStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        private JObject SetJSONObject(object fieldValue, JObject memberDetail)
        {
            JObject jsonObject = new JObject();

            IDictionary requestObject = (IDictionary)fieldValue;

            if (memberDetail == null)
            {
                foreach (KeyValuePair<object, object> requestObjectDetails in requestObject)
                {
                    object data = RedirectorForObjectToJSON(requestObjectDetails.Value);

                    jsonObject.Add((string)requestObjectDetails.Key, data != null ? JToken.FromObject(data) : JValue.CreateNull());
                }
            }
            else
            {
                JArray keysDetail = (JArray)memberDetail.GetValue(Constants.KEYS);

                for (int keyIndex = 0; keyIndex < keysDetail.Count; keyIndex++)
                {
                    JObject keyDetail = (JObject)keysDetail[keyIndex];

                    string keyName = (string)keyDetail.GetValue(Constants.NAME);

                    object keyValue = null;

                    if (requestObject.Contains(keyName) && requestObject[keyName] != null)
                    {
                        if (keyDetail.ContainsKey(Constants.STRUCTURE_NAME))
                        {
                            keyValue = FormRequest(requestObject[keyName], (string)keyDetail.GetValue(Constants.STRUCTURE_NAME), 1, memberDetail);

                            jsonObject.Add(keyName, keyValue != null? JToken.FromObject(keyValue) : JValue.CreateNull());
                        }
                        else
                        {
                            keyValue = requestObject[keyName];

                            object data = RedirectorForObjectToJSON(keyValue);

                            jsonObject.Add(keyName, data != null ? JToken.FromObject(data) : JValue.CreateNull());
                        }
                    }
                }
            }

            return jsonObject;
        }

        private IList SetJSONArray(object fieldValue, JObject memberDetail)
        {
            IList listObject = new List<object>();

            IList requestObjects = (IList)fieldValue;

            if (memberDetail == null)
            {
                foreach (object request in requestObjects)
                {
                    listObject.Add(RedirectorForObjectToJSON(request));
                }
            }
            else
            {
                if (memberDetail.ContainsKey(Constants.STRUCTURE_NAME))
                {
                    int instanceCount = 0;

                    string pack = (string)memberDetail.GetValue(Constants.STRUCTURE_NAME);

                    foreach (object request in requestObjects)
                    {
                        listObject.Add(FormRequest(request, pack, ++instanceCount, memberDetail));
                    }
                }
                else
                {
                    foreach (object request in requestObjects)
                    {
                        listObject.Add(RedirectorForObjectToJSON(request));
                    }
                }
            }
            
            return listObject;
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
            throw new NotImplementedException();
        }

        public override object GetResponse(object response, string pack)
        {
            throw new NotImplementedException();
        }
    }
}

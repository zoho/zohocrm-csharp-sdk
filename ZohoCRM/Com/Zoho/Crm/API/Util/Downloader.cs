using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Reflection;

using Newtonsoft.Json.Linq;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class is to process the download file and stream response.
    /// </summary>
    public class Downloader : Converter
    {
        public Downloader(CommonAPIHandler commonAPIHandler):base(commonAPIHandler) {}

        public override object FormRequest(object requestObject, string pack, int? instanceNumber, JObject memberDetail)
        {
            throw new NotImplementedException();
        }

        public override void AppendToRequest(HttpWebRequest requestBase, object requestObject)
        {
            throw new NotImplementedException();
        }

        public override object GetWrappedResponse(object response, string pack)
        {
            return GetResponse(response, pack);
        }

        public override object GetResponse(object response, string pack)
        {
            JObject recordJsonDetails = (JObject)Initializer.jsonDetails.GetValue(pack); // JSONdetails of class

            object instance = null;

            if (recordJsonDetails.ContainsKey(Constants.INTERFACE) && (bool)recordJsonDetails.GetValue(Constants.INTERFACE))
            {
                JArray classes = (JArray)recordJsonDetails.GetValue(Constants.CLASSES);
                
                foreach(object classObject in classes)
                {
                    string className = classObject.ToString();
                    
                    if(className.Contains(Constants.FILEBODYWRAPPER))
                    {
                        return GetResponse(response, className);
                    }
                }
                
                return instance;
            }
            else
            {
                instance = Activator.CreateInstance(Type.GetType(pack));

                foreach (KeyValuePair<string, JToken> memberName in recordJsonDetails)
                {
                    JObject memberJsonDetails = (JObject)recordJsonDetails[memberName.Key];// JSONdetails of the member

                    FieldInfo field = GetPrivateFieldInfo(instance.GetType(), memberName.Key);

                    if(field != null)
                    {
                        string type = (string)memberJsonDetails[Constants.TYPE];

                        if (type.Equals(Constants.STREAM_WRAPPER_CLASS_PATH, StringComparison.OrdinalIgnoreCase))
                        {
                            HttpWebResponse responseEntity = ((HttpWebResponse)response);

                            WebHeaderCollection collection = responseEntity.Headers;

                            string contentDisposition = collection[Constants.CONTENT_DISPOSITION];

                            string fileName = contentDisposition.Split(new string[] { "=" }, StringSplitOptions.None)[1];

                            if (fileName.Contains("''"))
                            {
                                fileName = fileName.Split(new string[] { "''" }, StringSplitOptions.None)[1];
                            }

                            fileName = fileName.Trim('\"');

                            object instanceValue = Activator.CreateInstance(Type.GetType(type), new object[] { fileName, responseEntity.GetResponseStream() });

                            field.SetValue(instance, instanceValue);
                        }
                    }
                }
            }
            
            return instance;
        }        
    }
}

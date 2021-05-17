using System;

using System.Net;

using System.Collections.Generic;

using System.Net.Mime;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API.Logger;

using Newtonsoft.Json;

using System.IO;

using System.Linq;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class is to process the API request and its response.
    /// Construct the objects that are to be sent as parameters or in the request body with the API.
    /// The Request parameter, header and body objects are constructed here.
    /// Process the response JSON and converts it to relevant objects in the library.
    /// </summary>
    public class CommonAPIHandler
    {
        private string apiPath;

        private ParameterMap param = new ParameterMap();

        private HeaderMap header = new HeaderMap();

        private object request;

        private string httpMethod;

        private string moduleAPIName;

        private string contentType;

        private string categoryMethod;

        private bool mandatoryChecker;

        public string CategoryMethod
        {
            get
            {
                return categoryMethod;
            }
            set
            {
                categoryMethod = value;
            }
        }

        public bool MandatoryChecker
        {
            get
            {
                return mandatoryChecker;
            }
            set
            {
                mandatoryChecker = value;
            }
        }
        
        /// <summary>
        /// This is a setter method to set the API request content type.
        /// </summary>
        /// <value>A string containing the API request content type.</value>
        public string ContentType
        {
            set
            {
                contentType = value;
            }
        }

        /// <summary>
        /// This is a setter method to set the API request URL.
        /// </summary>
        /// <value>A string containing the API request URL.</value>
        public string APIPath
        {
            get
            {
                return apiPath;
            }
            set
            {
                apiPath = value;
            }
        }

        /// <summary>
        /// This method is to add an API request parameter.
        /// </summary>
        /// <typeparam name="T">A T containing the specified method type.</typeparam>
        /// <param name="paramInstance">A Param instance containing the API request parameter.</param>
        /// <param name="paramValue">A T containing the API request parameter value.</param>
        public void AddParam<T>(Param<T> paramInstance, T paramValue)
        {
            if (paramValue == null)
            {
                return;
            }
           
            if (param == null)
            {
                param = new ParameterMap();
            }

            param.Add(paramInstance, paramValue);
        }

        /// <summary>
        /// This method to add an API request header.
        /// </summary>
        /// <typeparam name="T">A T containing the specified method type.</typeparam>
        /// <param name="headerInstance">A Header instance the API request header.</param>
        /// <param name="headerValue">A T containing the API request header value.</param>
        public void AddHeader<T>(Header<T> headerInstance, T headerValue)
        {
            if (headerValue == null)
            {
                return;
            }

            if (header == null)
            {
                header = new HeaderMap();
            }

            header.Add(headerInstance, headerValue);
        }

        /// <summary>
        /// This is a setter method to set the API request parameter map.
        /// </summary>
        /// <value>A ParameterMap class instance containing the API request parameter.</value>
        public ParameterMap Param
        {
            set
            {
                if(value == null)
                {
                    return;
                }

                if(param.ParameterMaps != null && param.ParameterMaps.Count > 0)
                {
                    value.ParameterMaps.ToList().ForEach(x => param.ParameterMaps[x.Key] = x.Value);
                }
                else
                {
                    param = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Zoho CRM module API name.
        /// </summary>
        /// <value>A string containing the Zoho CRM module API name.</value>
        /// <returns>A string representing the Zoho CRM module API name.</returns>
        public string ModuleAPIName
        {
            get
            {
                return moduleAPIName;
            }
            set
            {
                moduleAPIName = value;
            }
        }

        /// <summary>
        /// This is a setter method to set the API request header map.
        /// </summary>
        /// <value>A HeaderMap class instance containing the API request header.</value>
        public HeaderMap Header
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                if (header.HeaderMaps != null && header.HeaderMaps.Count > 0)
                {
                    value.HeaderMaps.ToList().ForEach(x => header.HeaderMaps[x.Key] = x.Value);
                }
                else
                {
                    header = value;
                }
            }
        }

        /// <summary>
        /// This is a setter method to set the API request body object.
        /// </summary>
        /// <value>A object containing the API request body object.</value>
        public object Request
        {
            set
            {
                request = value;
            }
        }

        /// <summary>
        /// This is a setter method to set the HTTP API request method.
        /// </summary>
        /// <value>A string containing the HTTP API request method.</value>
        public string HttpMethod
        {
            get
            {
                return httpMethod;
            }
            set
            {
                httpMethod = value;
            }
        }

        /// <summary>
        /// This method is used in constructing API request and response details. To make the Zoho CRM API calls.
        /// </summary>
        /// <typeparam name="T">A T containing the specified type method.</typeparam>
        /// <param name="className">A Type containing the method return type.</param>
        /// <param name="encodeType">A string containing the expected API response content type.</param>
        /// <returns>A APIResponse&lt;T&gt; representing the Zoho CRM API response instance or null. </returns>
        public APIResponse<T> APICall<T>(Type className, string encodeType)
        {
            if (Initializer.GetInitializer() == null)
            {
                throw new SDKException(Constants.SDK_UNINITIALIZATION_ERROR, Constants.SDK_UNINITIALIZATION_MESSAGE);
            }

            APIHTTPConnector connector = new APIHTTPConnector
            {
                RequestMethod = httpMethod
            };
            
            try
            {
                SetAPIURL(connector);
            }
            catch (SDKException e)
            {
                SDKLogger.LogError(Constants.SET_API_URL_EXCEPTION + JsonConvert.SerializeObject(e));

                throw e;
            }
            catch (Exception e)
            {
                SDKException exception = new SDKException(e);

                SDKLogger.LogError(Constants.SET_API_URL_EXCEPTION + JsonConvert.SerializeObject(exception));

                throw exception;
            }

            connector.ContentType = contentType;

            if (header != null && header.HeaderMaps.Count > 0)
            {
                connector.Headers = header.HeaderMaps;
            }

            if (param != null && param.ParameterMaps.Count > 0)
            {
                connector.Params = param.ParameterMaps;
            }

            try
            {
                Initializer.GetInitializer().Token.Authenticate(connector);
            }
            catch (SDKException e)
            {
                SDKLogger.LogError(Constants.AUTHENTICATION_EXCEPTION + JsonConvert.SerializeObject(e));

                throw e;
            }
            catch (Exception e)
            {
                SDKException exception = new SDKException(e);

                SDKLogger.LogError(Constants.AUTHENTICATION_EXCEPTION + JsonConvert.SerializeObject(exception));

                throw exception;
            }

            string pack = className.FullName;

            Converter convertInstance = null;

            if (contentType != null && Constants.IS_GENERATE_REQUEST_BODY.Contains(httpMethod))
            {
                object request;

                try
                {
                    convertInstance = GetConverterClassInstance(contentType.ToLower());

                    request = convertInstance.FormRequest(this.request, this.request.GetType().FullName, null, null);
                }
                catch (SDKException e)
                {
                    SDKLogger.LogError(Constants.FORM_REQUEST_EXCEPTION + JsonConvert.SerializeObject(e));

                    throw e;
                }
                catch (Exception e)
                {
                    SDKException exception = new SDKException(e);

                    SDKLogger.LogError(Constants.FORM_REQUEST_EXCEPTION + JsonConvert.SerializeObject(exception));

                    throw exception;
                }

                connector.RequestBody = request;
            }

            try
            {
                connector.AddHeader(Constants.ZOHO_SDK,  Environment.OSVersion.Platform.ToString() + "/" +
                                                    Environment.OSVersion.Version.ToString() + " CSharp/" +
                                                    Environment.Version.Major.ToString() + "." +
                                                    Environment.Version.Minor.ToString() + ":" + Constants.SDK_VERSION);

                HttpWebResponse response = connector.FireRequest(convertInstance);
                
                int statusCode = (int)response.StatusCode;

                Dictionary<string, string> headerMap = GetHeaders(response.Headers);

                bool isModel = false;

                string mimeType = response.ContentType;

                Model returnObject = null;

                if (!string.IsNullOrEmpty(mimeType) && !string.IsNullOrWhiteSpace(mimeType))
                {
                    if (mimeType.Contains(";"))
                    {
                        mimeType = mimeType.Split(';')[0];
                    }

                    convertInstance = GetConverterClassInstance(mimeType.ToLower());

                    returnObject = (Model)convertInstance.GetWrappedResponse(response, pack);

                    if (returnObject != null)
                    {
                        if (pack.Equals(returnObject.GetType().FullName) || IsExpectedType(returnObject, pack))
                        {
                            isModel = true;
                        }
                    }
                }
                else
                {
                    if(response != null)
                    {
                        HttpWebResponse responseEntity = ((HttpWebResponse)response);

                        string responseString = new StreamReader(responseEntity.GetResponseStream()).ReadToEnd();

                        SDKLogger.LogError(Constants.API_ERROR_RESPONSE + responseString);

                        responseEntity.Close();
                    }
                }

                return new APIResponse<T>(headerMap, statusCode, returnObject, isModel);
            }
            catch (SDKException e)
            {
                SDKLogger.LogError(Constants.API_CALL_EXCEPTION + JsonConvert.SerializeObject(e));

                throw e;
            }
            catch (Exception e)
            {
                SDKException exception = new SDKException(e);

                SDKLogger.LogError(Constants.API_CALL_EXCEPTION + JsonConvert.SerializeObject(exception));

                throw exception;
            }
        }

        /// <summary>
        /// This method is used to get a Converter class instance.
        /// </summary>
        /// <param name="encodeType">A String containing the API response content type.</param>
        /// <returns>A Converter class instance.</returns>
        public Converter GetConverterClassInstance(string encodeType)
        {
            switch (encodeType)
            {
                case "application/json":
                case "text/plain":
                case "application/ld+json":
                    return new JSONConverter(this);
                case "application/xml":
                case "text/xml":
                    return new XMLConverter(this);
                case "multipart/form-data":
                    return new FormDataConverter(this);
                case "image/png":
                case "image/jpeg":
                case "image/gif":
                case "image/tiff":
                case "image/svg+xml":
                case "image/bmp":
                case "image/webp":
                case "text/csv":
                case "text/html":
                case "text/css":
                case "text/javascript":
                case "text/calendar":
                case "application/x-download":
                case "application/zip":
                case "application/pdf":
                case "application/java-archive":
                case "application/javascript":
                case "application/octet-stream":
                case "application/xhtml+xml":
                case "application/x-bzip":
                case "application/msword":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                case "application/gzip":
                case "application/x-httpd-php":
                case "application/vnd.ms-powerpoint":
                case "application/vnd.rar":
                case "application/x-sh":
                case "application/x-tar":
                case "application/vnd.ms-excel":
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                case "application/x-7z-compressed":
                case "audio/mpeg":
                case "audio/x-ms-wma":
                case "audio/vnd.rn-realaudio":
                case "audio/x-wav":
                case "audio/3gpp":
                case "audio/3gpp2":
                case "video/mpeg":
                case "video/mp4":
                case "video/webm":
                case "video/3gpp":
                case "video/3gpp2":
                case "font/ttf":
                    return new Downloader(this);
            }

            return null;
        }

        /// <summary>
        /// This method to get API response headers.
        /// </summary>
        /// <param name="headers">A System.Net.WebHeaderCollection class instance containing the API response headers.</param>
        /// <returns>A Dictionary&lt;String,String&gt; representing the API response headers.</returns>
        public Dictionary<string, string> GetHeaders(WebHeaderCollection headers)
        {
            Dictionary<string, string> headerMap = new Dictionary<string, string>();

            for (int i = 0; i < headers.Count; ++i)
            {
                string headerKey = headers.GetKey(i);

                string headerValue = "";

                foreach (string value in headers.GetValues(i))
                {
                    headerValue = string.Concat(headerValue, value);
                }

                headerMap.Add(headerKey, headerValue);
            }

            return headerMap;
        }

        private bool IsExpectedType(Model model, string className)
        {
            Type[] interfaces = model.GetType().GetInterfaces();
            
            foreach(Type interfaceDetails in interfaces)
            {
                if(interfaceDetails.FullName.Equals(className))
                {
                    return true;
                }
            }
            
            return false;
        }

        private void SetAPIURL(APIHTTPConnector connector)
        {
            string APIPath = "";

            if (apiPath.Contains(Constants.HTTP))
            {
                if(apiPath.Contains(Constants.CONTENT_API_URL))
                {
                    APIPath = string.Concat(APIPath, Initializer.GetInitializer().Environment.GetFileUploadUrl());

                    try
                    {
                        var uri = new Uri(apiPath);

                        APIPath = string.Concat(APIPath, uri.AbsolutePath);
                        
                    }
                    catch (System.Exception ex)
                    {
                        SDKException excp = new SDKException(ex);

                        SDKLogger.LogError(Constants.INVALID_URL_ERROR + JsonConvert.SerializeObject(excp));

                        throw excp;
                    }
                }
                else
                {
                    if (apiPath.Substring(0, 1).Equals("/"))
                    {
                        apiPath = apiPath.Substring(1);
                    }

                    APIPath = string.Concat(APIPath, apiPath);
                }
            }
            else
            {
                APIPath = string.Concat(APIPath, Initializer.GetInitializer().Environment.GetUrl());

                APIPath = string.Concat(APIPath, apiPath);
            }

            connector.URL = APIPath;
        }
    }
}
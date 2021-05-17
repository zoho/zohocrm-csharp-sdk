using System;

using System.Collections.Generic;

using System.IO;

using System.Text;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API.Fields;

using Com.Zoho.Crm.API.Logger;

using Com.Zoho.Crm.API.Modules;

using Com.Zoho.Crm.API.RelatedLists;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

using static Com.Zoho.Crm.API.Modules.ModulesOperations;

using APIException = Com.Zoho.Crm.API.RelatedLists.APIException;

using Module = Com.Zoho.Crm.API.Modules.Module;

using ResponseHandler = Com.Zoho.Crm.API.RelatedLists.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.RelatedLists.ResponseWrapper;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class handles module field details.
    /// </summary>
    public class Utility
    {
        private static object LOCK = new object();

        private static Dictionary<string, string> apiTypeVsdataType = new Dictionary<string, string>();

        private static Dictionary<string, string> apiTypeVsStructureName = new Dictionary<string, string>();

        private static JObject JSONDETAILS = Initializer.jsonDetails;

        private static bool newFile = false;
	
	    private static bool getModifiedModules = false;

        private static bool forceRefresh = false;

        private static string moduleAPIName;

        /// <summary>
        /// This method to fetch field details of the current module for the current user and store the result in a JSON file.
        /// </summary>
        /// <param name="moduleAPIName">A String containing the CRM module API name.</param>

        public static void GetFields(string moduleAPIName)
        {
            lock (LOCK)
            {
                Utility.moduleAPIName = moduleAPIName;

                GetFieldsInfo(Utility.moduleAPIName);
            }
        }

        public static void GetFieldsInfo(string moduleAPIName)
        {
            lock (LOCK)
            {
                string recordFieldDetailsPath = null;
		
                string lastModifiedTime = null;

                try
                {
                    if (moduleAPIName != null && SearchJSONDetails(moduleAPIName) != null)
                    {
                        return;
                    }

                    string resourcesPath = Initializer.GetInitializer().ResourcePath + Path.DirectorySeparatorChar + Constants.FIELD_DETAILS_DIRECTORY;

                    if (!Directory.Exists(resourcesPath))
                    {
                        Directory.CreateDirectory(resourcesPath);
                    }

                    recordFieldDetailsPath = resourcesPath + Path.DirectorySeparatorChar + GetFileName();

                    if (System.IO.File.Exists(recordFieldDetailsPath))
                    {
                        JObject recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

                        if (Initializer.GetInitializer().SDKConfig.AutoRefreshFields && !newFile && !getModifiedModules && (String.IsNullOrEmpty((string)recordFieldDetailsJson[Constants.FIELDS_LAST_MODIFIED_TIME]) || forceRefresh || (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - Convert.ToInt64(recordFieldDetailsJson[Constants.FIELDS_LAST_MODIFIED_TIME])) > 3600000))
                        {
                            getModifiedModules = true;

                            lastModifiedTime = recordFieldDetailsJson.ContainsKey(Constants.FIELDS_LAST_MODIFIED_TIME) ? (string)recordFieldDetailsJson.GetValue(Constants.FIELDS_LAST_MODIFIED_TIME) : null;

                            ModifyFields(recordFieldDetailsPath, lastModifiedTime);

                            getModifiedModules = false;
                        }
                        else if(!Initializer.GetInitializer().SDKConfig.AutoRefreshFields && forceRefresh && !getModifiedModules)
                        {
                            getModifiedModules = true;
                            
                            ModifyFields(recordFieldDetailsPath, lastModifiedTime);
                            
                            getModifiedModules = false;
                        }

                        recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

                        if (moduleAPIName == null || recordFieldDetailsJson.ContainsKey(moduleAPIName.ToLower()))
                        {
                            return;
                        }
                        else
                        {
                            FillDataType();

                            recordFieldDetailsJson[moduleAPIName.ToLower()] = new JObject();

                            using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                            {
                                JsonSerializer serializer = new JsonSerializer();

                                serializer.Serialize(sw, recordFieldDetailsJson);

                                sw.Flush();

                                sw.Close();
                            }

                            JObject fieldDetails = (JObject)GetFieldsDetails(moduleAPIName);

                            recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

                            recordFieldDetailsJson[moduleAPIName.ToLower()] = fieldDetails;

                            using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                            {
                                JsonSerializer serializer = new JsonSerializer();

                                serializer.Serialize(sw, recordFieldDetailsJson);

                                sw.Flush();

                                sw.Close();
                            }
                        }
                    }
                    else if(Initializer.GetInitializer().SDKConfig.AutoRefreshFields)
                    {
                        newFile = true;

                        FillDataType();

                        List<string> moduleAPINames = GetModules(null);
                    
                        JObject recordFieldDetailsJson = new JObject();
                    
                        recordFieldDetailsJson[Constants.FIELDS_LAST_MODIFIED_TIME] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    
                        foreach(string module in moduleAPINames)
                        {
                            if (!recordFieldDetailsJson.ContainsKey(module.ToLower()))
                            {
                                recordFieldDetailsJson[module.ToLower()] = new JObject();

                                using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                                {
                                    JsonSerializer serializer = new JsonSerializer();

                                    serializer.Serialize(sw, recordFieldDetailsJson);

                                    sw.Flush();

                                    sw.Close();
                                }

							    JObject fieldDetails = (JObject)GetFieldsDetails(module);

							    recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

							    recordFieldDetailsJson[module.ToLower()] = fieldDetails;

                                using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                                {
                                    JsonSerializer serializer = new JsonSerializer();

                                    serializer.Serialize(sw, recordFieldDetailsJson);

                                    sw.Flush();

                                    sw.Close();
                                }
                            }
                        }
                        
                        newFile = false;
                    }
                    else if(forceRefresh && !getModifiedModules)
                    {
                        //New file - and force refresh by User
                        getModifiedModules = true;
                        
                        JObject recordFieldDetailsJson = new JObject();

                        using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            serializer.Serialize(sw, recordFieldDetailsJson);

                            sw.Flush();

                            sw.Close();// file created with only dummy
                        }
                        
                        ModifyFields(recordFieldDetailsPath, lastModifiedTime);
                        
                        getModifiedModules = false;
                    }
                    else
                    {
                        FillDataType();

                        JObject recordFieldDetailsJson = new JObject();

                        recordFieldDetailsJson[moduleAPIName.ToLower()] = new JObject();

                        using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            serializer.Serialize(sw, recordFieldDetailsJson);

                            sw.Flush();

                            sw.Close();// file created with only dummy
                        }

                        JObject fieldsDetails = (JObject)GetFieldsDetails(moduleAPIName);

                        recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

                        recordFieldDetailsJson[moduleAPIName.ToLower()] = fieldsDetails;

                        using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            serializer.Serialize(sw, recordFieldDetailsJson);

                            sw.Flush();

                            sw.Close();
                        }
                    }
                }
                catch (System.Exception e)
                {
                    if(recordFieldDetailsPath != null && System.IO.File.Exists(recordFieldDetailsPath))
			        {
				        JObject recordFieldDetailsJson;
				
				        try 
				        {
					        recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);

					        if(recordFieldDetailsJson.ContainsKey(moduleAPIName.ToLower()))
					        {
						        recordFieldDetailsJson.Remove(moduleAPIName.ToLower());
					        }
					
					        if(newFile)
					        {
						        if(recordFieldDetailsJson.GetValue(Constants.FIELDS_LAST_MODIFIED_TIME) != null)
						        {
							        recordFieldDetailsJson.Remove(Constants.FIELDS_LAST_MODIFIED_TIME);
						        }
						
						        newFile = false;
					        }
					
					        if(getModifiedModules || forceRefresh)
					        {
						        getModifiedModules = false;

                                forceRefresh = false;
						
						        if(lastModifiedTime != null)
						        {
							        recordFieldDetailsJson[Constants.FIELDS_LAST_MODIFIED_TIME] = lastModifiedTime;
						        }
					        }

							using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
							{
								JsonSerializer serializer = new JsonSerializer();

								serializer.Serialize(sw, recordFieldDetailsJson);

								sw.Flush();

								sw.Close();
							}
						} 
				        catch (IOException ex) 
				        {
                            throw new SDKException(Constants.EXCEPTION, ex);
				        }
			        }

                    throw (e is SDKException) ? (SDKException) e : new SDKException(Constants.EXCEPTION, e);
                }
            }
        }

        private static void ModifyFields(string recordFieldDetailsPath, string modifiedTime)
	    {
		    List<string> modifiedModules = GetModules(modifiedTime);
		
		    JObject recordFieldDetailsJson = Initializer.GetJSON(recordFieldDetailsPath);
		
		    recordFieldDetailsJson[Constants.FIELDS_LAST_MODIFIED_TIME] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		
			using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
			{
				JsonSerializer serializer = new JsonSerializer();

				serializer.Serialize(sw, recordFieldDetailsJson);

				sw.Flush();

				sw.Close();
			}

			if (modifiedModules.Count > 0)
		    {
			    foreach(string module in modifiedModules)
			    {
				    if(recordFieldDetailsJson.ContainsKey(module.ToLower()))
				    {
					    DeleteFields(recordFieldDetailsJson, module);
				    }
			    }

				using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
				{
					JsonSerializer serializer = new JsonSerializer();

					serializer.Serialize(sw, recordFieldDetailsJson);

					sw.Flush();

					sw.Close();
				}

				foreach (string module in modifiedModules)
			    {
                    GetFieldsInfo(module);
			    }
		    }
	    }

        public static void DeleteFields(JObject recordFieldDetailsJson, string module)
        {
            lock (LOCK)
            { 
                List<string> subformModules = new List<string>();

                JObject fieldsJSON = (JObject)recordFieldDetailsJson[module.ToLower()];

                foreach (KeyValuePair<string, JToken> fieldDetails in fieldsJSON)
                {
                    JObject fieldDetail = (JObject)fieldDetails.Value;

                    if (fieldDetail.ContainsKey(Constants.SUBFORM) && (bool)fieldDetail[Constants.SUBFORM] && recordFieldDetailsJson.ContainsKey((string)fieldDetail[Constants.MODULE]))
                    {
                        subformModules.Add((string)fieldDetail[Constants.MODULE]);
                    }
                }

                recordFieldDetailsJson.Remove(module.ToLower());

                if (subformModules.Count > 0)
                {
                    foreach (string subformModule in subformModules)
                    {
                        DeleteFields(recordFieldDetailsJson, subformModule);
                    }
                }
            }
        }

        private static string GetFileName()
	    {
			string fileName = Initializer.GetInitializer().User.Email;

			fileName = fileName.Substring(0, fileName.IndexOf("@")) + Initializer.GetInitializer().Environment.GetUrl();

			byte[] input = Encoding.UTF8.GetBytes(fileName);

			string str = Convert.ToBase64String(input);

			return str + ".json";
	    }

        public static void GetRelatedLists(string relatedModuleName, string moduleAPIName, CommonAPIHandler commonAPIHandler)
	    {
            lock (LOCK)
            {
                try
                {
                    bool isNewData = false;

                    string key = (moduleAPIName + Constants.UNDERSCORE + Constants.RELATED_LISTS).ToLower();

                    string resourcesPath = Initializer.GetInitializer().ResourcePath + Path.DirectorySeparatorChar + Constants.FIELD_DETAILS_DIRECTORY;

                    if (!Directory.Exists(resourcesPath))
                    {
                        Directory.CreateDirectory(resourcesPath);
                    }

                    string recordFieldDetailsPath = resourcesPath + Path.DirectorySeparatorChar + GetFileName();

                    if (!System.IO.File.Exists(recordFieldDetailsPath) || (System.IO.File.Exists(recordFieldDetailsPath) && (!Initializer.GetJSON(recordFieldDetailsPath).ContainsKey(key) || (Initializer.GetJSON(recordFieldDetailsPath).GetValue(key) == null || ((JArray)Initializer.GetJSON(recordFieldDetailsPath).GetValue(key)).Count <= 0))))
                    {
                        isNewData = true;

                        JArray relatedListValues = GetRelatedListDetails(moduleAPIName);

                        JObject recordFieldDetailsJSON1 = System.IO.File.Exists(recordFieldDetailsPath) ? Initializer.GetJSON(recordFieldDetailsPath) : new JObject();

                        recordFieldDetailsJSON1[key] = relatedListValues;

                        using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            serializer.Serialize(sw, recordFieldDetailsJSON1);

                            sw.Flush();

                            sw.Close();
                        }
                    }

                    JObject recordFieldDetailsJSON = Initializer.GetJSON(recordFieldDetailsPath);

                    JArray modulerelatedList = (JArray)recordFieldDetailsJSON.GetValue(key);

                    if (!CheckRelatedListExists(relatedModuleName, modulerelatedList, commonAPIHandler) && !isNewData)
                    {
                        recordFieldDetailsJSON.Remove(key);

                        using (StreamWriter sw = System.IO.File.CreateText(recordFieldDetailsPath))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            serializer.Serialize(sw, recordFieldDetailsJSON);

                            sw.Flush();

                            sw.Close();
                        }

                        GetRelatedLists(relatedModuleName, moduleAPIName, commonAPIHandler);
                    }
                }
                catch (SDKException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new SDKException(Constants.EXCEPTION, e);
                }
            }
	    }

        private static bool CheckRelatedListExists(string relatedModuleName, JArray modulerelatedListJA, CommonAPIHandler commonAPIHandler)
	    {
		    foreach (JObject relatedListJO in modulerelatedListJA)
		    {
			    if(relatedListJO.ContainsKey(Constants.API_NAME) && relatedListJO.GetValue(Constants.API_NAME) != null && relatedListJO.GetValue(Constants.API_NAME).ToString().Equals(relatedModuleName, StringComparison.OrdinalIgnoreCase))
			    {
                    if(relatedListJO[Constants.HREF].Equals(Constants.NULL_VALUE))
                    {
                        throw new SDKException(Constants.UNSUPPORTED_IN_API, commonAPIHandler.HttpMethod + " " + commonAPIHandler.APIPath + Constants.UNSUPPORTED_IN_API_MESSAGE);
                    }

                    if (relatedListJO.ContainsKey(Constants.MODULE) && !string.IsNullOrEmpty(relatedListJO[Constants.MODULE].ToString()))
                    {
                        commonAPIHandler.ModuleAPIName = (string)relatedListJO[Constants.MODULE];

                        GetFieldsInfo((string)relatedListJO[Constants.MODULE]);
                    }

				    return true;
			    }
		    }
		
		    return false;
	    }
	
	    private static JArray GetRelatedListDetails(string moduleAPIName)
	    {
		    RelatedListsOperations relatedListsOperations = new RelatedListsOperations(moduleAPIName);
		
		    APIResponse<ResponseHandler> response = relatedListsOperations.GetRelatedLists();
		
		    JArray relatedListJA = new JArray();
		
		    if(response != null)
		    {
			    if(response.StatusCode == Constants.NO_CONTENT_STATUS_CODE)
			    {
				    return relatedListJA;
			    }
			    if(response.IsExpected)
			    {
					ResponseHandler responseHandler = response.Object;
				
				    if(responseHandler is ResponseWrapper)
				    {
					    ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
					
					    List<RelatedList> relatedLists = (List<RelatedList>) responseWrapper.RelatedLists;
					
					    foreach(RelatedList relatedList in relatedLists)
					    {
						    JObject relatedListDetail = new JObject();
						
						    relatedListDetail.Add(Constants.API_NAME, relatedList.APIName);
						
						    relatedListDetail.Add(Constants.MODULE, relatedList.Module);
						
						    relatedListDetail.Add(Constants.NAME, relatedList.Name);
						
						    relatedListDetail.Add(Constants.HREF, relatedList.Href);
						
						    relatedListJA.Add(relatedListDetail);
					    }
				    }
				    else if(responseHandler is APIException)
				    {
					    APIException exception = (APIException) responseHandler;
					
					    JObject errorResponse = new JObject();
					
					    errorResponse.Add(Constants.CODE, exception.Code.Value);
					
					    errorResponse.Add(Constants.STATUS, exception.Status.Value);
					
					    errorResponse.Add(Constants.MESSAGE, exception.Message.Value);
					
					    throw new SDKException(Constants.API_EXCEPTION, errorResponse);
				    }
			    }
			    else
			    {
				    JObject errorResponse = new JObject();
				
				    errorResponse.Add(Constants.CODE, response.StatusCode);
				
				    throw new SDKException(Constants.API_EXCEPTION, errorResponse);
			    }
		    }
		
		    return relatedListJA;	
	    }

	    ///<summary>
	    ///This method to get module field data from Zoho CRM.
	    ///</summary>
	    ///<param name="moduleAPIName">A String containing the CRM module API name.</param>
	    ///<returns>A Object representing the Zoho CRM module field details.</returns>
	    public static object GetFieldsDetails(string moduleAPIName)
	    {		
		    JObject fieldsDetails = new JObject();
		
		    FieldsOperations fieldOperation = new FieldsOperations(moduleAPIName);

			ParameterMap parameterinstance = new ParameterMap();

		    APIResponse<Com.Zoho.Crm.API.Fields.ResponseHandler> response = fieldOperation.GetFields(parameterinstance);
		
		    if(response != null)
		    {
			    if(response.StatusCode == Constants.NO_CONTENT_STATUS_CODE)
			    {
				    return fieldsDetails;
			    }
			
			    //Check if expected response is received
			    if(response.IsExpected)
			    {
					Com.Zoho.Crm.API.Fields.ResponseHandler responseHandler = response.Object;
				
				    if (responseHandler is Com.Zoho.Crm.API.Fields.ResponseWrapper)
				    {
						Com.Zoho.Crm.API.Fields.ResponseWrapper responseWrapper = (Com.Zoho.Crm.API.Fields.ResponseWrapper) responseHandler;

					    List<Field> fields = (List<Field>) responseWrapper.Fields;

					    foreach (Field field in fields)
					    {
							string keyName = field.APIName;
						
						    if (Constants.KEYS_TO_SKIP.Contains(keyName))
						    {
							    continue;
						    }
                            			
						    JObject fieldDetail = new JObject();

						    SetDataType(fieldDetail, field, moduleAPIName);

						    fieldsDetails[field.APIName] = fieldDetail;
					    }
					
					    if(Constants.INVENTORY_MODULES.Contains(moduleAPIName.ToLower()))
					    {
						    JObject fieldDetail = new JObject();
						
						    fieldDetail.Add(Constants.NAME, Constants.LINE_TAX);
						
						    fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);
						
						    fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.LINE_TAX_NAMESPACE);

                            fieldDetail.Add(Constants.LOOKUP, true);
						
						    fieldsDetails.Add(Constants.LINE_TAX, fieldDetail);
					    }

                        if (Constants.NOTES.Equals(moduleAPIName, StringComparison.OrdinalIgnoreCase))
                        {
                            JObject fieldDetail = new JObject();

                            fieldDetail.Add(Constants.NAME, Constants.ATTACHMENTS);

                            fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);

                            fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.ATTACHMENTS_NAMESPACE);

                            fieldsDetails.Add(Constants.ATTACHMENTS, fieldDetail);
                        }
				    }
				    else if(responseHandler is Fields.APIException)
				    {
						Fields.APIException exception = (Fields.APIException)responseHandler;
					
					    JObject errorResponse = new JObject();
					
					    errorResponse.Add(Constants.CODE, exception.Code.Value);
					
					    errorResponse.Add(Constants.STATUS, exception.Status.Value);
					
					    errorResponse.Add(Constants.MESSAGE, exception.Message.Value);

                        SDKException exception1 = new SDKException(Constants.API_EXCEPTION, errorResponse);

                        if (Utility.moduleAPIName.ToLower().Equals(moduleAPIName.ToLower()))
                        {
                            throw exception1;
                        }

                        SDKLogger.LogError(JsonConvert.SerializeObject(exception1));
				    }
			    }
			    else
			    {
				    JObject errorResponse = new JObject();
				
				    errorResponse.Add(Constants.CODE, response.StatusCode);
				
				    throw new SDKException(Constants.API_EXCEPTION, errorResponse);
			    }
		    }
		
		    return fieldsDetails;
	    }

        public static JObject SearchJSONDetails(string key)
        {
            key = Constants.PACKAGE_NAMESPACE + ".Record." + key;

            foreach(KeyValuePair<string, JToken> member in JSONDETAILS)
            {
                string keyInJSON = member.Key;

                if(keyInJSON.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    JObject returnJSON = new JObject();

                    returnJSON.Add(Constants.MODULEPACKAGENAME, keyInJSON);

                    returnJSON.Add(Constants.MODULEDETAILS, (JObject)member.Value);

                    return returnJSON;
                }
            }

            return null;
        }

        public static void VerifyPhotoSupport(string moduleAPIName)
        {
            return;
        }

        private static List<string> GetModules(string header)
	    {
		    List<string> apiNames = new List<string>();
		
		    HeaderMap headerMap = new HeaderMap();
		
		    if(header != null)
		    {
				DateTimeOffset headerValue = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(header));
                
                DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(headerValue, TimeZoneInfo.Local);

                headerMap.Add(GetModulesHeader.IF_MODIFIED_SINCE, targetTime);
		    }
		
		    APIResponse<Com.Zoho.Crm.API.Modules.ResponseHandler> response = new ModulesOperations().GetModules(headerMap);
		
		    if(response != null)
		    {
                if (new List<int>() { Constants.NO_CONTENT_STATUS_CODE, Constants.NOT_MODIFIED_STATUS_CODE }.Contains(response.StatusCode))
                {
                    return apiNames;
                }

                // Check if expected response is received
                if (response.IsExpected)
                {
                    Com.Zoho.Crm.API.Modules.ResponseHandler responseObject = response.Object;

                    if (responseObject is Com.Zoho.Crm.API.Modules.ResponseWrapper)
                    {
                        List<Module> modules = ((Com.Zoho.Crm.API.Modules.ResponseWrapper)responseObject).Modules;

                        foreach (Module module in modules)
                        {
                            if (module.APISupported != null && (bool)module.APISupported)
                            {
                                apiNames.Add(module.APIName);
                            }
                        }
                    }
                    else if (responseObject is Com.Zoho.Crm.API.Modules.APIException)
                    {
                        Com.Zoho.Crm.API.Modules.APIException exception = (Com.Zoho.Crm.API.Modules.APIException) responseObject;

                        JObject errorResponse = new JObject();

                        errorResponse.Add(Constants.CODE, exception.Code.Value);

                        errorResponse.Add(Constants.STATUS, exception.Status.Value);

                        errorResponse.Add(Constants.MESSAGE, exception.Message.Value);

                        throw new SDKException(Constants.API_EXCEPTION, errorResponse);
                    }
                }
		    }
		
		    return apiNames;
	    }

        public static void RefreshModules()
        {
            lock (LOCK)
            {
                forceRefresh = true;

                GetFieldsInfo(null);

                forceRefresh = false;
            }
        }

        public static JObject GetJSONObject(JObject json, string key)
        {
            foreach(var entry in json)
            {
                string keyInJSON = entry.Key;

                if(keyInJSON.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    return (JObject)entry.Value;
                }
            }

            return null;
        }

        private static void SetDataType(JObject fieldDetail, Field field, string moduleAPIName)
        {
            string apiType = field.DataType;

            string keyName = field.APIName;

            string module = "";

            if(field.SystemMandatory != null && field.SystemMandatory == true && !(moduleAPIName.Equals(Constants.CALLS, StringComparison.OrdinalIgnoreCase) && keyName.Equals(Constants.CALL_DURATION, StringComparison.OrdinalIgnoreCase)))
            {
                fieldDetail.Add(Constants.REQUIRED, true);
            }
            
            if (keyName.Equals(Constants.PRODUCT_DETAILS, StringComparison.OrdinalIgnoreCase) && Constants.INVENTORY_MODULES.Contains(moduleAPIName.ToLower()))
            {
                fieldDetail.Add(Constants.NAME, keyName);

                fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);

                fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.INVENTORY_LINE_ITEMS);

                fieldDetail.Add(Constants.SKIP_MANDATORY, true);

                return;
            }
            else if (keyName.Equals(Constants.PRICING_DETAILS, StringComparison.OrdinalIgnoreCase) && moduleAPIName.Equals(Constants.PRICE_BOOKS, StringComparison.OrdinalIgnoreCase))
            {
                fieldDetail.Add(Constants.NAME, keyName);

                fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);

                fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.PRICINGDETAILS);

                fieldDetail.Add(Constants.SKIP_MANDATORY, true);

                return;
            }
            else if(keyName.Equals(Constants.PARTICIPANT_API_NAME, StringComparison.OrdinalIgnoreCase) && (moduleAPIName.Equals(Constants.EVENTS, StringComparison.OrdinalIgnoreCase) || moduleAPIName.Equals(Constants.ACTIVITIES, StringComparison.OrdinalIgnoreCase)))
            {
                fieldDetail.Add(Constants.NAME, keyName);

                fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);

                fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.PARTICIPANTS);

                fieldDetail.Add(Constants.SKIP_MANDATORY, true);

                return;
            }

            else if (keyName.Equals(Constants.COMMENTS, StringComparison.OrdinalIgnoreCase) && (moduleAPIName.Equals(Constants.SOLUTIONS, StringComparison.OrdinalIgnoreCase) || moduleAPIName.Equals(Constants.CASES, StringComparison.OrdinalIgnoreCase)))
            {
                fieldDetail.Add(Constants.NAME, keyName);

                fieldDetail.Add(Constants.TYPE, Constants.LIST_NAMESPACE);

                fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.COMMENT_NAMESPACE);

                fieldDetail.Add(Constants.LOOKUP, true);

                return;
            }
            else if(keyName.Equals(Constants.LAYOUT, StringComparison.OrdinalIgnoreCase))
            {
                fieldDetail.Add(Constants.NAME, keyName);

                fieldDetail.Add(Constants.TYPE, Constants.LAYOUT_NAMESPACE);

                fieldDetail.Add(Constants.STRUCTURE_NAME, Constants.LAYOUT_NAMESPACE);

                fieldDetail.Add(Constants.LOOKUP, true);

                return;

            }
            else if(apiTypeVsdataType.ContainsKey(apiType))
            {
                fieldDetail.Add(Constants.TYPE, apiTypeVsdataType[apiType]);
            }
            else if(apiType.Equals(Constants.FORMULA, StringComparison.OrdinalIgnoreCase))
            {
                if(field.Formula != null)
                {
                    string returnType = field.Formula.ReturnType;
                    
                    if(apiTypeVsdataType.ContainsKey(returnType) && apiTypeVsdataType[returnType] != null)
                    {
                        fieldDetail.Add(Constants.TYPE, apiTypeVsdataType[returnType]);
                    }
                }
                
                fieldDetail.Add(Constants.READ_ONLY, true);
            }
            else
            {
                return;
            }

            if(apiType.ToLower().Contains(Constants.LOOKUP))
            {
                fieldDetail[Constants.LOOKUP] = true;
            }

            if (apiType.ToLower().Equals(Constants.CONSENT_LOOKUP, StringComparison.OrdinalIgnoreCase))
            {
                fieldDetail[Constants.SKIP_MANDATORY] =  true;
            }

            if (apiTypeVsStructureName.ContainsKey(apiType))
            {
                fieldDetail.Add(Constants.STRUCTURE_NAME, apiTypeVsStructureName[apiType]);
            }

            if(field.DataType.Equals(Constants.PICKLIST, StringComparison.OrdinalIgnoreCase) && (field.PickListValues != null && field.PickListValues.Count > 0))
            {
                fieldDetail.Add(Constants.PICKLIST, true);

                JArray values = new JArray();

                field.PickListValues.ForEach(plv => values.Add(plv.DisplayValue));

                fieldDetail.Add(Constants.VALUES, values);
            }

            if(apiType.Equals(Constants.SUBFORM, StringComparison.OrdinalIgnoreCase))
            {
                module = field.Subform.Module_1;

                fieldDetail.Add(Constants.MODULE, module);

                fieldDetail.Add(Constants.SKIP_MANDATORY, true);
			
			    fieldDetail.Add(Constants.SUBFORM, true);
            }

            if(apiType.Equals(Constants.LOOKUP, StringComparison.OrdinalIgnoreCase))
            {
                module = field.Lookup.Module_1;

                if(module != null && !module.Equals(Constants.SE_MODULE, StringComparison.OrdinalIgnoreCase))
                {
                    fieldDetail.Add(Constants.MODULE, module);

                    if(module.Equals(Constants.ACCOUNTS, StringComparison.OrdinalIgnoreCase) && (field.CustomField != null && !(bool)field.CustomField))
                    {
                        fieldDetail.Add(Constants.SKIP_MANDATORY, true);
                    }
                }
                else
                {
                    module = "";
                }

                fieldDetail[Constants.LOOKUP] = true;
            }

            if (module.Length > 0)
            {
                Utility.GetFieldsInfo(module);
            }

            fieldDetail.Add(Constants.NAME, keyName);
        }

        private static void FillDataType()
        {
            if (apiTypeVsdataType.Count > 0)
            {
                return;
            }

            string[] fieldAPINamesString = new string[] { "textarea", "text", "website", "email", "phone", "mediumtext", "multiselectlookup", "profileimage", "autonumber"};

            string[] fieldAPINamesInteger = new string[] { "integer" };

            string[] fieldAPINamesBoolean = new string[] { "boolean" };

            string[] fieldAPINamesLong = new string[] { "long", "bigint" };

            string[] fieldAPINamesDouble = new string[] { "double", "percent", "lookup", "currency" };

            string[] fieldAPINamesFile = new string[] { "imageupload"};

            string[] fieldAPINamesFieldFile = new string[] { "fileupload" };

            string[] fieldAPINamesDateTime = new string[] { "datetime", "event_reminder" };

            string[] fieldAPINamesDate = new string[] { "date" };

            string[] fieldAPINamesLookup = new string[] { "lookup" };

            string[] fieldAPINamesPickList = new string[] { "picklist" };

            string[] fieldAPINamesMultiSelectPickList = new string[] { "multiselectpicklist" };

            string[] fieldAPINamesSubForm = new string[] { "subform" };

            string[] fieldAPINamesOwnerLookUp = new string[] { "ownerlookup", "userlookup" };

            string[] fieldAPINamesMultiUserLookUp = new string[] { "multiuserlookup" };

            string[] fieldAPINamesMultiModuleLookUp = new string[] { "multimodulelookup" };
            
            string[] fieldAPINameTaskRemindAt = new string[] { "ALARM" };
		
            string[] fieldAPINameRecurringActivity = new string[] {"RRULE"};
            
            string[] fieldAPINameReminder = new string[] {"multireminder"};

            string[] fieldAPINameConsentLookUp = new string[] { "consent_lookup" }; // No I18N

            foreach (string fieldAPIName in fieldAPINamesString)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CSHARP_STRING_NAME;
            }

            foreach (string fieldAPIName in fieldAPINamesInteger)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CSHARP_INT_NAME;
            }

            foreach (string fieldAPIName in fieldAPINamesBoolean)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CSHARP_BOOLEAN_NAME;
            }

            foreach (string fieldAPIName in fieldAPINamesLong)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CSHARP_LONG_NAME;
            }

            foreach (string fieldAPIName in fieldAPINamesDouble)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CSHARP_DOUBLE_NAME;
            }

            foreach (string fieldAPIName in fieldAPINamesFile)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.FILE_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesDateTime)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.SYSTEM_DATETIME_OFFSET;
            }

            foreach (string fieldAPIName in fieldAPINamesDate)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.SYSTEM_DATETIME;
            }

            foreach (string fieldAPIName in fieldAPINamesLookup)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.RECORD_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.RECORD_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesPickList)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.CHOICE_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesMultiSelectPickList)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.CHOICE_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesSubForm)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.RECORD_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesOwnerLookUp)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.USER_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.USER_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesMultiUserLookUp)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.USER_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesMultiModuleLookUp)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.MODULE_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINamesFieldFile)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;

                apiTypeVsStructureName[fieldAPIName] = Constants.FIELD_FILE_NAMESPACE;
            }

            foreach(string fieldAPIName in fieldAPINameTaskRemindAt)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.REMINDAT_NAMESPACE;
                
                apiTypeVsStructureName[fieldAPIName] = Constants.REMINDAT_NAMESPACE;
            }
            
            foreach(string fieldAPIName in fieldAPINameRecurringActivity)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.RECURRING_ACTIVITY_NAMESPACE;
                
                apiTypeVsStructureName[fieldAPIName] = Constants.RECURRING_ACTIVITY_NAMESPACE;
            }
            
            foreach(string fieldAPIName in fieldAPINameReminder)
            {
                apiTypeVsdataType[fieldAPIName] = Constants.LIST_NAMESPACE;
                
                apiTypeVsStructureName[fieldAPIName] = Constants.REMINDER_NAMESPACE;
            }

            foreach (string fieldAPIName in fieldAPINameConsentLookUp)
            {
                apiTypeVsdataType.Add(fieldAPIName, Constants.CONSENT_NAMESPACE);

                apiTypeVsStructureName.Add(fieldAPIName, Constants.CONSENT_NAMESPACE);
            }
        }
    }
}

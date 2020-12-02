using System;

using System.Collections.Generic;

using System.IO;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.BulkWrite;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.BulkWrite.BulkWriteOperations;

using ActionResponse = Com.Zoho.Crm.API.BulkWrite.ActionResponse;

using APIException = Com.Zoho.Crm.API.BulkWrite.APIException;

using File = Com.Zoho.Crm.API.BulkWrite.File;
using RequestWrapper = Com.Zoho.Crm.API.BulkWrite.RequestWrapper;
using ResponseHandler = Com.Zoho.Crm.API.BulkWrite.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.BulkWrite.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.BulkWrite.SuccessResponse;

namespace Com.Zoho.Crm.Sample.BulkWrite
{
    public class BulkWrite
    {
        /// <summary>
        /// This method is used to upload a CSV file in ZIP format for bulk write API. The response contains the file_id.
        /// Use this ID while making the bulk write request.
        /// </summary>
        /// <param name="orgID">The unique ID (zgid) of your organization obtained through the Organization API.</param>
        /// <param name="absoluteFilePath">The absoluteFilePath of the zip file you want to upload.</param>
        public static void UploadFile(string orgID, string absoluteFilePath)
        {
            //example
            //string absoluteFilePath = "/Users/user_name/Documents/Leads.zip";
            //string orgID = "673573045";
            
            //Get instance of BulkWriteOperations Class
            BulkWriteOperations bulkWriteOperations = new BulkWriteOperations();
            
            //Get instance of FileBodyWrapper class that will contain the request file
            FileBodyWrapper fileBodyWrapper = new FileBodyWrapper();

            //Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
            StreamWrapper streamWrapper = new StreamWrapper(absoluteFilePath);

            //FileInfo fileInfo = new FileInfo(absoluteFilePath);

            //Get instance of StreamWrapper class that takes file name and stream of the file to be attached as parameter
            //StreamWrapper streamWrapper = new StreamWrapper(fileInfo.Name, fileInfo.OpenRead());

            //Set file to the FileBodyWrapper instance
            fileBodyWrapper.File = streamWrapper;
            
            //Get instance of HeaderMap Class
            HeaderMap headerInstance = new HeaderMap();
            
            //To indicate that this a bulk write operation
            headerInstance.Add(UploadFileHeader.FEATURE, "bulk-write");
            
            headerInstance.Add(UploadFileHeader.X_CRM_ORG, orgID);
            
            //Call uploadFile method that takes FileBodyWrapper instance and headerInstance as parameter
            APIResponse<ActionResponse> response = bulkWriteOperations.UploadFile(fileBodyWrapper, headerInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ActionResponse actionResponse = response.Object;
                    
                    //Check if the request is successful
                    if(actionResponse is SuccessResponse)
                    {
                        //Get the received SuccessResponse instance
                        SuccessResponse successResponse = (SuccessResponse)actionResponse;
                        
                        //Get the Status
                        Console.WriteLine("Status: " + successResponse.Status.Value);
                        
                        //Get the Code
                        Console.WriteLine("Code: " + successResponse.Code.Value);
                        
                        Console.WriteLine("Details: " );
                        
                        //Get the details map
                        foreach(KeyValuePair<string, object> entry in successResponse.Details)
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                        }
                        
                        //Get the Message
                        Console.WriteLine("Message: " + successResponse.Message.Value);
                    }
                    //Check if the request returned an exception
                    else if(actionResponse is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) actionResponse;
                        
                        if(exception.Status != null)
                        {
                            //Get the Status
                            Console.WriteLine("Status: " + exception.Status.Value);
                        }
                        
                        if(exception.Code != null)
                        {
                            //Get the Code
                            Console.WriteLine("Code: " + exception.Code.Value);	
                        }
                        
                        if(exception.Message != null)
                        {
                            //Get the Message
                            Console.WriteLine("Message: " + exception.Message.Value);
                        }

                        Console.WriteLine("Details: " );
                        
                        if(exception.Details != null)
                        {
                            //Get the details map
                            foreach(KeyValuePair<string, object> entry in exception.Details)
                            {
                                //Get each value in the map
                                Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                            }
                        }

                        if(exception.ErrorMessage != null)
                        {
                            //Get the ErrorMessage
                            Console.WriteLine("ErrorMessage: " + exception.ErrorMessage.Value);
                        }
                        
                        //Get the ErrorCode
                        Console.WriteLine("ErrorCode: " + exception.ErrorCode);
                        
                        if(exception.XError != null)
                        {
                            //Get the XError
                            Console.WriteLine("XError: " + exception.XError.Value);
                        }
                        
                        if(exception.Info != null)
                        {
                            //Get the Info
                            Console.WriteLine("Info: " + exception.Info.Value);
                        }
                        
                        if(exception.XInfo != null)
                        {
                            //Get the XInfo
                            Console.WriteLine("XInfo: " + exception.XInfo.Value);
                        }
                        
                        //Get the HttpStatus
                        Console.WriteLine("HttpStatus: " + exception.HttpStatus);
                    }
                }
                else
                { //If response is not as expected

                    //Get model object from response
                    Model responseObject = response.Model;

                    //Get the response object's class
                    Type type = responseObject.GetType();

                    //Get all declared fields of the response class
                    Console.WriteLine("Type is: {0}", type.Name);

                    PropertyInfo[] props = type.GetProperties();

                    Console.WriteLine("Properties (N = {0}):", props.Length);

                    foreach (var prop in props)
                    {
                        if (prop.GetIndexParameters().Length == 0)
                        {
                            Console.WriteLine("{0} ({1}) : {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(responseObject));
                        }
                        else
                        {
                            Console.WriteLine("{0} ({1}) : <Indexed>", prop.Name, prop.PropertyType.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method is used to create a bulk write job.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the record's module.</param>
        /// <param name="fileId">The ID of the uploaded file to create BulkWrite Job.</param>
        public static void CreateBulkWriteJob(string moduleAPIName, string fileId)
        {
            //example
            //string moduleAPIName = "Leads";
            //string fileId  = "34770616121001";
            
            //Get instance of BulkWriteOperations Class
            BulkWriteOperations bulkWriteOperations = new BulkWriteOperations();
            
            //Get instance of RequestWrapper Class that will contain the request body
            RequestWrapper requestWrapper = new RequestWrapper();
            
            //Get instance of CallBack Class
            CallBack callback = new CallBack();

            // To set valid callback URL.
            callback.Url = "https://www.example.com/callback";

            //To set the HTTP method of the callback URL. The allowed value is post.
            callback.Method = new Choice<string>("post");
            
            //The Bulk Write Job's details are posted to this URL on successful completion of job or on failure of job.
            requestWrapper.Callback = callback;
            
            //To set the charset of the uploaded file
            requestWrapper.CharacterEncoding = "UTF-8";
            
            //To set the type of operation you want to perform on the bulk write job.
            requestWrapper.Operation = new Choice<string>("update");
            
            List<Resource> resource = new List<Resource>();
            
            //Get instance of Resource Class
            Resource resourceIns = new Resource();

            // To set the type of module that you want to import. The value is data.
            resourceIns.Type = new Choice<string>("data");

            //To set API name of the module that you select for bulk write job.
            resourceIns.Module = moduleAPIName;
            
            //To set the file_id obtained from file upload API.
            resourceIns.FileId = fileId;
            
            //True - Ignores the empty values.The default value is false. 
            resourceIns.IgnoreEmpty = true;

            // To set a field as a unique field or ID of a record. 
            resourceIns.FindBy = "Email";

            List<FieldMapping> fieldMappings = new List<FieldMapping>();
            
            FieldMapping fieldMapping;
            
            //Get instance of FieldMapping Class
            fieldMapping = new FieldMapping();
            
            //To set API name of the field present in Zoho module object that you want to import. 
            fieldMapping.APIName = "Last_Name";
            
            //To set the column index of the field you want to map to the CRM field.
            fieldMapping.Index = 0;
            
            fieldMappings.Add(fieldMapping);

            fieldMapping = new FieldMapping();

            fieldMapping.APIName = "Email";

            fieldMapping.Index = 1;
            
            fieldMappings.Add(fieldMapping);
            
            fieldMapping = new FieldMapping();
            
            fieldMapping.APIName = "Company";
            
            fieldMapping.Index = 2;
            
            fieldMappings.Add(fieldMapping);
            
            fieldMapping = new FieldMapping();
            
            fieldMapping.APIName = "Phone";
            
            fieldMapping.Index = 3;
            
            fieldMappings.Add(fieldMapping);
            
            fieldMapping = new FieldMapping();

            fieldMapping.APIName = "Website";

            //fieldMapping.Format = "";

            //fieldMapping.FindBy = "";

            Dictionary<string, object> defaultValue = new Dictionary<string, object>();
            
            defaultValue.Add("value", "https://www.zohoapis.com");
            
            //To set the default value for an empty column in the uploaded file.
            fieldMapping.DefaultValue = defaultValue;
            
            fieldMappings.Add(fieldMapping);
            
            resourceIns.FieldMappings = fieldMappings;
            
            resource.Add(resourceIns);
            
            requestWrapper.Resource = resource;
        
            //Call CreateBulkWriteJob method that takes RequestWrapper instance as parameter 
            APIResponse<ActionResponse> response = bulkWriteOperations.CreateBulkWriteJob(requestWrapper);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ActionResponse actionResponse = response.Object;
                    
                    //Check if the request is successful
                    if(actionResponse is SuccessResponse)
                    {
                        //Get the received SuccessResponse instance
                        SuccessResponse successResponse = (SuccessResponse)actionResponse;
                        
                        //Get the Status
                        Console.WriteLine("Status: " + successResponse.Status.Value);
                        
                        //Get the Code
                        Console.WriteLine("Code: " + successResponse.Code.Value);
                        
                        Console.WriteLine("Details: " );
                        
                        //Get the details map
                        foreach(KeyValuePair<string, object> entry in successResponse.Details)
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                        }
                        
                        //Get the Message
                        Console.WriteLine("Message: " + successResponse.Message.Value);
                    }
                    //Check if the request returned an exception
                    else if(actionResponse is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) actionResponse;
                        
                        //Get the Status
                        Console.WriteLine("Status: " + exception.Status.Value);
                        
                        //Get the Code
                        Console.WriteLine("Code: " + exception.Code.Value);
                        
                        Console.WriteLine("Details: " );
                        
                        //Get the details map
                        foreach(KeyValuePair<string, object> entry in exception.Details)
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                        }
                        
                        //Get the Message
                        Console.WriteLine("Message: " + exception.Message.Value);
                    }
                }
                else
                { //If response is not as expected

                    //Get model object from response
                    Model responseObject = response.Model;

                    //Get the response object's class
                    Type type = responseObject.GetType();

                    //Get all declared fields of the response class
                    Console.WriteLine("Type is: {0}", type.Name);

                    PropertyInfo[] props = type.GetProperties();

                    Console.WriteLine("Properties (N = {0}):", props.Length);

                    foreach (var prop in props)
                    {
                        if (prop.GetIndexParameters().Length == 0)
                        {
                            Console.WriteLine("{0} ({1}) : {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(responseObject));
                        }
                        else
                        {
                            Console.WriteLine("{0} ({1}) : <Indexed>", prop.Name, prop.PropertyType.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method is used to get the details of a bulk write job performed previously.
        /// </summary>
        /// <param name="jobId">The unique ID of the bulk write job.</param>
        public static void GetBulkWriteJobDetails(long jobId)
        {
            //example
            //long jobId = 34770615615003;
            
            //Get instance of BulkWriteOperations Class
            BulkWriteOperations bulkWriteOperations = new BulkWriteOperations();
            
            //Call GetBulkWriteJobDetails method that takes jobId as parameter
            APIResponse<ResponseWrapper> response = bulkWriteOperations.GetBulkWriteJobDetails(jobId);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if(new List<int>() { 204, 304 }.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode == 204? "No Content" : "Not Modified");

                    return;
                }
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ResponseWrapper responseWrapper = response.Object;
                    
                    if(responseWrapper is BulkWriteResponse)
                    {
                        //Get the received BulkWriteResponse instance
                        BulkWriteResponse bulkWriteResponse = (BulkWriteResponse) responseWrapper;
                        
                        //Get the Job Status of each bulkWriteResponse
                        Console.WriteLine("Bulk write Job Status: " + bulkWriteResponse.Status);
                        
                        //Get the CharacterEncoding of each bulkWriteResponse
                        Console.WriteLine("Bulk write CharacterEncoding: " + bulkWriteResponse.CharacterEncoding);
                        
                        List<Resource> resources = bulkWriteResponse.Resource;
                        
                        if(resources != null)
                        {
                            foreach(Resource resource in resources)
                            {
                                //Get the Status of each Resource
                                Console.WriteLine("Bulk write Resource Status: " + resource.Status.Value);
                                
                                //Get the Type of each Resource
                                Console.WriteLine("Bulk write Resource Type: " + resource.Type.Value);
                                
                                //Get the Module of each Resource
                                Console.WriteLine("Bulk write Resource Module: " + resource.Module);
                                
                                List<FieldMapping> fieldMappings = resource.FieldMappings;
                                
                                if(fieldMappings != null)
                                {
                                    foreach(FieldMapping fieldMapping in fieldMappings)
                                    {
                                        //Get the APIName of each FieldMapping
                                        Console.WriteLine("Bulk write Resource FieldMapping Module: " + fieldMapping.APIName);
                                        
                                        if(fieldMapping.Index != null)
                                        {
                                            //Get the Index of each FieldMapping
                                            Console.WriteLine("Bulk write Resource FieldMapping Index: " + fieldMapping.Index);
                                        }
                                        
                                        if(fieldMapping.Format != null)
                                        {
                                            //Get the Format of each FieldMapping
                                            Console.WriteLine("Bulk write Resource FieldMapping Format: " + fieldMapping.Format);
                                        }
                                        
                                        if(fieldMapping.FindBy != null)
                                        {
                                            //Get the FindBy of each FieldMapping
                                            Console.WriteLine("Bulk write Resource FieldMapping FindBy: " + fieldMapping.FindBy);
                                        }
                                        
                                        if(fieldMapping.DefaultValue != null)
                                        {
                                            //Get all entries from the keyValues map
                                            foreach(KeyValuePair<string, object> entry in fieldMapping.DefaultValue)
                                            {
                                                //Get each value from the map
                                                Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                                            }
                                        }
                                    }
                                }
                                
                                Com.Zoho.Crm.API.BulkWrite.File file = resource.File;
                                
                                if(file != null)
                                {
                                    //Get the Status of each File
                                    Console.WriteLine("Bulk write Resource File Status: " + file.Status.Value);
                                    
                                    //Get the Name of each File
                                    Console.WriteLine("Bulk write Resource File Name: " + file.Name);
                                    
                                    //Get the AddedCount of each File
                                    Console.WriteLine("Bulk write Resource File AddedCount: " + file.AddedCount);
                                    
                                    //Get the SkippedCount of each File
                                    Console.WriteLine("Bulk write Resource File SkippedCount: " + file.SkippedCount);
                                    
                                    //Get the UpdatedCount of each File
                                    Console.WriteLine("Bulk write Resource File UpdatedCount: " + file.UpdatedCount);
                                    
                                    //Get the TotalCount of each File
                                    Console.WriteLine("Bulk write Resource File TotalCount: " + file.TotalCount);
                                }

                                Console.WriteLine("Bulk write Resource FindBy: " + resource.FindBy);
                            }
                        }
                        
                        CallBack callback = bulkWriteResponse.Callback;
					
                        if(callback != null)
                        {
                            //Get the CallBack Url
                            Console.WriteLine("Bulk write CallBack Url: " + callback.Url);
                            
                            //Get the CallBack Method
                            Console.WriteLine("Bulk write CallBack Method: " + callback.Method.Value);
                        }

                        //Get the ID of each BulkWriteResponse
                        Console.WriteLine("Bulk write ID: " + bulkWriteResponse.Id);
                        
                        Result result = bulkWriteResponse.Result;
                        
                        if(result != null)
                        {
                            //Get the DownloadUrl of the Result
                            Console.WriteLine("Bulk write DownloadUrl: " + result.DownloadUrl);
                        }

                        //Get the CreatedBy User instance of each BulkWriteResponse
                        User createdBy = bulkWriteResponse.CreatedBy;
                        
                        //Check if createdBy is not null
                        if(createdBy != null)
                        {
                            //Get the ID of the CreatedBy User
                            Console.WriteLine("Bulkread Created By User-ID: " + createdBy.Id);
                            
                            //Get the Name of the CreatedBy User
                            Console.WriteLine("Bulkread Created By user-Name: " + createdBy.Name);
                        }
                        
                        //Get the Operation of each BulkWriteResponse
                        Console.WriteLine("Bulk write Operation: " + bulkWriteResponse.Operation);
                        
                        //Get the CreatedTime of each BulkWriteResponse
                        Console.WriteLine("Bulk write File CreatedTime: " + bulkWriteResponse.CreatedTime);
                    }
                    //Check if the request returned an exception
                    else if(responseWrapper is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) responseWrapper;
                        
                        //Get the Status
                        Console.WriteLine("Status: " + exception.Status.Value);
                        
                        //Get the Code
                        Console.WriteLine("Code: " + exception.Code.Value);
                        
                        Console.WriteLine("Details: " );
                        
                        //Get the details map
                        foreach(KeyValuePair<string, object> entry in exception.Details)
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                        }
                        
                        //Get the Message
                        Console.WriteLine("Message: " + exception.Message.Value);
                    }
                }
                else
                { //If response is not as expected

                    //Get model object from response
                    Model responseObject = response.Model;

                    //Get the response object's class
                    Type type = responseObject.GetType();

                    //Get all declared fields of the response class
                    Console.WriteLine("Type is: {0}", type.Name);

                    PropertyInfo[] props = type.GetProperties();

                    Console.WriteLine("Properties (N = {0}):", props.Length);

                    foreach (var prop in props)
                    {
                        if (prop.GetIndexParameters().Length == 0)
                        {
                            Console.WriteLine("{0} ({1}) : {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(responseObject));
                        }
                        else
                        {
                            Console.WriteLine("{0} ({1}) : <Indexed>", prop.Name, prop.PropertyType.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method is used to download the result of the bulk write job as a CSV file.
        /// </summary>
        /// <param name="downloadUrl">The URL present in the download_url parameter in the response of Get Bulk Write Job Details.</param>
        /// <param name="destinationFolder">The absolute path where downloaded file has to be stored.</param>
        public static void DownloadBulkWriteResult(string downloadUrl, string destinationFolder)
        {
            //example
            //string downloadUrl = "https://download-accl.zoho.com/v2/crm/6735/bulk-write/347706122009/347706122009.zip";
            //string destinationFolder = "/Users/user_name/Documents";
            
            //Get instance of BulkWriteOperations Class
            BulkWriteOperations bulkWriteOperations = new BulkWriteOperations();
            
            //Call DownloadBulkWriteResult method that takes downloadUrl as parameter
            APIResponse<ResponseHandler> response = bulkWriteOperations.DownloadBulkWriteResult(downloadUrl);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if(new List<int>() { 204, 304 }.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode == 204? "No Content" : "Not Modified");
                    
                    return;
                }
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ResponseHandler responseHandler = response.Object;
                    
                    if(responseHandler is FileBodyWrapper)
                    {
                        //Get object from response
                        FileBodyWrapper fileBodyWrapper = (FileBodyWrapper)responseHandler;
                        
                        //Get StreamWrapper instance from the returned FileBodyWrapper instance
                        StreamWrapper streamWrapper = fileBodyWrapper.File;

                        Stream file = streamWrapper.Stream;

                        string fullFilePath = Path.Combine(destinationFolder, streamWrapper.Name);

                        using (FileStream outputFileStream = new FileStream(fullFilePath, FileMode.Create))
                        {
                            file.CopyTo(outputFileStream);
                        }
                    }
                    //Check if the request returned an exception
                    else if(responseHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) responseHandler;
                        
                        if(exception.Status != null)
                        {
                            //Get the Status
                            Console.WriteLine("Status: " + exception.Status.Value);
                        }
                        
                        if(exception.Code != null)
                        {
                            //Get the Code
                            Console.WriteLine("Code: " + exception.Code.Value);
                        }
                        
                        if(exception.Details != null)
                        {
                            Console.WriteLine("Details: " );
                            
                            //Get the details map
                            foreach(KeyValuePair<string, object> entry in exception.Details)
                            {
                                //Get each value in the map
                                Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                            }
                        }
                        
                        if(exception.Message != null)
                        {
                            //Get the Message
                            Console.WriteLine("Message: " + exception.Message.Value);
                        }
                        
                        if(exception.XError != null)
                        {
                            //Get the Message
                            Console.WriteLine("XError: " + exception.XError.Value);
                        }
                        
                        if(exception.XInfo != null)
                        {
                            //Get the Message
                            Console.WriteLine("XInfo: " + exception.XInfo.Value);
                        }
                        
                        if(exception.HttpStatus != null)
                        {
                            //Get the Message
                            Console.WriteLine("Message: " + exception.HttpStatus);
                        }
                    }
                }
                else
                { //If response is not as expected

                    //Get model object from response
                    Model responseObject = response.Model;

                    //Get the response object's class
                    Type type = responseObject.GetType();

                    //Get all declared fields of the response class
                    Console.WriteLine("Type is: {0}", type.Name);

                    PropertyInfo[] props = type.GetProperties();

                    Console.WriteLine("Properties (N = {0}):", props.Length);

                    foreach (var prop in props)
                    {
                        if (prop.GetIndexParameters().Length == 0)
                        {
                            Console.WriteLine("{0} ({1}) : {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(responseObject));
                        }
                        else
                        {
                            Console.WriteLine("{0} ({1}) : <Indexed>", prop.Name, prop.PropertyType.Name);
                        }
                    }
                }
            }
        }
    }
}

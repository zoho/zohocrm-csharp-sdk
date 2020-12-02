using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Modules;

using Com.Zoho.Crm.API.ShareRecords;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.ShareRecords.ShareRecordsOperations;

using ActionHandler = Com.Zoho.Crm.API.ShareRecords.ActionHandler;

using ActionResponse = Com.Zoho.Crm.API.ShareRecords.ActionResponse;

using ActionWrapper = Com.Zoho.Crm.API.ShareRecords.ActionWrapper;

using APIException = Com.Zoho.Crm.API.ShareRecords.APIException;

using BodyWrapper = Com.Zoho.Crm.API.ShareRecords.BodyWrapper;

using Module = Com.Zoho.Crm.API.Modules.Module;

using ResponseHandler = Com.Zoho.Crm.API.ShareRecords.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.ShareRecords.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.ShareRecords.SuccessResponse;

namespace Com.Zoho.Crm.Sample.ShareRecords
{
    public class ShareRecords
    {
        /// <summary>
        /// This method is used to get the details of a shared record and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get shared record details.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        public static void GetSharedRecordDetails(string moduleAPIName, long recordId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId = 34770615177002;

            //Get instance of ShareRecordsOperations Class that takes recordId and moduleAPIName as parameter
            ShareRecordsOperations shareRecordsOperations = new ShareRecordsOperations(recordId, moduleAPIName);
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetSharedRecordDetailsParam.VIEW, "summary");

            //paramInstance.Add(GetSharedRecordDetailsParam.SHAREDTO, 34770615791024);

            //Call GetSharedRecordDetails method that takes paramInstance as parameter
            APIResponse<ResponseHandler> response = shareRecordsOperations.GetSharedRecordDetails(paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if(new List<int>(){204,304}.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode == 204? "No Content" : "Not Modified");

                    return;
                }
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ResponseHandler responseHandler = response.Object;
                    
                    if(responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the obtained ShareRecord instance
                        List<ShareRecord> shareRecords = responseWrapper.Share;
                        
                        foreach(ShareRecord shareRecord in shareRecords)
                        {					
                            //Get the ShareRelatedRecords of each ShareRecord
                            Console.WriteLine("ShareRecord ShareRelatedRecords: " + shareRecord.ShareRelatedRecords);
                            
                            //Get the SharedThrough instance of each ShareRecord
                            SharedThrough sharedThrough = shareRecord.SharedThrough;
                            
                            //Check if sharedThrough is not null
                            if(sharedThrough != null)
                            {
                                //Get the EntityName of the SharedThrough
							    Console.WriteLine("ShareRecord SharedThrough EntityName: " + sharedThrough.EntityName);

                                //Get the Module instance of each ShareRecord
                                Module module = sharedThrough.Module;
                                
                                if(module != null)
                                {
                                    //Get the ID of the Module
                                    Console.WriteLine("ShareRecord SharedThrough Module ID: " + module.Id);
                                    
                                    //Get the name of the Module
                                    Console.WriteLine("ShareRecord SharedThrough Module Name: " + module.Name);
                                }
                                
                                //Get the ID of the SharedThrough
                                Console.WriteLine("ShareRecord SharedThrough ID: " + sharedThrough.Id);
                            }
                            
                            //Get the Permission of each ShareRecord
                            Console.WriteLine("ShareRecord Permission: " + shareRecord.Permission);
                            
                            //Get the shared User instance of each ShareRecord
                            User user = shareRecord.User;
                            
                            //Check if user is not null
                            if(user != null)
                            {
                                //Get the ID of the shared User
                                Console.WriteLine("ShareRecord User-ID: " + user.Id);
                                
                                //Get the FullName of the shared User
                                Console.WriteLine("ShareRecord User-FullName: " + user.FullName);
                                
                                //Get the Zuid of the shared User
                                Console.WriteLine("ShareRecord User-Zuid: " + user.Zuid);
                            }
                        }
                        
                        if(responseWrapper.ShareableUser != null)
                        {
                            List<User> shareableUsers = responseWrapper.ShareableUser;
                            
                            foreach(User shareableUser in shareableUsers)
                            {
                                //Get the ID of the shareable User
                                Console.WriteLine("ShareRecord User-ID: " + shareableUser.Id);
                                
                                //Get the FullName of the shareable User
                                Console.WriteLine("ShareRecord User-FullName: " + shareableUser.FullName);
                                
                                //Get the Zuid of the shareable User
                                Console.WriteLine("ShareRecord User-Zuid: " + shareableUser.Zuid);
                            }
                        }
                    }
                    //Check if the request returned an exception
                    else if(responseHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) responseHandler;
                        
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
        /// This method is used to share the record and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to shared record.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        public static void ShareRecord(string moduleAPIName, long recordId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId = 34770615177002;

            //Get instance of ShareRecordsOperations Class that takes recordId and moduleAPIName as parameter
            ShareRecordsOperations shareRecordsOperations = new ShareRecordsOperations(recordId, moduleAPIName);

            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of ShareRecord instances
            List<ShareRecord> shareList = new List<ShareRecord>();
            
            //Get instance of ShareRecord Class
            ShareRecord share1 = new ShareRecord();
            
            for(int i = 0; i < 9; i++)
            {
                //Get instance of ShareRecord Class
                share1 = new ShareRecord();
                
                //Set the record is shared with or without related records.
                share1.ShareRelatedRecords = true;
                
                //Set the access permission given to the user for that record.
                share1.Permission = "read_write";
                
                User user1 = new User();
                
                user1.Id = 34770615791024;
                
                //Set the users details with whom the record is shared.
                share1.User = user1;
                
                shareList.Add(share1);
            }
            
            share1 = new ShareRecord();
            
            share1.ShareRelatedRecords = true;
            
            share1.Permission = "read_write";
            
            User user = new User();
            
            user.Id = 34770615791024;
            
            share1.User = user;
            
            shareList.Add(share1);
            
            request.Share = shareList;
            
            //Call ShareRecord method that takes BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = shareRecordsOperations.ShareRecord(request);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ActionHandler actionHandler = response.Object;
                    
                    if(actionHandler is ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        ActionWrapper actionWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = actionWrapper.Share;
                        
                        foreach(ActionResponse actionResponse in actionResponses)
                        {
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                                
                                //Get the Message
                                Console.WriteLine("Message: " + exception.Message.Value);
                            }
                        }
                    }
                    //Check if the request returned an exception
                    else if(actionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) actionHandler;
                        
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
        /// This method is used to update the sharing permissions of a record granted to users as Read-Write, Read-only, or grant full access.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to update share permissions.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        public static void UpdateSharePermissions(string moduleAPIName, long recordId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId = 34770615177002;

            //Get instance of ShareRecordsOperations Class that takes recordId and moduleAPIName as parameter
            ShareRecordsOperations shareRecordsOperations = new ShareRecordsOperations(recordId, moduleAPIName);

            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of ShareRecord instances
            List<ShareRecord> shareList = new List<ShareRecord>();
            
            //Get instance of ShareRecord Class
            ShareRecord share1 = new ShareRecord();
            
            share1.ShareRelatedRecords = true;
            
            share1.Permission = "full_access";
            
            User user = new User();
            
            user.Id = 34770615791024;
            
            share1.User = user;
            
            shareList.Add(share1);
            
            request.Share = shareList;
            
            //Call UpdateSharePermissions method that takes BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = shareRecordsOperations.UpdateSharePermissions(request);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ActionHandler actionHandler = response.Object;
                    
                    if(actionHandler is ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        ActionWrapper actionWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = actionWrapper.Share;
                        
                        foreach(ActionResponse actionResponse in actionResponses)
                        {
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                                
                                //Get the Message
                                Console.WriteLine("Message: " + exception.Message.Value);
                            }
                        }
                    }
                    //Check if the request returned an exception
                    else if(actionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) actionHandler;
                        
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
        /// This method is used to revoke access to a shared record that was shared to users and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to revoke shared record.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        public static void RevokeSharedRecord(string moduleAPIName, long recordId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId = 34770615177002;

            //Get instance of ShareRecordsOperations Class that takes recordId and moduleAPIName as parameter
            ShareRecordsOperations shareRecordsOperations = new ShareRecordsOperations(recordId, moduleAPIName);

            //Call RevokeSharedRecord method
            APIResponse<DeleteActionHandler> response = shareRecordsOperations.RevokeSharedRecord();
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    DeleteActionHandler deleteActionHandler = response.Object;
                    
                    if(deleteActionHandler is DeleteActionWrapper)
                    {
                        //Get the received DeleteActionWrapper instance
                        DeleteActionWrapper deleteActionWrapper = (DeleteActionWrapper) deleteActionHandler;
                        
                        //Get the received DeleteActionResponse instance
                        DeleteActionResponse deleteActionResponse = deleteActionWrapper.Share;
                        
                        //Check if the request is successful
                        if(deleteActionResponse is SuccessResponse)
                        {
                            //Get the received SuccessResponse instance
                            SuccessResponse successResponse = (SuccessResponse)deleteActionResponse;
                            
                            //Get the Status
                            Console.WriteLine("Status: " + successResponse.Status.Value);
                            
                            //Get the Code
                            Console.WriteLine("Code: " + successResponse.Code.Value);
                            
                            Console.WriteLine("Details: " );
                            
                            //Get the details map
                            foreach(KeyValuePair<string, object> entry in successResponse.Details)
                            {
                                //Get each value in the map
                                Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                            }
                            
                            //Get the Message
                            Console.WriteLine("Message: " + successResponse.Message.Value);
                        }
                        //Check if the request returned an exception
                        else if(deleteActionResponse is APIException)
                        {
                            //Get the received APIException instance
                            APIException exception = (APIException) deleteActionResponse;
                            
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
                    //Check if the request returned an exception
                    else if(deleteActionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) deleteActionHandler;
                        
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
    }
}

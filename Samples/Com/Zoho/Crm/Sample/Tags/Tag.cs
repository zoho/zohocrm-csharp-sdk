using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Tags;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Tags.TagsOperations;

using ActionHandler = Com.Zoho.Crm.API.Tags.ActionHandler;

using ActionResponse = Com.Zoho.Crm.API.Tags.ActionResponse;

using ActionWrapper = Com.Zoho.Crm.API.Tags.ActionWrapper;

using APIException =  Com.Zoho.Crm.API.Tags.APIException;

using BodyWrapper = Com.Zoho.Crm.API.Tags.BodyWrapper;

using Info =  Com.Zoho.Crm.API.Tags.Info;

using ResponseHandler =  Com.Zoho.Crm.API.Tags.ResponseHandler;

using ResponseWrapper =  Com.Zoho.Crm.API.Tags.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.Tags.SuccessResponse;

namespace Com.Zoho.Crm.Sample.Tags
{
    public class Tag
    {
        /// <summary>
        /// This method is used to get all the tags in a module.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get tags.</param>
        public static void GetTags(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetTagsParam.MODULE, moduleAPIName);

            //paramInstance.Add(GetTagsParam.MY_TAGS, ""); //Displays the names of the tags created by the current user.

            //Call getTags method that takes paramInstance as parameter
            APIResponse<ResponseHandler> response = tagsOperations.GetTags(paramInstance);
            
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
                    
                    if(responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the obtained ShareRecord instance
                        List<Com.Zoho.Crm.API.Tags.Tag> tags = responseWrapper.Tags;
                        
                        foreach(Com.Zoho.Crm.API.Tags.Tag tag in tags)
                        {	
                            //Get the CreatedTime of each Tag
                            Console.WriteLine("Tag CreatedTime: " + tag.CreatedTime);
                            
                            //Get the ModifiedTime of each Tag
                            Console.WriteLine("Tag ModifiedTime: " + tag.ModifiedTime);
                            
                            //Get the Name of each Tag
                            Console.WriteLine("Tag Name: " + tag.Name);
                            
                            //Get the modifiedBy User instance of each Tag
                             User modifiedBy = tag.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Tag Modified By User-ID: " + modifiedBy.Id);
                                
                                //Get the name of the modifiedBy User
                                Console.WriteLine("Tag Modified By User-Name: " + modifiedBy.Name);
                            }
                            
                            //Get the ID of each Tag
                            Console.WriteLine("Tag ID: " + tag.Id);
                            
                            //Get the createdBy User instance of each Tag
                             User createdBy = tag.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the ID of the createdBy User
                                Console.WriteLine("Tag Created By User-ID: " + createdBy.Id);
                                
                                //Get the name of the createdBy User
                                Console.WriteLine("Tag Created By User-Name: " + createdBy.Name);
                            }
                        }
                        
                        //Get the Object obtained Info instance
                        Info info = responseWrapper.Info;
                        
                        //Check if info is not null
                        if(info != null)
                        {
                            if(info.Count != null)
                            {
                                //Get the Count of the Info
                                Console.WriteLine("Tag Info Count: " + info.Count);
                            }
                            
                            if(info.AllowedCount != null)
                            {
                                //Get the AllowedCount of the Info
                                Console.WriteLine("Tag Info AllowedCount: " + info.AllowedCount);
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
        /// This method is used to create new tags and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to create tags.</param>
        public static void CreateTags(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(CreateTagsParam.MODULE, moduleAPIName);
            
            //List of Tag instances
            List<Com.Zoho.Crm.API.Tags.Tag> tagList = new List<Com.Zoho.Crm.API.Tags.Tag>();
            
            //Get instance of Tag Class
            Com.Zoho.Crm.API.Tags.Tag tag1 = new Com.Zoho.Crm.API.Tags.Tag();

            tag1.Name = "tagName001";

            tagList.Add(tag1);
            
            request.Tags = tagList;
            
            //Call createTags method that takes BodyWrapper instance and paramInstance as parameter
            APIResponse<ActionHandler> response = tagsOperations.CreateTags(request, paramInstance);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Tags;
                        
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
        /// This method is used to update multiple tags simultaneously and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to update tags.</param>
        public static void UpdateTags(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(UpdateTagsParam.MODULE, moduleAPIName);
            
            //List of Tag instances
            List<API.Tags.Tag> tagList = new List<API.Tags.Tag>();
            
            //Get instance of Tag Class
            API.Tags.Tag tag1 = new API.Tags.Tag();

            tag1.Id = 34770616052001;

            tag1.Name = "tagName123";

            tagList.Add(tag1);
            
            request.Tags = tagList;
            
            //Call updateTags method that takes BodyWrapper instance and paramInstance as parameter
            APIResponse<ActionHandler> response = tagsOperations.UpdateTags(request, paramInstance);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Tags;
                        
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
        /// This method is used to update single tag and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to update tag.</param>
        /// <param name="tagId">The ID of the tag to be obtained.</param>
        public static void UpdateTag(string moduleAPIName, long tagId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long tagId = 34770615794039;
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(UpdateTagParam.MODULE, moduleAPIName);
            
            //List of Tag instances
            List<Com.Zoho.Crm.API.Tags.Tag> tagList = new List<Com.Zoho.Crm.API.Tags.Tag>();
            
            //Get instance of Tag Class
            Com.Zoho.Crm.API.Tags.Tag tag1 = new Com.Zoho.Crm.API.Tags.Tag();

            tag1.Name = "tagName12345";

            tagList.Add(tag1);
            
            request.Tags = tagList;

            //Call UpdateTag method that takes tagId, paramInstance and BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = tagsOperations.UpdateTag(tagId, request, paramInstance);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Tags;
                        
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
        /// This method is used to delete a tag from the module and print the response.
        /// </summary>
        /// <param name="tagId">The ID of the tag to be obtained.</param>
        public static void DeleteTag(long tagId)
        {
            //example
            //long tagId = 34770615794039;
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Call DeleteTag method that takes tag id as parameter
            APIResponse<ActionHandler> response = tagsOperations.DeleteTag(tagId);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Tags;
                        
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
        /// This method is used to merge tags and put all the records under the two tags into a single tag and print the response.
        /// </summary>
        /// <param name="tagId">The ID of the tag to be obtained.</param>
        /// <param name="conflictId">The ID of the conflict tag to be obtained.</param>
        public static void MergeTags(long tagId, string conflictId)
        {
            //example
            //long tagId = 34770615794039;
            //string conflictId = "34770615803151";
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of MergeWrapper Class that will contain the request body
            MergeWrapper request = new MergeWrapper();
            
            //List of Tag ConflictWrapper
            List<ConflictWrapper> tags = new List<ConflictWrapper>();
            
            //Get instance of ConflictWrapper Class
            ConflictWrapper mergeTag = new ConflictWrapper();
            
            mergeTag.ConflictId = conflictId;
            
            tags.Add(mergeTag);
            
            request.Tags = tags;

            //Call mergeTags method that takes tagId and MergeWrapper instance as parameter
            APIResponse<ActionHandler> response = tagsOperations.MergeTags(tagId, request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Tags;
                        
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
        /// This method is used to add tags to a specific record and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to add tag.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        /// <param name="tagNames">The names of the tags to be added.</param>
        public static void AddTagsToRecord(string moduleAPIName, long recordId, List<string> tagNames)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId =  34770615623115;
            //List<string> tagNames = new List<string>(){"addtag1,addtag12"};
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(string tagName in tagNames)
            {
                paramInstance.Add(AddTagsToRecordParam.TAG_NAMES, tagName);
            }
            
            paramInstance.Add(AddTagsToRecordParam.OVER_WRITE, "false");

            //Call AddTagsToRecord method that takes recordId, moduleAPIName and paramInstance as parameter
            APIResponse<RecordActionHandler> response = tagsOperations.AddTagsToRecord(recordId, moduleAPIName, paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    RecordActionHandler recordActionHandler = response.Object;
                    
                    if(recordActionHandler is RecordActionWrapper)
                    {
                        //Get the received RecordActionWrapper instance
                        RecordActionWrapper recordActionWrapper = (RecordActionWrapper) recordActionHandler;
                        
                        //Get the list of obtained RecordActionResponse instances
                        List<RecordActionResponse> actionResponses = recordActionWrapper.Data;
                        
                        foreach(RecordActionResponse actionResponse in actionResponses)
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
                    else if(recordActionHandler is APIException)
                    {
                        //Check if the request returned an exception
                        APIException exception = (APIException) recordActionHandler;
                        
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
        /// This method is used to delete the tag associated with a specific record and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to remove tag.</param>
        /// <param name="recordId">The ID of the record to be obtained.</param>
        /// <param name="tagNames">The names of the tags to be remove.</param>
        public static void RemoveTagsFromRecord(string moduleAPIName, long recordId, List<string> tagNames)
        {
            //example
            //string moduleAPIName = "Leads";
            //long recordId =  34770615623115;
            //List<string> tagNames = new List<string>(new List<int>()("addtag1,addtag12"));
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(string tagName in tagNames)
            {
                paramInstance.Add(RemoveTagsFromRecordParam.TAG_NAMES, tagName);
            }

            //Call removeTagsFromRecord method that takes recordId, moduleAPIName and paramInstance as parameter
            APIResponse<RecordActionHandler> response = tagsOperations.RemoveTagsFromRecord(recordId, moduleAPIName, paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    RecordActionHandler recordActionHandler = response.Object;
                    
                    if(recordActionHandler is RecordActionWrapper)
                    {
                        //Get the received RecordActionWrapper instance
                        RecordActionWrapper recordActionWrapper = (RecordActionWrapper) recordActionHandler;
                        
                        //Get the list of obtained RecordActionResponse instances
                        List<RecordActionResponse> actionResponses = recordActionWrapper.Data;
                        
                        foreach(RecordActionResponse actionResponse in actionResponses)
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
                    else if(recordActionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) recordActionHandler;
                        
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
        /// This method is used to add tags to multiple records simultaneously and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to add tags.</param>
        /// <param name="recordIds">The ID of the record to be obtained.</param>
        /// <param name="tagNames">The names of the tags to be add.</param>
        public static void AddTagsToMultipleRecords(string moduleAPIName, List<long> recordIds, List<string> tagNames)
        {
            //example
            //string moduleAPIName = "Leads";
            //List<long> recordIds = new List<long>(){34770615623115, 34770616114067};
            //List<string> tagNames = new List<string>(){"addtag1,addtag12"};
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(string tagName in tagNames)
            {
                paramInstance.Add(AddTagsToMultipleRecordsParam.TAG_NAMES, tagName);
            }
            
            foreach(long recordId in recordIds)
            {
                paramInstance.Add(AddTagsToMultipleRecordsParam.IDS, recordId);
            }
            
            paramInstance.Add(AddTagsToMultipleRecordsParam.OVER_WRITE, "false");

            //Call AddTagsToMultipleRecords method that takes moduleAPIName, paramInstance as parameter
            APIResponse<RecordActionHandler> response = tagsOperations.AddTagsToMultipleRecords(moduleAPIName, paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    RecordActionHandler recordActionHandler = response.Object;
                    
                    if(recordActionHandler is RecordActionWrapper)
                    {
                        //Get the received RecordActionWrapper instance
                        RecordActionWrapper recordActionWrapper = (RecordActionWrapper) recordActionHandler;
                        
                        //Get the list of obtained RecordActionResponse instances
                        List<RecordActionResponse> actionResponses = recordActionWrapper.Data;
                        
                        foreach(RecordActionResponse actionResponse in actionResponses)
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
                        
                        //Check if locked count is null
                        if(recordActionWrapper.LockedCount != null)
                        {
                            Console.WriteLine("Locked Count: " + recordActionWrapper.LockedCount);
                        }
                        
                        //Check if success count is null
                        if(recordActionWrapper.SuccessCount != null)
                        {
                            Console.WriteLine("Success Count: " + recordActionWrapper.SuccessCount);
                        }
                        
                        //Check if wf scheduler is null
                        if(recordActionWrapper.WfScheduler != null)
                        {
                            Console.WriteLine("WF Scheduler: " + recordActionWrapper.WfScheduler);
                        }
                    }
                    //Check if the request returned an exception
                    else if(recordActionHandler is APIException)
                    {
                        //Check if the request returned an exception
                        APIException exception = (APIException) recordActionHandler;
                        
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
        /// This method is used to delete the tags associated with multiple records and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to remove tags.</param>
        /// <param name="recordIds">The ID of the record to be obtained.</param>
        /// <param name="tagNames">The names of the tags to be remove.</param>
        public static void RemoveTagsFromMultipleRecords(string moduleAPIName, List<long> recordIds, List<string> tagNames)
        {
            //example
            //string moduleAPIName = "Leads";
            //List<long> recordIds = new List<long>(){34770615623115, 34770616114067};
            //List<string> tagNames = new List<string>(){"addtag1,addtag12"};
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(string tagName in tagNames)
            {
                paramInstance.Add(RemoveTagsFromMultipleRecordsParam.TAG_NAMES, tagName);
            }
            
            foreach(long recordId in recordIds)
            {
                paramInstance.Add(RemoveTagsFromMultipleRecordsParam.IDS, recordId);
            }

            //Call RemoveTagsFromMultipleRecords method that takes moduleAPIName, paramInstance as parameter
            APIResponse<RecordActionHandler> response = tagsOperations.RemoveTagsFromMultipleRecords(moduleAPIName, paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    RecordActionHandler recordActionHandler = response.Object;
                    
                    if(recordActionHandler is RecordActionWrapper)
                    {
                        //Get the received RecordActionWrapper instance
                        RecordActionWrapper recordActionWrapper = (RecordActionWrapper) recordActionHandler;
                        
                        //Get the list of obtained RecordActionResponse instances
                        List<RecordActionResponse> actionResponses = recordActionWrapper.Data;
                        
                        foreach(RecordActionResponse actionResponse in actionResponses)
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
                        
                        //Check if locked count is null
                        if(recordActionWrapper.LockedCount != null)
                        {
                            Console.WriteLine("Locked Count: " + recordActionWrapper.LockedCount);
                        }
                        
                        //Check if success count is null
                        if(recordActionWrapper.SuccessCount != null)
                        {
                            Console.WriteLine("Success Count: " + recordActionWrapper.SuccessCount);
                        }
                        
                        //Check if wf scheduler is null
                        if(recordActionWrapper.WfScheduler != null)
                        {
                            Console.WriteLine("WF Scheduler: " + recordActionWrapper.WfScheduler);
                        }
                    }
                    //Check if the request returned an exception
                    else if(recordActionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) recordActionHandler;
                        
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
        /// This method is used to get the total number of records under a tag and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module.</param>
        /// <param name="tagId">The ID of the tag to be obtained.</param>
        public static void GetRecordCountForTag(string moduleAPIName, long tagId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long tagId = 34770615803151;
            
            //Get instance of TagsOperations Class
            TagsOperations tagsOperations = new TagsOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetRecordCountForTagParam.MODULE, moduleAPIName);

            //Call GetRecordCountForTag method that that takes tagId and paramInstance as parameter
            APIResponse<CountHandler> response = tagsOperations.GetRecordCountForTag(tagId, paramInstance);
            
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
                    CountHandler countHandler = response.Object;
                    
                    if(countHandler is CountWrapper)
                    {
                        //Get the received CountWrapper instance
                        CountWrapper countWrapper = (CountWrapper) countHandler;
                        
                        //Get the Count of Tag
                        Console.WriteLine("Tag Count: " + countWrapper.Count);
                    }
                    //Check if the request returned an exception
                    else if(countHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) countHandler;
                        
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

using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Util;

using Com.Zoho.Crm.API.Variables;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Variables.VariablesOperations;

namespace Com.Zoho.Crm.Sample.Variables
{
    public class Variable
    {
        /// <summary>
        /// This method is used to retrieve all the available variables through an API request and print the response.
        /// </summary>
        public static void GetVariables()
        {
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetVariablesParam.GROUP, "General");
            
            //Call GetVariables method that takes paramInstance as parameter 
            APIResponse<ResponseHandler> response = variablesOperations.GetVariables(paramInstance);
            
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
                        
                        //Get the obtained Variable instance
                        List<Com.Zoho.Crm.API.Variables.Variable> variables = responseWrapper.Variables;
                        
                        foreach(Com.Zoho.Crm.API.Variables.Variable variable in variables)
                        {	
                            //Get the APIName of each Variable
                            Console.WriteLine("Variable APIName: " + variable.APIName);
                            
                            //Get the Name of each Variable
                            Console.WriteLine("Variable Name: " + variable.Name);
                            
                            //Get the Description of each Variable
                            Console.WriteLine("Variable Description: " + variable.Description);
                            
                            //Get the ID of each Variable
                            Console.WriteLine("Variable ID: " + variable.Id);
                            
                            //Get the Type of each Variable
                            Console.WriteLine("Variable Type: " + variable.Type);
                            
                            // Get the VariableGroup instance of each Variable
                            API.VariableGroups.VariableGroup variableGroup = variable.VariableGroup;
                            
                            //Check if variableGroup is not null
                            if(variableGroup != null)
                            {
                                //Get the Name of each VariableGroup
                                Console.WriteLine("Variable VariableGroup APIName: " + variableGroup.APIName);
                                
                                //Get the ID of each VariableGroup
                                Console.WriteLine("Variable VariableGroup ID: " + variableGroup.Id);
                            }
                            
                            
                            //Get the Value of each Variable
                            Console.WriteLine("Variable Value: " + variable.Value);
                            
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
        /// This method is used to create a new variable in CRM and print the response.
        /// </summary>
        public static void CreateVariables()
        {
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Variable instances
            List<Com.Zoho.Crm.API.Variables.Variable> variableList = new List<Com.Zoho.Crm.API.Variables.Variable>();
            
            //Get instance of Variable Class
            Com.Zoho.Crm.API.Variables.Variable variable1 = new Com.Zoho.Crm.API.Variables.Variable();

            variable1.Name = "Variable5521";

            variable1.APIName = "Variable5521";
            
            API.VariableGroups.VariableGroup variableGroup = new API.VariableGroups.VariableGroup();
            
            variableGroup.Id = 34770613089001;

            variable1.VariableGroup = variableGroup;

            variable1.Type = "integer";

            variable1.Value = "55";
            
            variable1.Description = "This denotes variable 5 description";
            
            variableList.Add(variable1);
            
            variable1 = new Com.Zoho.Crm.API.Variables.Variable();
            
            variable1.Name = "Variable6621";
            
            variable1.APIName = "Variable6621";

            variableGroup = new API.VariableGroups.VariableGroup();
            
            variableGroup.Name = "General";
            
            variable1.VariableGroup = variableGroup;
            
            variable1.Type = "text";
            
            variable1.Value = "Hello";
            
            variable1.Description = "This denotes variable 6 description";
            
            variableList.Add(variable1);
            
            request.Variables = variableList;
            
            //Call CreateVariables method that takes BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = variablesOperations.CreateVariables(request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
        /// This method is used to update details of variables in CRM and print the response.
        /// </summary>
        public static void UpdateVariables()
        {
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Variable instances
            List<Com.Zoho.Crm.API.Variables.Variable> variableList = new List<Com.Zoho.Crm.API.Variables.Variable>();
            
            //Get instance of Variable Class
            Com.Zoho.Crm.API.Variables.Variable variable1 = new Com.Zoho.Crm.API.Variables.Variable();

            variable1.Id = 34770617444014;

            variable1.Value = "4763";
            
            variableList.Add(variable1);
            
            variable1 = new Com.Zoho.Crm.API.Variables.Variable();
            
            variable1.Id = 34770617444014;
            
            variable1.Description = "This is a new description";
            
            variableList.Add(variable1);
            
            variable1 = new Com.Zoho.Crm.API.Variables.Variable();
            
            variable1.Id = 34770617445001;
            
            variable1.APIName = "NewAPI12";
            
            variableList.Add(variable1);
            
            request.Variables = variableList;
            
            //Call UpdateVariables method that takes BodyWrapper class instance as parameter
            APIResponse<ActionHandler> response = variablesOperations.UpdateVariables(request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
        /// This method is used to delete details of multiple variables in CRM simultaneously and print the response.
        /// </summary>
        /// <param name="variableIds">The List of the Variable IDs to be deleted</param>
        public static void DeleteVariables(List<long> variableIds)
        {
            //example
            //List<long> variableIds = new List<long>(){34770616211003,34770616211001};
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(long variableId in variableIds)
            {
                paramInstance.Add(DeleteVariablesParam.IDS, variableId);
            }

            //Call deleteVariables method that takes paramInstance as parameter
            APIResponse<ActionHandler> response = variablesOperations.DeleteVariables(paramInstance);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
        /// This method is used to get the details of any specific variable.
        /// Specify the unique ID of the variable in your API request to get the data for that particular variable group.
        /// </summary>
        /// <param name="variableId">The ID of the Variable to be obtained</param>
        public static void GetVariableById(long variableId)
        {
            //example
            //long variableId = 34770613320163l;
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetVariableByIDParam.GROUP, "34770613089001");//"General"

            //Call GetVariableById method that takes variableId and paramInstance as parameter
            APIResponse<ResponseHandler> response = variablesOperations.GetVariableById(variableId, paramInstance);
            
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
                        //Get the received ActionWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the obtained Variable instance
                        List<Com.Zoho.Crm.API.Variables.Variable> variables = responseWrapper.Variables;
                        
                        foreach(Com.Zoho.Crm.API.Variables.Variable variable in variables)
                        {	
                            //Get the APIName of each Variable
                            Console.WriteLine("Variable APIName: " + variable.APIName);
                            
                            //Get the Name of each Variable
                            Console.WriteLine("Variable Name: " + variable.Name);
                            
                            //Get the Description of each Variable
                            Console.WriteLine("Variable Description: " + variable.Description);
                            
                            //Get the ID of each Variable
                            Console.WriteLine("Variable ID: " + variable.Id);
                            
                            //Get the Type of each Variable
                            Console.WriteLine("Variable Type: " + variable.Type);
                            
                            // Get the VariableGroup instance of each Variable
                            API.VariableGroups.VariableGroup variableGroup = variable.VariableGroup;
                            
                            //Check if variableGroup is not null
                            if(variableGroup != null)
                            {
                                //Get the Name of each VariableGroup
                                Console.WriteLine("Variable VariableGroup APIName: " + variableGroup.APIName);
                                
                                //Get the ID of each VariableGroup
                                Console.WriteLine("Variable VariableGroup ID: " + variableGroup.Id);
                            }
                            
                            
                            //Get the Value of each Variable
                            Console.WriteLine("Variable Value: " + variable.Value);
                            
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
        /// This method is used to update details of a specific variable in CRM and print the response.
        /// </summary>
        /// <param name="variableId">The ID of the Variable to be updated</param>
        public static void UpdateVariableById(long variableId)
        {
            //example
            //long variableId = 34770613320163;
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Variable instances
            List<Com.Zoho.Crm.API.Variables.Variable> variableList = new List<Com.Zoho.Crm.API.Variables.Variable>();
            
            //Get instance of Variable Class
            Com.Zoho.Crm.API.Variables.Variable variable1 = new Com.Zoho.Crm.API.Variables.Variable();

            variable1.APIName = "TestAPIName";

            variableList.Add(variable1);
            
            request.Variables = variableList;

            //Call UpdateVariableById method that takes variableId and BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = variablesOperations.UpdateVariableById(variableId, request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
        /// This method is used to delete details of a specific variable in CRM and print the response.
        /// </summary>
        /// <param name="variableId">The ID of the Variable to be deleted</param>
        public static void DeleteVariable(long variableId)
        {
            //example
            //long variableId = 34770613320163;
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Call DeleteVariable method that takes variableId as parameter
            APIResponse<ActionHandler> response = variablesOperations.DeleteVariable(variableId);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
        /// This method is used to get the details of any specific variable.
        /// Specify the unique name of the variable in your API request to get the data for that particular variable group.
        /// </summary>
        /// <param name="variableName">The name of the Variable to be obtained</param>
        public static void GetVariableForAPIName(string variableName)
        {
            //example
            //string variableName = "Variable55";
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetVariableForAPINameParam.GROUP, "General");

            //Call GetVariableForAPIName method that takes variableName and paramInstance as parameter
            APIResponse<ResponseHandler> response = variablesOperations.GetVariableForAPIName(variableName, paramInstance);
            
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
                        //Get the received ActionWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the obtained Variable instance
                        List<Com.Zoho.Crm.API.Variables.Variable> variables = responseWrapper.Variables;
                        
                        foreach(Com.Zoho.Crm.API.Variables.Variable variable in variables)
                        {	
                            //Get the APIName of each Variable
                            Console.WriteLine("Variable APIName: " + variable.APIName);
                            
                            //Get the Name of each Variable
                            Console.WriteLine("Variable Name: " + variable.Name);
                            
                            //Get the Description of each Variable
                            Console.WriteLine("Variable Description: " + variable.Description);
                            
                            //Get the ID of each Variable
                            Console.WriteLine("Variable ID: " + variable.Id);
                            
                            //Get the Type of each Variable
                            Console.WriteLine("Variable Type: " + variable.Type);
                            
                            // Get the VariableGroup instance of each Variable
                            API.VariableGroups.VariableGroup variableGroup = variable.VariableGroup;
                            
                            //Check if variableGroup is not null
                            if(variableGroup != null)
                            {
                                //Get the Name of each VariableGroup
                                Console.WriteLine("Variable VariableGroup APIName: " + variableGroup.APIName);
                                
                                //Get the ID of each VariableGroup
                                Console.WriteLine("Variable VariableGroup ID: " + variableGroup.Id);
                            }
                            
                            
                            //Get the Value of each Variable
                            Console.WriteLine("Variable Value: " + variable.Value);
                            
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
        /// This method is used to update details of a specific variable in CRM and print the response.
        /// </summary>
        /// <param name="variableName">The name of the Variable to be updated</param>
        public static void UpdateVariableByAPIName(string variableName)
        {
            //example
            //string variableName = "Variable55";
            
            //Get instance of VariablesOperations Class
            VariablesOperations variablesOperations = new VariablesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Variable instances
            List<Com.Zoho.Crm.API.Variables.Variable> variableList = new List<Com.Zoho.Crm.API.Variables.Variable>();
            
            //Get instance of Variable Class
            Com.Zoho.Crm.API.Variables.Variable variable1 = new Com.Zoho.Crm.API.Variables.Variable();

            variable1.Description = "Test update Variable By APIName";

            variableList.Add(variable1);
            
            request.Variables = variableList;

            //Call UpdateVariableByAPIName method that takes variableName and BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = variablesOperations.UpdateVariableByAPIName(variableName, request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Variables;
                        
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
    }
}

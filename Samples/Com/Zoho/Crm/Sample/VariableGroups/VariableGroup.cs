using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Zoho.Crm.API.Util;
using Com.Zoho.Crm.API.VariableGroups;
using Newtonsoft.Json;

namespace Com.Zoho.Crm.Sample.VariableGroups
{
    public class VariableGroup
    {
        /// <summary>
        /// This method is used to get the details of all the variable groups and print the response.
        /// </summary>
        public static void GetVariableGroups()
        {
            //Get instance of VariableGroupsOperations Class
            VariableGroupsOperations variableGroupsOperations = new VariableGroupsOperations();
            
            //Call GetVariableGroups method 
            APIResponse<ResponseHandler> response = variableGroupsOperations.GetVariableGroups();
            
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
                        
                        //Get the obtained VariableGroup instance
                        List<Com.Zoho.Crm.API.VariableGroups.VariableGroup> variableGroups = responseWrapper.VariableGroups;
                        
                        foreach(Com.Zoho.Crm.API.VariableGroups.VariableGroup variableGroup in variableGroups)
                        {	
                            //Get the DisplayLabel of each VariableGroup
                            Console.WriteLine("VariableGroup DisplayLabel: " + variableGroup.DisplayLabel);
                            
                            //Get the APIName of each VariableGroup
                            Console.WriteLine("VariableGroup APIName: " + variableGroup.APIName);
        
                            //Get the Name of each VariableGroup
                            Console.WriteLine("VariableGroup Name: " + variableGroup.Name);
                            
                            //Get the Description of each VariableGroup
                            Console.WriteLine("VariableGroup Description: " + variableGroup.Description);
                            
                            //Get the ID of each VariableGroup
                            Console.WriteLine("VariableGroup ID: " + variableGroup.Id);
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
        /// This method is used to get the details of any variable group with group id and print the response.
        /// </summary>
        /// <param name="variableGroupId">The ID of the VariableGroup to be obtained</param>
        public static void GetVariableGroupById(long variableGroupId)
        {
            //example
            //long variableGroupId = 34770613089001;
            
            //Get instance of VariableGroupsOperations Class
            VariableGroupsOperations variableGroupsOperations = new VariableGroupsOperations();
            
            //Call getVariableGroupById method that takes variableGroupId as parameter 
            APIResponse<ResponseHandler> response = variableGroupsOperations.GetVariableGroupById(variableGroupId);
            
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
                        
                        //Get the obtained VariableGroup instance
                        List<Com.Zoho.Crm.API.VariableGroups.VariableGroup> variableGroups = responseWrapper.VariableGroups;
                        
                        foreach(Com.Zoho.Crm.API.VariableGroups.VariableGroup variableGroup in variableGroups)
                        {	
                            //Get the DisplayLabel of each VariableGroup
                            Console.WriteLine("VariableGroup DisplayLabel: " + variableGroup.DisplayLabel);
                            
                            //Get the APIName of each VariableGroup
                            Console.WriteLine("VariableGroup APIName: " + variableGroup.APIName);
        
                            //Get the Name of each VariableGroup
                            Console.WriteLine("VariableGroup Name: " + variableGroup.Name);
                            
                            //Get the Description of each VariableGroup
                            Console.WriteLine("VariableGroup Description: " + variableGroup.Description);
                            
                            //Get the ID of each VariableGroup
                            Console.WriteLine("VariableGroup ID: " + variableGroup.Id);
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
        /// This method is used to get the details of any variable group with group name and print the response.
        /// </summary>
        /// <param name="variableGroupName">The API Name of the VariableGroup to be obtained</param>
        public static void GetVariableGroupByAPIName(string variableGroupName)
        {
            //example
            //string variableGroupName = "General";
            
            //Get instance of VariableGroupsOperations Class
            VariableGroupsOperations variableGroupsOperations = new VariableGroupsOperations();
            
            //Call GetVariableGroupByAPIName method that takes variableGroupName as parameter
            APIResponse<ResponseHandler> response = variableGroupsOperations.GetVariableGroupByAPIName(variableGroupName);
            
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
                        
                        //Get the obtained VariableGroup instance
                        List<Com.Zoho.Crm.API.VariableGroups.VariableGroup> variableGroups = responseWrapper.VariableGroups;
                        
                        foreach(Com.Zoho.Crm.API.VariableGroups.VariableGroup variableGroup in variableGroups)
                        {	
                            //Get the DisplayLabel of each VariableGroup
                            Console.WriteLine("VariableGroup DisplayLabel: " + variableGroup.DisplayLabel);
                            
                            //Get the APIName of each VariableGroup
                            Console.WriteLine("VariableGroup APIName: " + variableGroup.APIName);
        
                            //Get the Name of each VariableGroup
                            Console.WriteLine("VariableGroup Name: " + variableGroup.Name);
                            
                            //Get the Description of each VariableGroup
                            Console.WriteLine("VariableGroup Description: " + variableGroup.Description);
                            
                            //Get the ID of each VariableGroup
                            Console.WriteLine("VariableGroup ID: " + variableGroup.Id);
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
    }
}

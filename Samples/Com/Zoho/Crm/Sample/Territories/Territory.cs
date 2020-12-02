using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.CustomViews;

using Com.Zoho.Crm.API.Territories;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using APIException = Com.Zoho.Crm.API.Territories.APIException;

using ResponseHandler = Com.Zoho.Crm.API.Territories.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Territories.ResponseWrapper;

namespace Com.Zoho.Crm.Sample.Territories
{
    public class Territory
    {
        /// <summary>
        /// This method is used to get the list of territories enabled for your organization and print the response.
        /// </summary>
        public static void GetTerritories()
        {
            //Get instance of TerritoriesOperations Class
            TerritoriesOperations territoriesOperations = new TerritoriesOperations();
            
            //Call GetTerritories method
            APIResponse<ResponseHandler> response = territoriesOperations.GetTerritories();
            
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
                        
                        //Get the list of obtained Territory instances
                        List<Com.Zoho.Crm.API.Territories.Territory> territoryList = responseWrapper.Territories;
                    
                        foreach(Com.Zoho.Crm.API.Territories.Territory territory in territoryList)
                        {
                            Com.Zoho.Crm.Sample.Territories.Territory.GetTerritory((long)territory.Id);

                            //Get the CreatedTime of each Territory
                            Console.WriteLine("Territory CreatedTime: " + territory.CreatedTime);
                            
                            //Get the ModifiedTime of each Territory
                            Console.WriteLine("Territory ModifiedTime: " + territory.ModifiedTime);
                            
                            //Get the manager User instance of each Territory
                            User manager = territory.Manager;
                            
                            //Check if manager is not null
                            if(manager != null)
                            {
                                //Get the Name of the Manager
                                Console.WriteLine("Territory Manager User-Name: " + manager.Name);
                                
                                //Get the ID of the Manager
                                Console.WriteLine("Territory Manager User-ID: " + manager.Id);
                            }
                            
                            //Get the ParentId of each Territory
                            Console.WriteLine("Territory ParentId: " + territory.ParentId);
                            
                            // Get the Criteria instance of each Territory
                            Criteria criteria = territory.Criteria;
                            
                            //Check if criteria is not null
                            if(criteria != null)
                            {
                                PrintCriteria(criteria);
                            }
                            
                            //Get the Name of each Territory
                            Console.WriteLine("Territory Name: " + territory.Name);
                            
                            //Get the modifiedBy User instance of each Territory
                            User modifiedBy = territory.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Territory Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Territory Modified By User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Description of each Territory
                            Console.WriteLine("Territory Description: " + territory.Description);
                            
                            //Get the ID of each Territory
                            Console.WriteLine("Territory ID: " + territory.Id);
                            
                            //Get the createdBy User instance of each Territory
                            User createdBy = territory.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Territory Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Territory Created By User-ID: " + createdBy.Id);
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
        /// This method is used to get the single territory and print the response.
        /// </summary>
        /// <param name="territoryId">The ID of the Territory to be obtained</param>
        public static void GetTerritory(long territoryId)
        {
            //example
            //long territoryId = 34770613051397;
            
            //Get instance of TerritoriesOperations Class
            TerritoriesOperations territoriesOperations = new TerritoriesOperations();
            
            //Call GetTerritory method that takes territoryId as parameter
            APIResponse<ResponseHandler> response = territoriesOperations.GetTerritory(territoryId);
            
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
                        
                        //Get the list of obtained Territory instances
                        List<Com.Zoho.Crm.API.Territories.Territory> territoryList = responseWrapper.Territories;
                    
                        foreach(Com.Zoho.Crm.API.Territories.Territory territory in territoryList)
                        {
                            //Get the CreatedTime of each Territory
                            Console.WriteLine("Territory CreatedTime: " + territory.CreatedTime);
                            
                            //Get the ModifiedTime of each Territory
                            Console.WriteLine("Territory ModifiedTime: " + territory.ModifiedTime);
                            
                            //Get the manager User instance of each Territory
                            User manager = territory.Manager;
                            
                            //Check if manager is not null
                            if(manager != null)
                            {
                                //Get the Name of the Manager
                                Console.WriteLine("Territory Manager User-Name: " + manager.Name);
                                
                                //Get the ID of the Manager
                                Console.WriteLine("Territory Manager User-ID: " + manager.Id);
                            }
                            
                            //Get the ParentId of each Territory
                            Console.WriteLine("Territory ParentId: " + territory.ParentId);
                            
                            // Get the Criteria instance of each Territory
                            Criteria criteria = territory.Criteria;
                            
                            //Check if criteria is not null
                            if(criteria != null)
                            {
                                PrintCriteria(criteria);
                            }
                            
                            //Get the Name of each Territory
                            Console.WriteLine("Territory Name: " + territory.Name);
                            
                            //Get the modifiedBy User instance of each Territory
                            User modifiedBy = territory.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Territory Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Territory Modified By User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Description of each Territory
                            Console.WriteLine("Territory Description: " + territory.Description);
                            
                            //Get the ID of each Territory
                            Console.WriteLine("Territory ID: " + territory.Id);
                            
                            //Get the createdBy User instance of each Territory
                            User createdBy = territory.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Territory Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Territory Created By User-ID: " + createdBy.Id);
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
        
        private static void PrintCriteria(Criteria criteria)
        {
            if(criteria.Field != null)
            {
                //Get the Field of the Criteria
                Console.WriteLine("Territory Criteria Field: " + criteria.Field);
            }
            
            if(criteria.Comparator != null)
            {
                //Get the Comparator of the Criteria
                Console.WriteLine("Territory Criteria Comparator: " + criteria.Comparator.Value);
            }
            
            if(criteria.Value != null)
            {
                //Get the Value of the Criteria
                Console.WriteLine("Territory Criteria Value: " + criteria.Value);
            }
            
            // Get the List of Criteria instance of each Criteria
            List<Criteria> criteriaGroup = criteria.Group;
            
            if(criteriaGroup != null)
            {
                foreach(Criteria criteria1 in criteriaGroup)
                {
                    PrintCriteria(criteria1);
                }
            }
            
            if(criteria.GroupOperator != null)
            {
                //Get the Group Operator of the Criteria
                Console.WriteLine("Territory Criteria Group Operator: " + criteria.GroupOperator.Value);
            }
            
        }
    }
}

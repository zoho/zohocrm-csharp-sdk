using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.CustomViews;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.CustomViews.CustomViewsOperations;

namespace Com.Zoho.Crm.Sample.CustomView
{
    public class CustomView
    {
        /// <summary>
        /// This method is used to get the custom views data of a particular module.
        /// Specify the module name in your API request whose custom view data you want to retrieve.
        /// </summary>
        /// <param name="moduleAPIName">Specify the API name of the required module.</param>
        public static void GetCustomViews(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of CustomViewOperations Class that takes moduleAPIName as parameter
            CustomViewsOperations customViewsOperations = new CustomViewsOperations(moduleAPIName);

            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();

            paramInstance.Add(GetCustomViewsParam.PAGE, 1);

            paramInstance.Add(GetCustomViewsParam.PER_PAGE, 2);

            paramInstance.Add(new Param<string>("module", null), "Accounts");

            //Call GetCustomViews method
            APIResponse<ResponseHandler> response = customViewsOperations.GetCustomViews(paramInstance);
            
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
                        
                        //Get the list of obtained CustomView instances
                        List<Com.Zoho.Crm.API.CustomViews.CustomView> customViews = responseWrapper.CustomViews;
                    
                        foreach(Com.Zoho.Crm.API.CustomViews.CustomView customView in customViews)
                        {
                            //Get the DisplayValue of each CustomView
                            Console.WriteLine("CustomView DisplayValue: " + customView.DisplayValue);
                            
                            //Get the Offline of the each CustomView
                            Console.WriteLine("CustomView Offline: " + customView.Offline);
                            
                            //Get the Default of each CustomView
                            Console.WriteLine("CustomView Default: " + customView.Default);
                            
                            //Get the SystemName of each CustomView
                            Console.WriteLine("CustomView SystemName: " + customView.SystemName);
                            
                            //Get the SystemDefined of each CustomView
                            Console.WriteLine("CustomView SystemDefined: " + customView.SystemDefined);
                            
                            //Get the Name of each CustomView
                            Console.WriteLine("CustomView Name: " + customView.Name);
                            
                            //Get the ID of each CustomView
                            Console.WriteLine("CustomView ID: " + customView.Id);
                            
                            //Get the Category of each CustomView
                            Console.WriteLine("CustomView Category: " + customView.Category);
                            
                            if(customView.Favorite != null)
                            {
                                //Get the Favorite of each CustomView
                                Console.WriteLine("CustomView Favorite: " + customView.Favorite);
                            }
                        }
                        
                        //Get the object obtained Info instance
                        Info info = responseWrapper.Info;
                        
                        //Check if info is not null
                        if(info != null)
                        {
                            if(info.PerPage != null)
                            {
                                //Get the PerPage of the Info
                                Console.WriteLine("CustomView Info PerPage: " + info.PerPage);
                            }
                            
                            if(info.Default != null)
                            {
                                //Get the Default of the Info
                                Console.WriteLine("CustomView Info Default: " + info.Default);
                            }
                            
                            if(info.Count != null)
                            {
                                //Get the Count of the Info
                                Console.WriteLine("CustomView Info Count: " + info.Count);
                            }
                            
                            //Get the Translation instance of CustomView
                            Translation translation = info.Translation;
                            
                            if(translation != null)
                            {
                                //Get the PublicViews of the Translation
                                Console.WriteLine("CustomView Info Translation PublicViews: " + translation.PublicViews);
                                
                                //Get the OtherUsersViews of the Translation
                                Console.WriteLine("CustomView Info Translation OtherUsersViews: " + translation.OtherUsersViews);
                                
                                //Get the SharedWithMe of the Translation
                                Console.WriteLine("CustomView Info Translation SharedWithMe: " + translation.SharedWithMe);
                                
                                //Get the CreatedByMe of the Translation
                                Console.WriteLine("CustomView Info Translation CreatedByMe: " + translation.CreatedByMe);
                            }
                            
                            if(info.Page != null)
                            {
                                //Get the Page of the Info
                                Console.WriteLine("CustomView Info Page: " + info.Page);
                            }
                            
                            if(info.MoreRecords != null)
                            {
                                //Get the MoreRecords of the Info
                                Console.WriteLine("CustomView Info MoreRecords: " + info.MoreRecords);
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
        /// This method is used to get the data of any specific custom view of the module.
        /// Specify the custom view ID of the module in your API request whose custom view data you want to retrieve.
        /// </summary>
        /// <param name="moduleAPIName">Specify the API name of the required module.</param>
        /// <param name="customViewId">The ID of the CustomView to be obtained.</param>
        public static void GetCustomView(string moduleAPIName, long customViewId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long customViewId = 34770615629003;
            
            //Get instance of CustomViewOperations Class that takes moduleAPIName as parameter
            CustomViewsOperations customViewsOperations = new CustomViewsOperations(moduleAPIName);
            
            //Call GetCustomView method that takes customViewId as parameter
            APIResponse<ResponseHandler> response = customViewsOperations.GetCustomView(customViewId);
            
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
                        
                        //Get the list of obtained CustomView instances
                        List<Com.Zoho.Crm.API.CustomViews.CustomView> customViews = responseWrapper.CustomViews;
                    
                        foreach(Com.Zoho.Crm.API.CustomViews.CustomView customView in customViews)
                        {
                            //Get the DisplayValue of each CustomView
                            Console.WriteLine("CustomView DisplayValue: " + customView.DisplayValue);
                            
                            //Get the SharedType of each CustomView
                            Console.WriteLine("CustomView SharedType: " + customView.SharedType);
                            
                            //Get the SystemName of each CustomView
                            Console.WriteLine("CustomView SystemName: " + customView.SystemName);
                            
                            // Get the Criteria instance of each CustomView
                            Criteria criteria = customView.Criteria;
                            
                            //Check if criteria is not null
                            if(criteria != null)
                            {
                                PrintCriteria(criteria);
                            }
                            
                            List<SharedDetails> sharedDetails = customView.SharedDetails;
                            
                            if(sharedDetails != null)
                            {
                                foreach(SharedDetails sharedDetail in sharedDetails)
                                {
                                    //Get the Name of the each SharedDetails
                                    Console.WriteLine("SharedDetails Name: " + sharedDetail.Name);
                                    
                                    //Get the ID of the each SharedDetails
                                    Console.WriteLine("SharedDetails ID: " + sharedDetail.Id);
                                    
                                    //Get the Type of the each SharedDetails
                                    Console.WriteLine("SharedDetails Type: " + sharedDetail.Type);
                                    
                                    //Get the Subordinates of the each SharedDetails
                                    Console.WriteLine("SharedDetails Subordinates: " + sharedDetail.Subordinates);
                                }
                            }
                            
                            //Get the SortBy of the each CustomView
                            Console.WriteLine("CustomView SortBy: " + customView.SortBy);
                            
                            //Get the Offline of the each CustomView
                            Console.WriteLine("CustomView Offline: " + customView.Offline);
                            
                            //Get the Default of each CustomView
                            Console.WriteLine("CustomView Default: " + customView.Default);
                            
                            //Get the SystemDefined of each CustomView
                            Console.WriteLine("CustomView SystemDefined: " + customView.SystemDefined);
                            
                            //Get the Name of each CustomView
                            Console.WriteLine("CustomView Name: " + customView.Name);
                            
                            //Get the ID of each CustomView
                            Console.WriteLine("CustomView ID: " + customView.Id);
                            
                            //Get the Category of each CustomView
                            Console.WriteLine("CustomView Category: " + customView.Category);
                            
                            //Get the list of fields in each CustomView
                            List<string> fields = customView.Fields;
                            
                            if(fields != null)
                            {
                                foreach(string field in fields)
                                {
                                    Console.WriteLine(field);
                                }
                            }
                            
                            if(customView.Favorite != null)
                            {
                                //Get the Favorite of each CustomView
                                Console.WriteLine("CustomView Favorite: " + customView.Favorite);
                            }
                            
                            if(customView.SortOrder != null)
                            {
                                //Get the SortOrder of each CustomView
                                Console.WriteLine("CustomView SortOrder: " + customView.SortOrder);
                            }
                        }
                        
                        //Get the object obtained Info instance
                        Info info = responseWrapper.Info;
                        
                        //Check if info is not null
                        if(info != null)
                        {
                            //Get the Translation instance of CustomView
                            Translation translation = info.Translation;
                            
                            if(translation != null)
                            {
                                //Get the PublicViews of the Translation
                                Console.WriteLine("CustomView Info Translation PublicViews: " + translation.PublicViews);
                                
                                //Get the OtherUsersViews of the Translation
                                Console.WriteLine("CustomView Info Translation OtherUsersViews: " + translation.OtherUsersViews);
                                
                                //Get the SharedWithMe of the Translation
                                Console.WriteLine("CustomView Info Translation SharedWithMe: " + translation.SharedWithMe);
                                
                                //Get the CreatedByMe of the Translation
                                Console.WriteLine("CustomView Info Translation CreatedByMe: " + translation.CreatedByMe);
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
            if(criteria.Comparator != null)
            {
                //Get the Comparator of the Criteria
                Console.WriteLine("CustomView Criteria Comparator: " + criteria.Comparator.Value);
            }
            
            //Get the Field of the Criteria
            Console.WriteLine("CustomView Criteria Field: " + criteria.Field);
            
            if(criteria.Value != null)
            {
                //Get the Value of the Criteria
                Console.WriteLine("CustomView Criteria Value: " + criteria.Value);
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
                Console.WriteLine("CustomView Criteria Group Operator: " + criteria.GroupOperator.Value);
            }
        }
    }
}

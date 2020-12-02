using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.RelatedLists;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

namespace Com.Zoho.Crm.Sample.RelatedList
{
    public class RelatedList
    {
        /// <summary>
        /// This method is used to get the related list data of a particular module and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get related lists</param>
        public static void GetRelatedLists(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of RelatedListsOperations Class that takes moduleAPIName as parameter
            RelatedListsOperations relatedListsOperations = new RelatedListsOperations(moduleAPIName);
            
            //Call GetRelatedLists method
            APIResponse<ResponseHandler> response = relatedListsOperations.GetRelatedLists();
            
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
                        
                        //Get the list of obtained RelatedList instances
                        List<Com.Zoho.Crm.API.RelatedLists.RelatedList> relatedLists = responseWrapper.RelatedLists;
                    
                        foreach(Com.Zoho.Crm.API.RelatedLists.RelatedList relatedList in relatedLists)
                        {
                            //Get the SequenceNumber of each RelatedList
                            Console.WriteLine("RelatedList SequenceNumber: " + relatedList.SequenceNumber);
                            
                            //Get the DisplayLabel of each RelatedList
                            Console.WriteLine("RelatedList DisplayLabel: " + relatedList.DisplayLabel);
                            
                            //Get the APIName of each RelatedList
                            Console.WriteLine("RelatedList APIName: " + relatedList.APIName);
                            
                            //Get the Module of each RelatedList
                            Console.WriteLine("RelatedList Module: " + relatedList.Module);
                            
                            //Get the Name of each RelatedList
                            Console.WriteLine("RelatedList Name: " + relatedList.Name);
                            
                            //Get the Action of each RelatedList
                            Console.WriteLine("RelatedList Action: " + relatedList.Action);
        
                            //Get the ID of each RelatedList
                            Console.WriteLine("RelatedList ID: " + relatedList.Id);
                            
                            //Get the Href of each RelatedList
                            Console.WriteLine("RelatedList Href: " + relatedList.Href);
                            
                            //Get the Type of each RelatedList
                            Console.WriteLine("RelatedList Type: " + relatedList.Type);

                            //Get the Connectedmodule of each RelatedList
                            Console.WriteLine("RelatedList Connectedmodule: " + relatedList.Connectedmodule);
                            
                            //Get the Linkingmodule of each RelatedList
                            Console.WriteLine("RelatedList Linkingmodule: " + relatedList.Linkingmodule);
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
        /// This method is used to get the single related list data of a particular module with relatedListId and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get related list</param>
        /// <param name="relatedListId">The ID of the relatedList to be obtained</param>
        public static void GetRelatedList(string moduleAPIName, long relatedListId)
        {
            //example,
            //string moduleAPIName = "Leads";
            //long relatedListId = 5255085067912;
        
            //Get instance of RelatedListsOperations Class that takes moduleAPIName as parameter
            RelatedListsOperations relatedListsOperations = new RelatedListsOperations(moduleAPIName);
            
            //Call GetRelatedList method which takes relatedListId as parameter
            APIResponse<ResponseHandler> response = relatedListsOperations.GetRelatedList(relatedListId);
            
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
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the list of obtained CustomView instances
                        List<Com.Zoho.Crm.API.RelatedLists.RelatedList > relatedLists = responseWrapper.RelatedLists;
                    
                        foreach(Com.Zoho.Crm.API.RelatedLists.RelatedList relatedList in relatedLists)
                        {
                            //Get the SequenceNumber of each RelatedList
                            Console.WriteLine("RelatedList SequenceNumber: " + relatedList.SequenceNumber);
                            
                            //Get the DisplayLabel of each RelatedList
                            Console.WriteLine("RelatedList DisplayLabel: " + relatedList.DisplayLabel);
                            
                            //Get the APIName of each RelatedList
                            Console.WriteLine("RelatedList APIName: " + relatedList.APIName);
                            
                            //Get the Module of each RelatedList
                            Console.WriteLine("RelatedList Module: " + relatedList.Module);
                            
                            //Get the Name of each RelatedList
                            Console.WriteLine("RelatedList Name: " + relatedList.Name);
                            
                            //Get the Action of each RelatedList
                            Console.WriteLine("RelatedList Action: " + relatedList.Action);
        
                            //Get the ID of each RelatedList
                            Console.WriteLine("RelatedList ID: " + relatedList.Id);
                            
                            //Get the Href of each RelatedList
                            Console.WriteLine("RelatedList Href: " + relatedList.Href);
                            
                            //Get the Type of each RelatedList
                            Console.WriteLine("RelatedList Type: " + relatedList.Type);

                            //Get the Connectedmodule of each RelatedList
                            Console.WriteLine("RelatedList Connectedmodule: " + relatedList.Connectedmodule);
                            
                            //Get the Linkingmodule of each RelatedList
                            Console.WriteLine("RelatedList Linkingmodule: " + relatedList.Linkingmodule);
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

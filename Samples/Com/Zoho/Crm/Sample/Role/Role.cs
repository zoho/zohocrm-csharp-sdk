using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Roles;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using APIException = Com.Zoho.Crm.API.Roles.APIException;

using ResponseHandler = Com.Zoho.Crm.API.Roles.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Roles.ResponseWrapper;

namespace Com.Zoho.Crm.Sample.Role
{
    public class Role
    {
        /// <summary>
        /// This method is used to retrieve the data of roles through an API request and print the response.
        /// </summary>
        public static void GetRoles()
        {
            //Get instance of RolesOperations Class
            RolesOperations rolesOperations = new RolesOperations();

            //Call GetRoles method
            APIResponse<ResponseHandler> response = rolesOperations.GetRoles();

            if (response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);

                if (new List<int>() { 204, 304 }.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode == 204 ? "No Content" : "Not Modified");

                    return;
                }

                //Check if expected response is received
                if (response.IsExpected)
                {
                    //Get object from response
                    ResponseHandler responseHandler = response.Object;

                    if (responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper)responseHandler;

                        //Get the list of obtained Role instances
                        List<Com.Zoho.Crm.API.Roles.Role> roles = responseWrapper.Roles;

                        foreach (Com.Zoho.Crm.API.Roles.Role role in roles)
                        {
                            //Get the DisplayLabel of each Role
                            Console.WriteLine("Role DisplayLabel: " + role.DisplayLabel);

                            //Get the forecastManager User instance of each Role
                            User forecastManager = role.ForecastManager;

                            //Check if forecastManager is not null
                            if (forecastManager != null)
                            {
                                //Get the ID of the forecast Manager
                                Console.WriteLine("Role Forecast Manager User-ID: " + forecastManager.Id);

                                //Get the name of the forecast Manager
                                Console.WriteLine("Role Forecast Manager User-Name: " + forecastManager.Name);
                            }

                            //Get the ShareWithPeers of each Role
                            Console.WriteLine("Role ShareWithPeers: " + role.ShareWithPeers);

                            //Get the Name of each Role
                            Console.WriteLine("Role Name: " + role.Name);

                            //Get the Description of each Role
                            Console.WriteLine("Role Description: " + role.Description);

                            //Get the Id of each Role
                            Console.WriteLine("Role ID: " + role.Id);

                            //Get the reportingTo User instance of each Role
                            User reportingTo = role.ReportingTo;

                            //Check if reportingTo is not null
                            if (reportingTo != null)
                            {
                                //Get the ID of the reportingTo User
                                Console.WriteLine("Role ReportingTo User-ID: " + reportingTo.Id);

                                //Get the name of the reportingTo User
                                Console.WriteLine("Role ReportingTo User-Name: " + reportingTo.Name);
                            }

                            //Get the AdminUser of each Role
                            Console.WriteLine("Role AdminUser: " + role.AdminUser);
                        }
                    }
                    //Check if the request returned an exception
                    else if (responseHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException)responseHandler;

                        //Get the Status
                        Console.WriteLine("Status: " + exception.Status.Value);

                        //Get the Code
                        Console.WriteLine("Code: " + exception.Code.Value);

                        Console.WriteLine("Details: ");

                        //Get the details map
                        foreach (KeyValuePair<string, object> entry in exception.Details)
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
        /// This method is used to retrieve the data of single role through an API request and print the response.
        /// </summary>
        /// <param name="roleId">The ID of the Role to be obtained</param>
        public static void GetRole(long roleId)
        {
            //example
            //long roleId = 34770610003881;

            //Get instance of RolesOperations Class
            RolesOperations rolesOperations = new RolesOperations();

            //Call GetRole method that takes roleId as parameter
            APIResponse<ResponseHandler> response = rolesOperations.GetRole(roleId);

            if (response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);

                if (new List<int>() { 204, 304 }.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode == 204 ? "No Content" : "Not Modified");
                    return;
                }

                //Check if expected response is received
                if (response.IsExpected)
                {
                    //Get object from response
                    ResponseHandler responseHandler = response.Object;

                    if (responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper)responseHandler;

                        //Get the list of obtained Role instances
                        List<Com.Zoho.Crm.API.Roles.Role> roles = responseWrapper.Roles;

                        foreach (Com.Zoho.Crm.API.Roles.Role role in roles)
                        {
                            //Get the DisplayLabel of each Role
                            Console.WriteLine("Role DisplayLabel: " + role.DisplayLabel);

                            //Get the forecastManager User instance of each Role
                            User forecastManager = role.ForecastManager;

                            //Check if forecastManager is not null
                            if (forecastManager != null)
                            {
                                //Get the ID of the forecast Manager
                                Console.WriteLine("Role Forecast Manager User-ID: " + forecastManager.Id);

                                //Get the name of the forecast Manager
                                Console.WriteLine("Role Forecast Manager User-Name: " + forecastManager.Name);
                            }

                            //Get the ShareWithPeers of each Role
                            Console.WriteLine("Role ShareWithPeers: " + role.ShareWithPeers);

                            //Get the Name of each Role
                            Console.WriteLine("Role Name: " + role.Name);

                            //Get the Description of each Role
                            Console.WriteLine("Role Description: " + role.Description);

                            //Get the Id of each Role
                            Console.WriteLine("Role ID: " + role.Id);

                            //Get the reportingTo User instance of each Role
                            User reportingTo = role.ReportingTo;

                            //Check if reportingTo is not null
                            if (reportingTo != null)
                            {
                                //Get the ID of the reportingTo User
                                Console.WriteLine("Role ReportingTo User-ID: " + reportingTo.Id);

                                //Get the name of the reportingTo User
                                Console.WriteLine("Role ReportingTo User-Name: " + reportingTo.Name);
                            }

                            //Get the AdminUser of each Role
                            Console.WriteLine("Role AdminUser: " + role.AdminUser);
                        }
                    }
                    //Check if the request returned an exception
                    else if (responseHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException)responseHandler;

                        //Get the Status
                        Console.WriteLine("Status: " + exception.Status.Value);

                        //Get the Code
                        Console.WriteLine("Code: " + exception.Code.Value);

                        Console.WriteLine("Details: ");

                        //Get the details map
                        foreach (KeyValuePair<string, object> entry in exception.Details)
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
using System;
using System.Collections.Generic;
using System.Threading;
using Com.Zoho.API.Authenticator;
using Com.Zoho.API.Authenticator.Store;
using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.ContactRoles;
using Com.Zoho.Crm.API.Dc;
using Com.Zoho.Crm.API.Logger;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using Newtonsoft.Json;
using static Com.Zoho.API.Authenticator.OAuthToken;
using APIException = Com.Zoho.Crm.API.Record.APIException;
using ResponseHandler = Com.Zoho.Crm.API.Record.ResponseHandler;
using ResponseWrapper = Com.Zoho.Crm.API.Record.ResponseWrapper;
using SDKInitializer = Com.Zoho.Crm.API.Initializer;

namespace Com.Zoho.Crm.Sample.Threading.SingleUser
{
    public class SingleThread
    {
        public static void RunSingleThreadWithSingleUser()
        {
            Logger logger = Logger.GetInstance(Logger.Levels.ALL, "/Users/Documents/GitLab/csharp_sdk_log.log");

            DataCenter.Environment env = USDataCenter.PRODUCTION;

            UserSignature user1 = new UserSignature("abc@zoho.com");

            TokenStore tokenstore = new FileStore("/Users/Documents/GitLab/csharp_sdk_token.txt");

            Token token1 = new OAuthToken("1000.xxxxxx", "xxxxxx", "1000.xxxxxx.xxxxxx", TokenType.REFRESH, "https://www.zoho.com");

            string resourcePath = "/Users/Documents/GitLab/SampleApp/zohocrm-csharp-sdk-sample-application";

            DataCenter.Environment environment = USDataCenter.PRODUCTION;

            UserSignature user2 = new UserSignature("abc1@zoho.com");

            Token token2 = new OAuthToken("1000.xxxxxx", "xxxxxx", "1000.xxxxxx.xxxxxx", TokenType.REFRESH);

            SDKConfig config = new SDKConfig.Builder().SetAutoRefreshFields(true).Build();

            SDKInitializer.Initialize(user1, env, token1, tokenstore, config, resourcePath, logger);

            new SingleThread().GetRecords("Leads");

            new SingleThread().GetContactRoles();

        }

        public void GetRecords(string moduleAPIName)
        {
            try
            {
                Console.WriteLine("Fetching Cr's for user - " + SDKInitializer.GetInitializer().User.Email);

                RecordOperations recordOperation = new RecordOperations();

                APIResponse<ResponseHandler> response = recordOperation.GetRecords(moduleAPIName, null, null);

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

                            //Get the list of obtained Record instances
                            List<API.Record.Record> records = responseWrapper.Data;

                            foreach (API.Record.Record record in records)
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(record));
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
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public void GetContactRoles()
        {
            try
            {
                Console.WriteLine("Fetching Cr's for user - " + SDKInitializer.GetInitializer().User.Email);

                ContactRolesOperations contactRolesOperations = new ContactRolesOperations();

                APIResponse<API.ContactRoles.ResponseHandler> response = contactRolesOperations.GetContactRoles();

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
                        API.ContactRoles.ResponseHandler responseHandler = response.Object;

                        if (responseHandler is API.ContactRoles.ResponseWrapper)
                        {
                            //Get the received ResponseWrapper instance
                            API.ContactRoles.ResponseWrapper responseWrapper = (API.ContactRoles.ResponseWrapper)responseHandler;

                            //Get the list of obtained Record instances
                            List<ContactRole> contactRoles = responseWrapper.ContactRoles;

                            foreach (ContactRole contactRole in contactRoles)
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(contactRole));
                            }
                        }
                        //Check if the request returned an exception
                        else if (responseHandler is API.ContactRoles.APIException)
                        {
                            //Get the received APIException instance
                            API.ContactRoles.APIException exception = (API.ContactRoles.APIException)responseHandler;

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
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}

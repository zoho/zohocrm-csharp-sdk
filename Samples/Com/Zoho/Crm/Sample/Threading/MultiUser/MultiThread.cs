using System;
using System.Collections.Generic;
using System.Threading;
using Com.Zoho.API.Authenticator;
using Com.Zoho.API.Authenticator.Store;
using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Dc;
using Com.Zoho.Crm.API.Logger;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using Newtonsoft.Json;
using static Com.Zoho.API.Authenticator.OAuthToken;
using SDKInitializer = Com.Zoho.Crm.API.Initializer;

namespace Com.Zoho.Crm.Sample.Threading.MultiUser
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiThread
    {

        DataCenter.Environment environment;

        UserSignature user;

        Token token;

        string moduleAPIName;

        public MultiThread(UserSignature user, DataCenter.Environment environment, Token token, string moduleAPIName)
        {
            this.environment = environment;

            this.user = user;

            this.token = token;

            this.moduleAPIName = moduleAPIName;
        }

        public static void RunMultiThreadWithMultiUser()
        {
            Logger logger = Logger.GetInstance(Logger.Levels.ALL, "/Users/Documents/GitLab/csharp_sdk_log.log");

            DataCenter.Environment env = USDataCenter.PRODUCTION;

            UserSignature user1 = new UserSignature("abc@zoho.com");

            //TokenStore tokenstore = new DBStore(null, null, null, null, null);

            TokenStore tokenstore = new FileStore("/Users/Documents/GitLab/csharp_sdk_token.txt");

            Token token1 = new OAuthToken("1000.xxxxxx", "xxxxxx", "1000.xxxxxx.xxxxxx", TokenType.REFRESH, "https://www.zoho.com");

            string resourcePath = "/Users/Documents/GitLab/SampleApp/zohocrm-csharp-sdk-sample-application";

            DataCenter.Environment environment = USDataCenter.PRODUCTION;

            UserSignature user2 = new UserSignature("abc1@zoho.com");

            Token token2 = new OAuthToken("1000.xxxxxx", "xxxxxx", "1000.xxxxxx.xxxxxx", TokenType.REFRESH);

            SDKConfig config = new SDKConfig.Builder().SetAutoRefreshFields(true).Build();

            SDKInitializer.Initialize(user1, env, token1, tokenstore, config, resourcePath, logger);

            MultiThread multiThread1 = new MultiThread(user1, env, token1, "Vendors");

            Thread thread1 = new Thread(() => multiThread1.GetRecords());

            thread1.Start();

            MultiThread multiThread2 = new MultiThread(user2, environment, token2, "Quotes");

            Thread thread2 = new Thread(() => multiThread2.GetRecords());

            thread2.Start();

            thread1.Join();

            thread2.Join();
        }

        public void GetRecords()
        {
            try
            {
                SDKConfig config = new SDKConfig.Builder().SetAutoRefreshFields(true).Build();

                SDKInitializer.SwitchUser(this.user, this.environment, this.token, config);

                Console.WriteLine("Fetching Cr's for user - " + SDKInitializer.GetInitializer().User.Email);

                RecordOperations recordOperation = new RecordOperations();

                APIResponse<ResponseHandler> response = recordOperation.GetRecords(this.moduleAPIName, null, null);

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
    }
}

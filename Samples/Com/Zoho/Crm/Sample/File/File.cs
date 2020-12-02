using System;

using System.Collections.Generic;

using System.IO;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.File;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.File.FileOperations;

namespace Com.Zoho.Crm.Sample.File
{
    public class File
    {
        /// <summary>
        /// This method is used to upload a file and print the response.
        /// </summary>
        public static void UploadFiles()
        {
            //Get instance of RecordOperations Class
            FileOperations fileOperations = new FileOperations();
            
            //Get instance of FileBodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();

            //Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
            StreamWrapper streamWrapper = new StreamWrapper("/Users/Desktop/py.html");

            //Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
            StreamWrapper streamWrapper1 = new StreamWrapper("/Users/Desktop/download.png");

            //Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
            StreamWrapper streamWrapper2 = new StreamWrapper("/Users/Desktop/samplecode.txt");

            //Set file to the FileBodyWrapper instance
            bodyWrapper.File = new List<StreamWrapper>() { streamWrapper, streamWrapper1, streamWrapper2 };

            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();

            //Call uploadFile method that takes BodyWrapper instance as parameter.
            APIResponse<ActionHandler> response = fileOperations.UploadFiles(bodyWrapper, paramInstance);
            
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
                        
                        //Get the list of obtained action responses
                        List<ActionResponse> actionResponses = actionWrapper.Data;
                        
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
                                    Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to download a file.
        /// </summary>
        /// <param name="id">The ID of the uploaded File.</param>
        /// <param name="destinationFolder">The absolute path of the destination folder to store the File</param>
        public static void GetFile(string id, string destinationFolder)
        {
            //example
            //string id = "ae9c7cefa418aec1d6a5cc2d7d5e00a54b7563c0dd42b";
            //string destinationFolder = "/Users/user_name/Desktop"
            
            //Get instance of FileOperations Class
            FileOperations fileOperations = new FileOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetFileParam.ID, id);
            
            //Call getFile method that takes paramInstance as parameters
            APIResponse<ResponseHandler> response = fileOperations.GetFile(paramInstance);
            
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
                    
                    if(responseHandler is FileBodyWrapper)
                    {
                        //Get object from response
                        FileBodyWrapper fileBodyWrapper = (FileBodyWrapper)responseHandler;
                        
                        //Get StreamWrapper instance from the returned FileBodyWrapper instance
                        StreamWrapper streamWrapper = fileBodyWrapper.File;
                        
                        Stream file = streamWrapper.Stream;

						string fullFilePath = Path.Combine(destinationFolder, streamWrapper.Name);

						using (FileStream outputFileStream = new FileStream(fullFilePath, FileMode.Create))
						{
							file.CopyTo(outputFileStream);
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

                    if (responseObject != null)
                    {
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
}

using System;

using System.Collections.Generic;

using System.IO;

using System.Reflection;

using Com.Zoho.Crm.API.BulkRead;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using ActionHandler = Com.Zoho.Crm.API.BulkRead.ActionHandler;

using ActionResponse = Com.Zoho.Crm.API.BulkRead.ActionResponse;

using ActionWrapper = Com.Zoho.Crm.API.BulkRead.ActionWrapper;

using APIException = Com.Zoho.Crm.API.BulkRead.APIException;

using RequestWrapper = Com.Zoho.Crm.API.BulkRead.RequestWrapper;

using ResponseHandler = Com.Zoho.Crm.API.BulkRead.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.BulkRead.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.BulkRead.SuccessResponse;

namespace Com.Zoho.Crm.Sample.BulkRead
{
	public class BulkRead
    {
		/// <summary>
		/// This method is used to create a bulk read job to export records.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		public static void CreateBulkReadJob (string moduleAPIName)
        {
			//example
			//string moduleAPIName = "Leads";

			//Get instance of BulkReadOperations Class
			BulkReadOperations bulkReadOperations = new BulkReadOperations();

			//Get instance of RequestWrapper Class that will contain the request body
			RequestWrapper requestWrapper = new RequestWrapper();

			//Get instance of CallBack Class
			CallBack callback = new CallBack();

			// To set valid callback URL.
			callback.Url = "https://www.example.com/callback";

			//To set the HTTP method of the callback URL. The allowed value is post.
			callback.Method = new Choice<string> ("post");

			//The Bulk Read Job's details is posted to this URL on successful completion / failure of job.
			requestWrapper.Callback = callback;

			//Get instance of Query Class
			API.BulkRead.Query query = new API.BulkRead.Query();

			//Specifies the API Name of the module to be read.
			query.Module = moduleAPIName;

			//Specifies the unique ID of the custom view whose records you want to export.
			//query.Cvid = "34770610087501";

			// List of Field API Names
			List<string> fieldAPINames = new List<string>();

            fieldAPINames.Add("Last_Name");

            //Specifies the API Name of the fields to be fetched.
            //query.Fields = fieldAPINames;

            //To set page value, By default value is 1.
            query.Page = 1;

			//Get instance of Criteria Class
			Criteria criteria = new Criteria();
			
			criteria.GroupOperator = new Choice<string>("or");
			
			List<Criteria> criteriaList = new List<Criteria>();
			
			Criteria group11 = new Criteria();
			
			group11.GroupOperator = new Choice<string>("and");
			
			List<Criteria> groupList11 = new List<Criteria>();
			
			Criteria group111 = new Criteria();

			group111.APIName = "All_day";

			group111.Comparator = new Choice<string>("equal");
			
			group111.Value = false;
			
			groupList11.Add(group111);
			
			Criteria group112 = new Criteria();
			
			group112.APIName = "Owner";
			
			group112.Comparator = new Choice<string>("in");
			
			List<string> owner = new List<string>() { "34770610173021" };
			
			group112.Value = owner;
			
			groupList11.Add(group112);
			
			group11.Group = groupList11;
			
			criteriaList.Add(group11);
			
			Criteria group12 = new Criteria();
			
			group12.GroupOperator = new Choice<string>("or");
			
			List<Criteria> groupList12 = new List<Criteria>();
			
			Criteria group121 = new Criteria();
			
			group121.APIName = "Event_Title";
			
			group121.Comparator = new Choice<string>("equal");
			
			group121.Value = "New Automated Event";
			
			groupList12.Add(group121);
			
			Criteria group122 = new Criteria();
			
			// To set API name of a field.
			group122.APIName = "Created_Time";
			
			// To set comparator(eg: equal, greater_than.).
			group122.Comparator = new Choice<string>("between");
			
			List<string> createdTime = new List<string>() { "2020-06-03T17:31:48+05:30", "2020-06-03T17:31:48+05:30" };
			
			// To set the value to be compare.
			group122.Value = createdTime;
			
			groupList12.Add(group122);
			
			group12.Group = groupList12;
			
			criteriaList.Add(group12);
			
			criteria.Group = criteriaList;
			
			//To filter the records to be exported.
			query.Criteria = criteria;

			//To set query JSON object.
			requestWrapper.Query = query;

            //Specify the value for this key as "ics" to export all records in the Events module as an ICS file.
            requestWrapper.FileType = new Choice<string>("csv");

            //Call CreateBulkReadJob method that takes RequestWrapper instance as parameter 
            APIResponse<ActionHandler> response = bulkReadOperations.CreateBulkReadJob(requestWrapper);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
					//Get object from response
					ActionHandler actionHandler = response.Object;

					if (actionHandler is ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        API.BulkRead.ActionWrapper actionWrapper = (ActionWrapper) actionHandler;

						//Get the list of obtained ActionResponse instances
						List<ActionResponse> actionResponses = actionWrapper.Data;

						foreach(ActionResponse actionResponse in actionResponses)
                        {
							//Check if the request is successful
							if (actionResponse is SuccessResponse)
                            {
                                //Get the received SuccessResponse instance
                                API.BulkRead.SuccessResponse successResponse = (SuccessResponse) actionResponse;

								//Get the Status
								Console.WriteLine("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine("Code: " + successResponse.Code.Value);

								Console.WriteLine("Details: ");

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
							else if (actionResponse is APIException) //Get the received APIException instance
                            {
								APIException exception = (APIException) actionResponse;

                                //Get the Status
                                Console.WriteLine("Status: " + exception.Status.Value);

                                //Get the Code
                                Console.WriteLine("Code: " + exception.Code.Value);

                                Console.WriteLine("Details: ");

                                //Get the details map
                                foreach (KeyValuePair<string, object> entry in exception.Details)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
                                }

                                //Get the Message
                                Console.WriteLine("Message: " + exception.Message.Value);
                            }
                        }
					}
					//Check if the request returned an exception
					else if (actionHandler is APIException) //Get the received APIException instance
                    {
						APIException exception = (APIException)actionHandler;

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
		/// This method is used to get the details of a bulk read job performed previously.
		/// </summary>
		/// <param name="jobId">The unique ID of the bulk read job.</param>
		public static void GetBulkReadJobDetails (long jobId)
        {
			//example
			//long jobId = 34770615177002;

			//Get instance of BulkReadOperations Class
			BulkReadOperations bulkReadOperations = new BulkReadOperations();

			//Call GetBulkReadJobDetails method that takes jobId as parameter
			APIResponse<ResponseHandler> response = bulkReadOperations.GetBulkReadJobDetails(jobId);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine("Status Code: " + response.StatusCode);

				if (new List<int>() { 204, 304 }.Contains (response.StatusCode))
                {
					Console.WriteLine(response.StatusCode == 204 ? "No Content" : "Not Modified");

					return;
				}

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.BulkRead.ResponseHandler responseHandler = response.Object;

					if (responseHandler is ResponseWrapper)
                    {
						//Get the received ResponseWrapper instance
						ResponseWrapper responseWrapper = (API.BulkRead.ResponseWrapper) responseHandler;

						//Get the list of obtained jobDetail instances
						List<JobDetail> jobDetails = responseWrapper.Data;

						foreach(JobDetail jobDetail in jobDetails)
                        {
							//Get the Job ID of each jobDetail
							Console.WriteLine("Bulk read Job ID: " + jobDetail.Id);

							//Get the Operation of each jobDetail
							Console.WriteLine("Bulk read Operation: " + jobDetail.Operation);

							//Get the Operation of each jobDetail
							Console.WriteLine("Bulk read State: " + jobDetail.State.Value);

							//Get the Result instance of each jobDetail
							Result result = jobDetail.Result;

							//Check if Result is not null
							if (result != null)
                            {
								//Get the Page of the Result
								Console.WriteLine("Bulkread Result Page: " + result.Page);

								//Get the Count of the Result
								Console.WriteLine("Bulkread Result Count: " + result.Count);

								//Get the Download URL of the Result
								Console.WriteLine("Bulkread Result Download URL: " + result.DownloadUrl);

								//Get the Per_Page of the Result
								Console.WriteLine("Bulkread Result Per_Page: " + result.PerPage);

								//Get the MoreRecords of the Result
								Console.WriteLine("Bulkread Result MoreRecords: " + result.MoreRecords);

							}

							// Get the Query instance of each jobDetail
							API.BulkRead.Query query = jobDetail.Query;

							if (query != null)
                            {
								//Get the Module Name of the Query
								Console.WriteLine("Bulk read Query Module: " + query.Module);

								//Get the Page of the Query
								Console.WriteLine("Bulk read Query Page: " + query.Page);

								//Get the cvid of the Query
								Console.WriteLine("Bulk read Query cvid: " + query.Cvid);

								//Get the fields List of each Query
								List<string> fields = query.Fields;

								//Check if fields is not null
								if (fields != null)
                                {
									foreach(object fieldName in fields)
                                    {
										//Get the Field Name of the Query
										Console.WriteLine("Bulk read Query Fields: " + fieldName);
									}
								}

								// Get the Criteria instance of each Query
								Criteria criteria = query.Criteria;

								//Check if criteria is not null
								if (criteria != null)
                                {
									PrintCriteria (criteria);
								}
							}

							//Get the CreatedBy User instance of each jobDetail
							User createdBy = jobDetail.CreatedBy;

							//Check if createdBy is not null
							if (createdBy != null)
                            {
								//Get the ID of the CreatedBy User
								Console.WriteLine("Bulkread Created By User-ID: " + createdBy.Id);

								//Get the Name of the CreatedBy User
								Console.WriteLine("Bulkread Created By user-Name: " + createdBy.Name);
							}

							//Get the CreatedTime of each jobDetail
							Console.WriteLine("Bulkread CreatedTime: " + jobDetail.CreatedTime);

							//Get the ID of each jobDetail
							Console.WriteLine("Bulkread File Type: " + jobDetail.FileType);
						}
					}
					//Check if the request returned an exception
					else if (responseHandler is API.BulkRead.APIException)
                    {
                        //Get the received APIException instance
                        API.BulkRead.APIException exception = (API.BulkRead.APIException) responseHandler;

						//Get the Status
						Console.WriteLine("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine("Code: " + exception.Code.Value);

						Console.WriteLine("Details: ");

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

		private static void PrintCriteria (Criteria criteria)
        {
			//Get the APIName of the Criteria
			Console.WriteLine("Bulk read Query Criteria APIName: " + criteria.APIName);

			if (criteria.Comparator != null)
            {
				//Get the Comparator of the Criteria
				Console.WriteLine("Bulk read Query Criteria Comparator: " + criteria.Comparator.Value);
			}

			if (criteria.Value != null)
            {
				//Get the Value of the Criteria
				Console.WriteLine("Bulk read Query Criteria Value: " + criteria.Value);
			}

			//Get the List of Criteria instance of each Criteria
			List<Criteria> criteriaGroup = criteria.Group;

			if (criteriaGroup != null)
            {
				foreach(Criteria criteria1 in criteriaGroup)
                {
					PrintCriteria (criteria1);
				}
			}

			if (criteria.GroupOperator != null)
            {
				//Get the Group Operator of the Criteria
				Console.WriteLine("Bulk read Query Criteria Group Operator: " + criteria.GroupOperator.Value);
			}
		}

		/// <summary>
		/// This method is used to download the bulk read job as a CSV or an ICS file (only for the Events module). 
		/// </summary>
		/// <param name="jobId">The unique ID of the bulk read job.</param>
		/// <param name="destinationFolder">The absolute path where downloaded file has to be stored.</param>
		public static void DownloadResult (long jobId, string destinationFolder)
        {
			//example
			//long jobId = 34770615177002;
			//string destinationFolder = "/Users/user_name/Documents";

			//Get instance of BulkReadOperations Class
			BulkReadOperations bulkReadOperations = new BulkReadOperations();

			//Call DownloadResult method that takes jobId as parameters
			APIResponse<API.BulkRead.ResponseHandler> response = bulkReadOperations.DownloadResult(jobId);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine("Status Code: " + response.StatusCode);

				if (new List<int>() { 204, 304 }.Contains (response.StatusCode))
                {
					Console.WriteLine(response.StatusCode == 204 ? "No Content" : "Not Modified");

                    return;
				}

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.BulkRead.ResponseHandler responseHandler = response.Object;

					if (responseHandler is FileBodyWrapper)
                    {
						//Get the received FileBodyWrapper instance
						FileBodyWrapper fileBodyWrapper = (FileBodyWrapper) responseHandler;

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
					else if (responseHandler is API.BulkRead.APIException)
                    {
                        //Get the received APIException instance
                        API.BulkRead.APIException exception = (APIException) responseHandler;

						//Get the Status
						Console.WriteLine("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine("Code: " + exception.Code.Value);

						Console.WriteLine("Details: ");

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
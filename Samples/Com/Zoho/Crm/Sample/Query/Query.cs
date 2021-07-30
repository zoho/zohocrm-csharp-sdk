using System;

using System.Collections;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Query;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

namespace Com.Zoho.Crm.Sample.Query
{
	public class Query
	{
		/**
		 * <h3> Get Records </h3>
		 * This method is used to get records from the module through a COQL query.
		 * @throws Exception
		 */
		public static void GetRecords()
		{
			//Get instance of QueryOperations Class
			QueryOperations queryOperations = new QueryOperations();

			//Get instance of BodyWrapper Class that will contain the request body
			BodyWrapper bodyWrapper = new BodyWrapper();

			string selectQuery = "select Last_Name from Leads where Last_Name is not null limit 200";

			bodyWrapper.SelectQuery = selectQuery;

			//Call getRecords method that takes BodyWrapper instance as parameter 
			APIResponse<ResponseHandler> response = queryOperations.GetRecords(bodyWrapper);

			if (response != null)
			{
				//Get the status code from response
				Console.WriteLine("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
				{
					//Get the object from response
					ResponseHandler responseHandler = response.Object;

					if (responseHandler is ResponseWrapper)
					{
						//Get the received ResponseWrapper instance
						ResponseWrapper responseWrapper = (ResponseWrapper)responseHandler;

						//Get the obtained Record instances
						List<API.Record.Record> records = responseWrapper.Data;

						foreach (API.Record.Record record in records)
						{
							//Get the ID of each Record
							Console.WriteLine("Record ID: " + record.Id);

							//Get the createdBy User instance of each Record
							API.Users.User createdBy = record.CreatedBy;

							//Check if createdBy is not null
							if (createdBy != null)
							{
								//Get the ID of the createdBy User
								Console.WriteLine("Record Created By User-ID: " + createdBy.Id);

								//Get the name of the createdBy User
								Console.WriteLine("Record Created By User-Name: " + createdBy.Name);

								//Get the Email of the createdBy User
								Console.WriteLine("Record Created By User-Email: " + createdBy.Email);
							}

							//Get the CreatedTime of each Record
							Console.WriteLine("Record CreatedTime: " + record.CreatedTime);

							//Get the modifiedBy User instance of each Record
							API.Users.User modifiedBy = record.ModifiedBy;

							//Check if modifiedBy is not null
							if (modifiedBy != null)
							{
								//Get the ID of the modifiedBy User
								Console.WriteLine("Record Modified By User-ID: " + modifiedBy.Id);

								//Get the name of the modifiedBy User
								Console.WriteLine("Record Modified By User-Name: " + modifiedBy.Name);

								//Get the Email of the modifiedBy User
								Console.WriteLine("Record Modified By User-Email: " + modifiedBy.Email);
							}

							//Get the ModifiedTime of each Record
							Console.WriteLine("Record ModifiedTime: " + record.ModifiedTime);

							//To get particular field value 
							Console.WriteLine("Record Field Value: " + record.GetKeyValue("Last_Name"));// FieldApiName

							Console.WriteLine("Record KeyValues: ");

							//Get the KeyValue map
							foreach (KeyValuePair<string, object> entry in record.GetKeyValues())
							{
								string keyName = entry.Key;

								object value = entry.Value;

								if (value is IList)
								{
									Console.WriteLine("Record KeyName : " + keyName);

									IList dataList = (IList)value;

									foreach (object data in dataList)
									{
										if (data is IDictionary)
										{
											Console.WriteLine("Record KeyName : " + keyName + " - Value : ");

											foreach (KeyValuePair<string, object> entry1 in (Dictionary<string, object>)data)
											{
												Console.WriteLine(entry1.Key + " : " + JsonConvert.SerializeObject(entry1.Value));
											}
										}
										else
										{
											Console.WriteLine(JsonConvert.SerializeObject(data));
										}
									}
								}
								else if (value is IDictionary)
								{
									Console.WriteLine("Record KeyName : " + keyName + " - Value : ");

									foreach (KeyValuePair<string, object> entry1 in (Dictionary<string, object>)value)
									{
										Console.WriteLine(entry1.Key + " : " + JsonConvert.SerializeObject(entry1.Value));
									}
								}
								else
								{
									Console.WriteLine("Record KeyName : " + keyName + " - Value : " + JsonConvert.SerializeObject(value));
								}
							}
						}

						//Get the Object obtained Info instance
						API.Record.Info info = responseWrapper.Info;

						//Check if info is not null
						if (info != null)
						{
							if (info.Count != null)
							{
								//Get the Count of the Info
								Console.WriteLine("Record Info Count: " + info.Count.ToString());
							}

							if (info.MoreRecords != null)
							{
								//Get the MoreRecords of the Info
								Console.WriteLine("Record Info MoreRecords: " + info.MoreRecords.ToString());
							}
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
							Console.WriteLine(entry.Key + " : " + entry.Value);
						}

						//Get the Message
						Console.WriteLine("Message: " + exception.Message.Value);
					}
				}
				else
				{//If response is not as expected

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
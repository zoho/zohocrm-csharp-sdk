using System;

using System.Collections;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Notification;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Notification.NotificationOperations;

namespace Com.Zoho.Crm.Sample.Notification
{
    public class Notification
    {
		/// <summary>
		/// This method is used to Enable Notifications and print the response.
		/// </summary>
		public static void EnableNotifications()
		{
			//Get instance of NotificationOperations Class
			NotificationOperations notificationOperations = new NotificationOperations();

			//Get instance of BodyWrapper Class that will contain the request body
			BodyWrapper bodyWrapper = new BodyWrapper();

			//List of Notification instances
			List<API.Notification.Notification> notifications = new List<API.Notification.Notification>();

			//Get instance of Notification Class
			API.Notification.Notification notification = new API.Notification.Notification();

            //Set channel Id of the Notification
            notification.ChannelId = 1006800211;

            List<string> events = new List<string>();

            //events.Add("Deals.all");

            //To subscribe based on particular operations on given modules.
            notification.Events = events;

            //To set the expiry time for instant notifications. 
            notification.ChannelExpiry = new DateTimeOffset(new DateTime(2021, 05, 15, 12, 0, 0, DateTimeKind.Local));

			//To ensure that the notification is sent from Zoho CRM, by sending back the given value in notification URL body.
			//By using this value, user can validate the notifications.
			notification.Token = "TOKEN_FOR_VERIFICATION_OF_10068002";

            //URL to be notified (POST request)
            notification.NotifyUrl = "https://www.zohoapis.com";

            //Add Notification instance to the list
            notifications.Add(notification);

			//Get instance of Notification Class
			API.Notification.Notification notification2 = new API.Notification.Notification();

            //Set channel Id of the Notification
            notification2.ChannelId = 1006800211;

            List<string> events2 = new List<string>();

			events2.Add("Accounts.all");
		
			//To subscribe based on particular operations on given modules.
			notification2.Events = events2;
		
			//To set the expiry time for instant notifications. 
			notification2.ChannelExpiry = new DateTimeOffset(new DateTime(2021, 05, 15, 12, 0, 0, DateTimeKind.Local));

			//To ensure that the notification is sent from Zoho CRM, by sending back the given value in notification URL body.
			//By using this value, user can validate the notifications.
			notification2.Token = "TOKEN_FOR_VERIFICATION_OF_10068002";
		
			//URL to be notified (POST request)
			notification2.NotifyUrl = "https://www.zohoapis.com";
		
			//Add Notification instance to the list
			notifications.Add(notification2);
		
			//Set the list to notifications in BodyWrapper instance
			bodyWrapper.Watch = notifications;
		
			//Call enableNotifications method that takes BodyWrapper instance as parameter 
			APIResponse<ActionHandler> response = notificationOperations.EnableNotifications(bodyWrapper);
		
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
						ActionWrapper actionWrapper = (ActionWrapper)actionHandler;

						//Get the list of obtained ActionResponse instances
						List<ActionResponse> actionResponses = actionWrapper.Watch;
					
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
								if (entry.Value is IList && ((IList)entry.Value).Count > 0)
								{
									IList dataList = (IList)entry.Value;

									if (dataList.Count > 0 &&  dataList[0] is API.Notification.Notification)
									{
										List<API.Notification.Notification> eventList = (List<API.Notification.Notification>)dataList;

										foreach (API.Notification.Notification event1 in eventList)
										{
											//Get the ChannelExpiry of each Notification
											Console.WriteLine("Notification ChannelExpiry: " + event1.ChannelExpiry);
											
											//Get the ResourceUri each Notification
											Console.WriteLine("Notification ResourceUri: " + event1.ResourceUri);
											
											//Get the ResourceId each Notification
											Console.WriteLine("Notification ResourceId: " + event1.ResourceId);
											
											//Get the ResourceName each Notification
											Console.WriteLine("Notification ResourceName: " + event1.ResourceName);

											//Get the ChannelId each Notification
											Console.WriteLine("Notification ChannelId: " + event1.ChannelId);
										}
									}
								}
								else
								{
									//Get each value in the map
									Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
								}
							}
							
							//Get the Message
							Console.WriteLine("Message: " + successResponse.Message.Value);
						}
						//Check if the request returned an exception
						else if (actionResponse is APIException)
						{
							//Get the received APIException instance
							APIException exception = (APIException)actionResponse;

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
				else if (actionHandler is APIException)
				{
					//Get the received APIException instance
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
						Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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
		/// This method is used to get all the Notification and print the response.
		/// </summary>
		public static void GetNotificationDetails()
		{
			//Get instance of NotificationOperations Class
			NotificationOperations notificationOperations = new NotificationOperations();

			ParameterMap paramInstance = new ParameterMap();

			paramInstance.Add(GetNotificationDetailsParam.CHANNEL_ID, 1006800212);

			paramInstance.Add(GetNotificationDetailsParam.MODULE, "Leads");

			paramInstance.Add(GetNotificationDetailsParam.PAGE, 1);

			paramInstance.Add(GetNotificationDetailsParam.PER_PAGE, 2);

			//Call getNotificationDetails method
			APIResponse<ResponseHandler> response = notificationOperations.GetNotificationDetails(paramInstance);

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

						//Get the list of obtained Notification instances
						List<API.Notification.Notification> notifications = responseWrapper.Watch;

						foreach (API.Notification.Notification notification in notifications)
						{
							//Get the NotifyOnRelatedAction of each Notification
							Console.WriteLine("Notification NotifyOnRelatedAction: " + notification.NotifyOnRelatedAction);

							//Get the ChannelExpiry of each Notification
							Console.WriteLine("Notification ChannelExpiry: " + notification.ChannelExpiry);

							//Get the ResourceUri each Notification
							Console.WriteLine("Notification ResourceUri: " + notification.ResourceUri);

							//Get the ResourceId each Notification
							Console.WriteLine("Notification ResourceId: " + notification.ResourceId);

							//Get the NotifyUrl each Notification
							Console.WriteLine("Notification NotifyUrl: " + notification.NotifyUrl);

							//Get the ResourceName each Notification
							Console.WriteLine("Notification ResourceName: " + notification.ResourceName);

							//Get the ChannelId each Notification
							Console.WriteLine("Notification ChannelId: " + notification.ChannelId);

							//Get the events List of each Notification
							List<string> fields = notification.Events;

							//Check if fields is not null
							if (fields != null)
							{
								foreach (string fieldName in fields)
								{
									//Get the Events
									Console.WriteLine("Notification Events: " + fieldName);
								}
							}

							//Get the Token each Notification
							Console.WriteLine("Notification Token: " + notification.Token);
						}

						//Get the Object obtained Info instance
						Info info = responseWrapper.Info;

						//Check if info is not null
						if (info != null)
						{
							if (info.PerPage != null)
							{
								//Get the PerPage of the Info
								Console.WriteLine("Record Info PerPage: " + info.PerPage.ToString());
							}

							if (info.Count != null)
							{
								//Get the Count of the Info
								Console.WriteLine("Record Info Count: " + info.Count.ToString());
							}

							if (info.Page != null)
							{
								//Get the Page of the Info
								Console.WriteLine("Record Info Page: " + info.Page.ToString());
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
							Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine("Message: " + exception.Message.Value);
					}
				}
				else if (response.StatusCode != 204)
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
		
		/// <summary>
		/// This method is used to update Notifications and print the response.
		/// </summary>
		public static void UpdateNotifications()
		{
			//Get instance of NotificationOperations Class
			NotificationOperations notificationOperations = new NotificationOperations();

			//Get instance of BodyWrapper Class that will contain the request body
			BodyWrapper bodyWrapper = new BodyWrapper();

			//List of Notification instances
			List<API.Notification.Notification> notificationList = new List<API.Notification.Notification>();

			//Get instance of Notification Class
			API.Notification.Notification notification = new API.Notification.Notification();

            //Set ChannelId to the Notification instance
            notification.ChannelId = 1006800211;

            List<string> events = new List<string>();

			events.Add("Accounts.all");

            //To subscribe based on particular operations on given modules.
            notification.Events = events;

            //Set name to the Notification instance
            //notification.ChannelExpiry = DateTimeOffset.Now;

			//To ensure that the notification is sent from Zoho CRM, by sending back the given value in notification URL body.
			//By using this value, user can validate the notifications.
			//notification.Token = "TOKEN_FOR_VERIFICATION_OF_10068002";

            //URL to be notified (POST request)
            notification.NotifyUrl = "https://www.zohoapis.com";

            //Add Notification instance to the list
            notificationList.Add(notification);

			//Set the list to notification in BodyWrapper instance
			bodyWrapper.Watch = notificationList;

			//Call updateNotifications method that takes BodyWrapper instance as parameter
			APIResponse<ActionHandler> response = notificationOperations.UpdateNotifications(bodyWrapper);

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
						ActionWrapper actionWrapper = (ActionWrapper)actionHandler;

						//Get the list of obtained ActionResponse instances
						List<ActionResponse> actionResponses = actionWrapper.Watch;

						foreach (ActionResponse actionResponse in actionResponses)
						{
							//Check if the request is successful
							if (actionResponse is SuccessResponse)
							{
								//Get the received SuccessResponse instance
								SuccessResponse successResponse = (SuccessResponse)actionResponse;

								//Get the Status
								Console.WriteLine("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine("Code: " + successResponse.Code.Value);

								Console.WriteLine("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
								{
									if (entry.Value is IList && ((IList)entry.Value).Count > 0)
									{
										IList dataList = (IList)entry.Value;

										if (dataList.Count > 0 && dataList[0] is API.Notification.Notification)
										{
											List<API.Notification.Notification> eventList = (List<API.Notification.Notification>)dataList;

											foreach (API.Notification.Notification event1 in eventList)
											{
												//Get the ChannelExpiry of each Notification
												Console.WriteLine("Notification ChannelExpiry: " + event1.ChannelExpiry);

												//Get the ResourceUri each Notification
												Console.WriteLine("Notification ResourceUri: " + event1.ResourceUri);

												//Get the ResourceId each Notification
												Console.WriteLine("Notification ResourceId: " + event1.ResourceId);

												//Get the ResourceName each Notification
												Console.WriteLine("Notification ResourceName: " + event1.ResourceName);

												//Get the ChannelId each Notification
												Console.WriteLine("Notification ChannelId: " + event1.ChannelId);
											}
										}
									}
									else
									{
										//Get each value in the map
										Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
									}
								}

								//Get the Message
								Console.WriteLine("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is APIException)
							{
								//Get the received APIException instance
								APIException exception = (APIException)actionResponse;

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
					else if (actionHandler is APIException)
					{
						//Get the received APIException instance
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
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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

		/// <summary>
		/// This method is used to update single Notification and print the response.
		/// </summary>
		public static void UpdateNotification()
		{
			//Get instance of NotificationOperations Class
			NotificationOperations notificationOperations = new NotificationOperations();

			//Get instance of BodyWrapper Class that will contain the request body
			BodyWrapper bodyWrapper = new BodyWrapper();

			//List of Notification instances
			List<API.Notification.Notification> notificationList = new List<API.Notification.Notification>();

			//Get instance of Notification Class
			API.Notification.Notification notification = new API.Notification.Notification();

			//Set ChannelId to the Notification instance
			notification.ChannelId = 1006800211;

			List<string> events = new List<string>();

			events.Add("Deals.all");

            //To subscribe based on particular operations on given modules.
            notification.Events = events;

            //Set name to the Notification instance
            notification.ChannelExpiry = DateTimeOffset.Now;

            //To ensure that the notification is sent from Zoho CRM, by sending back the given value in notification URL body.
            //By using this value, user can validate the notifications.
            notification.Token = "TOKEN_FOR_VERIFICATION_OF_10068002";

            //URL to be notified (POST request)
            notification.NotifyUrl = "https://www.zohoapis.com";

            //Add Notification instance to the list
            notificationList.Add(notification);

			//Set the list to notification in BodyWrapper instance
			bodyWrapper.Watch = notificationList;

			//Call updateNotification method that takes BodyWrapper instance as parameters
			APIResponse<ActionHandler> response = notificationOperations.UpdateNotification(bodyWrapper);

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
						ActionWrapper actionWrapper = (ActionWrapper)actionHandler;

						//Get the list of obtained ActionResponse instances
						List<ActionResponse> actionResponses = actionWrapper.Watch;

						foreach (ActionResponse actionResponse in actionResponses)
						{
							//Check if the request is successful
							if (actionResponse is SuccessResponse)
							{
								//Get the received SuccessResponse instance
								SuccessResponse successResponse = (SuccessResponse)actionResponse;

								//Get the Status
								Console.WriteLine("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine("Code: " + successResponse.Code.Value);

								Console.WriteLine("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
								{
									if (entry.Value is IList && ((IList)entry.Value).Count > 0)
									{
										IList dataList = (IList)entry.Value;

										if (dataList.Count > 0 && dataList[0] is API.Notification.Notification)
										{
											List<API.Notification.Notification> eventList = (List<API.Notification.Notification>)dataList;

											foreach (API.Notification.Notification event1 in eventList)
											{
												//Get the ChannelExpiry of each Notification
												Console.WriteLine("Notification ChannelExpiry: " + event1.ChannelExpiry);

												//Get the ResourceUri each Notification
												Console.WriteLine("Notification ResourceUri: " + event1.ResourceUri);

												//Get the ResourceId each Notification
												Console.WriteLine("Notification ResourceId: " + event1.ResourceId);

												//Get the ResourceName each Notification
												Console.WriteLine("Notification ResourceName: " + event1.ResourceName);

												//Get the ChannelId each Notification
												Console.WriteLine("Notification ChannelId: " + event1.ChannelId);
											}
										}
									}
									else
									{
										//Get each value in the map
										Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));

									}
								}

								//Get the Message
								Console.WriteLine("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is APIException)
							{
								//Get the received APIException instance
								APIException exception = (APIException)actionResponse;

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
					else if (actionHandler is APIException)
					{
						//Get the received APIException instance
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
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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

		/// <summary>
		/// o stop all the instant notifications enabled by the user for a channel.
		/// </summary>
		/// <param name="channelIds">Specify the unique IDs of the notification channels to be disabled.</param>
		public static void DisableNotifications(List<long> channelIds)
		{
            //example
            //List<long> channelIds = new List<long>() { 34770615208001 };

            //Get instance of NotificationOperations Class
            NotificationOperations notificationOperations = new NotificationOperations();

			//Get instance of ParameterMap Class
			ParameterMap paramInstance = new ParameterMap();

			foreach (long id in channelIds)
			{
				paramInstance.Add(DisableNotificationsParam.CHANNEL_IDS, id);
			}

			//Call disableNotifications method that takes paramInstance as parameter 
			APIResponse<ActionHandler> response = notificationOperations.DisableNotifications(paramInstance);

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
						ActionWrapper actionWrapper = (ActionWrapper)actionHandler;

						//Get the list of obtained Notification instances
						List<ActionResponse> actionResponses = actionWrapper.Watch;

						foreach (ActionResponse actionResponse in actionResponses)
						{
							//Check if the request is successful
							if (actionResponse is SuccessResponse)
							{
								//Get the received SuccessResponse instance
								SuccessResponse successResponse = (SuccessResponse)actionResponse;

								//Get the Status
								Console.WriteLine("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine("Code: " + successResponse.Code.Value);

								Console.WriteLine("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
								{
									//Get each value in the map
									Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is APIException)
							{
								//Get the received APIException instance
								APIException exception = (APIException)actionResponse;

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
					else if (actionHandler is APIException)
					{
						//Get the received APIException instance
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
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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
		/// This method is used to disable notifications for the specified events in a channel.
		/// </summary>
		public static void DisableNotification()
		{
			//Get instance of NotificationOperations Class
			NotificationOperations notificationOperations = new NotificationOperations();

			//Get instance of BodyWrapper Class that will contain the request body
			BodyWrapper bodyWrapper = new BodyWrapper();

			//List of Notification instances
			List<API.Notification.Notification> notificationList = new List<API.Notification.Notification>();

			//Get instance of Notification Class
			API.Notification.Notification notification = new API.Notification.Notification();

            //Set ChannelId to the Notification instance
            notification.ChannelId = 1006800211;

            List<string> events = new List<string>();

			events.Add("Deals.edit");

            //To subscribe based on particular operations on given modules.
            notification.Events = events;

            notification.Deleteevents = true;

			//Add Notification instance to the list
			notificationList.Add(notification);

			//Set the list to notification in BodyWrapper instance
			bodyWrapper.Watch = notificationList;

			//Call disableNotification which takes BodyWrapper instance as parameter
			APIResponse<ActionHandler> response = notificationOperations.DisableNotification(bodyWrapper);

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
						ActionWrapper actionWrapper = (ActionWrapper)actionHandler;

						//Get the list of obtained ActionResponse instances
						List<ActionResponse> actionResponses = actionWrapper.Watch;

						foreach (ActionResponse actionResponse in actionResponses)
						{
							//Check if the request is successful
							if (actionResponse is SuccessResponse)
							{
								//Get the received SuccessResponse instance
								SuccessResponse successResponse = (SuccessResponse)actionResponse;

								//Get the Status
								Console.WriteLine("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine("Code: " + successResponse.Code.Value);

								Console.WriteLine("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
								{
									if (entry.Value is IList && ((IList)entry.Value).Count > 0)
									{
										IList dataList = (IList)entry.Value;

										if (dataList.Count > 0 && dataList[0] is API.Notification.Notification)
										{
											List<API.Notification.Notification> eventList = (List<API.Notification.Notification>)dataList;

											foreach (API.Notification.Notification event1 in eventList)
											{
												//Get the ChannelExpiry of each Notification
												Console.WriteLine("Notification ChannelExpiry: " + event1.ChannelExpiry);

												//Get the ResourceUri each Notification
												Console.WriteLine("Notification ResourceUri: " + event1.ResourceUri);

												//Get the ResourceId each Notification
												Console.WriteLine("Notification ResourceId: " + event1.ResourceId);

												//Get the ResourceName each Notification
												Console.WriteLine("Notification ResourceName: " + event1.ResourceName);

												//Get the ChannelId each Notification
												Console.WriteLine("Notification ChannelId: " + event1.ChannelId);
											}
										}
									}
									else
									{
										//Get each value in the map
										Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));

									}
								}

								//Get the Message
								Console.WriteLine("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is APIException)
							{
								//Get the received APIException instance
								APIException exception = (APIException)actionResponse;

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
					else if (actionHandler is APIException)
					{
						//Get the received APIException instance
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
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
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
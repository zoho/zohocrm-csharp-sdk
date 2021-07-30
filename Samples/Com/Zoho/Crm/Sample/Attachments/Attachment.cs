using System;

using System.Collections.Generic;

using System.IO;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Attachments;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Attachments.AttachmentsOperations;

using Info = Com.Zoho.Crm.API.Record.Info;

namespace Com.Zoho.Crm.Sample.Attachments
{
    public class Attachment 
	{
		/// <summary>
		/// This method is used to get a single record's attachments' details with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to get attachments</param>
		public static void GetAttachments (string moduleAPIName, long recordId) 
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations (moduleAPIName, recordId);

			//Get instance of ParameterMap Class
			ParameterMap paramInstance = new ParameterMap();

            paramInstance.Add(GetAttachmentsParam.PAGE, 1);

			paramInstance.Add(GetAttachmentsParam.PER_PAGE, 20);

			List<string> fields = new List<string>() { "Modified_Time", "File_Name", "Created_By" };

			foreach (string name in fields)
            {
				paramInstance.Add(GetAttachmentsParam.FIELDS, name);
			}

			//Call GetAttachments method
			APIResponse<API.Attachments.ResponseHandler> response = attachmentsOperations.GetAttachments(paramInstance);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code: " + response.StatusCode);

				if (new List<int>(){ 204, 304}.Contains (response.StatusCode))
                {
					Console.WriteLine (response.StatusCode == 204 ? "No Content" : "Not Modified");

					return;
				}

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ResponseHandler responseHandler = response.Object;

					if (responseHandler is API.Attachments.ResponseWrapper) 
					{
                        //Get the received ResponseWrapper instance
                        API.Attachments.ResponseWrapper responseWrapper = (API.Attachments.ResponseWrapper) responseHandler;

						//Get the list of obtained Attachment instances
						List<Com.Zoho.Crm.API.Attachments.Attachment> attachments = responseWrapper.Data;

						foreach (Com.Zoho.Crm.API.Attachments.Attachment attachment in attachments)
                        {
							//Get the owner User instance of each attachment
							User owner = attachment.Owner;

							//Check if owner is not null
							if (owner != null)
                            {
								//Get the Name of the Owner
								Console.WriteLine ("Attachment Owner User-Name: " + owner.Name);

								//Get the ID of the Owner
								Console.WriteLine ("Attachment Owner User-ID: " + owner.Id);

								//Get the Email of the Owner
								Console.WriteLine ("Attachment Owner User-Email: " + owner.Email);
							}

							//Get the modified time of each attachment
							Console.WriteLine ("Attachment Modified Time: " + attachment.ModifiedTime.ToString());

							//Get the name of the File
							Console.WriteLine ("Attachment File Name: " + attachment.FileName);

							//Get the created time of each attachment
							Console.WriteLine ("Attachment Created Time: " + attachment.CreatedTime.ToString());

							//Get the Attachment file size
							Console.WriteLine ("Attachment File Size: " + attachment.Size.ToString());

							//Get the parentId Record instance of each attachment
							Com.Zoho.Crm.API.Record.Record parentId = attachment.ParentId;

							//Check if parentId is not null
							if (parentId != null)
                            {
								//Get the parent record Name of each attachment
								Console.WriteLine ("Attachment parent record Name: " + parentId.GetKeyValue("name"));

								//Get the parent record ID of each attachment
								Console.WriteLine ("Attachment parent record ID: " + parentId.Id);
							}

							//Get the attachment is Editable
							Console.WriteLine ("Attachment is Editable: " + attachment.Editable.ToString());

							//Get the file ID of each attachment
							Console.WriteLine ("Attachment File ID: " + attachment.FileId);

							//Get the type of each attachment
							Console.WriteLine ("Attachment File Type: " + attachment.Type);

							//Get the seModule of each attachment
							Console.WriteLine ("Attachment seModule: " + attachment.SeModule);

							//Get the modifiedBy User instance of each attachment
							User modifiedBy = attachment.ModifiedBy;

							//Check if modifiedBy is not null
							if (modifiedBy != null)
                            {
								//Get the Name of the modifiedBy User
								Console.WriteLine ("Attachment Modified By User-Name: " + modifiedBy.Name);

								//Get the ID of the modifiedBy User
								Console.WriteLine ("Attachment Modified By User-ID: " + modifiedBy.Id);

								//Get the Email of the modifiedBy User
								Console.WriteLine ("Attachment Modified By User-Email: " + modifiedBy.Email);
							}

							//Get the state of each attachment
							Console.WriteLine ("Attachment State: " + attachment.State);

							//Get the ID of each attachment
							Console.WriteLine ("Attachment ID: " + attachment.Id);

							//Get the createdBy User instance of each attachment
							User createdBy = attachment.CreatedBy;

							//Check if createdBy is not null
							if (createdBy != null)
                            {
								//Get the name of the createdBy User
								Console.WriteLine ("Attachment Created By User-Name: " + createdBy.Name);

								//Get the ID of the createdBy User
								Console.WriteLine ("Attachment Created By User-ID: " + createdBy.Id);

								//Get the Email of the createdBy User
								Console.WriteLine ("Attachment Created By User-Email: " + createdBy.Email);
							}

							//Get the linkUrl of each attachment
							Console.WriteLine ("Attachment LinkUrl: " + attachment.LinkUrl);
						}

						//Get the Object obtained Info instance
						Info info = responseWrapper.Info;
						
						//Check if info is not null
						if(info != null)
						{
							if(info.PerPage != null)
							{
								//Get the PerPage of the Info
								Console.WriteLine ("Record Info PerPage: " + info.PerPage.ToString());
							}
							
							if(info.Count != null)
							{
								//Get the Count of the Info
								Console.WriteLine ("Record Info Count: " + info.Count.ToString());
							}
		
							if(info.Page != null)
							{
								//Get the Page of the Info
								Console.WriteLine ("Record Info Page: " + info.Page.ToString());
							}
							
							if(info.MoreRecords != null)
							{
								//Get the MoreRecords of the Info
								Console.WriteLine ("Record Info MoreRecords: " + info.MoreRecords.ToString());
							}
						}
					}
					//Check if the request returned an exception
					else if (responseHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) responseHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						//Get the details map
						foreach (KeyValuePair<string, object> entry in exception.Details)
                        {
							//Get each value in the map
							Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
					}
				}
				else
				{ //If response is not as expected

					//Get model object from response
					Model responseObject = response.Model;
					
					if(responseObject != null)
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

		/// <summary>
		/// This method is used to upload an attachment to a single record of a module with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to upload attachment</param>
		/// <param name="absoluteFilePath">The absolute file path of the file to be attached</param>
		public static void UploadAttachments (string moduleAPIName, long recordId, string absoluteFilePath)
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;
			//string absoluteFilePath = "/Users/use_name/Desktop/image.png";

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations(moduleAPIName, recordId);

			//Get instance of FileBodyWrapper class that will contain the request file
			API.Attachments.FileBodyWrapper fileBodyWrapper = new API.Attachments.FileBodyWrapper();

			//Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
			StreamWrapper streamWrapper = new StreamWrapper (absoluteFilePath);

			//Set file to the FileBodyWrapper instance
			fileBodyWrapper.File = streamWrapper;

			//Call UploadAttachment method that takes FileBodyWrapper instance as parameter
			APIResponse<API.Attachments.ActionHandler> response = attachmentsOperations.UploadAttachment (fileBodyWrapper);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ActionHandler actionHandler = response.Object;

					if (actionHandler is API.Attachments.ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        API.Attachments.ActionWrapper actionWrapper = (API.Attachments.ActionWrapper) actionHandler;

						//Get the list of obtained action responses
						List<API.Attachments.ActionResponse> actionResponses = actionWrapper.Data;

						foreach (API.Attachments.ActionResponse actionResponse in actionResponses)
                        {
							//Check if the request is successful
							if (actionResponse is API.Attachments.SuccessResponse)
                            {
                                //Get the received SuccessResponse instance
                                API.Attachments.SuccessResponse successResponse = (API.Attachments.SuccessResponse) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + successResponse.Code.Value);

								Console.WriteLine ("Details: ");

								if (successResponse.Details != null)
                                {
									//Get the details map
									foreach (KeyValuePair<string, object> entry in successResponse.Details)
                                    {
										//Get each value in the map
										Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
									}
								}

								//Get the Message
								Console.WriteLine ("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is API.Attachments.APIException)
                            {
                                //Get the received APIException instance
                                API.Attachments.APIException exception = (API.Attachments.APIException) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + exception.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + exception.Code.Value);

								Console.WriteLine ("Details: ");

								if (exception.Details != null)
                                {
									//Get the details map
									foreach (KeyValuePair<string, object> entry in exception.Details)
                                    {
										//Get each value in the map
										Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
									}
								}

								//Get the Message
								Console.WriteLine ("Message: " + exception.Message.Value);
							}
						}
					}
					//Check if the request returned an exception
					else if (actionHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) actionHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						if (exception.Details != null)
                        {
							//Get the details map
							foreach (KeyValuePair<string, object> entry in exception.Details)
                            {
								//Get each value in the map
								Console.WriteLine (entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
							}
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
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
		/// This method is used to Delete attachments to a single record of a module with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to delete attachment</param>
		/// <param name="attachmentIds">The List of attachment IDs to be deleted</param>
		public static void DeleteAttachments (string moduleAPIName, long recordId, List<long> attachmentIds)
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;
			//List<long> attachmentIds = new List<long>() { 34770615979001, 34770615968003, 34770615961010 };

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations(moduleAPIName, recordId);

			//Get instance of ParameterMap Class
			ParameterMap paramInstance = new ParameterMap();

			foreach (long attachmentId in attachmentIds)
            {
				paramInstance.Add(DeleteAttachmentsParam.IDS, attachmentId);
			}

			//Call DeleteAttachments method that takes paramInstance as parameter
			APIResponse<API.Attachments.ActionHandler> response = attachmentsOperations.DeleteAttachments (paramInstance);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ActionHandler actionHandler = response.Object;

					if (actionHandler is API.Attachments.ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        API.Attachments.ActionWrapper actionWrapper = (API.Attachments.ActionWrapper) actionHandler;

						//Get the list of obtained Attachment Record instances
						List<API.Attachments.ActionResponse> actionResponses = actionWrapper.Data;

						foreach (API.Attachments.ActionResponse actionResponse in actionResponses)
                        {
							//Check if the request is successful
							if (actionResponse is API.Attachments.SuccessResponse)
                            {
                                //Get the received SuccessResponse instance
                                API.Attachments.SuccessResponse successResponse = (API.Attachments.SuccessResponse) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + successResponse.Code.Value);

								Console.WriteLine ("Details: ");

								if (successResponse.Details != null)
                                {
									//Get the details map
									foreach (KeyValuePair<string, object> entry in successResponse.Details)
                                    {
										//Get each value in the map
										Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
									}
								}

								//Get the Message
								Console.WriteLine ("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is API.Attachments.APIException)
                            {
                                //Get the received APIException instance
                                API.Attachments.APIException exception = (API.Attachments.APIException) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + exception.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + exception.Code.Value);

								Console.WriteLine ("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in exception.Details)
                                {
									//Get each value in the map
									Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine ("Message: " + exception.Message.Value);
							}
						}
					}
					//Check if the request returned an exception
					else if (actionHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) actionHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						//Get the details map
						foreach (KeyValuePair<string, object> entry in exception.Details)
                        {
							//Get each value in the map
							Console.WriteLine (entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
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
		/// This method is used to download an attachment of a single record of a module with ID and attachment ID and write the file in the specified destination.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to download attachment</param>
		/// <param name="attachmentId">The ID of the attachment to be downloaded</param>
		/// <param name="destinationFolder">The absolute path of the destination folder to store the attachment</param>
		public static void DownloadAttachment (string moduleAPIName, long recordId, long attachmentId, string destinationFolder)
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;
			//long attachmentId = 34770615177023;
			//string destinationFolder = "/Users/user_name/Desktop";

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations(moduleAPIName, recordId);

			//Call DownloadAttachment method that takes attachmentId as parameters
			APIResponse<API.Attachments.ResponseHandler> response = attachmentsOperations.DownloadAttachment (attachmentId);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code : " + response.StatusCode);

				if (response.StatusCode == 204)
                {
					Console.WriteLine ("No Content");

					return;
				}

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ResponseHandler responseHandler = response.Object;

					if (responseHandler is API.Attachments.FileBodyWrapper)
                    {
                        //Get the received FileBodyWrapper instance
                        API.Attachments.FileBodyWrapper fileBodyWrapper = (API.Attachments.FileBodyWrapper) responseHandler;

						//Get StreamWrapper instance from the returned FileBodyWrapper instance
						StreamWrapper streamWrapper = fileBodyWrapper.File;

						//Get Stream from the response
						Stream file = streamWrapper.Stream;

						string fullFilePath = Path.Combine(destinationFolder, streamWrapper.Name);

						using (FileStream outputFileStream = new FileStream(fullFilePath, FileMode.Create))
						{
							file.CopyTo(outputFileStream);
						}
					}
					//Check if the request returned an exception
					else if (responseHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) responseHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						//Get the details map
						foreach (KeyValuePair<string, object> entry in exception.Details)
						{
							//Get each value in the map
							Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
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
		/// This method is used to delete an attachment to a single record of a module with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to delete attachment</param>
		/// <param name="attachmentId">The ID of the attachment to be deleted</param>
		public static void DeleteAttachment (string moduleAPIName, long recordId, long attachmentId)
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;
			//long attachmentId = "34770615177002";

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations(moduleAPIName, recordId);

			//Call deleteAttachment method that takes attachmentId as parameter
			APIResponse<API.Attachments.ActionHandler> response = attachmentsOperations.DeleteAttachment (attachmentId);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ActionHandler actionHandler = response.Object;

					if (actionHandler is API.Attachments.ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        API.Attachments.ActionWrapper actionWrapper = (API.Attachments.ActionWrapper) actionHandler;

						//Get the list of obtained Action Response instances
						List<API.Attachments.ActionResponse> actionResponses = actionWrapper.Data;

						foreach (API.Attachments.ActionResponse actionResponse in actionResponses)
                        {
							//Check if the request is successful
							if (actionResponse is API.Attachments.SuccessResponse)
                            {
                                //Get the received SuccessResponse instance
                                API.Attachments.SuccessResponse successResponse = (API.Attachments.SuccessResponse) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + successResponse.Code.Value);

								Console.WriteLine ("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
                                {
									//Get each value in the map
									Console.WriteLine (entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine ("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is API.Attachments.APIException)
                            {
                                //Get the received APIException instance
                                API.Attachments.APIException exception = (API.Attachments.APIException) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + exception.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + exception.Code.Value);

								Console.WriteLine ("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in exception.Details)
								{
									//Get each value in the map
									Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine ("Message: " + exception.Message.Value);
							}
						}
					}
					//Check if the request returned an exception
					else if (actionHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) actionHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						//Get the details map
						foreach (KeyValuePair<string, object> entry in exception.Details)
						{
							//Get each value in the map
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
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
		/// This method is used to upload link attachment to a single record of a module with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to upload Link attachment</param>
		/// <param name="attachmentURL">The attachmentURL of the doc or image link to be attached</param>
		public static void UploadLinkAttachments (string moduleAPIName, long recordId, string attachmentURL)
		{
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770615177002;
			//string attachmentURL = "https://5.imimg.com/data5/KJ/UP/MY-8655440/zoho-crm-500x500.png";

			//Get instance of AttachmentsOperations Class that takes moduleAPIName and recordId as parameter
			AttachmentsOperations attachmentsOperations = new AttachmentsOperations(moduleAPIName, recordId);

			//Get instance of ParameterMap Class
			ParameterMap paramInstance = new ParameterMap();

			paramInstance.Add(UploadLinkAttachmentParam.ATTACHMENTURL, attachmentURL);

			//Call UploadLinkAttachment method that takes paramInstance as parameter
			APIResponse<API.Attachments.ActionHandler> response = attachmentsOperations.UploadLinkAttachment (paramInstance);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine ("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.Attachments.ActionHandler actionHandler = response.Object;

					if (actionHandler is API.Attachments.ActionWrapper)
                    {
                        //Get the received ActionWrapper instance
                        API.Attachments.ActionWrapper actionWrapper = (API.Attachments.ActionWrapper) actionHandler;

						//Get the list of obtained Action Response instances
						List<API.Attachments.ActionResponse> actionResponses = actionWrapper.Data;

						foreach (API.Attachments.ActionResponse actionResponse in actionResponses)
                        {
							//Check if the request is successful
							if (actionResponse is API.Attachments.SuccessResponse)
                            {
                                //Get the received SuccessResponse instance
                                API.Attachments.SuccessResponse successResponse = (API.Attachments.SuccessResponse) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + successResponse.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + successResponse.Code.Value);

								Console.WriteLine ("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in successResponse.Details)
								{
									//Get each value in the map
									Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine ("Message: " + successResponse.Message.Value);
							}
							//Check if the request returned an exception
							else if (actionResponse is API.Attachments.APIException)
                            {
                                //Get the received APIException instance
                                API.Attachments.APIException exception = (API.Attachments.APIException) actionResponse;

								//Get the Status
								Console.WriteLine ("Status: " + exception.Status.Value);

								//Get the Code
								Console.WriteLine ("Code: " + exception.Code.Value);

								Console.WriteLine ("Details: ");

								//Get the details map
								foreach (KeyValuePair<string, object> entry in exception.Details)
								{
									//Get each value in the map
									Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
								}

								//Get the Message
								Console.WriteLine ("Message: " + exception.Message.Value);
							}
						}
					}
					//Check if the request returned an exception
					else if (actionHandler is API.Attachments.APIException)
                    {
                        //Get the received APIException instance
                        API.Attachments.APIException exception = (API.Attachments.APIException) actionHandler;

						//Get the Status
						Console.WriteLine ("Status: " + exception.Status.Value);

						//Get the Code
						Console.WriteLine ("Code: " + exception.Code.Value);

						Console.WriteLine ("Details: ");

						//Get the details map
						foreach (KeyValuePair<string, object> entry in exception.Details)
						{
							//Get each value in the map
							Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
						}

						//Get the Message
						Console.WriteLine ("Message: " + exception.Message.Value);
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
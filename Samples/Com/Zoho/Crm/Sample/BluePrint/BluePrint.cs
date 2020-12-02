using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.BluePrint;

using Com.Zoho.Crm.API.Fields;

using Com.Zoho.Crm.API.Layouts;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

namespace Com.Zoho.Crm.Sample.BluePrint
{
	public class BluePrint
    {
		/// <summary>
		/// This method is used to get a single record's Blueprint details with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to get Blueprint</param>
		public static void GetBlueprint (string moduleAPIName, long recordId)
        {
			//example
			//string moduleAPIName = "Leads";
			//long recordId = 34770614381002;

			//Get instance of BluePrintOperations Class that takes recordId and moduleAPIName as parameter
			BluePrintOperations bluePrintOperations = new BluePrintOperations (recordId, moduleAPIName);

			//Call GetBlueprint method
			APIResponse<API.BluePrint.ResponseHandler> response = bluePrintOperations.GetBlueprint();

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
                    API.BluePrint.ResponseHandler responseHandler = response.Object;

					if (responseHandler is API.BluePrint.ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        API.BluePrint.ResponseWrapper responseWrapper = (API.BluePrint.ResponseWrapper) responseHandler;

						//Get the obtained BluePrint instance
						API.BluePrint.BluePrint bluePrint = responseWrapper.Blueprint;

						//Get the ProcessInfo instance of the obtained BluePrint
						ProcessInfo processInfo = bluePrint.ProcessInfo;
						
						//Check if ProcessInfo is not null
						if (processInfo != null)
                        {
							//Get the Field ID of the ProcessInfo
							Console.WriteLine("ProcessInfo Field-ID: " + processInfo.FieldId);

							//Get the isContinuous of the ProcessInfo
							Console.WriteLine("ProcessInfo isContinuous: " + processInfo.IsContinuous);

							//Get the API Name of the ProcessInfo
							Console.WriteLine("ProcessInfo API Name: " + processInfo.APIName);

							//Get the Continuous of the ProcessInfo
							Console.WriteLine("ProcessInfo Continuous: " + processInfo.Continuous);

							//Get the FieldLabel of the ProcessInfo
							Console.WriteLine("ProcessInfo FieldLabel: " + processInfo.FieldLabel);

							//Get the Name of the ProcessInfo
							Console.WriteLine("ProcessInfo Name: " + processInfo.Name);

							//Get the ColumnName of the ProcessInfo
							Console.WriteLine("ProcessInfo ColumnName: " + processInfo.ColumnName);

							//Get the FieldValue of the ProcessInfo
							Console.WriteLine("ProcessInfo FieldValue: " + processInfo.FieldValue);

							//Get the ID of the ProcessInfo
							Console.WriteLine("ProcessInfo ID: " + processInfo.Id);

							//Get the FieldName of the ProcessInfo
							Console.WriteLine("ProcessInfo FieldName: " + processInfo.FieldName);

							//Get the Escalation of the ProcessInfo
							Console.WriteLine("ProcessInfo Escalation: " + processInfo.Escalation);
						}

						//Get the list of transitions from BluePrint instance
						List<Transition> transitions = bluePrint.Transitions;

						foreach (Transition transition in transitions)
                        {
							List<NextTransition> nextTransitions = transition.NextTransitions;

							foreach (NextTransition nextTransition in nextTransitions)
                            {
								//Get the ID of the NextTransition
								Console.WriteLine("NextTransition ID: " + nextTransition.Id);

								//Get the Name of the NextTransition
								Console.WriteLine("NextTransition Name: " + nextTransition.Name);
							}

							//Get the PercentPartialSave of each Transition
							Console.WriteLine("Transition PercentPartialSave: " + transition.PercentPartialSave);

							Com.Zoho.Crm.API.Record.Record data = transition.Data;

							//Get the ID of each record
							Console.WriteLine("Record ID: " + data.Id);

							//Get the createdBy User instance of each record
							User createdBy = data.CreatedBy;

							if (createdBy != null)
                            {
								//Get the ID of the createdBy User
								Console.WriteLine("Record Created By User-ID: " + createdBy.Id);

								//Get the name of the createdBy User
								Console.WriteLine("Record Created By User-Name: " + createdBy.Name);
							}

							//Check if the created time is not null
							if (data.CreatedTime != null)
                            {
								//Get the created time of each record
								Console.WriteLine("Record Created Time: " + data.CreatedTime.ToString());
							}

							//Check if the modified time is not null
							if (data.ModifiedTime != null)
                            {
								//Get the modified time of each record
								Console.WriteLine("Record Modified Time: " + data.ModifiedTime.ToString());
							}

							//Get the modifiedBy User instance of each record
							User modifiedBy = data.ModifiedBy;

							//Check if modifiedByUser is not null
							if (modifiedBy != null)
                            {
								//Get the ID of the modifiedBy User
								Console.WriteLine("Record Modified By User-ID: " + modifiedBy.Id);

								//Get the name of the modifiedBy User
								Console.WriteLine("Record Modified By user-Name: " + modifiedBy.Name);
							}

							//Get all entries from the keyValues map
							foreach (KeyValuePair<string, object> entry in data.GetKeyValues())
							{
								//Get each value in the map
								Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
							}

							//Get the NextFieldValue of the Transition
							Console.WriteLine("Transition NextFieldValue: " + transition.NextFieldValue);

							//Get the Name of each Transition
							Console.WriteLine("Transition Name: " + transition.Name);

							//Get the CriteriaMatched of the Transition
							Console.WriteLine("Transition CriteriaMatched: " + transition.CriteriaMatched.ToString());

							//Get the ID of the Transition
							Console.WriteLine("Transition ID: " + transition.Id);

							Console.WriteLine("Transition Fields: ");

							List<Field> fields = transition.Fields;

							foreach (Field field in fields)
                            {
								//Get the webhook of each Field
								Console.WriteLine("Transition Fields Webhook: " + field.Webhook);

								//Get the JsonType of each Field
								Console.WriteLine("Transition Fields JsonType: " + field.JsonType);

								//Get the DisplayLabel of each Field
								Console.WriteLine("Transition Fields DisplayLabel: " + field.DisplayLabel);

								//Get the ValidationRule of each Field
								Console.WriteLine("Transition Fields ValidationRule: " + field.ValidationRule);

								//Get the DataType of each Field
								Console.WriteLine("Transition Fields DataType: " + field.DataType);

								//Get the ColumnName of each Field
								Console.WriteLine("Transition Fields ColumnName: " + field.ColumnName);

								//Get the PersonalityName of each Field
								Console.WriteLine("Transition Fields PersonalityName: " + field.PersonalityName);

								//Get the ID of each Field
								Console.WriteLine("Transition Fields ID: " + field.Id);

								//Get the TransitionSequence of each Field
								Console.WriteLine("Transition Fields TransitionSequence: " + field.TransitionSequence.ToString());

								if(field.Mandatory != null)
								{
									//Get the Mandatory of each Field
									Console.WriteLine("Transition Fields Mandatory: " + field.Mandatory.ToString());
								}

								Layout layout = field.Layouts;

								if (layout != null) 
								{
									//Get the ID of the Layout
									Console.WriteLine("Transition Fields Layout ID: " + layout.Id);

									//Get the name of the Layout
									Console.WriteLine("Transition Fields Layout Name: " + layout.Name);
								}

								//Get the APIName of each Field
								Console.WriteLine("Transition Fields APIName: " + field.APIName);

								//Get the Content of each Field
								Console.WriteLine("Transition Fields Content: " + field.Content);

								if(field.SystemMandatory != null)
								{
									//Get the SystemMandatory of each Field
									Console.WriteLine("Transition Fields SystemMandatory: " + field.SystemMandatory.ToString());
								}

								//Get the Crypt of each Field
								Console.WriteLine("Transition Fields Crypt: " + field.Crypt);

								//Get the FieldLabel of each Field
								Console.WriteLine("Transition Fields FieldLabel: " + field.FieldLabel);

								//Get the Tooltip of each Field
								ToolTip toolTip = field.Tooltip;

								if (toolTip != null)
                                {
									//Get the Tooltip Name
									Console.WriteLine("Transition Fields Tooltip Name: " + toolTip.Name);

									//Get the Tooltip Value
									Console.WriteLine("Transition Fields Tooltip Value: " + toolTip.Value);
								}

								//Get the CreatedSource of each Field
								Console.WriteLine("Transition Fields CreatedSource: " + field.CreatedSource);

								if(field.FieldReadOnly != null)
								{
									//Get the FieldReadOnly of each Field
									Console.WriteLine("Transition Fields FieldReadOnly: " + field.FieldReadOnly.ToString());
								}

								if(field.ReadOnly != null)
								{
									//Get the ReadOnly of each Field
									Console.WriteLine("Transition Fields ReadOnly: " + field.ReadOnly.ToString());
								}
								
								//Get the AssociationDetails of each Field
								Console.WriteLine("Transition Fields AssociationDetails: " + field.AssociationDetails);

								if(field.QuickSequenceNumber != null)
								{
									//Get the QuickSequenceNumber of each Field
									Console.WriteLine("Transition Fields QuickSequenceNumber: " + field.QuickSequenceNumber.ToString());
								}

								if(field.CustomField != null)
								{
									//Get the CustomField of each Field
									Console.WriteLine("Transition Fields CustomField: " + field.CustomField.ToString());
								}

								if(field.Visible != null)
								{
									//Get the Visible of each Field
									Console.WriteLine("Transition Fields Visible: " + field.Visible.ToString());
								}

								if(field.Length != null)
								{
									//Get the Length of each Field
									Console.WriteLine("Transition Fields Length: " + field.Length.ToString());
								}
								
								//Get the DecimalPlace of each Field
								Console.WriteLine("Transition Fields DecimalPlace: " + field.DecimalPlace);

								ViewType viewType = field.ViewType;

								if (viewType != null)
                                {
									//Get the View of the ViewType
									Console.WriteLine(" Transition Fields View: " + viewType.View.ToString());

									//Get the Edit of the ViewType
									Console.WriteLine("Transition Fields Edit: " + viewType.Edit.ToString());

									//Get the Create of the ViewType
									Console.WriteLine("Transition Fields Create: " + viewType.Create.ToString());

									//Get the View of the ViewType
									Console.WriteLine("Transition Fields QuickCreate: " + viewType.QuickCreate.ToString());
								}

								List<PickListValue> pickListValues = field.PickListValues;

								if (pickListValues != null)
                                {
									foreach (PickListValue pickListValue in pickListValues)
                                    {
										//Get the DisplayValue of each PickListValues
										Console.WriteLine("Transition Fields DisplayValue: " + pickListValue.DisplayValue);

										//Get the SequenceNumber of each PickListValues
										Console.WriteLine("Transition Fields SequenceNumber: " + pickListValue.SequenceNumber.ToString());

										//Get the ExpectedDataType of each PickListValues
										Console.WriteLine("Transition Fields ExpectedDataType: " + pickListValue.ExpectedDataType);

										//Get the ActualValue of each PickListValues
										Console.WriteLine("Transition Fields ActualValue: " + pickListValue.ActualValue);

										foreach (object map in pickListValue.Maps)
                                        {
											//Get each value from the map
											Console.WriteLine(map);
										}
									}
								}

								//Get all entries from the MultiSelectLookup instance
								MultiSelectLookup multiSelectLookup = field.Multiselectlookup;

								if (multiSelectLookup != null) 
								{
									//Get the DisplayValue of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup DisplayLabel: " + multiSelectLookup.DisplayLabel);

									//Get the LinkingModule of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup LinkingModule: " + multiSelectLookup.LinkingModule);

									//Get the LookupAPIname of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup LookupAPIname: " + multiSelectLookup.LookupApiname);

									//Get the APIName of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup APIName: " + multiSelectLookup.APIName);

									//Get the ConnectedlookupAPIname of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup ConnectedlookupAPIname: " + multiSelectLookup.ConnectedlookupApiname);

									//Get the ID of the MultiSelectLookup
									Console.WriteLine("Transition Fields MultiSelectLookup ID: " + multiSelectLookup.Id);
								}

								//Get the AutoNumber of each Field
								AutoNumber autoNumber = field.AutoNumber;

								if (autoNumber != null)
                                {
									//Get the Prefix of the AutoNumber
									Console.WriteLine("Transition Fields AutoNumber Prefix: " + autoNumber.Prefix);

									//Get the Suffix of the AutoNumber
									Console.WriteLine("Transition Fields AutoNumber Suffix: " + autoNumber.Suffix);

									if(autoNumber.StartNumber != null)
									{
										//Get the StartNumber of the AutoNumber
										Console.WriteLine("Transition Fields AutoNumber StartNumber: " + autoNumber.StartNumber.ToString());
									}
								}

								//Get the ConvertMapping of each Field
								Console.WriteLine("Transition Fields ConvertMapping: ");

								if(field.ConvertMapping != null)
								{
									//Get the details map
									foreach (KeyValuePair<string, object> entry in field.ConvertMapping)
									{
										//Get each value in the map
										Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
									}
								}
							}

							//Get the CriteriaMessage of each Transition
							Console.WriteLine("Transition CriteriaMessage: " + transition.CriteriaMessage);

							//Get the Type of each Transition
							Console.WriteLine("Transition Type: " + transition.Type);

							//Get the ExecutionTime of each Transition
							Console.WriteLine("Transition ExecutionTime: " + transition.ExecutionTime);
						}
					}
					//Check if the request returned an exception
					else if (responseHandler is API.BluePrint.APIException)
                    {
                        //Get the received APIException instance
                        API.BluePrint.APIException exception = (API.BluePrint.APIException) responseHandler;

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
		/// This method is used to update a single record's Blueprint details with ID and print the response.
		/// </summary>
		/// <param name="moduleAPIName">The API Name of the record's module</param>
		/// <param name="recordId">The ID of the record to Get Blueprint</param>
		/// <param name="transitionId">The ID of the Blueprint transition Id</param>
		public static void UpdateBlueprint (string moduleAPIName, long recordId, long transitionId)
		{
			//ID of the BluePrint to be updated
			//string moduleAPIName = "Leads";
			//long recordId = 34770614381002;
			//long transitionId = 34770610173096;

			//Get instance of BluePrintOperations Class that takes recordId and moduleAPIName as parameter
			BluePrintOperations bluePrintOperations = new BluePrintOperations (recordId, moduleAPIName);

            //Get instance of BodyWrapper Class that will contain the request body
            API.BluePrint.BodyWrapper bodyWrapper = new API.BluePrint.BodyWrapper();

			//List of BluePrint instances
			List<API.BluePrint.BluePrint> bluePrintList = new List<API.BluePrint.BluePrint>();

			//Get instance of BluePrint Class
			API.BluePrint.BluePrint bluePrint = new API.BluePrint.BluePrint();

            //Set transition_id to the BluePrint instance
            bluePrint.TransitionId = transitionId;

            //Get instance of Record Class
            Com.Zoho.Crm.API.Record.Record data = new Com.Zoho.Crm.API.Record.Record();

			Dictionary<string, object> lookup = new Dictionary<string, object>();

			lookup.Add("Phone", "8940372937");

			lookup.Add("id", "8940372937");

            //data.AddKeyValue("Lookup_2", lookup);

            data.AddKeyValue("Phone", "8940372937");

			data.AddKeyValue("Notes", "Updated via blueprint");

			Dictionary<string, object> attachments = new Dictionary<string, object>();

			List<string> fileIds = new List<string>();
			
			fileIds.Add("blojtd2d13b5f044e4041a3315e0793fb21ef");
			
			attachments.Add("$file_id", fileIds);
			
			//data.AddKeyValue("Attachments", attachments);

			List<Dictionary<string, object>> checkLists = new List<Dictionary<string, object>>();

			Dictionary<string, object> checkListItem = new Dictionary<string, object>();
			
			checkListItem.Add("list 1", true);
			
			checkLists.Add(checkListItem);
			
			checkListItem = new Dictionary<string, object>();
			
			checkListItem.Add("list 2", true);
			
			checkLists.Add(checkListItem);
			
			checkListItem = new Dictionary<string, object>();
			
			checkListItem.Add("list 3", true);
			
			checkLists.Add(checkListItem);
			
			//data.AddKeyValue("CheckLists", checkLists);

            //Set data to the BluePrint instance
            bluePrint.Data = data;

            //Add BluePrint instance to the list
            bluePrintList.Add(bluePrint);

			//Set the list to bluePrint in BodyWrapper instance
			bodyWrapper.Blueprint = bluePrintList;

			//Call UpdateBlueprint method that takes BodyWrapper instance 
			APIResponse<API.BluePrint.ActionResponse> response = bluePrintOperations.UpdateBlueprint(bodyWrapper);

			if (response != null)
            {
				//Get the status code from response
				Console.WriteLine("Status Code: " + response.StatusCode);

				//Check if expected response is received
				if (response.IsExpected)
                {
                    //Get object from response
                    API.BluePrint.ActionResponse actionResponse = response.Object;

					//Check if the request is successful
					if (actionResponse is API.BluePrint.SuccessResponse)
                    {
                        //Get the received SuccessResponse instance
                        API.BluePrint.SuccessResponse successResponse = (API.BluePrint.SuccessResponse) actionResponse;

						//Get the Status
						Console.WriteLine("Status: " + successResponse.Status.Value);

						//Get the Code
						Console.WriteLine("Code: " + successResponse.Code.Value);

						Console.WriteLine("Details: ");

						if (successResponse.Details != null)
                        {
							//Get the details map
							foreach (KeyValuePair<string, object> entry in successResponse.Details)
							{
								//Get each value in the map
								Console.WriteLine(entry.Key + " : " + JsonConvert.SerializeObject(entry.Value));
							}
						}

						//Get the Message
						Console.WriteLine("Message: " + successResponse.Message.Value);
					}
					//Check if the request returned an exception
					else if (actionResponse is API.BluePrint.APIException)
                    {
                        //Get the received APIException instance
                        API.BluePrint.APIException exception = (API.BluePrint.APIException) actionResponse;

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
	}
}
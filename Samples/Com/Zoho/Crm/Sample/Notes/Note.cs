using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Attachments;

using Com.Zoho.Crm.API.Notes;

using Com.Zoho.Crm.API.Record;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Notes.NotesOperations;

using ActionHandler = Com.Zoho.Crm.API.Notes.ActionHandler;

using ActionResponse = Com.Zoho.Crm.API.Notes.ActionResponse;

using ActionWrapper = Com.Zoho.Crm.API.Notes.ActionWrapper;

using APIException = Com.Zoho.Crm.API.Notes.APIException;

using BodyWrapper = Com.Zoho.Crm.API.Notes.BodyWrapper;

using Info = Com.Zoho.Crm.API.Notes.Info;

using ResponseHandler = Com.Zoho.Crm.API.Notes.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Notes.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.Notes.SuccessResponse;

namespace Com.Zoho.Crm.Sample.Notes
{
    public class Note
    {
        /// <summary>
        /// This method is used to get the list of notes and print the response.
        /// </summary>
        public static void GetNotes()
        {
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetNotesParam.PAGE, 1);

            //paramInstance.Add(GetNotesParam.PER_PAGE, 1);

            paramInstance.Add(GetNotesParam.FIELDS, "Note_Title,Note_Content");

            //Get instance of HeaderMap Class
            HeaderMap headerInstance = new HeaderMap();

            DateTimeOffset ifModifiedSince = new DateTimeOffset(new DateTime(2020, 05, 15, 12, 0, 0, DateTimeKind.Local));

            headerInstance.Add(GetNotesHeader.IF_MODIFIED_SINCE, ifModifiedSince);
            
            //Call GetNotes method that takes paramInstance and headerInstance as parameters
            APIResponse<ResponseHandler> response = notesOperations.GetNotes(paramInstance, headerInstance);
            
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
                        
                        //Get the list of obtained Note instances
                        List<Com.Zoho.Crm.API.Notes.Note> notes = responseWrapper.Data;
                    
                        foreach(Com.Zoho.Crm.API.Notes.Note note in notes)
                        {
                            //Get the owner User instance of each Note
                            User owner = note.Owner;
                            
                            //Check if owner is not null
                            if(owner != null)
                            {
                                //Get the name of the owner User
                                Console.WriteLine("Note Owner User-Name: " + owner.Name);
                                
                                //Get the ID of the owner User
                                Console.WriteLine("Note Owner User-ID: " + owner.Id);
                                
                                //Get the Email of the owner User
                                Console.WriteLine("Note Owner Email: " + owner.Email);
                            }
                            
                            //Get the ModifiedTime of each Module
                            Console.WriteLine("Note ModifiedTime: " + note.ModifiedTime);
                            
                            //Get the list of Attachment instance each Note
                            List<Attachment> attachments = note.Attachments;
                            
                            //Check if attachments is not null
                            if(attachments != null)
                            {
                                foreach(Attachment attachment in attachments)
                                {
                                    PrintAttachment(attachment);
                                }
                            }
                            
                            //Get the CreatedTime of each Note
                            Console.WriteLine("Note CreatedTime: " + note.CreatedTime);

                            //Get the parentId Record instance of each Note
                            Com.Zoho.Crm.API.Record.Record parentId = note.ParentId;
                            
                            //Check if parentId is not null
                            if(parentId != null)
                            {
                                if(parentId.GetKeyValue("name") != null)
                                {
                                    //Get the parent record Name of each Note
                                    Console.WriteLine("Note parent record Name: " + parentId.GetKeyValue("name"));
                                }
                                
                                //Get the parent record ID of each Note
                                Console.WriteLine("Note parent record ID: " + parentId.Id);
                            }
                            
                            //Get the Editable of each Note
                            Console.WriteLine("Note Editable: " + note.Editable);
                            
                            //Get the SeModule of each Note
                            Console.WriteLine("Note SeModule: " + note.SeModule);
                            
                            //Get the IsSharedToClient of each Note
                            Console.WriteLine("Note IsSharedToClient: " + note.IsSharedToClient);
                            
                            //Get the modifiedBy User instance of each Note
                            User modifiedBy = note.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Note Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Note Modified By User-ID: " + modifiedBy.Id);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Note Modified By User-Email: " + modifiedBy.Email);
                            }
                            
                            //Get the Size of each Note
                            Console.WriteLine("Note Size: " + note.Size);
                            
                            //Get the State of each Note
                            Console.WriteLine("Note State: " + note.State);
                            
                            //Get the VoiceNote of each Note
                            Console.WriteLine("Note VoiceNote: " + note.VoiceNote);
                            
                            //Get the Id of each Note
                            Console.WriteLine("Note Id: " + note.Id);
                            
                            //Get the createdBy User instance of each Note
                            User createdBy = note.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Note Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Note Created By User-ID: " + createdBy.Id);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Note Created By User-Email: " + createdBy.Email);
                            }
                            
                            //Get the NoteTitle of each Note
                            Console.WriteLine("Note NoteTitle: " + note.NoteTitle);
                            
                            //Get the NoteContent of each Note
                            Console.WriteLine("Note NoteContent: " + note.NoteContent);
                        }
                        
                        //Get the Object obtained Info instance
                        Info info = responseWrapper.Info;
                        
                        if(info != null)
                        {
                            if(info.PerPage != null)
                            {
                                //Get the PerPage of the Info
                                Console.WriteLine("Note Info PerPage: " + info.PerPage);
                            }
                            
                            if(info.Count != null)
                            {
                                //Get the Count of the Info
                                Console.WriteLine("Note Info Count: " + info.Count);
                            }
                            
                            if(info.Page != null)
                            {
                                //Get the Default of the Info
                                Console.WriteLine("Note Info Page: " + info.Page);
                            }
                            
                            if(info.MoreRecords != null)
                            {
                                //Get the Default of the Info
                                Console.WriteLine("Note Info MoreRecords: " + info.MoreRecords);
                            }
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
        
        private static void PrintAttachment(Attachment attachment)
        {
            //Get the Owner User instance of each attachment
            User owner = attachment.Owner;
            
            //Check if owner is not null
            if(owner != null)
            {
                //Get the Name of the Owner
                Console.WriteLine("Note Attachment Owner User-Name: " + owner.Name);
                
                //Get the ID of the Owner
                Console.WriteLine("Note Attachment Owner User-ID: " + owner.Id);
                
                //Get the Email of the Owner
                Console.WriteLine("Note Attachment Owner User-Email: " + owner.Email);
            }
            
            //Get the modified time of each attachment
            Console.WriteLine("Note Attachment Modified Time: " + attachment.ModifiedTime);
            
            //Get the name of the File
            Console.WriteLine("Note Attachment File Name: " + attachment.FileName);
            
            //Get the created time of each attachment
            Console.WriteLine("Note Attachment Created Time: " + attachment.CreatedTime);
            
            //Get the Attachment file size
            Console.WriteLine("Note Attachment File Size: " + attachment.Size);

            //Get the parentId Record instance of each attachment
            Com.Zoho.Crm.API.Record.Record parentId = attachment.ParentId;
            
            //Check if parentId is not null
            if(parentId != null)
            {	
                //Get the parent record Name of each attachment
                Console.WriteLine("Note Attachment parent record Name: " + parentId.GetKeyValue("name"));
                
                //Get the parent record ID of each attachment
                Console.WriteLine("Note Attachment parent record ID: " + parentId.Id);
            }
            
            //Get the attachment is Editable
            Console.WriteLine("Note Attachment is Editable: " + attachment.Editable);
            
            //Get the file ID of each attachment
            Console.WriteLine("Note Attachment File ID: " + attachment.FileId);
            
            //Get the type of each attachment
            Console.WriteLine("Note Attachment File Type: " + attachment.Type);
            
            //Get the seModule of each attachment
            Console.WriteLine("Note Attachment seModule: " + attachment.SeModule);
            
            //Get the modifiedBy User instance of each attachment
            User modifiedBy = attachment.ModifiedBy;
            
            //Check if modifiedBy is not null
            if(modifiedBy != null)
            {
                //Get the Name of the modifiedBy User
                Console.WriteLine("Note Attachment Modified By User-Name: " + modifiedBy.Name);
                
                //Get the ID of the modifiedBy User
                Console.WriteLine("Note Attachment Modified By User-ID: " + modifiedBy.Id);
                
                //Get the Email of the modifiedBy User
                Console.WriteLine("Note Attachment Modified By User-Email: " + modifiedBy.Email);
            }
            
            //Get the state of each attachment
            Console.WriteLine("Note Attachment State: " + attachment.State);
            
            //Get the ID of each attachment
            Console.WriteLine("Note Attachment ID: " + attachment.Id);
            
            //Get the createdBy User instance of each attachment
            User createdBy = attachment.CreatedBy;
            
            //Check if createdBy is not null
            if(createdBy != null)
            {
                //Get the name of the createdBy User
                Console.WriteLine("Note Attachment Created By User-Name: " + createdBy.Name);
                
                //Get the ID of the createdBy User
                Console.WriteLine("Note Attachment Created By User-ID: " + createdBy.Id);
                
                //Get the Email of the createdBy User
                Console.WriteLine("Note Attachment Created By User-Email: " + createdBy.Email);
            }
            
            //Get the linkUrl of each attachment
            Console.WriteLine("Note Attachment LinkUrl: " + attachment.LinkUrl);
        }

        /// <summary>
        /// This method is used to add new notes and print the response.
        /// </summary>
        public static void CreateNotes()
        {	
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Note instances
            List<Com.Zoho.Crm.API.Notes.Note> notes = new List<Com.Zoho.Crm.API.Notes.Note>();
            
            for(int i = 1; i <= 5; i++)
            {
                //Get instance of Note Class
                Com.Zoho.Crm.API.Notes.Note note = new Com.Zoho.Crm.API.Notes.Note();

                //Set Note_Title of the Note
                note.NoteTitle = "Contacted";

                //Set NoteContent of the Note
                note.NoteContent = "Need to do further tracking";

                //Get instance of Record Class
                Com.Zoho.Crm.API.Record.Record parentRecord = new Com.Zoho.Crm.API.Record.Record();
                
                //Set ID of the Record
                parentRecord.Id = 34770616920152;

                //Set ParentId of the Note
                note.ParentId = parentRecord;

                //Set SeModule of the Record
                note.SeModule = "Leads";

                //Add Note instance to the list
                notes.Add(note);
            }
            
            //Set the list to notes in BodyWrapper instance
            bodyWrapper.Data = notes;
            
            //Call CreateNotes method that takes BodyWrapper instance as parameter 
            APIResponse<ActionHandler> response = notesOperations.CreateNotes(bodyWrapper);
            
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
                        
                        //Get the list of obtained ActionResponse instances
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to update an existing note and print the response.
        /// </summary>
        public static void UpdateNotes()
        {
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Note instances
            List<Com.Zoho.Crm.API.Notes.Note> notes = new List<Com.Zoho.Crm.API.Notes.Note>();

            //Get instance of Note Class
            Com.Zoho.Crm.API.Notes.Note note = new Com.Zoho.Crm.API.Notes.Note();

            note.Id = 34770617376024;

            //Set Note_Title of the Note
            note.NoteTitle = "Contacted12";

            //Set NoteContent of the Note
            note.NoteContent = "Need to do further tracking12";

            //Add Note instance to the list
            notes.Add(note);

            note = new Com.Zoho.Crm.API.Notes.Note();

            note.Id = 34770617376023;

            //Set Note_Title of the Note
            note.NoteTitle = "Contacted13";

            //Set NoteContent of the Note
            note.NoteContent = "Need to do further tracking13";

            //Add Note instance to the list
            notes.Add(note);

            //Set the list to notes in BodyWrapper instance
            bodyWrapper.Data = notes;
            
            //Call UpdateNotes method that takes BodyWrapper instance as parameter 
            APIResponse<ActionHandler> response = notesOperations.UpdateNotes(bodyWrapper);
            
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
                        
                        //Get the list of obtained ActionResponse instances
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                
                                if(exception.Details != null)
                                {
                                    //Get the details map
                                    foreach(KeyValuePair<string, object> entry in exception.Details)
                                    {
                                        //Get each value in the map
                                        Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                    }
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
        /// This method is used to delete notes in bulk and print the response.
        /// </summary>
        /// <param name="notesId">The List of Note IDs to be deleted</param>
        public static void DeleteNotes(List<long> notesId)
        {
            //example 
            //List<long> notesId = new List<long>() { 34770616153001, 34770616153002, 34770616154005 };

            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(long id in notesId)
            {
                paramInstance.Add(DeleteNotesParam.IDS, id);
            }
            
            //Call DeleteNotes method that takes paramInstance as parameter 
            APIResponse<ActionHandler> response = notesOperations.DeleteNotes(paramInstance);
            
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
                        
                        //Get the list of obtained ActionResponse instances
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                
                                if(exception.Details != null)
                                {
                                    //Get the details map
                                    foreach(KeyValuePair<string, object> entry in exception.Details)
                                    {
                                        //Get each value in the map
                                        Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                    }
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
        /// This method is used to get the note and print the response.
        /// </summary>
        /// <param name="noteId">The ID of the Note to be obtained</param>
        public static void GetNote(long noteId)
        {
            //example
            //long noteId = 34770616153005;
            
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();

            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();

            paramInstance.Add(GetNoteParam.FIELDS, "Note_Title,Note_Content");

            //Get instance of HeaderMap Class
            HeaderMap headerInstance = new HeaderMap();

            DateTimeOffset ifModifiedSince = new DateTimeOffset(new DateTime(2020, 05, 15, 12, 0, 0, DateTimeKind.Local));

            headerInstance.Add(GetNoteHeader.IF_MODIFIED_SINCE, ifModifiedSince);

            //Call GetNote method that takes noteId as parameter
            APIResponse<ResponseHandler> response = notesOperations.GetNote(noteId, paramInstance, headerInstance);
            
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
                        
                        //Get the list of obtained Note instances
                        List<Com.Zoho.Crm.API.Notes.Note> notes = responseWrapper.Data;
                    
                        foreach(Com.Zoho.Crm.API.Notes.Note note in notes)
                        {
                            //Get the owner User instance of each Note
                            User owner = note.Owner;
                            
                            //Check if owner is not null
                            if(owner != null)
                            {
                                //Get the name of the owner User
                                Console.WriteLine("Note Owner User-Name: " + owner.Name);
                                
                                //Get the ID of the owner User
                                Console.WriteLine("Note Owner User-ID: " + owner.Id);
                                
                                //Get the Email of the owner User
                                Console.WriteLine("Note Owner Email: " + owner.Email);
                            }
                            
                            //Get the ModifiedTime of each Module
                            Console.WriteLine("Note ModifiedTime: " + note.ModifiedTime);
                            
                            //Get the list of Attachment instance each Note
                            List<Attachment> attachments = note.Attachments;
                            
                            //Check if attachments is not null
                            if(attachments != null)
                            {
                                foreach(Attachment attachment in attachments)
                                {
                                    PrintAttachment(attachment);
                                }
                            }
                            
                            //Get the CreatedTime of each Note
                            Console.WriteLine("Note CreatedTime: " + note.CreatedTime);

                            //Get the parentId Record instance of each Note
                            Com.Zoho.Crm.API.Record.Record parentId = note.ParentId;
                            
                            //Check if parentId is not null
                            if(parentId != null)
                            {
                                if(parentId.GetKeyValue("name") != null)
                                {
                                    //Get the parent record Name of each Note
                                    Console.WriteLine("Note parent record Name: " + parentId.GetKeyValue("name"));
                                }
                                
                                //Get the parent record ID of each Note
                                Console.WriteLine("Note parent record ID: " + parentId.Id);
                            }
                            
                            //Get the Editable of each Note
                            Console.WriteLine("Note Editable: " + note.Editable);
                            
                            //Get the SeModule of each Note
                            Console.WriteLine("Note SeModule: " + note.SeModule);
                            
                            //Get the IsSharedToClient of each Note
                            Console.WriteLine("Note IsSharedToClient: " + note.IsSharedToClient);
                            
                            //Get the modifiedBy User instance of each Note
                            User modifiedBy = note.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Note Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Note Modified By User-ID: " + modifiedBy.Id);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Note Modified By User-Email: " + modifiedBy.Email);
                            }
                            
                            //Get the Size of each Note
                            Console.WriteLine("Note Size: " + note.Size);
                            
                            //Get the State of each Note
                            Console.WriteLine("Note State: " + note.State);
                            
                            //Get the VoiceNote of each Note
                            Console.WriteLine("Note VoiceNote: " + note.VoiceNote);
                            
                            //Get the Id of each Note
                            Console.WriteLine("Note Id: " + note.Id);
                            
                            //Get the createdBy User instance of each Note
                            User createdBy = note.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Note Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Note Created By User-ID: " + createdBy.Id);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Note Created By User-Email: " + createdBy.Email);
                            }
                            
                            //Get the NoteTitle of each Note
                            Console.WriteLine("Note NoteTitle: " + note.NoteTitle);
                            
                            //Get the NoteContent of each Note
                            Console.WriteLine("Note NoteContent: " + note.NoteContent);
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
        /// This method is used to update an existing note and print the response.
        /// </summary>
        /// <param name="noteId">The ID of the Note to be obtained</param>
        public static void UpdateNote(long noteId)
        {
            //example
            //long noteId = 34770616153005;
            
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Note instances
            List<Com.Zoho.Crm.API.Notes.Note> notes = new List<Com.Zoho.Crm.API.Notes.Note>();
            
            Com.Zoho.Crm.API.Notes.Note note = new Com.Zoho.Crm.API.Notes.Note();
            
            //Set Note_Title of the Note
            note.NoteTitle = "Contacted12";
            
            //Set NoteContent of the Note
            note.NoteContent = "Need to do further tracking12";

            //Get instance of Record Class
            API.Record.Record parentRecord = new API.Record.Record();
            
            //Set ID of the Record
            parentRecord.Id = 34770616920152;

            //Set ParentId of the Note
            note.ParentId = parentRecord;

            note.SeModule = "Leads";

            //Add Note instance to the list
            notes.Add(note);
            
            //Set the list to notes in BodyWrapper instance
            bodyWrapper.Data = notes;

            //Call updateNote method that takes noteId and BodyWrapper instance as parameter 
            APIResponse<ActionHandler> response = notesOperations.UpdateNote(noteId, bodyWrapper);
            
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
                        
                        //Get the list of obtained ActionResponse instances
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                
                                if(exception.Details != null)
                                {
                                    //Get the details map
                                    foreach(KeyValuePair<string, object> entry in exception.Details)
                                    {
                                        //Get each value in the map
                                        Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                    }
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
        /// This method is used to delete single Note with ID and print the response.
        /// </summary>
        /// <param name="noteId">The ID of the Note to be deleted</param>
        public static void DeleteNote(long noteId)
        {
            //example
            //long noteId = 34770616153005;
            
            //Get instance of NotesOperations Class
            NotesOperations notesOperations = new NotesOperations();
            
            //Call DeleteNote method that takes noteId as parameter 
            APIResponse<ActionHandler> response = notesOperations.DeleteNote(noteId);
            
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
                        
                        //Get the list of obtained ActionResponse instances
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
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
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
                                
                                if(exception.Details != null)
                                {
                                    //Get the details map
                                    foreach(KeyValuePair<string, object> entry in exception.Details)
                                    {
                                        //Get each value in the map
                                        Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                    }
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
    }
}

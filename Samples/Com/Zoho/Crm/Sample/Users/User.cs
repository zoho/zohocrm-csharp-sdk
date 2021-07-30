using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Users.UsersOperations;

namespace Com.Zoho.Crm.Sample.Users
{
    public class User
    {
        /// <summary>
        /// This method is used to retrieve the users data specified in the API request.
        /// You can specify the type of users that needs to be retrieved using the Users API.
        /// </summary>
        public static void GetUsers()
        {
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            paramInstance.Add(GetUsersParam.TYPE, "ActiveUsers");
            
            paramInstance.Add(GetUsersParam.PAGE, 1);
            
            //paramInstance.Add(GetUsersParam.PER_PAGE, 1);
            
            HeaderMap headerInstance = new HeaderMap();
            
            DateTimeOffset ifmodifiedsince = new DateTimeOffset(new DateTime(2020, 05, 15, 12, 0, 0, DateTimeKind.Local));
            
            headerInstance.Add(GetUsersHeader.IF_MODIFIED_SINCE, ifmodifiedsince);
            
            //Call GetUsers method that takes ParameterMap instance and HeaderMap instance as parameters
            APIResponse<ResponseHandler> response = usersOperations.GetUsers(paramInstance, headerInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if(new List<int>() { 204, 304}.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode== 204? "No Content" : "Not Modified");
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
                        
                        //Get the list of obtained User instances
                        List<Com.Zoho.Crm.API.Users.User> users = responseWrapper.Users;
                        
                        foreach(Com.Zoho.Crm.API.Users.User user in users)
                        {	
                            //Get the Country of each User
                            Console.WriteLine("User Country: " + user.Country);
                            
                            // Get the CustomizeInfo instance of each User
                            CustomizeInfo customizeInfo = user.CustomizeInfo;
                            
                            //Check if customizeInfo is not null
                            if(customizeInfo != null)
                            {
                                if(customizeInfo.NotesDesc!= null)
                                {
                                    //Get the NotesDesc of each User
                                    Console.WriteLine("User CustomizeInfo NotesDesc: " + customizeInfo.NotesDesc);
                                }
                                
                                if(customizeInfo.ShowRightPanel!= null)
                                {
                                    //Get the ShowRightPanel of each User
                                    Console.WriteLine("User CustomizeInfo ShowRightPanel: " + customizeInfo.ShowRightPanel);
                                }
                                
                                if(customizeInfo.BcView!= null)
                                {
                                    //Get the BcView of each User
                                    Console.WriteLine("User CustomizeInfo BcView: " + customizeInfo.BcView);
                                }
                                
                                if(customizeInfo.ShowHome!= null)
                                {
                                    //Get the ShowHome of each User
                                    Console.WriteLine("User CustomizeInfo ShowHome: " + customizeInfo.ShowHome);
                                }
                                
                                if(customizeInfo.ShowDetailView!= null)
                                {
                                    //Get the ShowDetailView of each User
                                    Console.WriteLine("User CustomizeInfo ShowDetailView: " + customizeInfo.ShowDetailView);
                                }
                                
                                if(customizeInfo.UnpinRecentItem!= null)
                                {
                                    //Get the UnpinRecentItem of each User
                                    Console.WriteLine("User CustomizeInfo UnpinRecentItem: " + customizeInfo.UnpinRecentItem);
                                }
                            }
                            
                            // Get the Role instance of each User
                            API.Roles.Role role = user.Role;
                            
                            //Check if role is not null
                            if(role != null)
                            {
                                //Get the Name of each Role
                                Console.WriteLine("User Role Name: " + role.Name);
                                
                                //Get the ID of each Role
                                Console.WriteLine("User Role ID: " + role.Id);
                            }
                            
                            //Get the Signature of each User
                            Console.WriteLine("User Signature: " + user.Signature);
                            
                            //Get the City of each User
                            Console.WriteLine("User City: " + user.City);
                            
                            //Get the NameFormat of each User
                            Console.WriteLine("User NameFormat: " + user.NameFormat);
                            
                            //Get the Language of each User
                            Console.WriteLine("User Language: " + user.Language);
                            
                            //Get the Locale of each User
                            Console.WriteLine("User Locale: " + user.Locale);
                            
                            //Get the Microsoft of each User
                            Console.WriteLine("User Microsoft: " + user.Microsoft);
                            
                            if(user.PersonalAccount!= null)
                            {
                                //Get the PersonalAccount of each User
                                Console.WriteLine("User PersonalAccount: " + user.PersonalAccount);
                            }
                            
                            //Get the DefaultTabGroup of each User
                            Console.WriteLine("User DefaultTabGroup: " + user.DefaultTabGroup);
                            
                            //Get the Isonline of each User
                            Console.WriteLine("User Isonline: " + user.Isonline);
                            
                            //Get the modifiedBy User instance of each User
                            Com.Zoho.Crm.API.Users.User modifiedBy = user.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("User Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("User Modified By User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Street of each User
                            Console.WriteLine("User Street: " + user.Street);
                            
                            //Get the Currency of each User
                            Console.WriteLine("User Currency: " + user.Currency);
                            
                            //Get the Alias of each User
                            Console.WriteLine("User Alias: " + user.Alias);
                            
                            // Get the Theme instance of each User
                            Theme theme = user.Theme;
                            
                            //Check if theme is not null
                            if(theme != null)
                            {
                                // Get the TabTheme instance of Theme
                                TabTheme normalTab = theme.NormalTab;
                                
                                //Check if normalTab is not null
                                if(normalTab != null)
                                {
                                    //Get the FontColor of NormalTab
                                    Console.WriteLine("User Theme NormalTab FontColor: " + normalTab.FontColor);
                                    
                                    //Get the Name of NormalTab
                                    Console.WriteLine("User Theme NormalTab Name: " + normalTab.Background);
                                }
                                
                                // Get the TabTheme instance of Theme
                                TabTheme selectedTab = theme.SelectedTab;
                                
                                //Check if selectedTab is not null
                                if(selectedTab != null)
                                {
                                    //Get the FontColor of SelectedTab
                                    Console.WriteLine("User Theme SelectedTab FontColor: " + selectedTab.FontColor);
                                    
                                    //Get the Name of SelectedTab
                                    Console.WriteLine("User Theme SelectedTab Name: " + selectedTab.Background);
                                }
                                
                                //Get the NewBackground of each Theme
                                Console.WriteLine("User Theme NewBackground: " + theme.NewBackground);
                                
                                //Get the Background of each Theme
                                Console.WriteLine("User Theme Background: " + theme.Background);
                                
                                //Get the Screen of each Theme
                                Console.WriteLine("User Theme Screen: " + theme.Screen);
                                
                                //Get the Type of each Theme
                                Console.WriteLine("User Theme Type: " + theme.Type);
                            }
                            
                            //Get the ID of each User
                            Console.WriteLine("User ID: " + user.Id);
                            
                            //Get the State of each User
                            Console.WriteLine("User State: " + user.State);
                            
                            //Get the Fax of each User
                            Console.WriteLine("User Fax: " + user.Fax);
                            
                            //Get the CountryLocale of each User
                            Console.WriteLine("User CountryLocale: " + user.CountryLocale);
                            
                            //Get the FirstName of each User
                            Console.WriteLine("User FirstName: " + user.FirstName);
                            
                            //Get the Email of each User
                            Console.WriteLine("User Email: " + user.Email);
                            
                            //Get the reportingTo User instance of each User
                            Com.Zoho.Crm.API.Users.User reportingTo = user.ReportingTo;
                            
                            //Check if reportingTo is not null
                            if(reportingTo != null)
                            {
                                //Get the Name of the reportingTo User
                                Console.WriteLine("User ReportingTo Name: " + reportingTo.Name);
                                
                                //Get the ID of the reportingTo User
                                Console.WriteLine("User ReportingTo ID: " + reportingTo.Id);
                            }
                            
                            //Get the DecimalSeparator of each User
                            Console.WriteLine("User DecimalSeparator: " + user.DecimalSeparator);
                            
                            //Get the Zip of each User
                            Console.WriteLine("User Zip: " + user.Zip);
                            
                            //Get the CreatedTime of each User
                            Console.WriteLine("User CreatedTime: " + user.CreatedTime);
                            
                            //Get the Website of each User
                            Console.WriteLine("User Website: " + user.Website);
                            
                            //Get the ModifiedTime of each User
                            Console.WriteLine("User ModifiedTime: " + user.ModifiedTime);
                            
                            //Get the TimeFormat of each User
                            Console.WriteLine("User TimeFormat: " + user.TimeFormat);
                            
                            //Get the Offset of each User
                            Console.WriteLine("User Offset: " + user.Offset);
                            
                            //Get the Profile instance of each User
                            API.Profiles.Profile profile = user.Profile;
                            
                            //Check if profile is not null
                            if(profile != null)
                            {
                                //Get the Name of each Profile
                                Console.WriteLine("User Profile Name: " + profile.Name);
                                
                                //Get the ID of each Profile
                                Console.WriteLine("User Profile ID: " + profile.Id);
                            }
                            
                            //Get the Mobile of each User
                            Console.WriteLine("User Mobile: " + user.Mobile);
                            
                            //Get the LastName of each User
                            Console.WriteLine("User LastName: " + user.LastName);
                            
                            //Get the TimeZone of each User
                            Console.WriteLine("User TimeZone: " + user.TimeZone);
                            
                            //Get the createdBy User instance of each User
                            Com.Zoho.Crm.API.Users.User createdBy = user.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("User Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("User Created By User-ID: " + createdBy.Id);
                            }
        
                            //Get the Zuid of each User
                            Console.WriteLine("User Zuid: " + user.Zuid);
                            
                            //Get the Confirm of each User
                            Console.WriteLine("User Confirm: " + user.Confirm);
                            
                            //Get the FullName of each User
                            Console.WriteLine("User FullName: " + user.FullName);
                            
                            //Get the list of obtained Territory instances
                            List<Com.Zoho.Crm.API.Users.Territory> territories = user.Territories;
                            
                            //Check if territories is not null
                            if(territories != null)
                            {
                                foreach(Territory territory in territories)
                                {
                                    //Get the Manager of the Territory
                                    Console.WriteLine("User Territory Manager: " + territory.Manager);
                                    
                                    //Get the Name of the Territory
                                    Console.WriteLine("User Territory Name: " + territory.Name);
                                    
                                    //Get the ID of the Territory
                                    Console.WriteLine("User Territory ID: " + territory.Id);
                                }
                            }
                            
                            //Get the Phone of each User
                            Console.WriteLine("User Phone: " + user.Phone);
                            
                            //Get the DOB of each User
                            Console.WriteLine("User DOB: " + user.Dob);
                            
                            //Get the DateFormat of each User
                            Console.WriteLine("User DateFormat: " + user.DateFormat);
                            
                            //Get the Status of each User
                            Console.WriteLine("User Status: " + user.Status);
                        }
                        
                        //Get the Object obtained Info instance
                        Info info = responseWrapper.Info;
                        
                        //Check if info is not null
                        if(info != null)
                        {
                            if(info.PerPage!= null)
                            {
                                //Get the PerPage of the Info
                                Console.WriteLine("User Info PerPage: " + info.PerPage);
                            }
                            
                            if(info.Count!= null)
                            {
                                //Get the Count of the Info
                                Console.WriteLine("User Info Count: " + info.Count);
                            }
                            
                            if(info.Page!= null)
                            {
                                //Get the Page of the Info
                                Console.WriteLine("User Info Page: " + info.Page);
                            }
                            
                            if(info.MoreRecords!= null)
                            {
                                //Get the MoreRecords of the Info
                                Console.WriteLine("User Info MoreRecords: " + info.MoreRecords);
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to add a user to your organization and print the response.
        /// </summary>
        public static void CreateUser()
        {
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();

            //Get instance of RequestWrapper Class that will contain the request body
            RequestWrapper request = new RequestWrapper();
            
            //List of User instances
            List<Com.Zoho.Crm.API.Users.User> userList = new List<Com.Zoho.Crm.API.Users.User>();
            
            //Get instance of User Class
            Com.Zoho.Crm.API.Users.User user1 = new Com.Zoho.Crm.API.Users.User();
            
            API.Roles.Role role = new API.Roles.Role();

            role.Id = 34770610026008;

            user1.Role = role;

            user1.FirstName = "TestUser";

            user1.Email = "testuser1@zoho.com";

            API.Profiles.Profile profile = new API.Profiles.Profile();
            
            profile.Id = 34770610026014;

            user1.Profile = profile;

            user1.LastName = "12";

            userList.Add(user1);
            
            request.Users = userList;
            
            //Call CreateUser method that takes BodyWrapper class instance as parameter
            APIResponse<ActionHandler> response = usersOperations.CreateUser(request);
            
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
                        ActionWrapper responseWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = responseWrapper.Users;
                        
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to update the details of multiple users of your organization and print the response.
        /// </summary>
        public static void UpdateUsers()
        {
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of User instances
            List<Com.Zoho.Crm.API.Users.User> userList = new List<Com.Zoho.Crm.API.Users.User>();
            
            //Get instance of User Class
            Com.Zoho.Crm.API.Users.User user1 = new Com.Zoho.Crm.API.Users.User();
            
            user1.Id = 34770615791024;

            API.Roles.Role role = new API.Roles.Role();
            
            role.Id = 34770610026008;
            
            user1.Role = role;
            
            user1.CountryLocale = "en_US";
            
            userList.Add(user1);
            
            user1 = new Com.Zoho.Crm.API.Users.User();
            
            user1.Id = 34770615791024;
            
            role = new API.Roles.Role();
            
            role.Id = 34770610026008;
            
            user1.Role = role;
            
            user1.CountryLocale = "en_US";

            //user1.AddKeyValue("apiName", "value");

            userList.Add(user1);
            
            request.Users = userList;
            
            //Call UpdateUsers method that takes BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = usersOperations.UpdateUsers(request);
            
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
                        ActionWrapper responseWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = responseWrapper.Users;
                        
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to get the details of any specific user.
        /// Specify the unique id of the user in your API request to get the data for that particular user.
        /// </summary>
        /// <param name="userId">The ID of the User to be obtained</param>
        public static void GetUser(long userId)
        {
            //example
            //long userId = 34770615817002;
            
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();
            
            HeaderMap headerInstance = new HeaderMap();
            
            DateTimeOffset ifmodifiedsince = new DateTimeOffset(new DateTime(2020, 05, 15, 12, 0, 0, DateTimeKind.Local));

            headerInstance.Add(GetUsersHeader.IF_MODIFIED_SINCE, ifmodifiedsince);

            //Call GetUser method that takes userId and headerInstance as parameter
            APIResponse<ResponseHandler> response = usersOperations.GetUser(userId, headerInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if(new List<int>() { 204, 304 }.Contains(response.StatusCode))
                {
                    Console.WriteLine(response.StatusCode== 204? "No Content" : "Not Modified");
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
                        
                        //Get the obtained User instance
                        List<Com.Zoho.Crm.API.Users.User> users = responseWrapper.Users;
                        
                        foreach(Com.Zoho.Crm.API.Users.User user in users)
                        {	
                            //Get the Country of each User
                            Console.WriteLine("User Country: " + user.Country);
                            
                            // Get the CustomizeInfo instance of each User
                            CustomizeInfo customizeInfo = user.CustomizeInfo;
                            
                            //Check if customizeInfo is not null
                            if(customizeInfo != null)
                            {
                                if(customizeInfo.NotesDesc!= null)
                                {
                                    //Get the NotesDesc of each User
                                    Console.WriteLine("User CustomizeInfo NotesDesc: " + customizeInfo.NotesDesc);
                                }
                                
                                if(customizeInfo.ShowRightPanel!= null)
                                {
                                    //Get the ShowRightPanel of each User
                                    Console.WriteLine("User CustomizeInfo ShowRightPanel: " + customizeInfo.ShowRightPanel);
                                }
                                
                                if(customizeInfo.BcView!= null)
                                {
                                    //Get the BcView of each User
                                    Console.WriteLine("User CustomizeInfo BcView: " + customizeInfo.BcView);
                                }
                                
                                if(customizeInfo.ShowHome!= null)
                                {
                                    //Get the ShowHome of each User
                                    Console.WriteLine("User CustomizeInfo ShowHome: " + customizeInfo.ShowHome);
                                }
                                
                                if(customizeInfo.ShowDetailView!= null)
                                {
                                    //Get the ShowDetailView of each User
                                    Console.WriteLine("User CustomizeInfo ShowDetailView: " + customizeInfo.ShowDetailView);
                                }
                                
                                if(customizeInfo.UnpinRecentItem!= null)
                                {
                                    //Get the UnpinRecentItem of each User
                                    Console.WriteLine("User CustomizeInfo UnpinRecentItem: " + customizeInfo.UnpinRecentItem);
                                }
                            }
                            
                            // Get the Role instance of each User
                            API.Roles.Role role = user.Role;
                            
                            //Check if role is not null
                            if(role != null)
                            {
                                //Get the Name of each Role
                                Console.WriteLine("User Role Name: " + role.Name);
                                
                                //Get the ID of each Role
                                Console.WriteLine("User Role ID: " + role.Id);
                            }
                            
                            //Get the Signature of each User
                            Console.WriteLine("User Signature: " + user.Signature);
                            
                            //Get the City of each User
                            Console.WriteLine("User City: " + user.City);
                            
                            //Get the NameFormat of each User
                            Console.WriteLine("User NameFormat: " + user.NameFormat);
                            
                            //Get the Language of each User
                            Console.WriteLine("User Language: " + user.Language);
                            
                            //Get the Locale of each User
                            Console.WriteLine("User Locale: " + user.Locale);
                            
                            //Get the Microsoft of each User
                            Console.WriteLine("User Microsoft: " + user.Microsoft);
                            
                            if(user.PersonalAccount!= null)
                            {
                                //Get the PersonalAccount of each User
                                Console.WriteLine("User PersonalAccount: " + user.PersonalAccount);
                            }
                            
                            //Get the DefaultTabGroup of each User
                            Console.WriteLine("User DefaultTabGroup: " + user.DefaultTabGroup);
                            
                            //Get the Isonline of each User
                            Console.WriteLine("User Isonline: " + user.Isonline);
                            
                            //Get the modifiedBy User instance of each User
                            Com.Zoho.Crm.API.Users.User modifiedBy = user.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("User Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("User Modified By User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Street of each User
                            Console.WriteLine("User Street: " + user.Street);
                            
                            //Get the Currency of each User
                            Console.WriteLine("User Currency: " + user.Currency);
                            
                            //Get the Alias of each User
                            Console.WriteLine("User Alias: " + user.Alias);
                            
                            // Get the Theme instance of each User
                            Theme theme = user.Theme;
                            
                            //Check if theme is not null
                            if(theme != null)
                            {
                                // Get the TabTheme instance of Theme
                                TabTheme normalTab = theme.NormalTab;
                                
                                //Check if normalTab is not null
                                if(normalTab != null)
                                {
                                    //Get the FontColor of NormalTab
                                    Console.WriteLine("User Theme NormalTab FontColor: " + normalTab.FontColor);
                                    
                                    //Get the Name of NormalTab
                                    Console.WriteLine("User Theme NormalTab Name: " + normalTab.Background);
                                }
                                
                                // Get the TabTheme instance of Theme
                                TabTheme selectedTab = theme.SelectedTab;
                                
                                //Check if selectedTab is not null
                                if(selectedTab != null)
                                {
                                    //Get the FontColor of SelectedTab
                                    Console.WriteLine("User Theme SelectedTab FontColor: " + selectedTab.FontColor);
                                    
                                    //Get the Name of SelectedTab
                                    Console.WriteLine("User Theme SelectedTab Name: " + selectedTab.Background);
                                }
                                
                                //Get the NewBackground of each Theme
                                Console.WriteLine("User Theme NewBackground: " + theme.NewBackground);
                                
                                //Get the Background of each Theme
                                Console.WriteLine("User Theme Background: " + theme.Background);
                                
                                //Get the Screen of each Theme
                                Console.WriteLine("User Theme Screen: " + theme.Screen);
                                
                                //Get the Type of each Theme
                                Console.WriteLine("User Theme Type: " + theme.Type);
                            }
                            
                            //Get the ID of each User
                            Console.WriteLine("User ID: " + user.Id);
                            
                            //Get the State of each User
                            Console.WriteLine("User State: " + user.State);
                            
                            //Get the Fax of each User
                            Console.WriteLine("User Fax: " + user.Fax);
                            
                            //Get the CountryLocale of each User
                            Console.WriteLine("User CountryLocale: " + user.CountryLocale);
                            
                            //Get the FirstName of each User
                            Console.WriteLine("User FirstName: " + user.FirstName);
                            
                            //Get the Email of each User
                            Console.WriteLine("User Email: " + user.Email);
                            
                            //Get the reportingTo User instance of each User
                            Com.Zoho.Crm.API.Users.User reportingTo = user.ReportingTo;
                            
                            //Check if reportingTo is not null
                            if(reportingTo != null)
                            {
                                //Get the Name of the reportingTo User
                                Console.WriteLine("User ReportingTo Name: " + reportingTo.Name);
                                
                                //Get the ID of the reportingTo User
                                Console.WriteLine("User ReportingTo ID: " + reportingTo.Id);
                            }
                            
                            //Get the DecimalSeparator of each User
                            Console.WriteLine("User DecimalSeparator: " + user.DecimalSeparator);
                            
                            //Get the Zip of each User
                            Console.WriteLine("User Zip: " + user.Zip);
                            
                            //Get the CreatedTime of each User
                            Console.WriteLine("User CreatedTime: " + user.CreatedTime);
                            
                            //Get the Website of each User
                            Console.WriteLine("User Website: " + user.Website);
                            
                            //Get the ModifiedTime of each User
                            Console.WriteLine("User ModifiedTime: " + user.ModifiedTime);
                            
                            //Get the TimeFormat of each User
                            Console.WriteLine("User TimeFormat: " + user.TimeFormat);
                            
                            //Get the Offset of each User
                            Console.WriteLine("User Offset: " + user.Offset);
                            
                            //Get the Profile instance of each User
                            API.Profiles.Profile profile = user.Profile;
                            
                            //Check if profile is not null
                            if(profile != null)
                            {
                                //Get the Name of each Profile
                                Console.WriteLine("User Profile Name: " + profile.Name);
                                
                                //Get the ID of each Profile
                                Console.WriteLine("User Profile ID: " + profile.Id);
                            }
                            
                            //Get the Mobile of each User
                            Console.WriteLine("User Mobile: " + user.Mobile);
                            
                            //Get the LastName of each User
                            Console.WriteLine("User LastName: " + user.LastName);
                            
                            //Get the TimeZone of each User
                            Console.WriteLine("User TimeZone: " + user.TimeZone);
                            
                            //Get the createdBy User instance of each User
                            Com.Zoho.Crm.API.Users.User createdBy = user.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("User Created By User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("User Created By User-ID: " + createdBy.Id);
                            }
        
                            //Get the Zuid of each User
                            Console.WriteLine("User Zuid: " + user.Zuid);
                            
                            //Get the Confirm of each User
                            Console.WriteLine("User Confirm: " + user.Confirm);
                            
                            //Get the FullName of each User
                            Console.WriteLine("User FullName: " + user.FullName);
                            
                            //Get the list of obtained Territory instances
                            List<Com.Zoho.Crm.API.Users.Territory> territories = user.Territories;
                            
                            //Check if territories is not null
                            if(territories != null)
                            {
                                foreach(Territory territory in territories)
                                {
                                    //Get the Manager of the Territory
                                    Console.WriteLine("User Territory Manager: " + territory.Manager);
                                    
                                    //Get the Name of the Territory
                                    Console.WriteLine("User Territory Name: " + territory.Name);
                                    
                                    //Get the ID of the Territory
                                    Console.WriteLine("User Territory ID: " + territory.Id);
                                }
                            }
                            
                            //Get the Phone of each User
                            Console.WriteLine("User Phone: " + user.Phone);
                            
                            //Get the DOB of each User
                            Console.WriteLine("User DOB: " + user.Dob);
                            
                            //Get the DateFormat of each User
                            Console.WriteLine("User DateFormat: " + user.DateFormat);
                            
                            //Get the Status of each User
                            Console.WriteLine("User Status: " + user.Status);
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to update the details of a user of your organization and print the response.
        /// </summary>
        /// <param name="userId">The ID of the User to be updated</param>
        public static void UpdateUser(long userId)
        {
            //example
            //long userId = 34770615817002;
            
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of User instances
            List<Com.Zoho.Crm.API.Users.User> userList = new List<Com.Zoho.Crm.API.Users.User>();
            
            //Get instance of User Class
            Com.Zoho.Crm.API.Users.User user1 = new Com.Zoho.Crm.API.Users.User();

            API.Roles.Role role = new API.Roles.Role();

            role.Id = 34770610026008;

            user1.Role = role;

            user1.CountryLocale = "en_US";

            userList.Add(user1);
            
            request.Users = userList;

            //Call UpdateUser method that takes userId and BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = usersOperations.UpdateUser(userId, request);
            
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
                        ActionWrapper responseWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = responseWrapper.Users;
                        
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to delete a user from your organization and print the response.
        /// </summary>
        /// <param name="userId">The ID of the User to be deleted</param>
        public static void DeleteUser(long userId)
        {
            //example
            //long userId = 34770615817002;
            
            //Get instance of UsersOperations Class
            UsersOperations usersOperations = new UsersOperations();
            
            //Call DeleteUser method that takes userId as parameter
            APIResponse<ActionHandler> response = usersOperations.DeleteUser(userId);
            
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
                        ActionWrapper responseWrapper = (ActionWrapper) actionHandler;
                        
                        //Get the list of obtained ActionResponse instances
                        List<ActionResponse> actionResponses = responseWrapper.Users;
                        
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                                    Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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
                            Console.WriteLine(entry.Key+ ": " + JsonConvert.SerializeObject(entry.Value));
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

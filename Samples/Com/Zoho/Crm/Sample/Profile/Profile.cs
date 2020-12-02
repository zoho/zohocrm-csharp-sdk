using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Profiles;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using APIException = Com.Zoho.Crm.API.Profiles.APIException;

using ResponseHandler = Com.Zoho.Crm.API.Profiles.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Profiles.ResponseWrapper;

namespace Com.Zoho.Crm.Sample.Profile
{
    public class Profile
    {
        /// <summary>
        /// This method is used to retrieve the data of profiles through an API request and print the response.
        /// </summary>
        public static void GetProfiles()
        {
            DateTimeOffset ifModifiedSince = new DateTimeOffset(new DateTime(2019, 05, 15, 12, 0, 0, DateTimeKind.Local));

            //Get instance of ProfilesOperations Class
            ProfilesOperations profilesOperations = new ProfilesOperations(null);
            
            //Call getProfiles method
            APIResponse<ResponseHandler> response = profilesOperations.GetProfiles();
            
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
                    
                    if(responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the list of obtained Profile instances
                        List<Com.Zoho.Crm.API.Profiles.Profile> profiles = responseWrapper.Profiles;
                    
                        foreach(Com.Zoho.Crm.API.Profiles.Profile profile in profiles)
                        {
                            //Get the DisplayLabel of the each Profile
                            Console.WriteLine("Profile DisplayLabel: " + profile.DisplayLabel);
                            
                            if(profile.CreatedTime != null)
                            {
                                //Get the CreatedTime of each Profile
                                Console.WriteLine("Profile CreatedTime: " + profile.CreatedTime);
                            }
                            
                            if(profile.ModifiedTime != null)
                            {
                                //Get the ModifiedTime of each Profile
                                Console.WriteLine("Profile ModifiedTime: " + profile.ModifiedTime);
                            }
                            
                            //Get the Name of the each Profile
                            Console.WriteLine("Profile Name: " + profile.Name);
                            
                            //Get the modifiedBy User instance of each Profile
                            User modifiedBy = profile.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-ID: " + modifiedBy.Id);
                                
                                //Get the name of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-Email: " + modifiedBy.Email);
                            }
                            
                            //Get the Description of the each Profile
                            Console.WriteLine("Profile Description: " + profile.Description);
                            
                            //Get the ID of the each Profile
                            Console.WriteLine("Profile ID: " + profile.Id);
                            
                            //Get the Category of the each Profile
                            Console.WriteLine("Profile Category: " + profile.Category);
                            
                            //Get the createdBy User instance of each Profile
                            User createdBy = profile.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the ID of the createdBy User
                                Console.WriteLine("Profile Created By User-ID: " + createdBy.Id);
                                
                                //Get the name of the createdBy User
                                Console.WriteLine("Profile Created By User-Name: " + createdBy.Name);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Profile Created By User-Email: " + createdBy.Email);
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

        /// <summary>
        /// This method is used to get the details of any specific profile.
        /// Specify the unique id of the profile in your API request to get the data for that particular profile.
        /// </summary>
        /// <param name="profileId">The ID of the Profile to be obtained</param>
        public static void GetProfile(long profileId)
        {
            //example
            //long profileId = 34770610026011;

            DateTimeOffset ifModifiedSince = new DateTimeOffset(new DateTime(2020, 05, 15, 12, 0, 0, DateTimeKind.Local));

            //Get instance of ProfilesOperations Class
            ProfilesOperations profilesOperations = new ProfilesOperations(null);
            
            //Call GetProfile method that takes profileId as parameter
            APIResponse<ResponseHandler> response = profilesOperations.GetProfile(profileId);
            
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
                        
                        //Get the list of obtained Profile instances
                        List<Com.Zoho.Crm.API.Profiles.Profile> profiles = responseWrapper.Profiles;
                    
                        foreach(Com.Zoho.Crm.API.Profiles.Profile profile in profiles)
                        {
                            //Get the DisplayLabel of the each Profile
                            Console.WriteLine("Profile DisplayLabel: " + profile.DisplayLabel);
                            
                            if(profile.CreatedTime != null)
                            {
                                //Get the CreatedTime of each Profile
                                Console.WriteLine("Profile CreatedTime: " + profile.CreatedTime);
                            }
                            
                            if(profile.ModifiedTime != null)
                            {
                                //Get the ModifiedTime of each Profile
                                Console.WriteLine("Profile ModifiedTime: " + profile.ModifiedTime);
                            }
						
                            //Get the permissionsDetails of each Profile
                            List<PermissionDetail> permissionsDetails = profile.PermissionsDetails;
                            
                            //Check if permissionsDetails is not null
                            if(permissionsDetails != null)
                            {
                                foreach(PermissionDetail permissionsDetail in permissionsDetails)
                                {
                                    //Get the DisplayLabel of the each PermissionDetail
                                    Console.WriteLine("Profile PermissionDetail DisplayLabel: " + permissionsDetail.DisplayLabel);
                                    
                                    //Get the Module of the each PermissionDetail
                                    Console.WriteLine("Profile PermissionDetail Module: " + permissionsDetail.Module);
                                    
                                    //Get the Name of the each PermissionDetail
                                    Console.WriteLine("Profile PermissionDetail Name: " + permissionsDetail.Name);
                                    
                                    //Get the ID of the each PermissionDetail
                                    Console.WriteLine("Profile PermissionDetail ID: " + permissionsDetail.Id);
                                    
                                    //Get the Enabled of the each PermissionDetail
                                    Console.WriteLine("Profile PermissionDetail Enabled: " + permissionsDetail.Enabled);
                                }
                            }
						
                            //Get the Name of the each Profile
                            Console.WriteLine("Profile Name: " + profile.Name);
                            
                            //Get the modifiedBy User instance of each Profile
                            User modifiedBy = profile.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-ID: " + modifiedBy.Id);
                                
                                //Get the name of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-Name: " + modifiedBy.Name);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Profile Modified By User-Email: " + modifiedBy.Email);
                            }
						
                            //Get the Description of the each Profile
                            Console.WriteLine("Profile Description: " + profile.Description);
                            
                            //Get the ID of the each Profile
                            Console.WriteLine("Profile ID: " + profile.Id);
                            
                            //Get the Category of the each Profile
                            Console.WriteLine("Profile Category: " + profile.Category);
                            
                            //Get the createdBy User instance of each Profile
                            User createdBy = profile.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the ID of the createdBy User
                                Console.WriteLine("Profile Created By User-ID: " + createdBy.Id);
                                
                                //Get the name of the createdBy User
                                Console.WriteLine("Profile Created By User-Name: " + createdBy.Name);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Profile Created By User-Email: " + createdBy.Email);
                            }
						
                            //Get the sections of each Profile
                            List<Section> sections = profile.Sections;
                            
                            //Check if sections is not null
                            if(sections != null)
                            {
                                foreach(Section section in sections)
                                {
                                    //Get the Name of the each Section
                                    Console.WriteLine("Profile Section Name: " + section.Name);
                                    
                                    //Get the categories of each Section
                                    List<Category> categories = section.Categories;
                                    
                                    foreach(Category category in categories)
                                    {
                                        //Get the DisplayLabel of the each Category
                                        Console.WriteLine("Profile Section Category DisplayLabel: " + category.DisplayLabel);
                                        
                                        //Get the permissionsDetails List of each Category
                                        List<string> categoryPermissionsDetails = category.PermissionsDetails;
                                        
                                        //Check if categoryPermissionsDetails is not null
                                        if(categoryPermissionsDetails != null)
                                        {
                                            foreach(object permissionsDetailID in categoryPermissionsDetails)
                                            {
                                                //Get the permissionsDetailID of the Category
                                                Console.WriteLine("Profile Section Category permissionsDetailID: " + permissionsDetailID);
                                            }
                                        }
                                        
                                        //Get the Name of the each Category
                                        Console.WriteLine("Profile Section Category Name: " + category.Name);
                                    }
                                }
                            }
                            
                            if(profile.Delete != null)
                            {
                                //Get the Delete of the each Profile
                                Console.WriteLine("Profile Delete: " + profile.Delete);
                            }
        
                            if(profile.Default != null)
                            {
                                //Get the Default of the each Profile
                                Console.WriteLine("Profile Default: " + profile.Default);
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
	}
}

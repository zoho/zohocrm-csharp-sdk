using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Org;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

namespace Com.Zoho.Crm.Sample.Organization
{
    public class Organization
    {
        /// <summary>
        /// This method is used to get the organization data and print the response.
        /// </summary>
        public static void GetOrganization()
        {
            //Get instance of OrgOperations Class
            OrgOperations orgOperations = new OrgOperations();
            
            //Call getOrganization method
            APIResponse<ResponseHandler> response = orgOperations.GetOrganization();
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ResponseHandler responseHandler = response.Object;
                    
                    if(responseHandler is ResponseWrapper)
                    {
                        //Get the received ResponseWrapper instance
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the list of obtained Org instances
                        List<API.Org.Org> orgs = responseWrapper.Org;
                    
                        foreach(API.Org.Org org in orgs)
                        {
                            //Get the Country of each Organization
                            Console.WriteLine("Organization Country: " + org.Country);
                            
                            //Get the PhotoId of each Organization
                            Console.WriteLine("Organization PhotoId: " + org.PhotoId);
                            
                            //Get the City of each Organization
                            Console.WriteLine("Organization City: " + org.City);
                            
                            //Get the Description of each Organization
                            Console.WriteLine("Organization Description: " + org.Description);
                            
                            //Get the McStatus of each Organization
                            Console.WriteLine("Organization McStatus: " + org.McStatus);
                            
                            //Get the GappsEnabled of each Organization
                            Console.WriteLine("Organization GappsEnabled: " + org.GappsEnabled);
                            
                            //Get the DomainName of each Organization
                            Console.WriteLine("Organization DomainName: " + org.DomainName);
                            
                            //Get the TranslationEnabled of each Organization
                            Console.WriteLine("Organization TranslationEnabled: " + org.TranslationEnabled);
                            
                            //Get the Street of each Organization
                            Console.WriteLine("Organization Street: " + org.Street);
                            
                            //Get the Alias of each Organization
                            Console.WriteLine("Organization Alias: " + org.Alias);
                            
                            //Get the Currency of each Organization
                            Console.WriteLine("Organization Currency: " + org.Currency);
                            
                            //Get the Id of each Organization
                            Console.WriteLine("Organization Id: " + org.Id);
                            
                            //Get the State of each Organization
                            Console.WriteLine("Organization State: " + org.State);
                            
                            //Get the Fax of each Organization
                            Console.WriteLine("Organization Fax: " + org.Fax);
                            
                            //Get the EmployeeCount of each Organization
                            Console.WriteLine("Organization EmployeeCount: " + org.EmployeeCount);
                            
                            //Get the Zip of each Organization
                            Console.WriteLine("Organization Zip: " + org.Zip);
                            
                            //Get the Website of each Organization
                            Console.WriteLine("Organization Website: " + org.Website);
                            
                            //Get the CurrencySymbol of each Organization
                            Console.WriteLine("Organization CurrencySymbol: " + org.CurrencySymbol);
                            
                            //Get the Mobile of each Organization
                            Console.WriteLine("Organization Mobile: " + org.Mobile);
                            
                            //Get the CurrencyLocale of each Organization
                            Console.WriteLine("Organization CurrencyLocale: " + org.CurrencyLocale);
                            
                            //Get the PrimaryZuid of each Organization
                            Console.WriteLine("Organization PrimaryZuid: " + org.PrimaryZuid);
                            
                            //Get the ZiaPortalId of each Organization
                            Console.WriteLine("Organization ZiaPortalId: " + org.ZiaPortalId);
                            
                            //Get the TimeZone of each Organization
                            Console.WriteLine("Organization TimeZone: " + org.TimeZone);
                            
                            //Get the Zgid of each Organization
                            Console.WriteLine("Organization Zgid: " + org.Zgid);
                            
                            //Get the CountryCode of each Organization
                            Console.WriteLine("Organization CountryCode: " + org.CountryCode);
                            
                            //Get the Object obtained LicenseDetails instance
                            LicenseDetails licenseDetails = org.LicenseDetails;
                            
                            //Check if licenseDetails is not null
                            if(licenseDetails != null)
                            {
                                //Get the PaidExpiry of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails PaidExpiry: " + licenseDetails.PaidExpiry);
                                
                                //Get the UsersLicensePurchased of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails UsersLicensePurchased: " + licenseDetails.UsersLicensePurchased);
                                
                                //Get the TrialType of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails TrialType: " + licenseDetails.TrialType);
                                
                                //Get the TrialExpiry of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails TrialExpiry: " + licenseDetails.TrialExpiry);
                                
                                //Get the Paid of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails Paid: " + licenseDetails.Paid);
                                
                                //Get the PaidType of each LicenseDetails
                                Console.WriteLine("Organization LicenseDetails PaidType: " + licenseDetails.PaidType);
                            }
                            
                            //Get the Phone of each Organization
                            Console.WriteLine("Organization Phone: " + org.Phone);
                            
                            //Get the CompanyName of each Organization
                            Console.WriteLine("Organization CompanyName: " + org.CompanyName);
                            
                            //Get the PrivacySettings of each Organization
                            Console.WriteLine("Organization PrivacySettings: " + org.PrivacySettings);
                            
                            //Get the PrimaryEmail of each Organization
                            Console.WriteLine("Organization PrimaryEmail: " + org.PrimaryEmail);
                            
                            //Get the IsoCode of each Organization
                            Console.WriteLine("Organization IsoCode: " + org.IsoCode);
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
        /// This method is used to upload the brand logo or image of the organization and print the response.
        /// </summary>
        /// <param name="absoluteFilePath">The absolute file path of the file to be attached</param>
        public static void UploadOrganizationPhoto(string absoluteFilePath)
        {
            //example
            //string absoluteFilePath = "/Users/user_name/Desktop/download.png";
            
            //Get instance of OrgOperations Class
            OrgOperations orgOperations = new OrgOperations();
            
            //Get instance of FileBodyWrapper class that will contain the request file
            FileBodyWrapper fileBodyWrapper = new FileBodyWrapper();
            
            //Get instance of StreamWrapper class that takes absolute path of the file to be attached as parameter
            StreamWrapper streamWrapper = new StreamWrapper(absoluteFilePath);
            
            //Set file to the FileBodyWrapper instance
            fileBodyWrapper.File = streamWrapper;
            
            //Call uploadOrganizationPhoto method that takes FileBodyWrapper instance
            APIResponse<ActionResponse> response = orgOperations.UploadOrganizationPhoto(fileBodyWrapper);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    ActionResponse actionResponse = response.Object;
                    
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
                        
                        if(successResponse.Details != null)
                        {
                            //Get the details map
                            foreach(KeyValuePair<string, object> entry in successResponse.Details)
                            {
                                //Get each value in the map
                                Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                            }
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

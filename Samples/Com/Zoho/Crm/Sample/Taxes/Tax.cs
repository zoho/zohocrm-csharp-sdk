using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Taxes;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.Crm.API.Taxes.TaxesOperations;

namespace Com.Zoho.Crm.Sample.Taxes
{
    public class Tax
    {
        /// <summary>
        /// This method is used to get all the Organization Taxes and print the response.
        /// </summary>
        public static void GetTaxes()
        {
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Call GetTaxes method 
            APIResponse<ResponseHandler> response = taxesOperations.GetTaxes();
            
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
                        
                        //Get the list of obtained Tax instances
                        List<Com.Zoho.Crm.API.Taxes.Tax> taxes = responseWrapper.Taxes;
                        
                        foreach(Com.Zoho.Crm.API.Taxes.Tax tax in taxes)
                        {	
                            //Get the DisplayLabel of each Tax
                            Console.WriteLine("Tax DisplayLabel: " + tax.DisplayLabel);
                            
                            //Get the Name of each Tax
                            Console.WriteLine("Tax Name: " + tax.Name);
                            
                            //Get the ID of each Tax
                            Console.WriteLine("Tax ID: " + tax.Id);
                            
                            //Get the Value of each Tax
                            Console.WriteLine("Tax Value: " + tax.Value);
                        }
                        
                        //Get the Preference instance of Tag
                        Preference preference = responseWrapper.Preference;
                        
                        //Check if preference is not null
                        if(preference != null)
                        {
                            //Get the AutoPopulateTax of each Preference
                            Console.WriteLine("Preference AutoPopulateTax: " + preference.AutoPopulateTax);
                            
                            //Get the ModifyTaxRates of each Preference
                            Console.WriteLine("Preference ModifyTaxRates: " + preference.ModifyTaxRates);
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
        /// This method is used to create Organization Taxes and print the response.
        /// </summary>
        public static void CreateTaxes()
        {
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Tax instances
            List<Com.Zoho.Crm.API.Taxes.Tax> taxList = new List<Com.Zoho.Crm.API.Taxes.Tax>();
            
            //Get instance of Tax Class
            Com.Zoho.Crm.API.Taxes.Tax tax1 = new Com.Zoho.Crm.API.Taxes.Tax();
            
            tax1.Name = "MyTax11";
            
            tax1.SequenceNumber = 2;
            
            tax1.Value = 10.0;
            
            taxList.Add(tax1);
            
            tax1 = new Com.Zoho.Crm.API.Taxes.Tax();

            tax1.Name = "MyTax21";

            tax1.Value = 12.0;

            taxList.Add(tax1);
            
            request.Taxes = taxList;
            
            //Call CreateTaxes method that takes BodyWrapper class instance as parameter
            APIResponse<ActionHandler> response = taxesOperations.CreateTaxes(request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Taxes;
                        
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
        /// This method is used to update Organization Taxes and print the response.
        /// </summary>
        public static void UpdateTaxes()
        {
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper request = new BodyWrapper();
            
            //List of Tax instances
            List<Com.Zoho.Crm.API.Taxes.Tax> taxList = new List<Com.Zoho.Crm.API.Taxes.Tax>();
            
            //Get instance of Tax Class
            Com.Zoho.Crm.API.Taxes.Tax tax1 = new Com.Zoho.Crm.API.Taxes.Tax();

            tax1.Id = 34770615799133;

            tax1.Name = "MyTax1134";

            tax1.SequenceNumber = 1;

            tax1.Value = 15.0;

            taxList.Add(tax1);

            tax1 = new Com.Zoho.Crm.API.Taxes.Tax();
            
            tax1.Id = 34770610339001;

            tax1.Value = 25.0;

            taxList.Add(tax1);

            tax1 = new Com.Zoho.Crm.API.Taxes.Tax();
            
            tax1.Id = 34770610339001;

            tax1.SequenceNumber = 2;

            taxList.Add(tax1);

            request.Taxes = taxList;
            
            //Call UpdateTaxes method that takes BodyWrapper instance as parameter
            APIResponse<ActionHandler> response = taxesOperations.UpdateTaxes(request);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Taxes;
                        
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
        /// This method is used to delete Organization Taxes and print the response.
        /// </summary>
        /// <param name="taxIds">The List of the tax IDs to be deleted</param>
        public static void DeleteTaxes(List<long> taxIds)
        {
            //example
            //List<long> taxIds = new List<long>(){34770616198032,34770615682038};
            
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            foreach(long taxId in taxIds)
            {
                paramInstance.Add(DeleteTaxesParam.IDS, taxId);
            }
            
            //Call deleteTaxes method that takes paramInstance as parameter
            APIResponse<ActionHandler> response = taxesOperations.DeleteTaxes(paramInstance);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Taxes;
                        
                        foreach(ActionResponse actionResponse in  actionResponses)
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
        /// This method is used to get the Organization Tax and print the response.
        /// </summary>
        /// <param name="taxId">The ID of the tax to be obtained</param>
        public static void GetTax(long taxId)
        {
            //example
            //long taxId = 34770616054012;
            
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Call GetTax method that takes taxId as parameter 
            APIResponse<ResponseHandler> response = taxesOperations.GetTax(taxId);
            
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
                        
                        //Get the list of obtained Tax instances
                        List<Com.Zoho.Crm.API.Taxes.Tax> taxes = responseWrapper.Taxes;
                        
                        foreach(Com.Zoho.Crm.API.Taxes.Tax tax in taxes)
                        {	
                            //Get the DisplayLabel of each Tax
                            Console.WriteLine("Tax DisplayLabel: " + tax.DisplayLabel);
                            
                            //Get the Name of each Tax
                            Console.WriteLine("Tax Name: " + tax.Name);
                            
                            //Get the ID of each Tax
                            Console.WriteLine("Tax ID: " + tax.Id);
                            
                            //Get the Value of each Tax
                            Console.WriteLine("Tax Value: " + tax.Value);
                        }
                        
                        //Get the Preference instance of Tag
                        Preference preference = responseWrapper.Preference;
                        
                        //Check if preference is not null
                        if(preference != null)
                        {
                            //Get the AutoPopulateTax of each Preference
                            Console.WriteLine("Preference AutoPopulateTax: " + preference.AutoPopulateTax);
                            
                            //Get the ModifyTaxRates of each Preference
                            Console.WriteLine("Preference ModifyTaxRates: " + preference.ModifyTaxRates);
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
        /// This method is used to delete Organization Tax and print the response.
        /// </summary>
        /// <param name="taxId">The ID of the tax to be deleted</param>
        public static void DeleteTax(long taxId)
        {
            //example
            //long taxId = "34770616054012";
            
            //Get instance of TaxesOperations Class
            TaxesOperations taxesOperations = new TaxesOperations();
            
            //Call DeleteTax method that takes taxId as parameter
            APIResponse<ActionHandler> response = taxesOperations.DeleteTax(taxId);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Taxes;
                        
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
    }
}

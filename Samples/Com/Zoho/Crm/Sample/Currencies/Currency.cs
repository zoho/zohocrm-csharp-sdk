using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Currencies;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using ActionHandler = Com.Zoho.Crm.API.Currencies.ActionHandler;

using ActionResponse = Com.Zoho.Crm.API.Currencies.ActionResponse;

using ActionWrapper = Com.Zoho.Crm.API.Currencies.ActionWrapper;

using APIException = Com.Zoho.Crm.API.Currencies.APIException;

using BodyWrapper = Com.Zoho.Crm.API.Currencies.BodyWrapper;

using ResponseHandler = Com.Zoho.Crm.API.Currencies.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Currencies.ResponseWrapper;

using SuccessResponse = Com.Zoho.Crm.API.Currencies.SuccessResponse;

namespace Com.Zoho.Crm.Sample.Currencies
{
    public class Currency
    {
        /// <summary>
        /// This method is used to get all the available currencies in your organization.
        /// </summary>
        public static void GetCurrencies()
        {
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Call GetCurrencies method 
            APIResponse<ResponseHandler> response = currenciesOperations.GetCurrencies();
            
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
                        
                        //Get the list of obtained Currency instances
                        List<Com.Zoho.Crm.API.Currencies.Currency> currenciesList = responseWrapper.Currencies;
                        
                        foreach(Com.Zoho.Crm.API.Currencies.Currency currency in currenciesList)
                        {	
                            //Get the Symbol of each currency
                            Console.WriteLine("Currency Symbol: " + currency.Symbol);
                            
                            //Get the CreatedTime of each currency
                            Console.WriteLine("Currency CreatedTime: " + currency.CreatedTime);
                            
                            //Get the currency is IsActive
                            Console.WriteLine("Currency IsActive: " + currency.IsActive);
                            
                            //Get the ExchangeRate of each currency
                            Console.WriteLine("Currency ExchangeRate: " + currency.ExchangeRate);
                            
                            //Get the format instance of each currency
                            Format format = currency.Format;
                            
                            //Check if format is not null
                            if(format != null)
                            {
                                //Get the DecimalSeparator of the Format
                                Console.WriteLine("Currency Format DecimalSeparator: " + format.DecimalSeparator.Value);
                                
                                //Get the ThousandSeparator of the Format
                                Console.WriteLine("Currency Format ThousandSeparator: " + format.ThousandSeparator.Value);
                                
                                //Get the DecimalPlaces of the Format
                                Console.WriteLine("Currency Format DecimalPlaces: " + format.DecimalPlaces.Value);
                            }
                            
                            //Get the createdBy User instance of each currency
                            User createdBy = currency.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Currency CreatedBy User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Currency CreatedBy User-ID: " + createdBy.Id);
                            }
                            
                            //Get the PrefixSymbol of each currency
                            Console.WriteLine("Currency PrefixSymbol: " + currency.PrefixSymbol);
                            
                            //Get the IsBase of each currency
                            Console.WriteLine("Currency IsBase: " + currency.IsBase);
                            
                            //Get the ModifiedTime of each currency
                            Console.WriteLine("Currency ModifiedTime: " + currency.ModifiedTime);
                            
                            //Get the Name of each currency
                            Console.WriteLine("Currency Name: " + currency.Name);
                            
                            //Get the modifiedBy User instance of each currency
                            User modifiedBy = currency.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Currency ModifiedBy User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Currency ModifiedBy User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Id of each currency
                            Console.WriteLine("Currency Id: " + currency.Id);
                            
                            //Get the IsoCode of each currency
                            Console.WriteLine("Currency IsoCode: " + currency.IsoCode);
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
        /// This method is used to add new currencies to your organization.
        /// </summary>
        public static void AddCurrencies()
        {		
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Currency instances
            List<Com.Zoho.Crm.API.Currencies.Currency> currencies = new List<Com.Zoho.Crm.API.Currencies.Currency>();

            //Get instance of Currency Class
            Com.Zoho.Crm.API.Currencies.Currency currency = new Com.Zoho.Crm.API.Currencies.Currency();
            
            //To set the position of the ISO code in the currency.
            //true: Display ISO code before the currency value.
            //false: Display ISO code after the currency value.
            currency.PrefixSymbol = true;

            //To set the name of the currency.
            currency.Name = "Angolan Kwanza - AOA";

            //To set the ISO code of the currency.
            currency.IsoCode = "AOA";

            //To set the symbol of the currency.
            currency.Symbol = "Kz";

            //To set the rate at which the currency has to be exchanged for home currency.
            currency.ExchangeRate = "20.0000";

            //To set the status of the currency.
            //true: The currency is active.
            //false: The currency is inactive.
            currency.IsActive = true;
            
            Format format = new Format();
            
            //It can be a Period or Comma, depending on the currency.
            format.DecimalSeparator = new Choice<string>("Period");
            
            //It can be a Period, Comma, or Space, depending on the currency.
            format.ThousandSeparator = new Choice<string>("Comma");
        
            //To set the number of decimal places allowed for the currency. It can be 0, 2, or 3.
            format.DecimalPlaces = new Choice<string>("2");
            
            //To set the format of the currency
            currency.Format = format;
            
            currencies.Add(currency);
            
            //Set the list to Currency in BodyWrapper instance
            bodyWrapper.Currencies = currencies;
            
            //Call AddCurrencies method that takes BodyWrapper instance as parameter 
            APIResponse<ActionHandler> response = currenciesOperations.AddCurrencies(bodyWrapper);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Currencies;
                        
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
        /// This method is used to update currency details.
        /// </summary>
        public static void UpdateCurrencies()
        {
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Currency instances
            List<Com.Zoho.Crm.API.Currencies.Currency> currencies = new List<Com.Zoho.Crm.API.Currencies.Currency>();

            //Get instance of Currency Class
            Com.Zoho.Crm.API.Currencies.Currency currency = new Com.Zoho.Crm.API.Currencies.Currency();
            
            //To set the position of the ISO code in the currency.
            //true: Display ISO code before the currency value.
            //false: Display ISO code after the currency value.
            currency.PrefixSymbol = true;

            //To set currency Id
            //currency.Id = 34770616040001;

            //To set the rate at which the currency has to be exchanged for home currency.
            currency.ExchangeRate = "5.00";
            
            //To set the status of the currency.
            //true: The currency is active.
            //false: The currency is inactive.
            currency.IsActive = true;
            
            Format format = new Format();

            //It can be a Period or Comma, depending on the currency.
            format.DecimalSeparator = new Choice<string>("Period");

            //It can be a Period, Comma, or Space, depending on the currency.
            format.ThousandSeparator = new Choice<string>("Comma");

            //To set the number of decimal places allowed for the currency. It can be 0, 2, or 3.
            format.DecimalPlaces = new Choice<string>("2");

            //To set the format of the currency
            currency.Format = format;

            //Add Currency instance to the list
            currencies.Add(currency);
            
            //Set the list to Currency in BodyWrapper instance
            bodyWrapper.Currencies = currencies;
            
            //Call UpdateCurrencies method that takes BodyWrapper instance as parameter 
            APIResponse<ActionHandler> response = currenciesOperations.UpdateCurrencies(bodyWrapper);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Currencies;
                        
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
        /// This method is used to enable multiple currencies for your organization.
        /// </summary>
        public static void EnableMultipleCurrencies()
        {
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Get instance of BaseCurrencyWrapper Class that will contain the request body
            BaseCurrencyWrapper bodyWrapper = new BaseCurrencyWrapper();
            
            //Get instance of Currency Class
            Com.Zoho.Crm.API.Currencies.Currency currency = new Com.Zoho.Crm.API.Currencies.Currency();
            
            //To set the position of the ISO code in the base currency.
            //true: Display ISO code before the currency value.
            //false: Display ISO code after the currency value.
            //currency.PrefixSymbol = true;
            
            //To set the name of the base currency.
            currency.Name = "Algerian Dinar-ADN";
            
            //To set the ISO code of the base currency.
            currency.IsoCode = "DZD";
            
            //To set the symbol of the base currency.
            currency.Symbol = "Af";
            
            //To set the rate at which the currency has to be exchanged for home base currency.
            currency.ExchangeRate = "1.00";
            
            //To set the status of the base currency.
            //true: The currency is active.
            //false: The currency is inactive.
            currency.IsActive = true;
            
            Format format = new Format();
            
            //It can be a Period or Comma, depending on the base currency.
            format.DecimalSeparator = new Choice<string>("Period");
            
            //It can be a Period, Comma, or Space, depending on the base currency.  
            format.ThousandSeparator = new Choice<string>("Comma");
        
            //To set the number of decimal places allowed for the base currency. It can be 0, 2, or 3.
            format.DecimalPlaces = new Choice<string>("2");
            
            //To set the format of the base currency
            //currency.Format = format;
            
            //Set the Currency in BodyWrapper instance
            bodyWrapper.BaseCurrency = currency;
            
            //Call EnableMultipleCurrencies method that takes BodyWrapper instance as parameter 
            APIResponse<BaseCurrencyActionHandler> response = currenciesOperations.EnableMultipleCurrencies(bodyWrapper);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    BaseCurrencyActionHandler baseCurrencyActionHandler = response.Object;
                    
                    if(baseCurrencyActionHandler is BaseCurrencyActionWrapper)
                    {
                        //Get the received BaseCurrencyActionWrapper instance
                        BaseCurrencyActionWrapper baseCurrencyActionWrapper = (BaseCurrencyActionWrapper) baseCurrencyActionHandler;
                        
                        //Get the received obtained ActionResponse instances
                        ActionResponse actionResponse = baseCurrencyActionWrapper.BaseCurrency;
                        
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
                    //Check if the request returned an exception
                    else if(baseCurrencyActionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) baseCurrencyActionHandler;
                        
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
        /// This method is used to update base currency details.
        /// </summary>
        public static void UpdateBaseCurrency()
        {
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Get instance of BaseCurrencyWrapper Class that will contain the request body
            BaseCurrencyWrapper bodyWrapper = new BaseCurrencyWrapper();
            
            //Get instance of Currency Class
            Com.Zoho.Crm.API.Currencies.Currency currency = new Com.Zoho.Crm.API.Currencies.Currency();
            
            //To set the position of the ISO code in the base currency.
            //true: Display ISO code before the currency value.
            //false: Display ISO code after the currency value.
            currency.PrefixSymbol = true;
            
            //To set the symbol of the base currency.
            currency.Symbol = "Af";
            
            //To set the rate at which the currency has to be exchanged for home base currency.
            currency.ExchangeRate = "1.00";

            //To set currency Id
            currency.Id = 34770616008002;

            Format format = new Format();
            
            //It can be a Period or Comma, depending on the base currency.
            format.DecimalSeparator = new Choice<string>("Period");
            
            //It can be a Period, Comma, or Space, depending on the base currency.
            format.ThousandSeparator = new Choice<string>("Comma");

            //To set the number of decimal places allowed for the base currency. It can be 0, 2, or 3.
            format.DecimalPlaces = new Choice<string>("2");

            //To set the format of the base currency
            currency.Format = format;

            //Set the Currency in BodyWrapper instance
            bodyWrapper.BaseCurrency = currency;
            
            //Call UpdateBaseCurrency method that takes BodyWrapper instance as parameter 
            APIResponse<BaseCurrencyActionHandler> response = currenciesOperations.UpdateBaseCurrency(bodyWrapper);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                //Check if expected response is received
                if(response.IsExpected)
                {
                    //Get object from response
                    BaseCurrencyActionHandler baseCurrencyActionHandler = response.Object;
                    
                    if(baseCurrencyActionHandler is BaseCurrencyActionWrapper)
                    {
                        //Get the received BaseCurrencyActionWrapper instance
                        BaseCurrencyActionWrapper baseCurrencyActionWrapper = (BaseCurrencyActionWrapper) baseCurrencyActionHandler;
                        
                        //Get the ActionResponse instance
                        ActionResponse actionResponse = baseCurrencyActionWrapper.BaseCurrency;
                        
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
                    //Check if the request returned an exception
                    else if(baseCurrencyActionHandler is APIException)
                    {
                        //Get the received APIException instance
                        APIException exception = (APIException) baseCurrencyActionHandler;
                        
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
        /// This method is used to get the details of a specific currency.
        /// </summary>
        /// <param name="currencyId">Specify the unique ID of the currency.</param>
        public static void GetCurrency(long currencyId)
        {
            //example
            //long currencyId = 34770616011001;
            
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Call GetCurrency method that takes currencyId as parameter 
            APIResponse<ResponseHandler> response = currenciesOperations.GetCurrency(currencyId);
            
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
                        ResponseWrapper responseWrapper = (ResponseWrapper) responseHandler;
                        
                        //Get the obtained Currency instance
                        List<Com.Zoho.Crm.API.Currencies.Currency> currenciesList = responseWrapper.Currencies;
                        
                        foreach(Com.Zoho.Crm.API.Currencies.Currency currency in currenciesList)
                        {	
                            //Get the Symbol of each currency
                            Console.WriteLine("Currency Symbol: " + currency.Symbol);
                            
                            //Get the CreatedTime of each currency
                            Console.WriteLine("Currency CreatedTime: " + currency.CreatedTime);
                            
                            //Get the currency is IsActive
                            Console.WriteLine("Currency IsActive: " + currency.IsActive);
                            
                            //Get the ExchangeRate of each currency
                            Console.WriteLine("Currency ExchangeRate: " + currency.ExchangeRate);
                            
                            //Get the format Format instance of each currency
                            Format format = currency.Format;
                            
                            //Check if format is not null
                            if(format != null)
                            {
                                //Get the DecimalSeparator of the Format
                                Console.WriteLine("Currency Format DecimalSeparator: " + format.DecimalSeparator.Value);
                                
                                //Get the ThousandSeparator of the Format
                                Console.WriteLine("Currency Format ThousandSeparator: " + format.ThousandSeparator.Value);
                                
                                //Get the DecimalPlaces of the Format
                                Console.WriteLine("Currency Format DecimalPlaces: " + format.DecimalPlaces.Value);
                            }
                            
                            //Get the createdBy User instance of each currency
                            User createdBy = currency.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Currency CreatedBy User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Currency CreatedBy User-ID: " + createdBy.Id);
                            }
                            
                            //Get the PrefixSymbol of each currency
                            Console.WriteLine("Currency PrefixSymbol: " + currency.PrefixSymbol);
                            
                            //Get the IsBase of each currency
                            Console.WriteLine("Currency IsBase: " + currency.IsBase);
                            
                            //Get the ModifiedTime of each currency
                            Console.WriteLine("Currency ModifiedTime: " + currency.ModifiedTime);
                            
                            //Get the Name of each currency
                            Console.WriteLine("Currency Name: " + currency.Name);
                            
                            //Get the modifiedBy User instance of each currency
                            User modifiedBy = currency.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Currency ModifiedBy User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Currency ModifiedBy User-ID: " + modifiedBy.Id);
                            }
                            
                            //Get the Id of each currency
                            Console.WriteLine("Currency Id: " + currency.Id);
                            
                            //Get the IsoCode of each currency
                            Console.WriteLine("Currency IsoCode: " + currency.IsoCode);
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
        /// This method is used to update currency details.
        /// </summary>
        /// <param name="currencyId">Specify the unique ID of the currency.</param>
        public static void UpdateCurrency(long currencyId)
        {
            //example
            //long currencyId = 34770616011001;
            
            //Get instance of CurrenciesOperations Class
            CurrenciesOperations currenciesOperations = new CurrenciesOperations();
            
            //Get instance of BodyWrapper Class that will contain the request body
            BodyWrapper bodyWrapper = new BodyWrapper();
            
            //List of Currency instances
            List<Com.Zoho.Crm.API.Currencies.Currency> currencies = new List<Com.Zoho.Crm.API.Currencies.Currency>();
            
            //Get instance of Currency Class
            Com.Zoho.Crm.API.Currencies.Currency currency = new Com.Zoho.Crm.API.Currencies.Currency();
            
            //To set the position of the ISO code in the currency.
            //true: Display ISO code before the currency value.
            //false: Display ISO code after the currency value.
            currency.PrefixSymbol = true;
            
            //To set the rate at which the currency has to be exchanged for home currency.
            currency.ExchangeRate = "5.00";
            
            //To set the status of the currency.
            //true: The currency is active.
            //false: The currency is inactive.
            currency.IsActive = true;
            
            Format format = new Format();
            
            //It can be a Period or Comma, depending on the currency.
            format.DecimalSeparator = new Choice<string>("Period");
            
            //It can be a Period, Comma, or Space, depending on the currency.
            format.ThousandSeparator = new Choice<string>("Comma");

            //To set the number of decimal places allowed for the currency. It can be 0, 2, or 3.
            format.DecimalPlaces = new Choice<string>("2");

            //To set the format of the currency
            currency.Format = format;
            
            currencies.Add(currency);
            
            //Set the list to Currency in BodyWrapper instance
            bodyWrapper.Currencies = currencies;

            //Call UpdateCurrency method that takes currencyId and BodyWrapper instance as parameters 
            APIResponse<ActionHandler>response = currenciesOperations.UpdateCurrency(currencyId, bodyWrapper);
            
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
                        List<ActionResponse> actionResponses = actionWrapper.Currencies;
                        
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

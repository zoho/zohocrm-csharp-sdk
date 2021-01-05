using System;

using Com.Zoho.Crm.API.Fields;

using System.Collections.Generic;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Util;

using static Com.Zoho.Crm.API.Fields.FieldsOperations;

using Newtonsoft.Json;

using Com.Zoho.Crm.API.Layouts;

using ResponseHandler = Com.Zoho.Crm.API.Fields.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Fields.ResponseWrapper;

using APIException = Com.Zoho.Crm.API.Fields.APIException;

using System.Reflection;

using Module = Com.Zoho.Crm.API.Fields.Module;

namespace Com.Zoho.Crm.Sample.Fields
{
    public class Fields
    {

        /// <summary>
        /// This method is used to get metadata about all the fields of a module and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get fields</param>
        public static void GetFields(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of FieldsOperations Class that takes moduleAPIName as parameter
            FieldsOperations fieldOperations = new FieldsOperations(moduleAPIName);
            
            //Get instance of ParameterMap Class
            ParameterMap paramInstance = new ParameterMap();
            
            //paramInstance.Add(GetFieldsParam.TYPE, "Unused");
            
            //Call GetFields method that takes paramInstance as parameter 
            APIResponse<ResponseHandler> response = fieldOperations.GetFields(paramInstance);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if( new List<int>() { 204, 304 }.Contains(response.StatusCode))
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
                        
                        //Get the list of obtained Field instances
                        List<Field> fields = responseWrapper.Fields;
                    
                        foreach(Field field in fields)
                        {
                            //Get the SystemMandatory of each Field
                            Console.WriteLine("Field SystemMandatory: " + field.SystemMandatory);
                            
                            //Get the Webhook of each Field
                            Console.WriteLine("Field Webhook: " + field.Webhook);

                            //Get the Object obtained Private instance
                            Private private1 = field.Private;

                            //Check if private is not null
                            if (private1 != null)
                            {
                                //Get the Restricted of the Private
                                Console.WriteLine("Field Private Restricted: " + private1.Restricted);

                                //Get the Export of the Private
                                Console.WriteLine("Field Private Export: " + private1.Export);

                                //Get the Type of the Private
                                Console.WriteLine("Field Private Type: " + private1.Type);
                            }

                            //Get the JsonType of each Field
                            Console.WriteLine("Field JsonType: " + field.JsonType);
                            
                            //Get the Object obtained Crypt instance
                            Crypt crypt = field.Crypt;
                            
                            //Check if crypt is not null
                            if(crypt != null)
                            {
                                //Get the Mode of the Crypt
                                Console.WriteLine("Field Crypt Mode: " + crypt.Mode);
                                
                                //Get the Column of the Crypt
                                Console.WriteLine("Field Crypt Column: " + crypt.Column);
                                
                                //Get the Table of the Crypt
                                Console.WriteLine("Field Crypt Table: " + crypt.Table);
                                
                                //Get the Status of the Crypt
                                Console.WriteLine("Field Crypt Status: " + crypt.Status);
                            }
                            
                            //Get the FieldLabel of each Field
                            Console.WriteLine("Field FieldLabel: " + field.FieldLabel);
                            
                            //Get the Object obtained ToolTip instance
                            ToolTip tooltip = field.Tooltip;
                            
                            //Check if tooltip is not null
                            if(tooltip != null)
                            {
                                //Get the Name of the ToolTip
                                Console.WriteLine("Field ToolTip Name: " + tooltip.Name);
                                
                                //Get the Value of the ToolTip
                                Console.WriteLine("Field ToolTip Value: " + tooltip.Value);
                            }
                            
                            //Get the CreatedSource of each Field
                            Console.WriteLine("Field CreatedSource: " + field.CreatedSource);
                            
                            //Get the FieldReadOnly of each Field
                            Console.WriteLine("Field FieldReadOnly: " + field.FieldReadOnly);
                            
                            //Get the DisplayLabel of each Field
                            Console.WriteLine("Field DisplayLabel: " + field.DisplayLabel);
                            
                            //Get the ReadOnly of each Field
                            Console.WriteLine("Field ReadOnly: " + field.ReadOnly);
                            
                            //Get the Object obtained AssociationDetails instance
                            AssociationDetails associationDetails = field.AssociationDetails;
                            
                            //Check if associationDetails is not null
                            if(associationDetails != null)
                            {
                                //Get the Object obtained LookupField instance
                                LookupField lookupField = associationDetails.LookupField;
                                
                                //Check if lookupField is not null
                                if(lookupField != null)
                                {
                                    //Get the ID of the LookupField
                                    Console.WriteLine("Field AssociationDetails LookupField ID: " + lookupField.Id);
                                    
                                    //Get the Name of the LookupField
                                    Console.WriteLine("Field AssociationDetails LookupField Name: " + lookupField.Name);
                                }
                                
                                //Get the Object obtained LookupField instance
                                LookupField relatedField = associationDetails.RelatedField;
                                
                                //Check if relatedField is not null
                                if(relatedField != null)
                                {
                                    //Get the ID of the relatedField
                                    Console.WriteLine("Field AssociationDetails RelatedField ID: " + relatedField.Id);
                                    
                                    //Get the Name of the relatedField
                                    Console.WriteLine("Field AssociationDetails RelatedField Name: " + relatedField.Name);
                                }
                            }
                            
                            if(field.QuickSequenceNumber != null)
                            {
                                //Get the QuickSequenceNumber of each Field
                                Console.WriteLine("Field QuickSequenceNumber: " + field.QuickSequenceNumber);
                            }
                            
                            //Get the BusinesscardSupported of each Field
                            Console.WriteLine("Field BusinesscardSupported: " + field.BusinesscardSupported);
                            
                            //Check if MultiModuleLookup is not null
                            if(field.MultiModuleLookup != null)
                            {
                                //Get the MultiModuleLookup map
                                foreach(KeyValuePair<string, object> entry in field.MultiModuleLookup)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Get the Object obtained Currency instance
                            Com.Zoho.Crm.API.Fields.Currency currency = field.Currency;
                            
                            //Check if currency is not null
                            if(currency != null)
                            {
                                //Get the RoundingOption of the Currency
                                Console.WriteLine("Field Currency RoundingOption: " + currency.RoundingOption);
                                
                                if(currency.Precision != null)
                                {
                                    //Get the Precision of the Currency
                                    Console.WriteLine("Field Currency Precision: " + currency.Precision);
                                }
                            }
                            
                            //Get the ID of each Field
                            Console.WriteLine("Field ID: " + field.Id);
                            
                            if(field.CustomField != null)
                            {
                                //Get the CustomField of each Field
                                Console.WriteLine("Field CustomField: " + field.CustomField);
                            }
                            
                            //Get the Object obtained Module instance
                            Module lookup = field.Lookup;
                            
                            //Check if lookup is not null
                            if(lookup != null)
                            {
                                //Get the Object obtained Layout instance
                                Layout layout = lookup.Layout;
                                
                                //Check if layout is not null
                                if(layout != null)
                                {
                                    //Get the ID of the Layout
                                    Console.WriteLine("Field ModuleLookup Layout ID: " + layout.Id);
                                    
                                    //Get the Name of the Layout
                                    Console.WriteLine("Field ModuleLookup Layout Name: " + layout.Name);
                                }
                                
                                //Get the DisplayLabel of the Module
                                Console.WriteLine("Field ModuleLookup DisplayLabel: " + lookup.DisplayLabel);
                                
                                //Get the APIName of the Module
                                Console.WriteLine("Field ModuleLookup APIName: " + lookup.APIName);
                                
                                //Get the Module of the Module
                                Console.WriteLine("Field ModuleLookup Module: " + lookup.Module_1);
                                
                                if(lookup.Id != null)
                                {
                                    //Get the ID of the Module
                                    Console.WriteLine("Field ModuleLookup ID: " + lookup.Id);
                                }
                            }
                            
                            if(field.Visible != null)
                            {
                                //Get the Visible of each Field
                                Console.WriteLine("Field Visible: " + field.Visible);
                            }
                            
                            if(field.Length != null)
                            {
                                //Get the Length of each Field
                                Console.WriteLine("Field Length: " + field.Length);
                            }
                            
                            //Get the Object obtained ViewType instance
                            ViewType viewType = field.ViewType;
                            
                            //Check if viewType is not null
                            if(viewType != null)
                            {
                                //Get the View of the ViewType
                                Console.WriteLine("Field ViewType View: " + viewType.View);
                                
                                //Get the Edit of the ViewType
                                Console.WriteLine("Field ViewType Edit: " + viewType.Edit);
                                
                                //Get the Create of the ViewType
                                Console.WriteLine("Field ViewType Create: " + viewType.Create);
                                
                                //Get the View of the ViewType
                                Console.WriteLine("Field ViewType QuickCreate: " + viewType.QuickCreate);
                            }
                            
                            //Get the Object obtained Module instance
                            Module subform = field.Subform;

                            //Check if Subform is not null
                            if (subform != null)
                            {
                                //Get the Object obtained Layout instance
                                Layout layout = subform.Layout;
                                
                                //Check if layout is not null
                                if(layout != null)
                                {
                                    //Get the ID of the Layout
                                    Console.WriteLine("Field Subform Layout ID: " + layout.Id);
                                    
                                    //Get the Name of the Layout
                                    Console.WriteLine("Field Subform Layout Name: " + layout.Name);
                                }
                                
                                //Get the DisplayLabel of the Module
                                Console.WriteLine("Field Subform DisplayLabel: " + subform.DisplayLabel);
                                
                                //Get the APIName of the Module
                                Console.WriteLine("Field Subform APIName: " + subform.APIName);
                                
                                //Get the Module of the Module
                                Console.WriteLine("Field Subform Module: " + subform.Module_1);
                                
                                if(subform.Id != null)
                                {
                                    //Get the ID of the Module
                                    Console.WriteLine("Field Subform ID: " + subform.Id);	
                                }
                            }
                            
                            //Get the APIName of each Field
                            Console.WriteLine("Field APIName: " + field.APIName);
                            
                            //Get the Object obtained Unique instance
                            Unique unique = field.Unique;
                            
                            //Check if unique is not null
                            if(unique != null)
                            {
                                //Get the Casesensitive of the Unique
                                Console.WriteLine("Field Unique Casesensitive in " + unique.Casesensitive);
                            }
                            
                            if(field.HistoryTracking != null)
                            {
                                //Get the HistoryTracking of each Field
                                Console.WriteLine("Field HistoryTracking: " + field.HistoryTracking);
                            }
                            
                            //Get the DataType of each Field
                            Console.WriteLine("Field DataType: " + field.DataType);
                            
                            //Get the Object obtained Formula instance
                            Formula formula = field.Formula;
                            
                            //Check if foreachmula is not null
                            if(formula != null)
                            {
                                //Get the ReturnType of the Formula
                                Console.WriteLine("Field Formula ReturnType in " + formula.ReturnType);
                                
                                if(formula.Expression != null)
                                {
                                    //Get the Expression of the Formula
                                    Console.WriteLine("Field Formula Expression in " + formula.Expression);
                                }
                            }
                            
                            if(field.DecimalPlace != null)
                            {
                                //Get the DecimalPlace of each Field
                                Console.WriteLine("Field DecimalPlace: " + field.DecimalPlace);
                            }
                            
                            //Get the MassUpdate of each Field
                            Console.WriteLine("Field MassUpdate: " + field.MassUpdate);
                            
                            if(field.BlueprintSupported != null)
                            {
                                //Get the BlueprintSupported of each Field
                                Console.WriteLine("Field BlueprintSupported: " + field.BlueprintSupported);
                            }
                            
                            //Get all entries from the MultiSelectLookup instance
                            MultiSelectLookup multiSelectLookup = field.Multiselectlookup;
                            
                            //Check if foreachmula is not null
                            if(multiSelectLookup != null)
                            {
                                //Get the DisplayValue of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup DisplayLabel: " + multiSelectLookup.DisplayLabel);
                                
                                //Get the LinkingModule of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup LinkingModule: " + multiSelectLookup.LinkingModule);
                                
                                //Get the LookupApiname of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup LookupApiname: " + multiSelectLookup.LookupApiname);
                                
                                //Get the APIName of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup APIName: " + multiSelectLookup.APIName);
                                
                                //Get the ConnectedlookupApiname of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup ConnectedlookupApiname: " + multiSelectLookup.ConnectedlookupApiname);
                                
                                //Get the ID of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup ID: " + multiSelectLookup.Id);
                            }
                            
                            //Get the PickListValue of each Field
                            List<PickListValue> pickListValues = field.PickListValues;
                            
                            //Check if foreachmula is not null
                            if(pickListValues != null)
                            {
                                foreach(PickListValue pickListValue in pickListValues)
                                {
                                    //Get the DisplayValue of each PickListValues
                                    Console.WriteLine("Field PickListValue DisplayValue: " + pickListValue.DisplayValue);
                                    
                                    if(pickListValue.SequenceNumber != null)
                                    {
                                        //Get the SequenceNumber of each PickListValues
                                        Console.WriteLine(" Field PickListValue SequenceNumber: " + pickListValue.SequenceNumber);
                                    }
                                    
                                    //Get the ExpectedDataType of each PickListValues
                                    Console.WriteLine("Field PickListValue ExpectedDataType: " + pickListValue.ExpectedDataType);
                                    
                                    //Get the ActualValue of each PickListValues
                                    Console.WriteLine("Field PickListValue ActualValue: " + pickListValue.ActualValue);
                                    
                                    if(pickListValue.Maps != null)
                                    {
                                        foreach(object map in pickListValue.Maps)
                                        {
                                            //Get each value from the map
                                            Console.WriteLine(map);
                                        }
                                    }
                                    
                                    //Get the SysRefName of each PickListValues
                                    Console.WriteLine("Field PickListValue SysRefName: " + pickListValue.SysRefName);
                                    
                                    //Get the Type of each PickListValues
                                    Console.WriteLine("Field PickListValue Type: " + pickListValue.Type);
                                    
                                }
                            }
                            
                            //Get the AutoNumber of each Field
                            AutoNumber autoNumber = field.AutoNumber;
                            
                            //Check if autoNumber is not null
                            if(autoNumber != null)
                            {
                                //Get the Prefix of the AutoNumber
                                Console.WriteLine("Field AutoNumber Prefix: " + autoNumber.Prefix);
                                
                                //Get the Suffix of the AutoNumber
                                Console.WriteLine("Field AutoNumber Suffix: " + autoNumber.Suffix);
                                
                                if(autoNumber.StartNumber != null)
                                {
                                    //Get the StartNumber of the AutoNumber
                                    Console.WriteLine("Field AutoNumber StartNumber: " + autoNumber.StartNumber);
                                }
                            }
                            
                            if(field.DefaultValue != null)
                            {
                                //Get the DefaultValue of each Field
                                Console.WriteLine("Field DefaultValue: " + field.DefaultValue);
                            }
                            
                            if(field.SectionId != null)
                            {
                                //Get the SectionId of each Field
                                Console.WriteLine("Field SectionId: " + field.SectionId);
                            }
                            
                            //Check if ValidationRule is not null
                            if(field.ValidationRule != null)
                            {
                                //Get the details map
                                foreach(KeyValuePair<string, object> entry in field.ValidationRule)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Check if ConvertMapping is not null
                            if(field.ConvertMapping != null)
                            {
                                //Get the details map
                                foreach(KeyValuePair<string, Object> entry in field.ConvertMapping)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
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
                        foreach(KeyValuePair<string, Object> entry in exception.Details)
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
        /// This method is used to get metadata about a single field of a module with fieldID and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the field's module</param>
        /// <param name="fieldId">The ID of the field to be obtained</param>
        public static void GetField(string moduleAPIName, long fieldId)
        {
            //example,
            //string moduleAPIName = "Leads";
            //long fieldId = 5255085067912);
            
            //Get instance of FieldsOperations Class that takes moduleAPIName as parameter
            FieldsOperations fieldOperations = new FieldsOperations(moduleAPIName);
            
            //Call GetField method which takes fieldId as parameter
            APIResponse<ResponseHandler>response = fieldOperations.GetField(fieldId);
            
            if(response != null)
            {
                //Get the status code from response
                Console.WriteLine("Status Code: " + response.StatusCode);
                
                if( new List<int>() { 204, 304 }.Contains(response.StatusCode))
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
                        
                        //Get the list of obtained Field instances
                        List<Field> fields = responseWrapper.Fields;
                    
                        foreach(Field field in fields)
                        {
                            //Get the SystemMandatory of each Field
                            Console.WriteLine("Field SystemMandatory: " + field.SystemMandatory);
                            
                            //Get the Webhook of each Field
                            Console.WriteLine("Field Webhook: " + field.Webhook);

                            //Get the Object obtained Private instance
                            Private private1 = field.Private;

                            //Check if private is not null
                            if (private1 != null)
                            {
                                //Get the Restricted of the Private
                                Console.WriteLine("Field Private Restricted: " + private1.Restricted);

                                //Get the Export of the Private
                                Console.WriteLine("Field Private Export: " + private1.Export);

                                //Get the Type of the Private
                                Console.WriteLine("Field Private Type: " + private1.Type);
                            }

                            //Get the JsonType of each Field
                            Console.WriteLine("Field JsonType: " + field.JsonType);
                            
                            //Get the Object obtained Crypt instance
                            Crypt crypt = field.Crypt;
                            
                            //Check if crypt is not null
                            if(crypt != null)
                            {
                                //Get the Mode of the Crypt
                                Console.WriteLine("Field Crypt Mode: " + crypt.Mode);
                                
                                //Get the Column of the Crypt
                                Console.WriteLine("Field Crypt Column: " + crypt.Column);
                                
                                //Get the Table of the Crypt
                                Console.WriteLine("Field Crypt Table: " + crypt.Table);
                                
                                //Get the Status of the Crypt
                                Console.WriteLine("Field Crypt Status: " + crypt.Status);
                            }
                            
                            //Get the FieldLabel of each Field
                            Console.WriteLine("Field FieldLabel: " + field.FieldLabel);
                            
                            //Get the Object obtained ToolTip instance
                            ToolTip tooltip = field.Tooltip;
                            
                            //Check if tooltip is not null
                            if(tooltip != null)
                            {
                                //Get the Name of the ToolTip
                                Console.WriteLine("Field ToolTip Name: " + tooltip.Name);
                                
                                //Get the Value of the ToolTip
                                Console.WriteLine("Field ToolTip Value: " + tooltip.Value);
                            }
                            
                            //Get the CreatedSource of each Field
                            Console.WriteLine("Field CreatedSource: " + field.CreatedSource);
                            
                            //Get the FieldReadOnly of each Field
                            Console.WriteLine("Field FieldReadOnly: " + field.FieldReadOnly);
                            
                            //Get the DisplayLabel of each Field
                            Console.WriteLine("Field DisplayLabel: " + field.DisplayLabel);
                            
                            //Get the ReadOnly of each Field
                            Console.WriteLine("Field ReadOnly: " + field.ReadOnly);
                            
                            //Get the Object obtained AssociationDetails instance
                            AssociationDetails associationDetails = field.AssociationDetails;
                            
                            //Check if associationDetails is not null
                            if(associationDetails != null)
                            {
                                //Get the Object obtained LookupField instance
                                LookupField lookupField = associationDetails.LookupField;
                                
                                //Check if lookupField is not null
                                if(lookupField != null)
                                {
                                    //Get the ID of the LookupField
                                    Console.WriteLine("Field AssociationDetails LookupField ID: " + lookupField.Id);
                                    
                                    //Get the Name of the LookupField
                                    Console.WriteLine("Field AssociationDetails LookupField Name: " + lookupField.Name);
                                }
                                
                                //Get the Object obtained LookupField instance
                                LookupField relatedField = associationDetails.RelatedField;
                                
                                //Check if relatedField is not null
                                if(relatedField != null)
                                {
                                    //Get the ID of the LookupField
                                    Console.WriteLine("Field AssociationDetails RelatedField ID: " + relatedField.Id);
                                    
                                    //Get the Name of the LookupField
                                    Console.WriteLine("Field AssociationDetails RelatedField Name: " + relatedField.Name);
                                }
                            }
                            
                            if(field.QuickSequenceNumber != null)
                            {
                                //Get the QuickSequenceNumber of each Field
                                Console.WriteLine("Field QuickSequenceNumber: " + field.QuickSequenceNumber);
                            }
                            
                            //Get the BusinesscardSupported of each Field
                            Console.WriteLine("Field BusinesscardSupported: " + field.BusinesscardSupported);
                            
                            //Check if MultiModuleLookup is not null
                            if(field.MultiModuleLookup != null)
                            {
                                //Get the MultiModuleLookup map
                                foreach(KeyValuePair<string, Object> entry in field.MultiModuleLookup)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Get the Object obtained Currency instance
                            Com.Zoho.Crm.API.Fields.Currency currency = field.Currency;
                            
                            //Check if currency is not null
                            if(currency != null)
                            {
                                //Get the RoundingOption of the Currency
                                Console.WriteLine("Field Currency RoundingOption: " + currency.RoundingOption);
                                
                                if(currency.Precision != null)
                                {
                                    //Get the Precision of the Currency
                                    Console.WriteLine("Field Currency Precision: " + currency.Precision);
                                }
                            }
                            
                            //Get the ID of each Field
                            Console.WriteLine("Field ID: " + field.Id);
                            
                            if(field.CustomField != null)
                            {
                                //Get the CustomField of each Field
                                Console.WriteLine("Field CustomField: " + field.CustomField);
                            }
                            
                            //Get the Object obtained Module instance
                            Module lookup = field.Lookup;
                            
                            //Check if lookup is not null
                            if(lookup != null)
                            {
                                //Get the Object obtained Layout instance
                                Layout layout = lookup.Layout;
                                
                                //Check if layout is not null
                                if(layout != null)
                                {
                                    //Get the ID of the Layout
                                    Console.WriteLine("Field ModuleLookup Layout ID: " + layout.Id);
                                    
                                    //Get the Name of the Layout
                                    Console.WriteLine("Field ModuleLookup Layout Name: " + layout.Name);
                                }
                                
                                //Get the DisplayLabel of the Module
                                Console.WriteLine("Field ModuleLookup DisplayLabel: " + lookup.DisplayLabel);
                                
                                //Get the APIName of the Module
                                Console.WriteLine("Field ModuleLookup APIName: " + lookup.APIName);
                                
                                //Get the Module of the Module
                                Console.WriteLine("Field ModuleLookup Module: " + lookup.Module_1);
                                
                                if(lookup.Id != null)
                                {
                                    //Get the ID of the Module
                                    Console.WriteLine("Field ModuleLookup ID: " + lookup.Id);
                                }
                            }
                            
                            if(field.Visible != null)
                            {
                                //Get the Visible of each Field
                                Console.WriteLine("Field Visible: " + field.Visible);
                            }
                            
                            if(field.Length != null)
                            {
                                //Get the Length of each Field
                                Console.WriteLine("Field Length: " + field.Length);
                            }
                            
                            //Get the Object obtained ViewType instance
                            ViewType viewType = field.ViewType;
                            
                            //Check if viewType is not null
                            if(viewType != null)
                            {
                                //Get the View of the ViewType
                                Console.WriteLine("Field ViewType View: " + viewType.View);
                                
                                //Get the Edit of the ViewType
                                Console.WriteLine("Field ViewType Edit: " + viewType.Edit);
                                
                                //Get the Create of the ViewType
                                Console.WriteLine("Field ViewType Create: " + viewType.Create);
                                
                                //Get the View of the ViewType
                                Console.WriteLine("Field ViewType QuickCreate: " + viewType.QuickCreate);
                            }
                            
                            //Get the Object obtained Module instance
                            Module subform = field.Subform;

                            //Check if subform is not null
                            if (subform != null)
                            {
                                //Get the Object obtained Layout instance
                                Layout layout = subform.Layout;
                                
                                //Check if layout is not null
                                if(layout != null)
                                {
                                    //Get the ID of the Layout
                                    Console.WriteLine("Field Subform Layout ID: " + layout.Id);
                                    
                                    //Get the Name of the Layout
                                    Console.WriteLine("Field Subform Layout Name: " + layout.Name);
                                }
                                
                                //Get the DisplayLabel of the Module
                                Console.WriteLine("Field Subform DisplayLabel: " + subform.DisplayLabel);
                                
                                //Get the APIName of the Module
                                Console.WriteLine("Field Subform APIName: " + subform.APIName);
                                
                                //Get the Module of the Module
                                Console.WriteLine("Field Subform Module: " + subform.Module_1);
                                
                                if(subform.Id != null)
                                {
                                    //Get the ID of the Module
                                    Console.WriteLine("Field Subform ID: " + subform.Id);	
                                }
                            }
                            
                            //Get the APIName of each Field
                            Console.WriteLine("Field APIName: " + field.APIName);
                            
                            //Get the Object obtained Unique instance
                            Unique unique = field.Unique;
                            
                            //Check if unique is not null
                            if(unique != null)
                            {
                                //Get the Casesensitive of the Unique
                                Console.WriteLine("Field Unique Casesensitive in " + unique.Casesensitive);
                            }
                            
                            if(field.HistoryTracking != null)
                            {
                                //Get the HistoryTracking of each Field
                                Console.WriteLine("Field HistoryTracking: " + field.HistoryTracking);
                            }
                            
                            //Get the DataType of each Field
                            Console.WriteLine("Field DataType: " + field.DataType);
                            
                            //Get the Object obtained Formula instance
                            Formula formula = field.Formula;
                            
                            //Check if foreachmula is not null
                            if(formula != null)
                            {
                                //Get the ReturnType of the Formula
                                Console.WriteLine("Field Formula ReturnType in " + formula.ReturnType);
                                
                                if(formula.Expression != null)
                                {
                                    //Get the Expression of the Formula
                                    Console.WriteLine("Field Formula Expression in " + formula.Expression);
                                }
                            }
                            
                            if(field.DecimalPlace != null)
                            {
                                //Get the DecimalPlace of each Field
                                Console.WriteLine("Field DecimalPlace: " + field.DecimalPlace);
                            }
                            
                            //Get the MassUpdate of each Field
                            Console.WriteLine("Field MassUpdate: " + field.MassUpdate);
                            
                            if(field.BlueprintSupported != null)
                            {
                                //Get the BlueprintSupported of each Field
                                Console.WriteLine("Field BlueprintSupported: " + field.BlueprintSupported);
                            }
                            
                            //Get all entries from the MultiSelectLookup instance
                            MultiSelectLookup multiSelectLookup = field.Multiselectlookup;
                            
                            //Check if foreachmula is not null
                            if(multiSelectLookup != null)
                            {
                                //Get the DisplayValue of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup DisplayLabel: " + multiSelectLookup.DisplayLabel);
                                
                                //Get the LinkingModule of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup LinkingModule: " + multiSelectLookup.LinkingModule);
                                
                                //Get the LookupApiname of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup LookupApiname: " + multiSelectLookup.LookupApiname);
                                
                                //Get the APIName of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup APIName: " + multiSelectLookup.APIName);
                                
                                //Get the ConnectedlookupApiname of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup ConnectedlookupApiname: " + multiSelectLookup.ConnectedlookupApiname);
                                
                                //Get the ID of the MultiSelectLookup
                                Console.WriteLine("Field MultiSelectLookup ID: " + multiSelectLookup.Id);
                            }
                            
                            //Get the PickListValue of each Field
                            List<PickListValue> pickListValues = field.PickListValues;
                            
                            //Check if foreachmula is not null
                            if(pickListValues != null)
                            {
                                foreach(PickListValue pickListValue in pickListValues)
                                {
                                    //Get the DisplayValue of each PickListValues
                                    Console.WriteLine("Field PickListValue DisplayValue: " + pickListValue.DisplayValue);
                                    
                                    if(pickListValue.SequenceNumber != null)
                                    {
                                        //Get the SequenceNumber of each PickListValues
                                        Console.WriteLine(" Field PickListValue SequenceNumber: " + pickListValue.SequenceNumber);
                                    }
                                    
                                    if(pickListValue.ExpectedDataType != null)
                                    {
                                        //Get the ExpectedDataType of each PickListValues
                                        Console.WriteLine("Field PickListValue ExpectedDataType: " + pickListValue.ExpectedDataType);
                                    }
                                    
                                    //Get the ActualValue of each PickListValues
                                    Console.WriteLine("Field PickListValue ActualValue: " + pickListValue.ActualValue);
                                    
                                    if(pickListValue.Maps != null)
                                    {
                                        foreach(object map in pickListValue.Maps)
                                        {
                                            //Get each value from the map
                                            Console.WriteLine(map);
                                        }
                                    }
                                    
                                    //Get the SysRefName of each PickListValues
                                    Console.WriteLine("Field PickListValue SysRefName: " + pickListValue.SysRefName);
                                    
                                    //Get the Type of each PickListValues
                                    Console.WriteLine("Field PickListValue Type: " + pickListValue.Type);
                                    
                                }
                            }
                            
                            //Get the AutoNumber of each Field
                            AutoNumber autoNumber = field.AutoNumber;
                            
                            //Check if foreachmula is not null
                            if(autoNumber != null)
                            {
                                //Get the Prefix of the AutoNumber
                                Console.WriteLine("Field AutoNumber Prefix: " + autoNumber.Prefix);
                                
                                //Get the Suffix of the AutoNumber
                                Console.WriteLine("Field AutoNumber Suffix: " + autoNumber.Suffix);
                                
                                if(autoNumber.StartNumber != null)
                                {
                                    //Get the StartNumber of the AutoNumber
                                    Console.WriteLine("Field AutoNumber StartNumber: " + autoNumber.StartNumber);
                                }
                            }
                            
                            if(field.DefaultValue != null)
                            {
                                //Get the DefaultValue of each Field
                                Console.WriteLine("Field DefaultValue: " + field.DefaultValue);
                            }
                            
                            if(field.SectionId != null)
                            {
                                //Get the SectionId of each Field
                                Console.WriteLine("Field SectionId: " + field.SectionId);
                            }
                            
                            //Check if ValidationRule is not null
                            if(field.ValidationRule != null)
                            {
                                //Get the details map
                                foreach(KeyValuePair<string, Object> entry in field.ValidationRule)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Check if ConvertMapping is not null
                            if(field.ConvertMapping != null)
                            {
                                //Get the details map
                                foreach(KeyValuePair<string, Object> entry in field.ConvertMapping)
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " + JsonConvert.SerializeObject(entry.Value));
                                }
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

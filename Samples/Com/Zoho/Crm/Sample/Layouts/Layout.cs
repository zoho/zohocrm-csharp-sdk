using System;

using System.Collections.Generic;

using System.Reflection;

using Com.Zoho.Crm.API.Fields;

using Com.Zoho.Crm.API.Layouts;

using Com.Zoho.Crm.API.Profiles;

using Com.Zoho.Crm.API.Users;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using APIException = Com.Zoho.Crm.API.Layouts.APIException;

using Module = Com.Zoho.Crm.API.Fields.Module;

using ResponseHandler = Com.Zoho.Crm.API.Layouts.ResponseHandler;

using ResponseWrapper = Com.Zoho.Crm.API.Layouts.ResponseWrapper;

using Section = Com.Zoho.Crm.API.Layouts.Section;

namespace Com.Zoho.Crm.Sample.Layouts
{
    public class Layout
    {
        /// <summary>
        /// This method is used to get metadata about all the layouts of a module and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the module to get layouts.</param>
        public static void GetLayouts(string moduleAPIName)
        {
            //example
            //string moduleAPIName = "Leads";
            
            //Get instance of LayoutsOperations Class that takes moduleAPIName as parameter
            LayoutsOperations layoutsOperations = new LayoutsOperations(moduleAPIName);
            
            //Call GetLayouts method
            APIResponse<ResponseHandler> response = layoutsOperations.GetLayouts();
            
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
                        
                        //Get the list of obtained Layout instances
                        List<Com.Zoho.Crm.API.Layouts.Layout> layouts = responseWrapper.Layouts;
                    
                        foreach(Com.Zoho.Crm.API.Layouts.Layout layout in layouts)
                        {
                            if (layout.CreatedTime != null)
                            {
                                //Get the CreatedTime of each Layout
                                Console.WriteLine("Layout CreatedTime: " + layout.CreatedTime);
                            }
                            
                            //Check if ConvertMapping is not null
                            if(layout.ConvertMapping != null)
                            {
                                //Get the MultiModuleLookup map
                                foreach(KeyValuePair<string, object> entry in layout.ConvertMapping )
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Get the ModifiedTime of each Layout
                            Console.WriteLine("Layout ModifiedTime: " + layout.ModifiedTime);
                            
                            //Get the Visible of each Layout
                            Console.WriteLine("Layout Visible: " + layout.Visible);
                            
                            //Get the createdFor User instance of each Layout
                            User createdFor = layout.CreatedFor;
                            
                            //Check if createdFor is not null
                            if(createdFor != null)
                            {
                                //Get the Name of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-Name: " + createdFor.Name);
                                
                                //Get the ID of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-ID: " + createdFor.Id);
                                
                                //Get the Email of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-Email: " + createdFor.Email);
                            }
                            
                            //Get the Name of each Layout
                            Console.WriteLine("Layout Name: " + layout.Name);
                            
                            //Get the modifiedBy User instance of each Layout
                            User modifiedBy = layout.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-ID: " + modifiedBy.Id);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-Email: " + modifiedBy.Email);
                            }
                            
                            //Get the profiles of each Layout
                            List<Com.Zoho.Crm.API.Profiles.Profile> profiles = layout.Profiles;
                            
                            //Check if profiles is not null
                            if(profiles != null)
                            {
                                foreach(Com.Zoho.Crm.API.Profiles.Profile profile in profiles)
                                {
                                    //Get the Default of each Profile
                                    Console.WriteLine("Layout Profile Default: " + profile.Default);
                                        
                                    //Get the Name of each Profile
                                    Console.WriteLine("Layout Profile Name: " + profile.Name);
                                        
                                    //Get the ID of each Profile
                                    Console.WriteLine("Layout Profile ID: " + profile.Id);
                                }
                            }
                            
                            //Get the ID of each Layout
                            Console.WriteLine("Layout ID: " + layout.Id);
                            
                            //Get the createdBy User instance of each Layout
                            User createdBy = layout.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-ID: " + createdBy.Id);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-Email: " + createdBy.Email);
                            }
                            
                            //Get the sections of each Layout
                            List<Section> sections = layout.Sections;
                            
                            //Check if sections is not null
                            if(sections != null)
                            {
                                foreach(Section section in sections)
                                {
                                    //Get the DisplayLabel of each Section
                                    Console.WriteLine("Layout Section DisplayLabel: " + section.DisplayLabel);
                                    
                                    //Get the SequenceNumber of each Section
                                    Console.WriteLine("Layout Section SequenceNumber: " + section.SequenceNumber);
                                    
                                    //Get the Issubformsection of each Section
                                    Console.WriteLine("Layout Section Issubformsection: " + section.Issubformsection);
                                    
                                    //Get the TabTraversal of each Section
                                    Console.WriteLine("Layout Section TabTraversal: " + section.TabTraversal);
                                    
                                    //Get the APIName of each Section
                                    Console.WriteLine("Layout Section APIName: " + section.APIName);
                                    
                                    //Get the ColumnCount of each Section
                                    Console.WriteLine("Layout Section ColumnCount: " + section.ColumnCount);
                                    
                                    //Get the Name of each Section
                                    Console.WriteLine("Layout Section Name: " + section.Name);
                                    
                                    //Get the GeneratedType of each Section
                                    Console.WriteLine("Layout Section GeneratedType: " + section.GeneratedType);
                                    
                                    //Get the fields of each Section
                                    List<Field> fields = section.Fields;
                                    
                                    //Check if sections is not null
                                    if(fields != null)
                                    {
                                        foreach(Field field in fields)
                                        {
                                            PrintField(field);
                                        }
                                    }
                                    
                                    //Get the properties User instance of each Section
                                    Properties properties = section.Properties;
                                    
                                    //Check if properties is not null
                                    if(properties != null)
                                    {
                                        //Get the ReorderRows of each Properties
                                        Console.WriteLine("Layout Section Properties ReorderRows: " + properties.ReorderRows);
                                        
                                        //Get the tooltip User instance of the Properties
                                        ToolTip tooltip = properties.Tooltip;
                                        
                                        //Check if tooltip is not null
                                        if(tooltip != null)
                                        {
                                            //Get the Name of the ToolTip
                                            Console.WriteLine("Layout Section Properties ToolTip Name: " + tooltip.Name);
                                            
                                            //Get the Value of the ToolTip
                                            Console.WriteLine("Layout Section Properties ToolTip Value: " + tooltip.Value);
                                        }
                                        
                                        //Get the MaximumRows of each Properties
                                        Console.WriteLine("Layout Section Properties MaximumRows: " + properties.MaximumRows);
                                    }
                                }
                            }
                            
                            //Get the Status of each Layout
                            Console.WriteLine("Layout Status: " + layout.Status);
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
                        foreach(KeyValuePair<string, object> entry in exception.Details )
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
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
        /// This method is used to get metadata about a single layout of a module with layoutID and print the response.
        /// </summary>
        /// <param name="moduleAPIName">The API Name of the layout's module</param>
        /// <param name="layoutId">The ID of the field to be obtained</param>
        public static void GetLayout(string moduleAPIName, long layoutId)
        {
            //example
            //string moduleAPIName = "Leads";
            //long layoutId = 34770610091055;
            
            //Get instance of LayoutsOperations Class that takes moduleAPIName as parameter
            LayoutsOperations layoutsOperations = new LayoutsOperations(moduleAPIName);
            
            //Call GetLayout method that takes layoutId as parameter
            APIResponse<ResponseHandler> response = layoutsOperations.GetLayout(layoutId);
            
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
                        
                        //Get the list of obtained Layout instances
                        List<Com.Zoho.Crm.API.Layouts.Layout> layouts = responseWrapper.Layouts;
                    
                        foreach(Com.Zoho.Crm.API.Layouts.Layout layout in layouts)
                        {
                            if(layout.CreatedTime != null)
                            {
                                //Get the CreatedTime of each Layout
                                Console.WriteLine("Layout CreatedTime: " + layout.CreatedTime);
                            }
                            
                            //Check if ConvertMapping is not null
                            if(layout.ConvertMapping != null)
                            {
                                //Get the MultiModuleLookup map
                                foreach (KeyValuePair<string, object> entry in layout.ConvertMapping )
                                {
                                    //Get each value in the map
                                    Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
                                }
                            }
                            
                            //Get the ModifiedTime of each Layout
                            Console.WriteLine("Layout ModifiedTime: " + layout.ModifiedTime);
                            
                            //Get the Visible of each Layout
                            Console.WriteLine("Layout Visible: " + layout.Visible);
                            
                            //Get the createdFor User instance of each Layout
                            User createdFor = layout.CreatedFor;
                            
                            //Check if createdFor is not null
                            if(createdFor != null)
                            {
                                //Get the Name of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-Name: " + createdFor.Name);
                                
                                //Get the ID of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-ID: " + createdFor.Id);
                                
                                //Get the Email of the createdFor User
                                Console.WriteLine("Layout CreatedFor User-Email: " + createdFor.Email);
                            }
                            
                            //Get the Name of each Layout
                            Console.WriteLine("Layout Name: " + layout.Name);
                            
                            //Get the modifiedBy User instance of each Layout
                            User modifiedBy = layout.ModifiedBy;
                            
                            //Check if modifiedBy is not null
                            if(modifiedBy != null)
                            {
                                //Get the Name of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-Name: " + modifiedBy.Name);
                                
                                //Get the ID of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-ID: " + modifiedBy.Id);
                                
                                //Get the Email of the modifiedBy User
                                Console.WriteLine("Layout ModifiedBy User-Email: " + modifiedBy.Email);
                            }
                            
                            //Get the profiles of each Layout
                            List<Com.Zoho.Crm.API.Profiles.Profile> profiles = layout.Profiles;
                            
                            //Check if profiles is not null
                            if(profiles != null)
                            {
                                foreach (Com.Zoho.Crm.API.Profiles.Profile profile in profiles)
                                {
                                    //Get the Default of each Profile
                                    Console.WriteLine("Layout Profile Default: " + profile.Default);
                                        
                                    //Get the Name of each Profile
                                    Console.WriteLine("Layout Profile Name: " + profile.Name);
                                        
                                    //Get the ID of each Profile
                                    Console.WriteLine("Layout Profile ID: " + profile.Id);
                                }
                            }
                            
                            //Get the ID of each Layout
                            Console.WriteLine("Layout ID: " + layout.Id);
                            
                            //Get the createdBy User instance of each Layout
                            User createdBy = layout.CreatedBy;
                            
                            //Check if createdBy is not null
                            if(createdBy != null)
                            {
                                //Get the Name of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-Name: " + createdBy.Name);
                                
                                //Get the ID of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-ID: " + createdBy.Id);
                                
                                //Get the Email of the createdBy User
                                Console.WriteLine("Layout CreatedBy User-Email: " + createdBy.Email);
                            }
                            
                            //Get the sections of each Layout
                            List<Section> sections = layout.Sections;
                            
                            //Check if sections is not null
                            if(sections != null)
                            {
                                foreach (Section section in sections)
                                {
                                    //Get the DisplayLabel of each Section
                                    Console.WriteLine("Layout Section DisplayLabel: " + section.DisplayLabel);
                                    
                                    //Get the SequenceNumber of each Section
                                    Console.WriteLine("Layout Section SequenceNumber: " + section.SequenceNumber);
                                    
                                    //Get the Issubformsection of each Section
                                    Console.WriteLine("Layout Section Issubformsection: " + section.Issubformsection);
                                    
                                    //Get the TabTraversal of each Section
                                    Console.WriteLine("Layout Section TabTraversal: " + section.TabTraversal);
                                    
                                    //Get the APIName of each Section
                                    Console.WriteLine("Layout Section APIName: " + section.APIName);
                                    
                                    //Get the ColumnCount of each Section
                                    Console.WriteLine("Layout Section ColumnCount: " + section.ColumnCount);
                                    
                                    //Get the Name of each Section
                                    Console.WriteLine("Layout Section Name: " + section.Name);
                                    
                                    //Get the GeneratedType of each Section
                                    Console.WriteLine("Layout Section GeneratedType: " + section.GeneratedType);
                                    
                                    //Get the fields of each Section
                                    List<Field> fields = section.Fields;
                                    
                                    //Check if sections is not null
                                    if(fields != null)
                                    {
                                        foreach (Field field in fields)
                                        {
                                            PrintField(field);
                                        }
                                    }
                                    
                                    //Get the properties User instance of each Section
                                    Properties properties = section.Properties;
                                    
                                    //Check if properties is not null
                                    if(properties != null)
                                    {
                                        //Get the ReorderRows of each Properties
                                        Console.WriteLine("Layout Section Properties ReorderRows: " + properties.ReorderRows);
                                        
                                        //Get the tooltip User instance of the Properties
                                        ToolTip tooltip = properties.Tooltip;
                                        
                                        //Check if tooltip is not null
                                        if(tooltip != null)
                                        {
                                            //Get the Name of the ToolTip
                                            Console.WriteLine("Layout Section Properties ToolTip Name: " + tooltip.Name);
                                            
                                            //Get the Value of the ToolTip
                                            Console.WriteLine("Layout Section Properties ToolTip Value: " + tooltip.Value);
                                        }
                                        
                                        //Get the MaximumRows of each Properties
                                        Console.WriteLine("Layout Section Properties MaximumRows: " + properties.MaximumRows);
                                    }
                                }
                            }
                            
                            //Get the Status of each Layout
                            Console.WriteLine("Layout Status: " + layout.Status);
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
                        foreach (KeyValuePair<string, object> entry in exception.Details )
                        {
                            //Get each value in the map
                            Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
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

        private static void PrintField(Field field)
        {
            //Get the SystemMandatory of each Field
            Console.WriteLine("Field SystemMandatory: " + field.SystemMandatory);
            
            //Get the Webhook of each Field
            Console.WriteLine("Field Webhook: " + field.Webhook);
            
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
            
            if(field.BusinesscardSupported != null)
            {
                //Get the BusinesscardSupported of each Field
                Console.WriteLine("Field BusinesscardSupported: " + field.BusinesscardSupported);
            }
            
            //Check if MultiModuleLookup is not null
            if(field.MultiModuleLookup != null)
            {
                //Get the MultiModuleLookup map
                foreach(KeyValuePair<string, object> entry in field.MultiModuleLookup )
                {
                    //Get each value in the map
                    Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
                }
            }
            
            //Get the Object obtained Currency instance
            Currency currency = field.Currency;
            
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
                Com.Zoho.Crm.API.Layouts.Layout layout = lookup.Layout;
                
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
            if(subform != null)
            {
                //Get the Object obtained Layout instance
                Com.Zoho.Crm.API.Layouts.Layout layout = subform.Layout;
                
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
            
            //Check if formula is not null
            if(formula != null)
            {
                //Get the ReturnType of the Formula
                Console.WriteLine("Field Formula ReturnType:" + formula.ReturnType);
                
                if(formula.Expression != null)
                {
                    //Get the Expression of the Formula
                    Console.WriteLine("Field Formula Expression:" + formula.Expression);
                }
            }
            
            if(field.DecimalPlace != null)
            {
                //Get the DecimalPlace of each Field
                Console.WriteLine("Field DecimalPlace: " + field.DecimalPlace);
            }
            
            if(field.MassUpdate != null)
            {
                //Get the MassUpdate of each Field
                Console.WriteLine("Field MassUpdate: " + field.MassUpdate);
            }
            
            if(field.BlueprintSupported != null)
            {
                //Get the BlueprintSupported of each Field
                Console.WriteLine("Field BlueprintSupported: " + field.BlueprintSupported);
            }
            
            //Get all entries from the MultiSelectLookup instance
            MultiSelectLookup multiSelectLookup = field.Multiselectlookup;
            
            //Check if formula is not null
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
            
            //Check if formula is not null
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
                        foreach(Object map in pickListValue.Maps)
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
            
            //Check if formula is not null
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
                foreach(KeyValuePair<string, object> entry in field.ValidationRule )
                {
                    //Get each value in the map
                    Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
                }
            }
            
            //Check if ConvertMapping is not null
            if(field.ConvertMapping != null)
            {
                //Get the details map
                foreach(KeyValuePair<string, object> entry in field.ConvertMapping )
                {
                    //Get each value in the map
                    Console.WriteLine(entry.Key + ": " +  JsonConvert.SerializeObject(entry.Value));
                }
            }
        }
    }
}

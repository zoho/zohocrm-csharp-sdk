using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Attachment = Com.Zoho.Crm.Sample.Attachments.Attachment;
using Com.Zoho.Crm.Sample.Initializer;
using Com.Zoho.Crm.API.Util;
using Newtonsoft.Json;
using Com.Zoho.Crm.API;
using static Com.Zoho.Crm.API.Modules.ModulesOperations;
using Newtonsoft.Json.Linq;
using Com.Zoho.API.Exception;

namespace csharpsdksampleapplication
{
    class Test
    {
        static void Main(string[] args)
        {
            Initialize.SDKInitialize();

            Attachment();

            BluePrint();

            BulkRead();

            BulkWrite();

            ContactRoles();

            Currency();

            CustomView();

            Field();

            File();

            Layout();

            Module();

            Note();

            Notification();

            Organization();

            Profile();

            Query();

            Record();

            RelatedList();

            RelatedRecords();

            Role();

            ShareRecords();

            Tags();

            Tax();

            Territory();

            User();

            VariableGroup();

            Variable();

            //Threading();

            //TestUpload();
        }

        public static void Attachment()
        {
            try
            {
                string moduleAPIName = "Leads";

                long recordId = 34770616920152;

                long attachmentId = 34770617606001;

                string absoluteFilePath = "/Users/Desktop/test.html";

                string destinationFolder = "/Users/Documents/java/attachment";

                string attachmentURL = "https://5.imimg.com/data5/KJ/UP/MY-8655440/zoho-crm-500x500.png";

                List<long> attachmentIds = new List<long>() { 34770617600002, 34770617607001, 34770615961010 };

                Com.Zoho.Crm.Sample.Attachments.Attachment.UploadAttachments(moduleAPIName, recordId, absoluteFilePath);

                Com.Zoho.Crm.Sample.Attachments.Attachment.GetAttachments(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.Attachments.Attachment.DeleteAttachments(moduleAPIName, recordId, attachmentIds);

                Com.Zoho.Crm.Sample.Attachments.Attachment.DownloadAttachment(moduleAPIName, recordId, attachmentId, destinationFolder);

                Com.Zoho.Crm.Sample.Attachments.Attachment.DeleteAttachment(moduleAPIName, recordId, attachmentId);

                Com.Zoho.Crm.Sample.Attachments.Attachment.UploadLinkAttachments(moduleAPIName, recordId, attachmentURL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void BluePrint()
        {
            try
            {
                string moduleAPIName = "Leads";

                long recordId = 34770614381002;

                long transitionId = 34770610173093;

                Com.Zoho.Crm.Sample.BluePrint.BluePrint.GetBlueprint(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.BluePrint.BluePrint.UpdateBlueprint(moduleAPIName, recordId, transitionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void BulkRead()
        {
            try
            {
                string moduleAPIName = "Events";

                long jobId = 34770617610008;

                string destinationFolder = "/Users/Documents/java/attachment";

                Com.Zoho.Crm.Sample.BulkRead.BulkRead.CreateBulkReadJob(moduleAPIName);

                Com.Zoho.Crm.Sample.BulkRead.BulkRead.GetBulkReadJobDetails(jobId);

                Com.Zoho.Crm.Sample.BulkRead.BulkRead.DownloadResult(jobId, destinationFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void BulkWrite()
        {
            try
            {
                string absoluteFilePath = "/Users/Documents/Leads.zip";

                string orgID = "xxxxxx";

                string moduleAPIName = "Leads";

                string fileId = "34770617621001";

                long jobID = 34770617608008;

                string downloadUrl = "https://download-accl.zoho.com/v2/crm/xxxx/bulk-write/34770617608008/34770617608008.zip";

                string destinationFolder = "/Users/Documents/java/attachment";

                Com.Zoho.Crm.Sample.BulkWrite.BulkWrite.UploadFile(orgID, absoluteFilePath);

                Com.Zoho.Crm.Sample.BulkWrite.BulkWrite.CreateBulkWriteJob(moduleAPIName, fileId);

                Com.Zoho.Crm.Sample.BulkWrite.BulkWrite.GetBulkWriteJobDetails(jobID);

                Com.Zoho.Crm.Sample.BulkWrite.BulkWrite.DownloadBulkWriteResult(downloadUrl, destinationFolder);
            }
            catch (SDKException ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void ContactRoles()
        {
            try
            {
                long contactRoleId = 34770617540001;

                List<long> contactRoleIds = new List<long>() { 34770617600010, 34770617600011, 34770617600012, 34770617600013, 34770617600014 };

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.GetContactRoles();

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.CreateContactRoles();

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.UpdateContactRoles();

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.DeleteContactRoles(contactRoleIds);

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.GetContactRole(contactRoleId);

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.UpdateContactRole(contactRoleId);

                Com.Zoho.Crm.Sample.ContactRoles.ContactRoles.DeleteContactRole(contactRoleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Currency()
        {
            try
            {
                long currencyId = 34770617368016;

                Com.Zoho.Crm.Sample.Currencies.Currency.GetCurrencies();

                Com.Zoho.Crm.Sample.Currencies.Currency.AddCurrencies();

                Com.Zoho.Crm.Sample.Currencies.Currency.UpdateCurrencies();

                Com.Zoho.Crm.Sample.Currencies.Currency.EnableMultipleCurrencies();

                Com.Zoho.Crm.Sample.Currencies.Currency.UpdateBaseCurrency();

                Com.Zoho.Crm.Sample.Currencies.Currency.GetCurrency(currencyId);

                Com.Zoho.Crm.Sample.Currencies.Currency.UpdateCurrency(currencyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void CustomView()
        {
            try
            {
                string moduleAPIName = "Leads";

                long customID = 34770610087501;

                //List<string> names = new List<string>() { "Products", "Tasks", "Vendors", "Calls", "Leads", "Deals", "Campaigns", "Quotes", "Invoices", "Attachments", "Price_Books", "Sales_Orders", "Contacts", "Solutions", "Events", "Purchase_Orders", "Accounts", "Cases", "Notes" };

                //foreach (string name in names)
                //{
                //    Com.Zoho.Crm.Sample.CustomView.CustomView.GetCustomViews(name);
                //}

                Com.Zoho.Crm.Sample.CustomView.CustomView.GetCustomViews(moduleAPIName);

                Com.Zoho.Crm.Sample.CustomView.CustomView.GetCustomView(moduleAPIName, customID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Field()
        {
            try
            {
                string moduleAPIName = "Leads";

                long fieldId = 34770610022011;

                //List<string> names = new List<string>() { "Products", "Tasks", "Vendors", "Calls", "Leads", "Deals", "Campaigns", "Quotes", "Invoices", "Attachments", "Price_Books", "Sales_Orders", "Contacts", "Solutions", "Events", "Purchase_Orders", "Accounts", "Cases", "Notes" };

                //foreach (string name in names)
                //{
                //    Com.Zoho.Crm.Sample.Fields.Fields.GetFields(name);
                //}

                Com.Zoho.Crm.Sample.Fields.Fields.GetFields(moduleAPIName);

                Com.Zoho.Crm.Sample.Fields.Fields.GetField(moduleAPIName, fieldId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void File()
        {
            try
            {
                string destinationFolder = "/Users/Desktop/field/";

                string id = "ae9c7cefa418aec61f7ae1b547fbcd42e5756301";

                Com.Zoho.Crm.Sample.File.File.UploadFiles();

                Com.Zoho.Crm.Sample.File.File.GetFile(id, destinationFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Layout()
        {
            try
            {
                string moduleAPIName = "Leads";

                long layoutId = 34770610091055;

                //List<string> names = new List<string>() { "Products", "Tasks", "Vendors", "Calls", "Leads", "Deals", "Campaigns", "Quotes", "Invoices", "Attachments", "Price_Books", "Sales_Orders", "Contacts", "Solutions", "Events", "Purchase_Orders", "Accounts", "Cases", "Notes" };

                //foreach (string name in names)
                //{
                //    Com.Zoho.Crm.Sample.Layouts.Layout.GetLayouts(name);
                //}

                Com.Zoho.Crm.Sample.Layouts.Layout.GetLayouts(moduleAPIName);

                Com.Zoho.Crm.Sample.Layouts.Layout.GetLayout(moduleAPIName, layoutId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Module()
        {
            try
            {
                string moduleAPIName = "apiName1";

                long moduleId = 34770613905003;

                Com.Zoho.Crm.Sample.Modules.Modules.GetModules();

                Com.Zoho.Crm.Sample.Modules.Modules.GetModule(moduleAPIName);

                Com.Zoho.Crm.Sample.Modules.Modules.UpdateModuleByAPIName(moduleAPIName);

                Com.Zoho.Crm.Sample.Modules.Modules.UpdateModuleById(moduleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Note()
        {
            try
            {
                List<long> notesId = new List<long>() { 34770617613024, 34770617613023, 34770617613022 };

                long noteId = 34770617613021;

                Com.Zoho.Crm.Sample.Notes.Note.GetNotes();

                Com.Zoho.Crm.Sample.Notes.Note.CreateNotes();

                Com.Zoho.Crm.Sample.Notes.Note.UpdateNotes();

                Com.Zoho.Crm.Sample.Notes.Note.DeleteNotes(notesId);

                Com.Zoho.Crm.Sample.Notes.Note.GetNote(noteId);

                Com.Zoho.Crm.Sample.Notes.Note.UpdateNote(noteId);

                Com.Zoho.Crm.Sample.Notes.Note.DeleteNote(noteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Notification()
        {
            try
            {
                List<long> channelIds = new List<long>() { 1006800212 };

                Com.Zoho.Crm.Sample.Notification.Notification.EnableNotifications();

                Com.Zoho.Crm.Sample.Notification.Notification.GetNotificationDetails();

                Com.Zoho.Crm.Sample.Notification.Notification.UpdateNotifications();

                Com.Zoho.Crm.Sample.Notification.Notification.UpdateNotification();

                Com.Zoho.Crm.Sample.Notification.Notification.DisableNotifications(channelIds);

                Com.Zoho.Crm.Sample.Notification.Notification.DisableNotification();
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Organization()
        {
            try
            {
                string absoluteFilePath = "/Users/Desktop/download.png";

                Com.Zoho.Crm.Sample.Organization.Organization.GetOrganization();

                Com.Zoho.Crm.Sample.Organization.Organization.UploadOrganizationPhoto(absoluteFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Profile()
        {
            try
            {
                long profileId = 34770610026011;

                Com.Zoho.Crm.Sample.Profile.Profile.GetProfiles();

                Com.Zoho.Crm.Sample.Profile.Profile.GetProfile(profileId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Query()
        {
            try
            {
                Com.Zoho.Crm.Sample.Query.Query.GetRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Record()
        {
            try
            {
                string moduleAPIName = "Leads";

                long recordId = 34770617589001;

                string destinationFolder = "/Users/Desktop/field/";

                //List<string> modules = new List<string>() { "products", "Tasks", "Vendors", "Calls", "Leads", "Deals", "Campaigns", "Quotes", "Invoices", "Attachments", "Price_Books", "Sales_Orders", "Contacts", "Solutions", "Events", "Purchase_Orders", "Accounts", "Cases", "Notes" };

                //foreach (string module in modules)
                //{
                //    Com.Zoho.Crm.Sample.Record.Record.GetRecords(module);
                //}

                string absoluteFilePath = "/Users/Desktop/field/download.png";

                List<long> recordIds = new List<long>() { 34770617079170, 34770616595015, 34770615908001 };

                string jobId = "34770617633026";

                Com.Zoho.Crm.Sample.Record.Record.GetRecord(moduleAPIName, recordId, destinationFolder);

                Com.Zoho.Crm.Sample.Record.Record.UpdateRecord(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.Record.Record.DeleteRecord(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.Record.Record.GetRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.CreateRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.UpdateRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.DeleteRecords(moduleAPIName, recordIds);

                Com.Zoho.Crm.Sample.Record.Record.UpsertRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.GetDeletedRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.SearchRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.ConvertLead(recordId);

                Com.Zoho.Crm.Sample.Record.Record.UploadPhoto(moduleAPIName, recordId, absoluteFilePath);

                Com.Zoho.Crm.Sample.Record.Record.GetPhoto(moduleAPIName, recordId, destinationFolder);

                Com.Zoho.Crm.Sample.Record.Record.DeletePhoto(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.Record.Record.MassUpdateRecords(moduleAPIName);

                Com.Zoho.Crm.Sample.Record.Record.GetMassUpdateStatus(moduleAPIName, jobId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void RelatedList()
        {
            try
            {
                string moduleAPIName = "Leads";

                long relatedListId = 34770610003771;

                //List<string> names = new List<string>() { "Products", "Tasks", "Vendors", "Calls", "Leads", "Deals", "Campaigns", "Quotes", "Invoices", "Attachments", "Price_Books", "Sales_Orders", "Contacts", "Solutions", "Events", "Purchase_Orders", "Accounts", "Cases" };

                //foreach (string name in names)
                //{
                //    Com.Zoho.Crm.Sample.RelatedList.RelatedList.GetRelatedLists(name);
                //}

                Com.Zoho.Crm.Sample.RelatedList.RelatedList.GetRelatedLists(moduleAPIName);

                Com.Zoho.Crm.Sample.RelatedList.RelatedList.GetRelatedList(moduleAPIName, relatedListId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void RelatedRecords()
        {
            try
            {
                string moduleAPIName = "Products";

                long recordId = 34770617606020;

                string relatedListAPIName = "Price_Books";

                long relatedRecordId = 34770615917011;

                string destinationFolder = "/Users/Desktop/field/";

                List<long> relatedListIds = new List<long>(){ 34770610307003, 34770615917011, 34770615919001 };

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.GetRelatedRecords(moduleAPIName, recordId, relatedListAPIName);

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.UpdateRelatedRecords(moduleAPIName, recordId, relatedListAPIName);

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.DelinkRecords(moduleAPIName, recordId, relatedListAPIName, relatedListIds);

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.GetRelatedRecord(moduleAPIName, recordId, relatedListAPIName, relatedRecordId, destinationFolder);

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.UpdateRelatedRecord(moduleAPIName, recordId, relatedListAPIName, relatedRecordId);

                Com.Zoho.Crm.Sample.RelatedRecords.RelatedRecords.DelinkRecord(moduleAPIName, recordId, relatedListAPIName, relatedRecordId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Role()
        {
            try
            {
                long roleId = 34770610026008;

                Com.Zoho.Crm.Sample.Role.Role.GetRoles();

                Com.Zoho.Crm.Sample.Role.Role.GetRole(roleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void ShareRecords()
        {
            try
            {
                string moduleAPIName = "Leads";

                long recordId = 34770615623115L;

                Com.Zoho.Crm.Sample.ShareRecords.ShareRecords.GetSharedRecordDetails(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.ShareRecords.ShareRecords.ShareRecord(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.ShareRecords.ShareRecords.UpdateSharePermissions(moduleAPIName, recordId);

                Com.Zoho.Crm.Sample.ShareRecords.ShareRecords.RevokeSharedRecord(moduleAPIName, recordId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Tags()
        {
            try
            {
                string moduleAPIName = "Leads";

                long tagId = 34770617286001;

                long recordId = 34770615623115;

                List<string> tagNames = new List<string>() { "addtag1,addtag12" };

                List<long> recordIds = new List<long>() { 34770617074131, 34770616920152 };

                string conflictId = "34770617029041";

                Com.Zoho.Crm.Sample.Tags.Tag.GetTags(moduleAPIName);

                Com.Zoho.Crm.Sample.Tags.Tag.CreateTags(moduleAPIName);

                Com.Zoho.Crm.Sample.Tags.Tag.UpdateTags(moduleAPIName);

                Com.Zoho.Crm.Sample.Tags.Tag.UpdateTag(moduleAPIName, tagId);

                Com.Zoho.Crm.Sample.Tags.Tag.DeleteTag(tagId);

                Com.Zoho.Crm.Sample.Tags.Tag.MergeTags(tagId, conflictId);

                Com.Zoho.Crm.Sample.Tags.Tag.AddTagsToRecord(moduleAPIName, recordId, tagNames);

                Com.Zoho.Crm.Sample.Tags.Tag.RemoveTagsFromRecord(moduleAPIName, recordId, tagNames);

                Com.Zoho.Crm.Sample.Tags.Tag.AddTagsToMultipleRecords(moduleAPIName, recordIds, tagNames);

                Com.Zoho.Crm.Sample.Tags.Tag.RemoveTagsFromMultipleRecords(moduleAPIName, recordIds, tagNames);

                Com.Zoho.Crm.Sample.Tags.Tag.GetRecordCountForTag(moduleAPIName, tagId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Tax()
        {
            try
            {
                long taxId = 34770616449002;

                List<long> taxIds = new List<long>() { 34770617643024, 34770615682038 };

                Com.Zoho.Crm.Sample.Taxes.Tax.GetTaxes();

                Com.Zoho.Crm.Sample.Taxes.Tax.CreateTaxes();

                Com.Zoho.Crm.Sample.Taxes.Tax.UpdateTaxes();

                Com.Zoho.Crm.Sample.Taxes.Tax.DeleteTaxes(taxIds);

                Com.Zoho.Crm.Sample.Taxes.Tax.GetTax(taxId);

                Com.Zoho.Crm.Sample.Taxes.Tax.DeleteTax(taxId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Territory()
        {
            try
            {
                long territoryId = 34770613051397;

                Com.Zoho.Crm.Sample.Territories.Territory.GetTerritories();

                Com.Zoho.Crm.Sample.Territories.Territory.GetTerritory(territoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Threading()
        {
            try
            {
                Com.Zoho.Crm.Sample.Threading.MultiUser.MultiThread.RunMultiThreadWithMultiUser();

                Com.Zoho.Crm.Sample.Threading.MultiUser.SingleThread.RunSingleThreadWithMultiUser();

                Com.Zoho.Crm.Sample.Threading.SingleUser.MultiThread.RunMultiThreadWithSingleUser();

                Com.Zoho.Crm.Sample.Threading.SingleUser.SingleThread.RunSingleThreadWithSingleUser();
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void User()
        {
            try
            {
                long userId = 34770617639002;

                Com.Zoho.Crm.Sample.Users.User.GetUsers();

                Com.Zoho.Crm.Sample.Users.User.CreateUser();

                Com.Zoho.Crm.Sample.Users.User.UpdateUsers();

                Com.Zoho.Crm.Sample.Users.User.GetUser(userId);

                Com.Zoho.Crm.Sample.Users.User.UpdateUser(userId);

                Com.Zoho.Crm.Sample.Users.User.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void VariableGroup()
        {
            try
            {
                string variableGroupName = "General";

                long variableGroupId = 34770613089001;
                
                Com.Zoho.Crm.Sample.VariableGroups.VariableGroup.GetVariableGroups();

                Com.Zoho.Crm.Sample.VariableGroups.VariableGroup.GetVariableGroupById(variableGroupId);

                Com.Zoho.Crm.Sample.VariableGroups.VariableGroup.GetVariableGroupByAPIName(variableGroupName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void Variable()
        {
            try
            {
                List<long> variableIds = new List<long>() { 34770617636020, 34770617636022 };

                long variableId = 34770617444007;

                string variableName = "Variable552";

                Com.Zoho.Crm.Sample.Variables.Variable.GetVariables();

                Com.Zoho.Crm.Sample.Variables.Variable.CreateVariables();

                Com.Zoho.Crm.Sample.Variables.Variable.UpdateVariables();

                Com.Zoho.Crm.Sample.Variables.Variable.DeleteVariables(variableIds);

                Com.Zoho.Crm.Sample.Variables.Variable.GetVariableById(variableId);

                Com.Zoho.Crm.Sample.Variables.Variable.UpdateVariableById(variableId);

                Com.Zoho.Crm.Sample.Variables.Variable.DeleteVariable(variableId);

                Com.Zoho.Crm.Sample.Variables.Variable.GetVariableForAPIName(variableName);

                Com.Zoho.Crm.Sample.Variables.Variable.UpdateVariableByAPIName(variableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        public static void TestUpload()
        {
            string boundary = "----FILEBOUNDARY----";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.zohoapis.com/crm/v2/files");

            request.ContentType = "multipart/form-data; boundary=" + boundary;

            request.Method = "POST";

            request.Headers["Authorization"] = "Zoho-oauthtoken 1000.xxxx.xxxxx";

            request.KeepAlive = true;

            Stream memStream = new System.IO.MemoryStream();

            var boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var endBoundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--");

            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + "Content-Type: application/octet-stream\r\n\r\n";

            StreamWrapper streamWrapper = new StreamWrapper("/Users/Desktop/test.html");

            StreamWrapper streamWrapper1 = new StreamWrapper("/Users/Desktop/test.html");

            List<StreamWrapper> streamWrapperList = new List<StreamWrapper>() { streamWrapper, streamWrapper1 };

            for (int i = 0; i < streamWrapperList.Count; i++)
            {
                StreamWrapper streamWrapperInstance = streamWrapperList[i];

                memStream.Write(boundarybytes, 0, boundarybytes.Length);

                var header = string.Format(headerTemplate, "file", streamWrapperInstance.Name);

                var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                memStream.Write(headerbytes, 0, headerbytes.Length);

                var buffer = new byte[1024];

                var bytesRead = 0;

                while ((bytesRead = streamWrapperInstance.Stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
            }

            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);

            request.ContentLength = memStream.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                memStream.Position = 0;

                byte[] tempBuffer = new byte[memStream.Length];

                memStream.Read(tempBuffer, 0, tempBuffer.Length);

                memStream.Close();

                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            }

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response == null) { throw; }

                response = (HttpWebResponse)e.Response;
            }

            HttpWebResponse responseEntity = response;

            string responsestring = new StreamReader(responseEntity.GetResponseStream()).ReadToEnd();

            responseEntity.Close();

            Console.WriteLine(responsestring);
        }
    }
}
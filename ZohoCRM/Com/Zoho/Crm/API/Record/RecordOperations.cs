using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;
using System;

namespace Com.Zoho.Crm.API.Record
{

	public class RecordOperations
	{
		/// <summary>The method to get record</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetRecord(long? id, string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to update record</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateRecord(long? id, string moduleAPIName, BodyWrapper request, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete record</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteRecord(long? id, string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetRecords(string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to create records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> CreateRecords(string moduleAPIName, BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to update records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateRecords(string moduleAPIName, BodyWrapper request, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteRecords(string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to upsert records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpsertRecords(string moduleAPIName, BodyWrapper request, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/upsert");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_ACTION;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get deleted records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<DeletedRecordsHandler></returns>
		public APIResponse<DeletedRecordsHandler> GetDeletedRecords(string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/deleted");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<DeletedRecordsHandler>(typeof(DeletedRecordsHandler), "application/json");


		}

		/// <summary>The method to search records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> SearchRecords(string moduleAPIName, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/search");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to convert lead</summary>
		/// <param name="id">long?</param>
		/// <param name="request">Instance of ConvertBodyWrapper</param>
		/// <returns>Instance of APIResponse<ConvertActionHandler></returns>
		public APIResponse<ConvertActionHandler> ConvertLead(long? id, ConvertBodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Leads/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/actions/convert");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			Utility.GetFields("Deals");

			return handlerInstance.APICall<ConvertActionHandler>(typeof(ConvertActionHandler), "application/json");


		}

		/// <summary>The method to get photo</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <returns>Instance of APIResponse<DownloadHandler></returns>
		public APIResponse<DownloadHandler> GetPhoto(long? id, string moduleAPIName)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/photo");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			return handlerInstance.APICall<DownloadHandler>(typeof(DownloadHandler), "application/x-download");


		}

		/// <summary>The method to upload photo</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of FileBodyWrapper</param>
		/// <returns>Instance of APIResponse<FileHandler></returns>
		public APIResponse<FileHandler> UploadPhoto(long? id, string moduleAPIName, FileBodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/photo");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="multipart/form-data";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			Utility.VerifyPhotoSupport(moduleAPIName);

			return handlerInstance.APICall<FileHandler>(typeof(FileHandler), "application/json");


		}

		/// <summary>The method to delete photo</summary>
		/// <param name="id">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <returns>Instance of APIResponse<FileHandler></returns>
		public APIResponse<FileHandler> DeletePhoto(long? id, string moduleAPIName)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/photo");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			return handlerInstance.APICall<FileHandler>(typeof(FileHandler), "application/json");


		}

		/// <summary>The method to mass update records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="request">Instance of MassUpdateBodyWrapper</param>
		/// <returns>Instance of APIResponse<MassUpdateActionHandler></returns>
		public APIResponse<MassUpdateActionHandler> MassUpdateRecords(string moduleAPIName, MassUpdateBodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/actions/mass_update");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			Utility.GetFields(moduleAPIName);

			handlerInstance.ModuleAPIName=moduleAPIName;

			return handlerInstance.APICall<MassUpdateActionHandler>(typeof(MassUpdateActionHandler), "application/json");


		}

		/// <summary>The method to get mass update status</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<MassUpdateResponseHandler></returns>
		public APIResponse<MassUpdateResponseHandler> GetMassUpdateStatus(string moduleAPIName, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/actions/mass_update");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<MassUpdateResponseHandler>(typeof(MassUpdateResponseHandler), "application/json");


		}


		public static class GetRecordParam
		{
			public static readonly Param<string> APPROVED=new Param<string>("approved", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> CONVERTED=new Param<string>("converted", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> CVID=new Param<string>("cvid", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> UID=new Param<string>("uid", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> FIELDS=new Param<string>("fields", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<DateTimeOffset?> STARTDATETIME=new Param<DateTimeOffset?>("startDateTime", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<DateTimeOffset?> ENDDATETIME=new Param<DateTimeOffset?>("endDateTime", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> TERRITORY_ID=new Param<string>("territory_id", "com.zoho.crm.api.Record.GetRecordParam");
			public static readonly Param<string> INCLUDE_CHILD=new Param<string>("include_child", "com.zoho.crm.api.Record.GetRecordParam");
		}


		public static class GetRecordHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.Record.GetRecordHeader");
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.GetRecordHeader");
		}


		public static class UpdateRecordHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.UpdateRecordHeader");
		}


		public static class DeleteRecordParam
		{
			public static readonly Param<string> WF_TRIGGER=new Param<string>("wf_trigger", "com.zoho.crm.api.Record.DeleteRecordParam");
		}


		public static class DeleteRecordHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.DeleteRecordHeader");
		}


		public static class GetRecordsParam
		{
			public static readonly Param<string> APPROVED=new Param<string>("approved", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> CONVERTED=new Param<string>("converted", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> CVID=new Param<string>("cvid", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> UID=new Param<string>("uid", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> FIELDS=new Param<string>("fields", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> SORT_BY=new Param<string>("sort_by", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> SORT_ORDER=new Param<string>("sort_order", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<DateTimeOffset?> STARTDATETIME=new Param<DateTimeOffset?>("startDateTime", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<DateTimeOffset?> ENDDATETIME=new Param<DateTimeOffset?>("endDateTime", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> TERRITORY_ID=new Param<string>("territory_id", "com.zoho.crm.api.Record.GetRecordsParam");
			public static readonly Param<string> INCLUDE_CHILD=new Param<string>("include_child", "com.zoho.crm.api.Record.GetRecordsParam");
		}


		public static class GetRecordsHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.Record.GetRecordsHeader");
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.GetRecordsHeader");
		}


		public static class UpdateRecordsHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.UpdateRecordsHeader");
		}


		public static class DeleteRecordsParam
		{
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Record.DeleteRecordsParam");
			public static readonly Param<string> WF_TRIGGER=new Param<string>("wf_trigger", "com.zoho.crm.api.Record.DeleteRecordsParam");
		}


		public static class DeleteRecordsHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.DeleteRecordsHeader");
		}


		public static class UpsertRecordsHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.UpsertRecordsHeader");
		}


		public static class GetDeletedRecordsParam
		{
			public static readonly Param<string> TYPE=new Param<string>("type", "com.zoho.crm.api.Record.GetDeletedRecordsParam");
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Record.GetDeletedRecordsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Record.GetDeletedRecordsParam");
		}


		public static class GetDeletedRecordsHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.Record.GetDeletedRecordsHeader");
		}


		public static class SearchRecordsParam
		{
			public static readonly Param<string> CRITERIA=new Param<string>("criteria", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<string> EMAIL=new Param<string>("email", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<string> PHONE=new Param<string>("phone", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<string> WORD=new Param<string>("word", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<string> CONVERTED=new Param<string>("converted", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<string> APPROVED=new Param<string>("approved", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Record.SearchRecordsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Record.SearchRecordsParam");
		}


		public static class SearchRecordsHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.Record.SearchRecordsHeader");
		}


		public static class GetMassUpdateStatusParam
		{
			public static readonly Param<string> JOB_ID=new Param<string>("job_id", "com.zoho.crm.api.Record.GetMassUpdateStatusParam");
		}

	}
}
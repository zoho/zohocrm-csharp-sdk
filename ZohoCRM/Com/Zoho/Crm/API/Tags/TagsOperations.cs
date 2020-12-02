using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Tags
{

	public class TagsOperations
	{
		/// <summary>The method to get tags</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetTags(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to create tags</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> CreateTags(BodyWrapper request, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to update tags</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateTags(BodyWrapper request, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to update tag</summary>
		/// <param name="id">long?</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateTag(long? id, BodyWrapper request, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete tag</summary>
		/// <param name="id">long?</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteTag(long? id)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to merge tags</summary>
		/// <param name="id">long?</param>
		/// <param name="request">Instance of MergeWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> MergeTags(long? id, MergeWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/actions/merge");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to add tags to record</summary>
		/// <param name="recordId">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<RecordActionHandler></returns>
		public APIResponse<RecordActionHandler> AddTagsToRecord(long? recordId, string moduleAPIName, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, recordId.ToString());

			apiPath=string.Concat(apiPath, "/actions/add_tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<RecordActionHandler>(typeof(RecordActionHandler), "application/json");


		}

		/// <summary>The method to remove tags from record</summary>
		/// <param name="recordId">long?</param>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<RecordActionHandler></returns>
		public APIResponse<RecordActionHandler> RemoveTagsFromRecord(long? recordId, string moduleAPIName, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, recordId.ToString());

			apiPath=string.Concat(apiPath, "/actions/remove_tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<RecordActionHandler>(typeof(RecordActionHandler), "application/json");


		}

		/// <summary>The method to add tags to multiple records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<RecordActionHandler></returns>
		public APIResponse<RecordActionHandler> AddTagsToMultipleRecords(string moduleAPIName, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/actions/add_tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<RecordActionHandler>(typeof(RecordActionHandler), "application/json");


		}

		/// <summary>The method to remove tags from multiple records</summary>
		/// <param name="moduleAPIName">string</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<RecordActionHandler></returns>
		public APIResponse<RecordActionHandler> RemoveTagsFromMultipleRecords(string moduleAPIName, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath, moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/actions/remove_tags");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<RecordActionHandler>(typeof(RecordActionHandler), "application/json");


		}

		/// <summary>The method to get record count for tag</summary>
		/// <param name="id">long?</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<CountHandler></returns>
		public APIResponse<CountHandler> GetRecordCountForTag(long? id, ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/settings/tags/");

			apiPath=string.Concat(apiPath, id.ToString());

			apiPath=string.Concat(apiPath, "/actions/records_count");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<CountHandler>(typeof(CountHandler), "application/json");


		}


		public static class GetTagsParam
		{
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Tags.GetTagsParam");
			public static readonly Param<string> MY_TAGS=new Param<string>("my_tags", "com.zoho.crm.api.Tags.GetTagsParam");
		}


		public static class CreateTagsParam
		{
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Tags.CreateTagsParam");
		}


		public static class UpdateTagsParam
		{
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Tags.UpdateTagsParam");
		}


		public static class UpdateTagParam
		{
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Tags.UpdateTagParam");
		}


		public static class AddTagsToRecordParam
		{
			public static readonly Param<string> TAG_NAMES=new Param<string>("tag_names", "com.zoho.crm.api.Tags.AddTagsToRecordParam");
			public static readonly Param<string> OVER_WRITE=new Param<string>("over_write", "com.zoho.crm.api.Tags.AddTagsToRecordParam");
		}


		public static class RemoveTagsFromRecordParam
		{
			public static readonly Param<string> TAG_NAMES=new Param<string>("tag_names", "com.zoho.crm.api.Tags.RemoveTagsFromRecordParam");
		}


		public static class AddTagsToMultipleRecordsParam
		{
			public static readonly Param<string> TAG_NAMES=new Param<string>("tag_names", "com.zoho.crm.api.Tags.AddTagsToMultipleRecordsParam");
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Tags.AddTagsToMultipleRecordsParam");
			public static readonly Param<string> OVER_WRITE=new Param<string>("over_write", "com.zoho.crm.api.Tags.AddTagsToMultipleRecordsParam");
		}


		public static class RemoveTagsFromMultipleRecordsParam
		{
			public static readonly Param<string> TAG_NAMES=new Param<string>("tag_names", "com.zoho.crm.api.Tags.RemoveTagsFromMultipleRecordsParam");
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Tags.RemoveTagsFromMultipleRecordsParam");
		}


		public static class GetRecordCountForTagParam
		{
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Tags.GetRecordCountForTagParam");
		}

	}
}
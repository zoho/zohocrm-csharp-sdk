using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;
using System;

namespace Com.Zoho.Crm.API.RelatedRecords
{

	public class RelatedRecordsOperations
	{
		private string moduleAPIName;
		private long? recordId;
		private string relatedListAPIName;

		/// <summary>		/// Creates an instance of RelatedRecordsOperations with the given parameters
		/// <param name="relatedListAPIName">string</param>
		/// <param name="recordId">long?</param>
		/// <param name="moduleAPIName">string</param>
		
		public RelatedRecordsOperations(string relatedListAPIName, long? recordId, string moduleAPIName)
		{
			 this.relatedListAPIName=relatedListAPIName;

			 this.recordId=recordId;

			 this.moduleAPIName=moduleAPIName;


		}

		/// <summary>The method to get related records</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetRelatedRecords(ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			Utility.GetRelatedLists( this.relatedListAPIName,  this.moduleAPIName, handlerInstance);

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to update related records</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateRelatedRecords(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			Utility.GetRelatedLists( this.relatedListAPIName,  this.moduleAPIName, handlerInstance);

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delink records</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DelinkRecords(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get related record</summary>
		/// <param name="relatedRecordId">long?</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetRelatedRecord(long? relatedRecordId, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, relatedRecordId.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Header=headerInstance;

			Utility.GetRelatedLists( this.relatedListAPIName,  this.moduleAPIName, handlerInstance);

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to update related record</summary>
		/// <param name="relatedRecordId">long?</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateRelatedRecord(long? relatedRecordId, BodyWrapper request, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, relatedRecordId.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.Header=headerInstance;

			Utility.GetRelatedLists( this.relatedListAPIName,  this.moduleAPIName, handlerInstance);

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delink record</summary>
		/// <param name="relatedRecordId">long?</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DelinkRecord(long? relatedRecordId, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.relatedListAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, relatedRecordId.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}


		public static class GetRelatedRecordsParam
		{
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.RelatedRecords.GetRelatedRecordsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.RelatedRecords.GetRelatedRecordsParam");
		}


		public static class GetRelatedRecordsHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.RelatedRecords.GetRelatedRecordsHeader");
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.RelatedRecords.GetRelatedRecordsHeader");
		}


		public static class DelinkRecordsParam
		{
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.RelatedRecords.DelinkRecordsParam");
		}


		public static class GetRelatedRecordHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.RelatedRecords.GetRelatedRecordHeader");
		}


		public static class UpdateRelatedRecordHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.RelatedRecords.UpdateRelatedRecordHeader");
		}


		public static class DelinkRecordHeader
		{
			public static readonly Header<string> X_EXTERNAL=new Header<string>("X-EXTERNAL", "com.zoho.crm.api.RelatedRecords.DelinkRecordHeader");
		}

	}
}
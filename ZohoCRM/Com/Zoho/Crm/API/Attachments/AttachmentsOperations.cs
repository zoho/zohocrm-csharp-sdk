using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Attachments
{

	public class AttachmentsOperations
	{
		private long? recordId;
		private string moduleAPIName;

		/// <summary>		/// Creates an instance of AttachmentsOperations with the given parameters
		/// <param name="moduleAPIName">string</param>
		/// <param name="recordId">long?</param>
		
		public AttachmentsOperations(string moduleAPIName, long? recordId)
		{
			 this.moduleAPIName=moduleAPIName;

			 this.recordId=recordId;


		}

		/// <summary>The method to download attachment</summary>
		/// <param name="id">long?</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> DownloadAttachment(long? id)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/x-download");


		}

		/// <summary>The method to delete attachment</summary>
		/// <param name="id">long?</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteAttachment(long? id)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get attachments</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetAttachments(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to upload attachment</summary>
		/// <param name="request">Instance of FileBodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UploadAttachment(FileBodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="multipart/form-data";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to upload link attachment</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UploadLinkAttachment(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete attachments</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteAttachments(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/");

			apiPath=string.Concat(apiPath,  this.moduleAPIName.ToString());

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath,  this.recordId.ToString());

			apiPath=string.Concat(apiPath, "/Attachments");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}


		public static class GetAttachmentsParam
		{
			public static readonly Param<string> FIELDS=new Param<string>("fields", "com.zoho.crm.api.Attachments.GetAttachmentsParam");
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Attachments.GetAttachmentsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Attachments.GetAttachmentsParam");
		}


		public static class UploadLinkAttachmentParam
		{
			public static readonly Param<string> ATTACHMENTURL=new Param<string>("attachmentUrl", "com.zoho.crm.api.Attachments.UploadLinkAttachmentParam");
		}


		public static class DeleteAttachmentsParam
		{
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Attachments.DeleteAttachmentsParam");
		}

	}
}
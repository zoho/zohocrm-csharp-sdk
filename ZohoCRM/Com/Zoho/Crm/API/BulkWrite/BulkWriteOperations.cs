using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.BulkWrite
{

	public class BulkWriteOperations
	{
		/// <summary>The method to upload file</summary>
		/// <param name="request">Instance of FileBodyWrapper</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ActionResponse></returns>
		public APIResponse<ActionResponse> UploadFile(FileBodyWrapper request, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "https://content.zohoapis.com/crm/v2/upload");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="multipart/form-data";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ActionResponse>(typeof(ActionResponse), "application/json");


		}

		/// <summary>The method to create bulk write job</summary>
		/// <param name="request">Instance of RequestWrapper</param>
		/// <returns>Instance of APIResponse<ActionResponse></returns>
		public APIResponse<ActionResponse> CreateBulkWriteJob(RequestWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/bulk/v2/write");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionResponse>(typeof(ActionResponse), "application/json");


		}

		/// <summary>The method to get bulk write job details</summary>
		/// <param name="jobId">long?</param>
		/// <returns>Instance of APIResponse<ResponseWrapper></returns>
		public APIResponse<ResponseWrapper> GetBulkWriteJobDetails(long? jobId)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/bulk/v2/write/");

			apiPath=string.Concat(apiPath, jobId.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			return handlerInstance.APICall<ResponseWrapper>(typeof(ResponseWrapper), "application/json");


		}

		/// <summary>The method to download bulk write result</summary>
		/// <param name="downloadUrl">string</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> DownloadBulkWriteResult(string downloadUrl)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/");

			apiPath=string.Concat(apiPath, downloadUrl.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/octet-stream");


		}


		public static class UploadFileHeader
		{
			public static readonly Header<string> FEATURE=new Header<string>("feature", "com.zoho.crm.api.BulkWrite.UploadFileHeader");
			public static readonly Header<string> X_CRM_ORG=new Header<string>("X-CRM-ORG", "com.zoho.crm.api.BulkWrite.UploadFileHeader");
		}

	}
}
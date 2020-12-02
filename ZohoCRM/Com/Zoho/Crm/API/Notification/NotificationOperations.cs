using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Notification
{

	public class NotificationOperations
	{
		/// <summary>The method to enable notifications</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> EnableNotifications(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get notification details</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetNotificationDetails(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to update notifications</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateNotifications(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to update notification</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateNotification(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PATCH;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to disable notifications</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DisableNotifications(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to disable notification</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DisableNotification(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/actions/watch");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PATCH;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}


		public static class GetNotificationDetailsParam
		{
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Notification.GetNotificationDetailsParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Notification.GetNotificationDetailsParam");
			public static readonly Param<long?> CHANNEL_ID=new Param<long?>("channel_id", "com.zoho.crm.api.Notification.GetNotificationDetailsParam");
			public static readonly Param<string> MODULE=new Param<string>("module", "com.zoho.crm.api.Notification.GetNotificationDetailsParam");
		}


		public static class DisableNotificationsParam
		{
			public static readonly Param<long?> CHANNEL_IDS=new Param<long?>("channel_ids", "com.zoho.crm.api.Notification.DisableNotificationsParam");
		}

	}
}
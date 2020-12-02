using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Util;
using System;

namespace Com.Zoho.Crm.API.Notes
{

	public class NotesOperations
	{
		/// <summary>The method to get notes</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetNotes(ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to create notes</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> CreateNotes(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_POST;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_CREATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to update notes</summary>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateNotes(BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			handlerInstance.MandatoryChecker=true;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete notes</summary>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteNotes(ParameterMap paramInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes");

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.Param=paramInstance;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to get note</summary>
		/// <param name="id">long?</param>
		/// <param name="paramInstance">Instance of ParameterMap</param>
		/// <param name="headerInstance">Instance of HeaderMap</param>
		/// <returns>Instance of APIResponse<ResponseHandler></returns>
		public APIResponse<ResponseHandler> GetNote(long? id, ParameterMap paramInstance, HeaderMap headerInstance)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_GET;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_READ;

			handlerInstance.Param=paramInstance;

			handlerInstance.Header=headerInstance;

			return handlerInstance.APICall<ResponseHandler>(typeof(ResponseHandler), "application/json");


		}

		/// <summary>The method to update note</summary>
		/// <param name="id">long?</param>
		/// <param name="request">Instance of BodyWrapper</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> UpdateNote(long? id, BodyWrapper request)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_PUT;

			handlerInstance.CategoryMethod=Constants.REQUEST_CATEGORY_UPDATE;

			handlerInstance.ContentType="application/json";

			handlerInstance.Request=request;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}

		/// <summary>The method to delete note</summary>
		/// <param name="id">long?</param>
		/// <returns>Instance of APIResponse<ActionHandler></returns>
		public APIResponse<ActionHandler> DeleteNote(long? id)
		{
			CommonAPIHandler handlerInstance=new CommonAPIHandler();

			string apiPath="";

			apiPath=string.Concat(apiPath, "/crm/v2/Notes/");

			apiPath=string.Concat(apiPath, id.ToString());

			handlerInstance.APIPath=apiPath;

			handlerInstance.HttpMethod=Constants.REQUEST_METHOD_DELETE;

			handlerInstance.CategoryMethod=Constants.REQUEST_METHOD_DELETE;

			return handlerInstance.APICall<ActionHandler>(typeof(ActionHandler), "application/json");


		}


		public static class GetNotesParam
		{
			public static readonly Param<int?> PAGE=new Param<int?>("page", "com.zoho.crm.api.Notes.GetNotesParam");
			public static readonly Param<int?> PER_PAGE=new Param<int?>("per_page", "com.zoho.crm.api.Notes.GetNotesParam");
			public static readonly Param<string> FIELDS=new Param<string>("fields", "com.zoho.crm.api.Notes.GetNotesParam");
		}


		public static class GetNotesHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.Notes.GetNotesHeader");
		}


		public static class DeleteNotesParam
		{
			public static readonly Param<long?> IDS=new Param<long?>("ids", "com.zoho.crm.api.Notes.DeleteNotesParam");
		}


		public static class GetNoteParam
		{
			public static readonly Param<string> FIELDS=new Param<string>("fields", "com.zoho.crm.api.Notes.GetNoteParam");
		}


		public static class GetNoteHeader
		{
			public static readonly Header<DateTimeOffset?> IF_MODIFIED_SINCE=new Header<DateTimeOffset?>("If-Modified-Since", "com.zoho.crm.api.Notes.GetNoteHeader");
		}

	}
}
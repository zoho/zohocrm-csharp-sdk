using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BulkWrite
{

	public class APIException : Model, ActionResponse, ResponseWrapper, ResponseHandler
	{
		private Choice<string> code;
		private Choice<string> message;
		private Choice<string> status;
		private Dictionary<string, object> details;
		private Choice<string> errorMessage;
		private int? errorCode;
		private Choice<string> xError;
		private Choice<string> info;
		private Choice<string> xInfo;
		private string httpStatus;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public Choice<string> Code
		{
			/// <summary>The method to get the code</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.code;

			}
			/// <summary>The method to set the value to code</summary>
			/// <param name="code">Instance of Choice<string></param>
			set
			{
				 this.code=value;

				 this.keyModified["code"] = 1;

			}
		}

		public Choice<string> Message
		{
			/// <summary>The method to get the message</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.message;

			}
			/// <summary>The method to set the value to message</summary>
			/// <param name="message">Instance of Choice<string></param>
			set
			{
				 this.message=value;

				 this.keyModified["message"] = 1;

			}
		}

		public Choice<string> Status
		{
			/// <summary>The method to get the status</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.status;

			}
			/// <summary>The method to set the value to status</summary>
			/// <param name="status">Instance of Choice<string></param>
			set
			{
				 this.status=value;

				 this.keyModified["status"] = 1;

			}
		}

		public Dictionary<string, object> Details
		{
			/// <summary>The method to get the details</summary>
			/// <returns>Dictionary representing the details<String,Object></returns>
			get
			{
				return  this.details;

			}
			/// <summary>The method to set the value to details</summary>
			/// <param name="details">Dictionary<string,object></param>
			set
			{
				 this.details=value;

				 this.keyModified["details"] = 1;

			}
		}

		public Choice<string> ErrorMessage
		{
			/// <summary>The method to get the errorMessage</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.errorMessage;

			}
			/// <summary>The method to set the value to errorMessage</summary>
			/// <param name="errorMessage">Instance of Choice<string></param>
			set
			{
				 this.errorMessage=value;

				 this.keyModified["ERROR_MESSAGE"] = 1;

			}
		}

		public int? ErrorCode
		{
			/// <summary>The method to get the errorCode</summary>
			/// <returns>int? representing the errorCode</returns>
			get
			{
				return  this.errorCode;

			}
			/// <summary>The method to set the value to errorCode</summary>
			/// <param name="errorCode">int?</param>
			set
			{
				 this.errorCode=value;

				 this.keyModified["ERROR_CODE"] = 1;

			}
		}

		public Choice<string> XError
		{
			/// <summary>The method to get the xError</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.xError;

			}
			/// <summary>The method to set the value to xError</summary>
			/// <param name="xError">Instance of Choice<string></param>
			set
			{
				 this.xError=value;

				 this.keyModified["x-error"] = 1;

			}
		}

		public Choice<string> Info
		{
			/// <summary>The method to get the info</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.info;

			}
			/// <summary>The method to set the value to info</summary>
			/// <param name="info">Instance of Choice<string></param>
			set
			{
				 this.info=value;

				 this.keyModified["info"] = 1;

			}
		}

		public Choice<string> XInfo
		{
			/// <summary>The method to get the xInfo</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.xInfo;

			}
			/// <summary>The method to set the value to xInfo</summary>
			/// <param name="xInfo">Instance of Choice<string></param>
			set
			{
				 this.xInfo=value;

				 this.keyModified["x-info"] = 1;

			}
		}

		public string HttpStatus
		{
			/// <summary>The method to get the httpStatus</summary>
			/// <returns>string representing the httpStatus</returns>
			get
			{
				return  this.httpStatus;

			}
			/// <summary>The method to set the value to httpStatus</summary>
			/// <param name="httpStatus">string</param>
			set
			{
				 this.httpStatus=value;

				 this.keyModified["http_status"] = 1;

			}
		}

		/// <summary>The method to check if the user has modified the given key</summary>
		/// <param name="key">string</param>
		/// <returns>int? representing the modification</returns>
		public int? IsKeyModified(string key)
		{
			if((( this.keyModified.ContainsKey(key))))
			{
				return  this.keyModified[key];

			}
			return null;


		}

		/// <summary>The method to mark the given key as modified</summary>
		/// <param name="key">string</param>
		/// <param name="modification">int?</param>
		public void SetKeyModified(string key, int? modification)
		{
			 this.keyModified[key] = modification;


		}


	}
}
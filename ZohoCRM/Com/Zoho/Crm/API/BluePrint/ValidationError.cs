using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BluePrint
{

	public class ValidationError : Model
	{
		private string apiName;
		private string message;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string APIName
		{
			/// <summary>The method to get the aPIName</summary>
			/// <returns>string representing the apiName</returns>
			get
			{
				return  this.apiName;

			}
			/// <summary>The method to set the value to aPIName</summary>
			/// <param name="apiName">string</param>
			set
			{
				 this.apiName=value;

				 this.keyModified["api_name"] = 1;

			}
		}

		public string Message
		{
			/// <summary>The method to get the message</summary>
			/// <returns>string representing the message</returns>
			get
			{
				return  this.message;

			}
			/// <summary>The method to set the value to message</summary>
			/// <param name="message">string</param>
			set
			{
				 this.message=value;

				 this.keyModified["message"] = 1;

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
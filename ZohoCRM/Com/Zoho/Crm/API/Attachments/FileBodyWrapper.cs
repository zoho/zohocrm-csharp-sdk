using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Attachments
{

	public class FileBodyWrapper : Model, ResponseHandler
	{
		private StreamWrapper file;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public StreamWrapper File
		{
			/// <summary>The method to get the file</summary>
			/// <returns>Instance of StreamWrapper</returns>
			get
			{
				return  this.file;

			}
			/// <summary>The method to set the value to file</summary>
			/// <param name="file">Instance of StreamWrapper</param>
			set
			{
				 this.file=value;

				 this.keyModified["file"] = 1;

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
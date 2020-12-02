using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BulkWrite
{

	public class Result : Model
	{
		private string downloadUrl;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string DownloadUrl
		{
			/// <summary>The method to get the downloadUrl</summary>
			/// <returns>string representing the downloadUrl</returns>
			get
			{
				return  this.downloadUrl;

			}
			/// <summary>The method to set the value to downloadUrl</summary>
			/// <param name="downloadUrl">string</param>
			set
			{
				 this.downloadUrl=value;

				 this.keyModified["download_url"] = 1;

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
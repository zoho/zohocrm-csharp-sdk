using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class ConvertActionWrapper : Model, ConvertActionHandler
	{
		private List<ConvertActionResponse> data;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<ConvertActionResponse> Data
		{
			/// <summary>The method to get the data</summary>
			/// <returns>Instance of List<ConvertActionResponse></returns>
			get
			{
				return  this.data;

			}
			/// <summary>The method to set the value to data</summary>
			/// <param name="data">Instance of List<ConvertActionResponse></param>
			set
			{
				 this.data=value;

				 this.keyModified["data"] = 1;

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
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Query
{

	public class BodyWrapper : Model
	{
		private string selectQuery;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string SelectQuery
		{
			/// <summary>The method to get the selectQuery</summary>
			/// <returns>string representing the selectQuery</returns>
			get
			{
				return  this.selectQuery;

			}
			/// <summary>The method to set the value to selectQuery</summary>
			/// <param name="selectQuery">string</param>
			set
			{
				 this.selectQuery=value;

				 this.keyModified["select_query"] = 1;

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
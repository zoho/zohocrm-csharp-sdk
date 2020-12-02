using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class Unique : Model
	{
		private string casesensitive;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Casesensitive
		{
			/// <summary>The method to get the casesensitive</summary>
			/// <returns>string representing the casesensitive</returns>
			get
			{
				return  this.casesensitive;

			}
			/// <summary>The method to set the value to casesensitive</summary>
			/// <param name="casesensitive">string</param>
			set
			{
				 this.casesensitive=value;

				 this.keyModified["casesensitive"] = 1;

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
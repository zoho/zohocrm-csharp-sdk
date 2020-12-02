using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Currencies
{

	public class BodyWrapper : Model
	{
		private List<Currency> currencies;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<Currency> Currencies
		{
			/// <summary>The method to get the currencies</summary>
			/// <returns>Instance of List<Currency></returns>
			get
			{
				return  this.currencies;

			}
			/// <summary>The method to set the value to currencies</summary>
			/// <param name="currencies">Instance of List<Currency></param>
			set
			{
				 this.currencies=value;

				 this.keyModified["currencies"] = 1;

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
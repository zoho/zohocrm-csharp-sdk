using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class RecurringActivity : Model
	{
		private string rrule;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Rrule
		{
			/// <summary>The method to get the rrule</summary>
			/// <returns>string representing the rrule</returns>
			get
			{
				return  this.rrule;

			}
			/// <summary>The method to set the value to rrule</summary>
			/// <param name="rrule">string</param>
			set
			{
				 this.rrule=value;

				 this.keyModified["RRULE"] = 1;

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
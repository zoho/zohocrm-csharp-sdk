using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Taxes
{

	public class BodyWrapper : Model
	{
		private List<Tax> taxes;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<Tax> Taxes
		{
			/// <summary>The method to get the taxes</summary>
			/// <returns>Instance of List<Tax></returns>
			get
			{
				return  this.taxes;

			}
			/// <summary>The method to set the value to taxes</summary>
			/// <param name="taxes">Instance of List<Tax></param>
			set
			{
				 this.taxes=value;

				 this.keyModified["taxes"] = 1;

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
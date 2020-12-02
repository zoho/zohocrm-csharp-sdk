using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class Currency : Model
	{
		private string roundingOption;
		private int? precision;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string RoundingOption
		{
			/// <summary>The method to get the roundingOption</summary>
			/// <returns>string representing the roundingOption</returns>
			get
			{
				return  this.roundingOption;

			}
			/// <summary>The method to set the value to roundingOption</summary>
			/// <param name="roundingOption">string</param>
			set
			{
				 this.roundingOption=value;

				 this.keyModified["rounding_option"] = 1;

			}
		}

		public int? Precision
		{
			/// <summary>The method to get the precision</summary>
			/// <returns>int? representing the precision</returns>
			get
			{
				return  this.precision;

			}
			/// <summary>The method to set the value to precision</summary>
			/// <param name="precision">int?</param>
			set
			{
				 this.precision=value;

				 this.keyModified["precision"] = 1;

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
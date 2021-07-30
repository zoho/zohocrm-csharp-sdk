using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Taxes
{

	public class Preference : Model
	{
		private bool? autoPopulateTax;
		private bool? modifyTaxRates;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public bool? AutoPopulateTax
		{
			/// <summary>The method to get the autoPopulateTax</summary>
			/// <returns>bool? representing the autoPopulateTax</returns>
			get
			{
				return  this.autoPopulateTax;

			}
			/// <summary>The method to set the value to autoPopulateTax</summary>
			/// <param name="autoPopulateTax">bool?</param>
			set
			{
				 this.autoPopulateTax=value;

				 this.keyModified["auto_populate_tax"] = 1;

			}
		}

		public bool? ModifyTaxRates
		{
			/// <summary>The method to get the modifyTaxRates</summary>
			/// <returns>bool? representing the modifyTaxRates</returns>
			get
			{
				return  this.modifyTaxRates;

			}
			/// <summary>The method to set the value to modifyTaxRates</summary>
			/// <param name="modifyTaxRates">bool?</param>
			set
			{
				 this.modifyTaxRates=value;

				 this.keyModified["modify_tax_rates"] = 1;

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
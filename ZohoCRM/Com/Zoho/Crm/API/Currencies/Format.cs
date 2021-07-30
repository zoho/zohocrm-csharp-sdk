using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Currencies
{

	public class Format : Model
	{
		private Choice<string> decimalSeparator;
		private Choice<string> thousandSeparator;
		private Choice<string> decimalPlaces;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public Choice<string> DecimalSeparator
		{
			/// <summary>The method to get the decimalSeparator</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.decimalSeparator;

			}
			/// <summary>The method to set the value to decimalSeparator</summary>
			/// <param name="decimalSeparator">Instance of Choice<string></param>
			set
			{
				 this.decimalSeparator=value;

				 this.keyModified["decimal_separator"] = 1;

			}
		}

		public Choice<string> ThousandSeparator
		{
			/// <summary>The method to get the thousandSeparator</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.thousandSeparator;

			}
			/// <summary>The method to set the value to thousandSeparator</summary>
			/// <param name="thousandSeparator">Instance of Choice<string></param>
			set
			{
				 this.thousandSeparator=value;

				 this.keyModified["thousand_separator"] = 1;

			}
		}

		public Choice<string> DecimalPlaces
		{
			/// <summary>The method to get the decimalPlaces</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.decimalPlaces;

			}
			/// <summary>The method to set the value to decimalPlaces</summary>
			/// <param name="decimalPlaces">Instance of Choice<string></param>
			set
			{
				 this.decimalPlaces=value;

				 this.keyModified["decimal_places"] = 1;

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
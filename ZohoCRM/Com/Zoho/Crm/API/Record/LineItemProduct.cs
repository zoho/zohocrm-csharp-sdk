using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Record
{

	public class LineItemProduct : Record , Model
	{

		public string ProductCode
		{
			/// <summary>The method to get the productCode</summary>
			/// <returns>string representing the productCode</returns>
			get
			{
				if((( this.GetKeyValue("Product_Code")) != (null)))
				{
					return (string) this.GetKeyValue("Product_Code");

				}
					return null;


			}
			/// <summary>The method to set the value to productCode</summary>
			/// <param name="productCode">string</param>
			set
			{
				 this.AddKeyValue("Product_Code", value);

			}
		}

		public string Currency
		{
			/// <summary>The method to get the currency</summary>
			/// <returns>string representing the currency</returns>
			get
			{
				if((( this.GetKeyValue("Currency")) != (null)))
				{
					return (string) this.GetKeyValue("Currency");

				}
					return null;


			}
			/// <summary>The method to set the value to currency</summary>
			/// <param name="currency">string</param>
			set
			{
				 this.AddKeyValue("Currency", value);

			}
		}

		public string Name
		{
			/// <summary>The method to get the name</summary>
			/// <returns>string representing the name</returns>
			get
			{
				if((( this.GetKeyValue("name")) != (null)))
				{
					return (string) this.GetKeyValue("name");

				}
					return null;


			}
			/// <summary>The method to set the value to name</summary>
			/// <param name="name">string</param>
			set
			{
				 this.AddKeyValue("name", value);

			}
		}


	}
}
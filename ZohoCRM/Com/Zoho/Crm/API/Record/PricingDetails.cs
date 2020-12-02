using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Record
{

	public class PricingDetails : Record , Model
	{

		public double? ToRange
		{
			/// <summary>The method to get the toRange</summary>
			/// <returns>double? representing the toRange</returns>
			get
			{
				if((( this.GetKeyValue("to_range")) != (null)))
				{
					return (double?) this.GetKeyValue("to_range");

				}
					return null;


			}
			/// <summary>The method to set the value to toRange</summary>
			/// <param name="toRange">double?</param>
			set
			{
				 this.AddKeyValue("to_range", value);

			}
		}

		public double? Discount
		{
			/// <summary>The method to get the discount</summary>
			/// <returns>double? representing the discount</returns>
			get
			{
				if((( this.GetKeyValue("discount")) != (null)))
				{
					return (double?) this.GetKeyValue("discount");

				}
					return null;


			}
			/// <summary>The method to set the value to discount</summary>
			/// <param name="discount">double?</param>
			set
			{
				 this.AddKeyValue("discount", value);

			}
		}

		public double? FromRange
		{
			/// <summary>The method to get the fromRange</summary>
			/// <returns>double? representing the fromRange</returns>
			get
			{
				if((( this.GetKeyValue("from_range")) != (null)))
				{
					return (double?) this.GetKeyValue("from_range");

				}
					return null;


			}
			/// <summary>The method to set the value to fromRange</summary>
			/// <param name="fromRange">double?</param>
			set
			{
				 this.AddKeyValue("from_range", value);

			}
		}


	}
}
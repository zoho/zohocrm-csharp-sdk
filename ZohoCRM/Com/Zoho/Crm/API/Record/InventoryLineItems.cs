using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class InventoryLineItems : Record , Model
	{

		public LineItemProduct Product
		{
			/// <summary>The method to get the product</summary>
			/// <returns>Instance of LineItemProduct</returns>
			get
			{
				if((( this.GetKeyValue("product")) != (null)))
				{
					return (LineItemProduct) this.GetKeyValue("product");

				}
					return null;


			}
			/// <summary>The method to set the value to product</summary>
			/// <param name="product">Instance of LineItemProduct</param>
			set
			{
				 this.AddKeyValue("product", value);

			}
		}

		public double? Quantity
		{
			/// <summary>The method to get the quantity</summary>
			/// <returns>double? representing the quantity</returns>
			get
			{
				if((( this.GetKeyValue("quantity")) != (null)))
				{
					return (double?) this.GetKeyValue("quantity");

				}
					return null;


			}
			/// <summary>The method to set the value to quantity</summary>
			/// <param name="quantity">double?</param>
			set
			{
				 this.AddKeyValue("quantity", value);

			}
		}

		public string Discount
		{
			/// <summary>The method to get the discount</summary>
			/// <returns>string representing the discount</returns>
			get
			{
				if((( this.GetKeyValue("Discount")) != (null)))
				{
					return (string) this.GetKeyValue("Discount");

				}
					return null;


			}
			/// <summary>The method to set the value to discount</summary>
			/// <param name="discount">string</param>
			set
			{
				 this.AddKeyValue("Discount", value);

			}
		}

		public double? TotalAfterDiscount
		{
			/// <summary>The method to get the totalAfterDiscount</summary>
			/// <returns>double? representing the totalAfterDiscount</returns>
			get
			{
				if((( this.GetKeyValue("total_after_discount")) != (null)))
				{
					return (double?) this.GetKeyValue("total_after_discount");

				}
					return null;


			}
			/// <summary>The method to set the value to totalAfterDiscount</summary>
			/// <param name="totalAfterDiscount">double?</param>
			set
			{
				 this.AddKeyValue("total_after_discount", value);

			}
		}

		public double? NetTotal
		{
			/// <summary>The method to get the netTotal</summary>
			/// <returns>double? representing the netTotal</returns>
			get
			{
				if((( this.GetKeyValue("net_total")) != (null)))
				{
					return (double?) this.GetKeyValue("net_total");

				}
					return null;


			}
			/// <summary>The method to set the value to netTotal</summary>
			/// <param name="netTotal">double?</param>
			set
			{
				 this.AddKeyValue("net_total", value);

			}
		}

		public double? Book
		{
			/// <summary>The method to get the book</summary>
			/// <returns>double? representing the book</returns>
			get
			{
				if((( this.GetKeyValue("book")) != (null)))
				{
					return (double?) this.GetKeyValue("book");

				}
					return null;


			}
			/// <summary>The method to set the value to book</summary>
			/// <param name="book">double?</param>
			set
			{
				 this.AddKeyValue("book", value);

			}
		}

		public double? Tax
		{
			/// <summary>The method to get the tax</summary>
			/// <returns>double? representing the tax</returns>
			get
			{
				if((( this.GetKeyValue("Tax")) != (null)))
				{
					return (double?) this.GetKeyValue("Tax");

				}
					return null;


			}
			/// <summary>The method to set the value to tax</summary>
			/// <param name="tax">double?</param>
			set
			{
				 this.AddKeyValue("Tax", value);

			}
		}

		public double? ListPrice
		{
			/// <summary>The method to get the listPrice</summary>
			/// <returns>double? representing the listPrice</returns>
			get
			{
				if((( this.GetKeyValue("list_price")) != (null)))
				{
					return (double?) this.GetKeyValue("list_price");

				}
					return null;


			}
			/// <summary>The method to set the value to listPrice</summary>
			/// <param name="listPrice">double?</param>
			set
			{
				 this.AddKeyValue("list_price", value);

			}
		}

		public double? UnitPrice
		{
			/// <summary>The method to get the unitPrice</summary>
			/// <returns>double? representing the unitPrice</returns>
			get
			{
				if((( this.GetKeyValue("unit_price")) != (null)))
				{
					return (double?) this.GetKeyValue("unit_price");

				}
					return null;


			}
			/// <summary>The method to set the value to unitPrice</summary>
			/// <param name="unitPrice">double?</param>
			set
			{
				 this.AddKeyValue("unit_price", value);

			}
		}

		public double? QuantityInStock
		{
			/// <summary>The method to get the quantityInStock</summary>
			/// <returns>double? representing the quantityInStock</returns>
			get
			{
				if((( this.GetKeyValue("quantity_in_stock")) != (null)))
				{
					return (double?) this.GetKeyValue("quantity_in_stock");

				}
					return null;


			}
			/// <summary>The method to set the value to quantityInStock</summary>
			/// <param name="quantityInStock">double?</param>
			set
			{
				 this.AddKeyValue("quantity_in_stock", value);

			}
		}

		public double? Total
		{
			/// <summary>The method to get the total</summary>
			/// <returns>double? representing the total</returns>
			get
			{
				if((( this.GetKeyValue("total")) != (null)))
				{
					return (double?) this.GetKeyValue("total");

				}
					return null;


			}
			/// <summary>The method to set the value to total</summary>
			/// <param name="total">double?</param>
			set
			{
				 this.AddKeyValue("total", value);

			}
		}

		public string ProductDescription
		{
			/// <summary>The method to get the productDescription</summary>
			/// <returns>string representing the productDescription</returns>
			get
			{
				if((( this.GetKeyValue("product_description")) != (null)))
				{
					return (string) this.GetKeyValue("product_description");

				}
					return null;


			}
			/// <summary>The method to set the value to productDescription</summary>
			/// <param name="productDescription">string</param>
			set
			{
				 this.AddKeyValue("product_description", value);

			}
		}

		public List<LineTax> LineTax
		{
			/// <summary>The method to get the lineTax</summary>
			/// <returns>Instance of List<LineTax></returns>
			get
			{
				if((( this.GetKeyValue("line_tax")) != (null)))
				{
					return (List<LineTax>) this.GetKeyValue("line_tax");

				}
					return null;


			}
			/// <summary>The method to set the value to lineTax</summary>
			/// <param name="lineTax">Instance of List<LineTax></param>
			set
			{
				 this.AddKeyValue("line_tax", value);

			}
		}


	}
}
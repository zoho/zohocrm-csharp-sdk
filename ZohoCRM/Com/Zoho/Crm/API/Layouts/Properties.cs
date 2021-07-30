using Com.Zoho.Crm.API.Fields;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Layouts
{

	public class Properties : Model
	{
		private bool? reorderRows;
		private ToolTip tooltip;
		private int? maximumRows;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public bool? ReorderRows
		{
			/// <summary>The method to get the reorderRows</summary>
			/// <returns>bool? representing the reorderRows</returns>
			get
			{
				return  this.reorderRows;

			}
			/// <summary>The method to set the value to reorderRows</summary>
			/// <param name="reorderRows">bool?</param>
			set
			{
				 this.reorderRows=value;

				 this.keyModified["reorder_rows"] = 1;

			}
		}

		public ToolTip Tooltip
		{
			/// <summary>The method to get the tooltip</summary>
			/// <returns>Instance of ToolTip</returns>
			get
			{
				return  this.tooltip;

			}
			/// <summary>The method to set the value to tooltip</summary>
			/// <param name="tooltip">Instance of ToolTip</param>
			set
			{
				 this.tooltip=value;

				 this.keyModified["tooltip"] = 1;

			}
		}

		public int? MaximumRows
		{
			/// <summary>The method to get the maximumRows</summary>
			/// <returns>int? representing the maximumRows</returns>
			get
			{
				return  this.maximumRows;

			}
			/// <summary>The method to set the value to maximumRows</summary>
			/// <param name="maximumRows">int?</param>
			set
			{
				 this.maximumRows=value;

				 this.keyModified["maximum_rows"] = 1;

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
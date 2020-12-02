using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class Crypt : Model
	{
		private string mode;
		private string column;
		private List<string> encfldids;
		private string notify;
		private string table;
		private int? status;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Mode
		{
			/// <summary>The method to get the mode</summary>
			/// <returns>string representing the mode</returns>
			get
			{
				return  this.mode;

			}
			/// <summary>The method to set the value to mode</summary>
			/// <param name="mode">string</param>
			set
			{
				 this.mode=value;

				 this.keyModified["mode"] = 1;

			}
		}

		public string Column
		{
			/// <summary>The method to get the column</summary>
			/// <returns>string representing the column</returns>
			get
			{
				return  this.column;

			}
			/// <summary>The method to set the value to column</summary>
			/// <param name="column">string</param>
			set
			{
				 this.column=value;

				 this.keyModified["column"] = 1;

			}
		}

		public List<string> Encfldids
		{
			/// <summary>The method to get the encfldids</summary>
			/// <returns>Instance of List<String></returns>
			get
			{
				return  this.encfldids;

			}
			/// <summary>The method to set the value to encfldids</summary>
			/// <param name="encfldids">Instance of List<string></param>
			set
			{
				 this.encfldids=value;

				 this.keyModified["encFldIds"] = 1;

			}
		}

		public string Notify
		{
			/// <summary>The method to get the notify</summary>
			/// <returns>string representing the notify</returns>
			get
			{
				return  this.notify;

			}
			/// <summary>The method to set the value to notify</summary>
			/// <param name="notify">string</param>
			set
			{
				 this.notify=value;

				 this.keyModified["notify"] = 1;

			}
		}

		public string Table
		{
			/// <summary>The method to get the table</summary>
			/// <returns>string representing the table</returns>
			get
			{
				return  this.table;

			}
			/// <summary>The method to set the value to table</summary>
			/// <param name="table">string</param>
			set
			{
				 this.table=value;

				 this.keyModified["table"] = 1;

			}
		}

		public int? Status
		{
			/// <summary>The method to get the status</summary>
			/// <returns>int? representing the status</returns>
			get
			{
				return  this.status;

			}
			/// <summary>The method to set the value to status</summary>
			/// <param name="status">int?</param>
			set
			{
				 this.status=value;

				 this.keyModified["status"] = 1;

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
using Com.Zoho.Crm.API.Modules;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.ShareRecords
{

	public class SharedThrough : Model
	{
		private Module module;
		private long? id;
		private string entityName;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public Module Module
		{
			/// <summary>The method to get the module</summary>
			/// <returns>Instance of Module</returns>
			get
			{
				return  this.module;

			}
			/// <summary>The method to set the value to module</summary>
			/// <param name="module">Instance of Module</param>
			set
			{
				 this.module=value;

				 this.keyModified["module"] = 1;

			}
		}

		public long? Id
		{
			/// <summary>The method to get the id</summary>
			/// <returns>long? representing the id</returns>
			get
			{
				return  this.id;

			}
			/// <summary>The method to set the value to id</summary>
			/// <param name="id">long?</param>
			set
			{
				 this.id=value;

				 this.keyModified["id"] = 1;

			}
		}

		public string EntityName
		{
			/// <summary>The method to get the entityName</summary>
			/// <returns>string representing the entityName</returns>
			get
			{
				return  this.entityName;

			}
			/// <summary>The method to set the value to entityName</summary>
			/// <param name="entityName">string</param>
			set
			{
				 this.entityName=value;

				 this.keyModified["entity_name"] = 1;

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
using Com.Zoho.Crm.API.Layouts;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class Module : Model
	{
		private Layout layout;
		private string displayLabel;
		private string apiName;
		private string module;
		private long? id;
		private string moduleName;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public Layout Layout
		{
			/// <summary>The method to get the layout</summary>
			/// <returns>Instance of Layout</returns>
			get
			{
				return  this.layout;

			}
			/// <summary>The method to set the value to layout</summary>
			/// <param name="layout">Instance of Layout</param>
			set
			{
				 this.layout=value;

				 this.keyModified["layout"] = 1;

			}
		}

		public string DisplayLabel
		{
			/// <summary>The method to get the displayLabel</summary>
			/// <returns>string representing the displayLabel</returns>
			get
			{
				return  this.displayLabel;

			}
			/// <summary>The method to set the value to displayLabel</summary>
			/// <param name="displayLabel">string</param>
			set
			{
				 this.displayLabel=value;

				 this.keyModified["display_label"] = 1;

			}
		}

		public string APIName
		{
			/// <summary>The method to get the aPIName</summary>
			/// <returns>string representing the apiName</returns>
			get
			{
				return  this.apiName;

			}
			/// <summary>The method to set the value to aPIName</summary>
			/// <param name="apiName">string</param>
			set
			{
				 this.apiName=value;

				 this.keyModified["api_name"] = 1;

			}
		}

		public string Module_1
		{
			/// <summary>The method to get the module</summary>
			/// <returns>string representing the module</returns>
			get
			{
				return  this.module;

			}
			/// <summary>The method to set the value to module</summary>
			/// <param name="module">string</param>
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

		public string ModuleName
		{
			/// <summary>The method to get the moduleName</summary>
			/// <returns>string representing the moduleName</returns>
			get
			{
				return  this.moduleName;

			}
			/// <summary>The method to set the value to moduleName</summary>
			/// <param name="moduleName">string</param>
			set
			{
				 this.moduleName=value;

				 this.keyModified["module_name"] = 1;

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
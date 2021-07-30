using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BulkWrite
{

	public class FieldMapping : Model
	{
		private string apiName;
		private int? index;
		private string format;
		private string findBy;
		private Dictionary<string, object> defaultValue;
		private string module;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

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

		public int? Index
		{
			/// <summary>The method to get the index</summary>
			/// <returns>int? representing the index</returns>
			get
			{
				return  this.index;

			}
			/// <summary>The method to set the value to index</summary>
			/// <param name="index">int?</param>
			set
			{
				 this.index=value;

				 this.keyModified["index"] = 1;

			}
		}

		public string Format
		{
			/// <summary>The method to get the format</summary>
			/// <returns>string representing the format</returns>
			get
			{
				return  this.format;

			}
			/// <summary>The method to set the value to format</summary>
			/// <param name="format">string</param>
			set
			{
				 this.format=value;

				 this.keyModified["format"] = 1;

			}
		}

		public string FindBy
		{
			/// <summary>The method to get the findBy</summary>
			/// <returns>string representing the findBy</returns>
			get
			{
				return  this.findBy;

			}
			/// <summary>The method to set the value to findBy</summary>
			/// <param name="findBy">string</param>
			set
			{
				 this.findBy=value;

				 this.keyModified["find_by"] = 1;

			}
		}

		public Dictionary<string, object> DefaultValue
		{
			/// <summary>The method to get the defaultValue</summary>
			/// <returns>Dictionary representing the defaultValue<String,Object></returns>
			get
			{
				return  this.defaultValue;

			}
			/// <summary>The method to set the value to defaultValue</summary>
			/// <param name="defaultValue">Dictionary<string,object></param>
			set
			{
				 this.defaultValue=value;

				 this.keyModified["default_value"] = 1;

			}
		}

		public string Module
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
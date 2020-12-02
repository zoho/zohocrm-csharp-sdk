using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BulkWrite
{

	public class Resource : Model
	{
		private Choice<string> status;
		private Choice<string> type;
		private string module;
		private string fileId;
		private bool? ignoreEmpty;
		private string findBy;
		private List<FieldMapping> fieldMappings;
		private File file;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public Choice<string> Status
		{
			/// <summary>The method to get the status</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.status;

			}
			/// <summary>The method to set the value to status</summary>
			/// <param name="status">Instance of Choice<string></param>
			set
			{
				 this.status=value;

				 this.keyModified["status"] = 1;

			}
		}

		public Choice<string> Type
		{
			/// <summary>The method to get the type</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.type;

			}
			/// <summary>The method to set the value to type</summary>
			/// <param name="type">Instance of Choice<string></param>
			set
			{
				 this.type=value;

				 this.keyModified["type"] = 1;

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

		public string FileId
		{
			/// <summary>The method to get the fileId</summary>
			/// <returns>string representing the fileId</returns>
			get
			{
				return  this.fileId;

			}
			/// <summary>The method to set the value to fileId</summary>
			/// <param name="fileId">string</param>
			set
			{
				 this.fileId=value;

				 this.keyModified["file_id"] = 1;

			}
		}

		public bool? IgnoreEmpty
		{
			/// <summary>The method to get the ignoreEmpty</summary>
			/// <returns>bool? representing the ignoreEmpty</returns>
			get
			{
				return  this.ignoreEmpty;

			}
			/// <summary>The method to set the value to ignoreEmpty</summary>
			/// <param name="ignoreEmpty">bool?</param>
			set
			{
				 this.ignoreEmpty=value;

				 this.keyModified["ignore_empty"] = 1;

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

		public List<FieldMapping> FieldMappings
		{
			/// <summary>The method to get the fieldMappings</summary>
			/// <returns>Instance of List<FieldMapping></returns>
			get
			{
				return  this.fieldMappings;

			}
			/// <summary>The method to set the value to fieldMappings</summary>
			/// <param name="fieldMappings">Instance of List<FieldMapping></param>
			set
			{
				 this.fieldMappings=value;

				 this.keyModified["field_mappings"] = 1;

			}
		}

		public File File
		{
			/// <summary>The method to get the file</summary>
			/// <returns>FileInfo representing the file</returns>
			get
			{
				return  this.file;

			}
			/// <summary>The method to set the value to file</summary>
			/// <param name="file">FileInfo</param>
			set
			{
				 this.file=value;

				 this.keyModified["file"] = 1;

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
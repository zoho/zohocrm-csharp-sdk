using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Attachments
{

	public class Attachment : Model
	{
		private User owner;
		private DateTimeOffset? modifiedTime;
		private string fileName;
		private DateTimeOffset? createdTime;
		private long? size;
		private Record.Record parentId;
		private bool? editable;
		private string fileId;
		private string type;
		private string seModule;
		private User modifiedBy;
		private string state;
		private long? id;
		private User createdBy;
		private string linkUrl;
		private string description;
		private string category;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public User Owner
		{
			/// <summary>The method to get the owner</summary>
			/// <returns>Instance of User</returns>
			get
			{
				return  this.owner;

			}
			/// <summary>The method to set the value to owner</summary>
			/// <param name="owner">Instance of User</param>
			set
			{
				 this.owner=value;

				 this.keyModified["Owner"] = 1;

			}
		}

		public DateTimeOffset? ModifiedTime
		{
			/// <summary>The method to get the modifiedTime</summary>
			/// <returns>DateTimeOffset? representing the modifiedTime</returns>
			get
			{
				return  this.modifiedTime;

			}
			/// <summary>The method to set the value to modifiedTime</summary>
			/// <param name="modifiedTime">DateTimeOffset?</param>
			set
			{
				 this.modifiedTime=value;

				 this.keyModified["Modified_Time"] = 1;

			}
		}

		public string FileName
		{
			/// <summary>The method to get the fileName</summary>
			/// <returns>string representing the fileName</returns>
			get
			{
				return  this.fileName;

			}
			/// <summary>The method to set the value to fileName</summary>
			/// <param name="fileName">string</param>
			set
			{
				 this.fileName=value;

				 this.keyModified["File_Name"] = 1;

			}
		}

		public DateTimeOffset? CreatedTime
		{
			/// <summary>The method to get the createdTime</summary>
			/// <returns>DateTimeOffset? representing the createdTime</returns>
			get
			{
				return  this.createdTime;

			}
			/// <summary>The method to set the value to createdTime</summary>
			/// <param name="createdTime">DateTimeOffset?</param>
			set
			{
				 this.createdTime=value;

				 this.keyModified["Created_Time"] = 1;

			}
		}

		public long? Size
		{
			/// <summary>The method to get the size</summary>
			/// <returns>long? representing the size</returns>
			get
			{
				return  this.size;

			}
			/// <summary>The method to set the value to size</summary>
			/// <param name="size">long?</param>
			set
			{
				 this.size=value;

				 this.keyModified["Size"] = 1;

			}
		}

		public Record.Record ParentId
		{
			/// <summary>The method to get the parentId</summary>
			/// <returns>Instance of Record</returns>
			get
			{
				return  this.parentId;

			}
			/// <summary>The method to set the value to parentId</summary>
			/// <param name="parentId">Instance of Record</param>
			set
			{
				 this.parentId=value;

				 this.keyModified["Parent_Id"] = 1;

			}
		}

		public bool? Editable
		{
			/// <summary>The method to get the editable</summary>
			/// <returns>bool? representing the editable</returns>
			get
			{
				return  this.editable;

			}
			/// <summary>The method to set the value to editable</summary>
			/// <param name="editable">bool?</param>
			set
			{
				 this.editable=value;

				 this.keyModified["$editable"] = 1;

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

				 this.keyModified["$file_id"] = 1;

			}
		}

		public string Type
		{
			/// <summary>The method to get the type</summary>
			/// <returns>string representing the type</returns>
			get
			{
				return  this.type;

			}
			/// <summary>The method to set the value to type</summary>
			/// <param name="type">string</param>
			set
			{
				 this.type=value;

				 this.keyModified["$type"] = 1;

			}
		}

		public string SeModule
		{
			/// <summary>The method to get the seModule</summary>
			/// <returns>string representing the seModule</returns>
			get
			{
				return  this.seModule;

			}
			/// <summary>The method to set the value to seModule</summary>
			/// <param name="seModule">string</param>
			set
			{
				 this.seModule=value;

				 this.keyModified["$se_module"] = 1;

			}
		}

		public User ModifiedBy
		{
			/// <summary>The method to get the modifiedBy</summary>
			/// <returns>Instance of User</returns>
			get
			{
				return  this.modifiedBy;

			}
			/// <summary>The method to set the value to modifiedBy</summary>
			/// <param name="modifiedBy">Instance of User</param>
			set
			{
				 this.modifiedBy=value;

				 this.keyModified["Modified_By"] = 1;

			}
		}

		public string State
		{
			/// <summary>The method to get the state</summary>
			/// <returns>string representing the state</returns>
			get
			{
				return  this.state;

			}
			/// <summary>The method to set the value to state</summary>
			/// <param name="state">string</param>
			set
			{
				 this.state=value;

				 this.keyModified["$state"] = 1;

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

		public User CreatedBy
		{
			/// <summary>The method to get the createdBy</summary>
			/// <returns>Instance of User</returns>
			get
			{
				return  this.createdBy;

			}
			/// <summary>The method to set the value to createdBy</summary>
			/// <param name="createdBy">Instance of User</param>
			set
			{
				 this.createdBy=value;

				 this.keyModified["Created_By"] = 1;

			}
		}

		public string LinkUrl
		{
			/// <summary>The method to get the linkUrl</summary>
			/// <returns>string representing the linkUrl</returns>
			get
			{
				return  this.linkUrl;

			}
			/// <summary>The method to set the value to linkUrl</summary>
			/// <param name="linkUrl">string</param>
			set
			{
				 this.linkUrl=value;

				 this.keyModified["$link_url"] = 1;

			}
		}

		public string Description
		{
			/// <summary>The method to get the description</summary>
			/// <returns>string representing the description</returns>
			get
			{
				return  this.description;

			}
			/// <summary>The method to set the value to description</summary>
			/// <param name="description">string</param>
			set
			{
				 this.description=value;

				 this.keyModified["description"] = 1;

			}
		}

		public string Category
		{
			/// <summary>The method to get the category</summary>
			/// <returns>string representing the category</returns>
			get
			{
				return  this.category;

			}
			/// <summary>The method to set the value to category</summary>
			/// <param name="category">string</param>
			set
			{
				 this.category=value;

				 this.keyModified["category"] = 1;

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
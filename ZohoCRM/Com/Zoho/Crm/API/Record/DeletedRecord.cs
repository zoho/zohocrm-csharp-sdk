using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class DeletedRecord : Model
	{
		private User deletedBy;
		private long? id;
		private string displayName;
		private string type;
		private User createdBy;
		private DateTimeOffset? deletedTime;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public User DeletedBy
		{
			/// <summary>The method to get the deletedBy</summary>
			/// <returns>Instance of User</returns>
			get
			{
				return  this.deletedBy;

			}
			/// <summary>The method to set the value to deletedBy</summary>
			/// <param name="deletedBy">Instance of User</param>
			set
			{
				 this.deletedBy=value;

				 this.keyModified["deleted_by"] = 1;

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

		public string DisplayName
		{
			/// <summary>The method to get the displayName</summary>
			/// <returns>string representing the displayName</returns>
			get
			{
				return  this.displayName;

			}
			/// <summary>The method to set the value to displayName</summary>
			/// <param name="displayName">string</param>
			set
			{
				 this.displayName=value;

				 this.keyModified["display_name"] = 1;

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

				 this.keyModified["type"] = 1;

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

				 this.keyModified["created_by"] = 1;

			}
		}

		public DateTimeOffset? DeletedTime
		{
			/// <summary>The method to get the deletedTime</summary>
			/// <returns>DateTimeOffset? representing the deletedTime</returns>
			get
			{
				return  this.deletedTime;

			}
			/// <summary>The method to set the value to deletedTime</summary>
			/// <param name="deletedTime">DateTimeOffset?</param>
			set
			{
				 this.deletedTime=value;

				 this.keyModified["deleted_time"] = 1;

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
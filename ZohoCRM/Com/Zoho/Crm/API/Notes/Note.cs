using Com.Zoho.Crm.API.Attachments;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Notes
{

	public class Note : Model
	{
		private User owner;
		private DateTimeOffset? modifiedTime;
		private List<Attachment> attachments;
		private DateTimeOffset? createdTime;
		private Record.Record parentId;
		private bool? editable;
		private string seModule;
		private bool? isSharedToClient;
		private User modifiedBy;
		private string size;
		private string state;
		private bool? voiceNote;
		private long? id;
		private User createdBy;
		private string noteTitle;
		private string noteContent;
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

		public List<Attachment> Attachments
		{
			/// <summary>The method to get the attachments</summary>
			/// <returns>Instance of List<Attachment></returns>
			get
			{
				return  this.attachments;

			}
			/// <summary>The method to set the value to attachments</summary>
			/// <param name="attachments">Instance of List<Attachment></param>
			set
			{
				 this.attachments=value;

				 this.keyModified["$attachments"] = 1;

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

		public bool? IsSharedToClient
		{
			/// <summary>The method to get the isSharedToClient</summary>
			/// <returns>bool? representing the isSharedToClient</returns>
			get
			{
				return  this.isSharedToClient;

			}
			/// <summary>The method to set the value to isSharedToClient</summary>
			/// <param name="isSharedToClient">bool?</param>
			set
			{
				 this.isSharedToClient=value;

				 this.keyModified["$is_shared_to_client"] = 1;

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

		public string Size
		{
			/// <summary>The method to get the size</summary>
			/// <returns>string representing the size</returns>
			get
			{
				return  this.size;

			}
			/// <summary>The method to set the value to size</summary>
			/// <param name="size">string</param>
			set
			{
				 this.size=value;

				 this.keyModified["$size"] = 1;

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

		public bool? VoiceNote
		{
			/// <summary>The method to get the voiceNote</summary>
			/// <returns>bool? representing the voiceNote</returns>
			get
			{
				return  this.voiceNote;

			}
			/// <summary>The method to set the value to voiceNote</summary>
			/// <param name="voiceNote">bool?</param>
			set
			{
				 this.voiceNote=value;

				 this.keyModified["$voice_note"] = 1;

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

		public string NoteTitle
		{
			/// <summary>The method to get the noteTitle</summary>
			/// <returns>string representing the noteTitle</returns>
			get
			{
				return  this.noteTitle;

			}
			/// <summary>The method to set the value to noteTitle</summary>
			/// <param name="noteTitle">string</param>
			set
			{
				 this.noteTitle=value;

				 this.keyModified["Note_Title"] = 1;

			}
		}

		public string NoteContent
		{
			/// <summary>The method to get the noteContent</summary>
			/// <returns>string representing the noteContent</returns>
			get
			{
				return  this.noteContent;

			}
			/// <summary>The method to set the value to noteContent</summary>
			/// <param name="noteContent">string</param>
			set
			{
				 this.noteContent=value;

				 this.keyModified["Note_Content"] = 1;

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
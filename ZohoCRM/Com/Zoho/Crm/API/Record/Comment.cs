using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class Comment : Model
	{
		private string commentedBy;
		private DateTimeOffset? commentedTime;
		private string commentContent;
		private long? id;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string CommentedBy
		{
			/// <summary>The method to get the commentedBy</summary>
			/// <returns>string representing the commentedBy</returns>
			get
			{
				return  this.commentedBy;

			}
			/// <summary>The method to set the value to commentedBy</summary>
			/// <param name="commentedBy">string</param>
			set
			{
				 this.commentedBy=value;

				 this.keyModified["commented_by"] = 1;

			}
		}

		public DateTimeOffset? CommentedTime
		{
			/// <summary>The method to get the commentedTime</summary>
			/// <returns>DateTimeOffset? representing the commentedTime</returns>
			get
			{
				return  this.commentedTime;

			}
			/// <summary>The method to set the value to commentedTime</summary>
			/// <param name="commentedTime">DateTimeOffset?</param>
			set
			{
				 this.commentedTime=value;

				 this.keyModified["commented_time"] = 1;

			}
		}

		public string CommentContent
		{
			/// <summary>The method to get the commentContent</summary>
			/// <returns>string representing the commentContent</returns>
			get
			{
				return  this.commentContent;

			}
			/// <summary>The method to set the value to commentContent</summary>
			/// <param name="commentContent">string</param>
			set
			{
				 this.commentContent=value;

				 this.keyModified["comment_content"] = 1;

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
using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.ShareRecords
{

	public class ResponseWrapper : Model, ResponseHandler
	{
		private List<ShareRecord> share;
		private List<User> shareableUser;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<ShareRecord> Share
		{
			/// <summary>The method to get the share</summary>
			/// <returns>Instance of List<ShareRecord></returns>
			get
			{
				return  this.share;

			}
			/// <summary>The method to set the value to share</summary>
			/// <param name="share">Instance of List<ShareRecord></param>
			set
			{
				 this.share=value;

				 this.keyModified["share"] = 1;

			}
		}

		public List<User> ShareableUser
		{
			/// <summary>The method to get the shareableUser</summary>
			/// <returns>Instance of List<User></returns>
			get
			{
				return  this.shareableUser;

			}
			/// <summary>The method to set the value to shareableUser</summary>
			/// <param name="shareableUser">Instance of List<User></param>
			set
			{
				 this.shareableUser=value;

				 this.keyModified["shareable_user"] = 1;

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
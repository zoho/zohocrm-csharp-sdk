using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.ShareRecords
{

	public class DeleteActionWrapper : Model, DeleteActionHandler
	{
		private DeleteActionResponse share;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public DeleteActionResponse Share
		{
			/// <summary>The method to get the share</summary>
			/// <returns>Instance of DeleteActionResponse</returns>
			get
			{
				return  this.share;

			}
			/// <summary>The method to set the value to share</summary>
			/// <param name="share">Instance of DeleteActionResponse</param>
			set
			{
				 this.share=value;

				 this.keyModified["share"] = 1;

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
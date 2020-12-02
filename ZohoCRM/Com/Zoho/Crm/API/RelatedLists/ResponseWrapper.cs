using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.RelatedLists
{

	public class ResponseWrapper : Model, ResponseHandler
	{
		private List<RelatedList> relatedLists;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<RelatedList> RelatedLists
		{
			/// <summary>The method to get the relatedLists</summary>
			/// <returns>Instance of List<RelatedList></returns>
			get
			{
				return  this.relatedLists;

			}
			/// <summary>The method to set the value to relatedLists</summary>
			/// <param name="relatedLists">Instance of List<RelatedList></param>
			set
			{
				 this.relatedLists=value;

				 this.keyModified["related_lists"] = 1;

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
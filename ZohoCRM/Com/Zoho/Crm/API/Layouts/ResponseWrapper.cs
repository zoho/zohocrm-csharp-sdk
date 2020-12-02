using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Layouts
{

	public class ResponseWrapper : Model, ResponseHandler
	{
		private List<Layout> layouts;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<Layout> Layouts
		{
			/// <summary>The method to get the layouts</summary>
			/// <returns>Instance of List<Layout></returns>
			get
			{
				return  this.layouts;

			}
			/// <summary>The method to set the value to layouts</summary>
			/// <param name="layouts">Instance of List<Layout></param>
			set
			{
				 this.layouts=value;

				 this.keyModified["layouts"] = 1;

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
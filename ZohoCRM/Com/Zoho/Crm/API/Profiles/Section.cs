using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Profiles
{

	public class Section : Model
	{
		private string name;
		private List<Category> categories;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Name
		{
			/// <summary>The method to get the name</summary>
			/// <returns>string representing the name</returns>
			get
			{
				return  this.name;

			}
			/// <summary>The method to set the value to name</summary>
			/// <param name="name">string</param>
			set
			{
				 this.name=value;

				 this.keyModified["name"] = 1;

			}
		}

		public List<Category> Categories
		{
			/// <summary>The method to get the categories</summary>
			/// <returns>Instance of List<Category></returns>
			get
			{
				return  this.categories;

			}
			/// <summary>The method to set the value to categories</summary>
			/// <param name="categories">Instance of List<Category></param>
			set
			{
				 this.categories=value;

				 this.keyModified["categories"] = 1;

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
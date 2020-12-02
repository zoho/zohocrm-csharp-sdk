using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.CustomViews
{

	public class Info : Model
	{
		private int? perPage;
		private string default1;
		private int? count;
		private int? page;
		private bool? moreRecords;
		private Translation translation;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public int? PerPage
		{
			/// <summary>The method to get the perPage</summary>
			/// <returns>int? representing the perPage</returns>
			get
			{
				return  this.perPage;

			}
			/// <summary>The method to set the value to perPage</summary>
			/// <param name="perPage">int?</param>
			set
			{
				 this.perPage=value;

				 this.keyModified["per_page"] = 1;

			}
		}

		public string Default
		{
			/// <summary>The method to get the default</summary>
			/// <returns>string representing the default1</returns>
			get
			{
				return  this.default1;

			}
			/// <summary>The method to set the value to default</summary>
			/// <param name="default1">string</param>
			set
			{
				 this.default1=value;

				 this.keyModified["default"] = 1;

			}
		}

		public int? Count
		{
			/// <summary>The method to get the count</summary>
			/// <returns>int? representing the count</returns>
			get
			{
				return  this.count;

			}
			/// <summary>The method to set the value to count</summary>
			/// <param name="count">int?</param>
			set
			{
				 this.count=value;

				 this.keyModified["count"] = 1;

			}
		}

		public int? Page
		{
			/// <summary>The method to get the page</summary>
			/// <returns>int? representing the page</returns>
			get
			{
				return  this.page;

			}
			/// <summary>The method to set the value to page</summary>
			/// <param name="page">int?</param>
			set
			{
				 this.page=value;

				 this.keyModified["page"] = 1;

			}
		}

		public bool? MoreRecords
		{
			/// <summary>The method to get the moreRecords</summary>
			/// <returns>bool? representing the moreRecords</returns>
			get
			{
				return  this.moreRecords;

			}
			/// <summary>The method to set the value to moreRecords</summary>
			/// <param name="moreRecords">bool?</param>
			set
			{
				 this.moreRecords=value;

				 this.keyModified["more_records"] = 1;

			}
		}

		public Translation Translation
		{
			/// <summary>The method to get the translation</summary>
			/// <returns>Instance of Translation</returns>
			get
			{
				return  this.translation;

			}
			/// <summary>The method to set the value to translation</summary>
			/// <param name="translation">Instance of Translation</param>
			set
			{
				 this.translation=value;

				 this.keyModified["translation"] = 1;

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
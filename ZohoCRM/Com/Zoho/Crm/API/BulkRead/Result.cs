using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BulkRead
{

	public class Result : Model
	{
		private int? page;
		private int? count;
		private string downloadUrl;
		private int? perPage;
		private bool? moreRecords;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

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

		public string DownloadUrl
		{
			/// <summary>The method to get the downloadUrl</summary>
			/// <returns>string representing the downloadUrl</returns>
			get
			{
				return  this.downloadUrl;

			}
			/// <summary>The method to set the value to downloadUrl</summary>
			/// <param name="downloadUrl">string</param>
			set
			{
				 this.downloadUrl=value;

				 this.keyModified["download_url"] = 1;

			}
		}

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
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class MassUpdateBodyWrapper : Model
	{
		private List<Record> data;
		private string cvid;
		private List<long?> ids;
		private Territory territory;
		private bool? overWrite;
		private List<Criteria> criteria;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<Record> Data
		{
			/// <summary>The method to get the data</summary>
			/// <returns>Instance of List<Record></returns>
			get
			{
				return  this.data;

			}
			/// <summary>The method to set the value to data</summary>
			/// <param name="data">Instance of List<Record></param>
			set
			{
				 this.data=value;

				 this.keyModified["data"] = 1;

			}
		}

		public string Cvid
		{
			/// <summary>The method to get the cvid</summary>
			/// <returns>string representing the cvid</returns>
			get
			{
				return  this.cvid;

			}
			/// <summary>The method to set the value to cvid</summary>
			/// <param name="cvid">string</param>
			set
			{
				 this.cvid=value;

				 this.keyModified["cvid"] = 1;

			}
		}

		public List<long?> Ids
		{
			/// <summary>The method to get the ids</summary>
			/// <returns>Instance of List<Long></returns>
			get
			{
				return  this.ids;

			}
			/// <summary>The method to set the value to ids</summary>
			/// <param name="ids">Instance of List<long?></param>
			set
			{
				 this.ids=value;

				 this.keyModified["ids"] = 1;

			}
		}

		public Territory Territory
		{
			/// <summary>The method to get the territory</summary>
			/// <returns>Instance of Territory</returns>
			get
			{
				return  this.territory;

			}
			/// <summary>The method to set the value to territory</summary>
			/// <param name="territory">Instance of Territory</param>
			set
			{
				 this.territory=value;

				 this.keyModified["territory"] = 1;

			}
		}

		public bool? OverWrite
		{
			/// <summary>The method to get the overWrite</summary>
			/// <returns>bool? representing the overWrite</returns>
			get
			{
				return  this.overWrite;

			}
			/// <summary>The method to set the value to overWrite</summary>
			/// <param name="overWrite">bool?</param>
			set
			{
				 this.overWrite=value;

				 this.keyModified["over_write"] = 1;

			}
		}

		public List<Criteria> Criteria
		{
			/// <summary>The method to get the criteria</summary>
			/// <returns>Instance of List<Criteria></returns>
			get
			{
				return  this.criteria;

			}
			/// <summary>The method to set the value to criteria</summary>
			/// <param name="criteria">Instance of List<Criteria></param>
			set
			{
				 this.criteria=value;

				 this.keyModified["criteria"] = 1;

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
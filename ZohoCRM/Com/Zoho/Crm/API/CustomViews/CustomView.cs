using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.CustomViews
{

	public class CustomView : Model
	{
		private long? id;
		private string name;
		private string systemName;
		private string displayValue;
		private string sharedType;
		private string category;
		private string sortBy;
		private string sortOrder;
		private int? favorite;
		private bool? offline;
		private bool? default1;
		private bool? systemDefined;
		private Criteria criteria;
		private List<SharedDetails> sharedDetails;
		private List<string> fields;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

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

		public string SystemName
		{
			/// <summary>The method to get the systemName</summary>
			/// <returns>string representing the systemName</returns>
			get
			{
				return  this.systemName;

			}
			/// <summary>The method to set the value to systemName</summary>
			/// <param name="systemName">string</param>
			set
			{
				 this.systemName=value;

				 this.keyModified["system_name"] = 1;

			}
		}

		public string DisplayValue
		{
			/// <summary>The method to get the displayValue</summary>
			/// <returns>string representing the displayValue</returns>
			get
			{
				return  this.displayValue;

			}
			/// <summary>The method to set the value to displayValue</summary>
			/// <param name="displayValue">string</param>
			set
			{
				 this.displayValue=value;

				 this.keyModified["display_value"] = 1;

			}
		}

		public string SharedType
		{
			/// <summary>The method to get the sharedType</summary>
			/// <returns>string representing the sharedType</returns>
			get
			{
				return  this.sharedType;

			}
			/// <summary>The method to set the value to sharedType</summary>
			/// <param name="sharedType">string</param>
			set
			{
				 this.sharedType=value;

				 this.keyModified["shared_type"] = 1;

			}
		}

		public string Category
		{
			/// <summary>The method to get the category</summary>
			/// <returns>string representing the category</returns>
			get
			{
				return  this.category;

			}
			/// <summary>The method to set the value to category</summary>
			/// <param name="category">string</param>
			set
			{
				 this.category=value;

				 this.keyModified["category"] = 1;

			}
		}

		public string SortBy
		{
			/// <summary>The method to get the sortBy</summary>
			/// <returns>string representing the sortBy</returns>
			get
			{
				return  this.sortBy;

			}
			/// <summary>The method to set the value to sortBy</summary>
			/// <param name="sortBy">string</param>
			set
			{
				 this.sortBy=value;

				 this.keyModified["sort_by"] = 1;

			}
		}

		public string SortOrder
		{
			/// <summary>The method to get the sortOrder</summary>
			/// <returns>string representing the sortOrder</returns>
			get
			{
				return  this.sortOrder;

			}
			/// <summary>The method to set the value to sortOrder</summary>
			/// <param name="sortOrder">string</param>
			set
			{
				 this.sortOrder=value;

				 this.keyModified["sort_order"] = 1;

			}
		}

		public int? Favorite
		{
			/// <summary>The method to get the favorite</summary>
			/// <returns>int? representing the favorite</returns>
			get
			{
				return  this.favorite;

			}
			/// <summary>The method to set the value to favorite</summary>
			/// <param name="favorite">int?</param>
			set
			{
				 this.favorite=value;

				 this.keyModified["favorite"] = 1;

			}
		}

		public bool? Offline
		{
			/// <summary>The method to get the offline</summary>
			/// <returns>bool? representing the offline</returns>
			get
			{
				return  this.offline;

			}
			/// <summary>The method to set the value to offline</summary>
			/// <param name="offline">bool?</param>
			set
			{
				 this.offline=value;

				 this.keyModified["offline"] = 1;

			}
		}

		public bool? Default
		{
			/// <summary>The method to get the default</summary>
			/// <returns>bool? representing the default1</returns>
			get
			{
				return  this.default1;

			}
			/// <summary>The method to set the value to default</summary>
			/// <param name="default1">bool?</param>
			set
			{
				 this.default1=value;

				 this.keyModified["default"] = 1;

			}
		}

		public bool? SystemDefined
		{
			/// <summary>The method to get the systemDefined</summary>
			/// <returns>bool? representing the systemDefined</returns>
			get
			{
				return  this.systemDefined;

			}
			/// <summary>The method to set the value to systemDefined</summary>
			/// <param name="systemDefined">bool?</param>
			set
			{
				 this.systemDefined=value;

				 this.keyModified["system_defined"] = 1;

			}
		}

		public Criteria Criteria
		{
			/// <summary>The method to get the criteria</summary>
			/// <returns>Instance of Criteria</returns>
			get
			{
				return  this.criteria;

			}
			/// <summary>The method to set the value to criteria</summary>
			/// <param name="criteria">Instance of Criteria</param>
			set
			{
				 this.criteria=value;

				 this.keyModified["criteria"] = 1;

			}
		}

		public List<SharedDetails> SharedDetails
		{
			/// <summary>The method to get the sharedDetails</summary>
			/// <returns>Instance of List<SharedDetails></returns>
			get
			{
				return  this.sharedDetails;

			}
			/// <summary>The method to set the value to sharedDetails</summary>
			/// <param name="sharedDetails">Instance of List<SharedDetails></param>
			set
			{
				 this.sharedDetails=value;

				 this.keyModified["shared_details"] = 1;

			}
		}

		public List<string> Fields
		{
			/// <summary>The method to get the fields</summary>
			/// <returns>Instance of List<String></returns>
			get
			{
				return  this.fields;

			}
			/// <summary>The method to set the value to fields</summary>
			/// <param name="fields">Instance of List<string></param>
			set
			{
				 this.fields=value;

				 this.keyModified["fields"] = 1;

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
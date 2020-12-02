using Com.Zoho.Crm.API.Fields;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Layouts
{

	public class Section : Model
	{
		private string displayLabel;
		private int? sequenceNumber;
		private bool? issubformsection;
		private int? tabTraversal;
		private string apiName;
		private int? columnCount;
		private string name;
		private string generatedType;
		private List<Field> fields;
		private Properties properties;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string DisplayLabel
		{
			/// <summary>The method to get the displayLabel</summary>
			/// <returns>string representing the displayLabel</returns>
			get
			{
				return  this.displayLabel;

			}
			/// <summary>The method to set the value to displayLabel</summary>
			/// <param name="displayLabel">string</param>
			set
			{
				 this.displayLabel=value;

				 this.keyModified["display_label"] = 1;

			}
		}

		public int? SequenceNumber
		{
			/// <summary>The method to get the sequenceNumber</summary>
			/// <returns>int? representing the sequenceNumber</returns>
			get
			{
				return  this.sequenceNumber;

			}
			/// <summary>The method to set the value to sequenceNumber</summary>
			/// <param name="sequenceNumber">int?</param>
			set
			{
				 this.sequenceNumber=value;

				 this.keyModified["sequence_number"] = 1;

			}
		}

		public bool? Issubformsection
		{
			/// <summary>The method to get the issubformsection</summary>
			/// <returns>bool? representing the issubformsection</returns>
			get
			{
				return  this.issubformsection;

			}
			/// <summary>The method to set the value to issubformsection</summary>
			/// <param name="issubformsection">bool?</param>
			set
			{
				 this.issubformsection=value;

				 this.keyModified["isSubformSection"] = 1;

			}
		}

		public int? TabTraversal
		{
			/// <summary>The method to get the tabTraversal</summary>
			/// <returns>int? representing the tabTraversal</returns>
			get
			{
				return  this.tabTraversal;

			}
			/// <summary>The method to set the value to tabTraversal</summary>
			/// <param name="tabTraversal">int?</param>
			set
			{
				 this.tabTraversal=value;

				 this.keyModified["tab_traversal"] = 1;

			}
		}

		public string APIName
		{
			/// <summary>The method to get the aPIName</summary>
			/// <returns>string representing the apiName</returns>
			get
			{
				return  this.apiName;

			}
			/// <summary>The method to set the value to aPIName</summary>
			/// <param name="apiName">string</param>
			set
			{
				 this.apiName=value;

				 this.keyModified["api_name"] = 1;

			}
		}

		public int? ColumnCount
		{
			/// <summary>The method to get the columnCount</summary>
			/// <returns>int? representing the columnCount</returns>
			get
			{
				return  this.columnCount;

			}
			/// <summary>The method to set the value to columnCount</summary>
			/// <param name="columnCount">int?</param>
			set
			{
				 this.columnCount=value;

				 this.keyModified["column_count"] = 1;

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

		public string GeneratedType
		{
			/// <summary>The method to get the generatedType</summary>
			/// <returns>string representing the generatedType</returns>
			get
			{
				return  this.generatedType;

			}
			/// <summary>The method to set the value to generatedType</summary>
			/// <param name="generatedType">string</param>
			set
			{
				 this.generatedType=value;

				 this.keyModified["generated_type"] = 1;

			}
		}

		public List<Field> Fields
		{
			/// <summary>The method to get the fields</summary>
			/// <returns>Instance of List<Field></returns>
			get
			{
				return  this.fields;

			}
			/// <summary>The method to set the value to fields</summary>
			/// <param name="fields">Instance of List<Field></param>
			set
			{
				 this.fields=value;

				 this.keyModified["fields"] = 1;

			}
		}

		public Properties Properties
		{
			/// <summary>The method to get the properties</summary>
			/// <returns>Instance of Properties</returns>
			get
			{
				return  this.properties;

			}
			/// <summary>The method to set the value to properties</summary>
			/// <param name="properties">Instance of Properties</param>
			set
			{
				 this.properties=value;

				 this.keyModified["properties"] = 1;

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
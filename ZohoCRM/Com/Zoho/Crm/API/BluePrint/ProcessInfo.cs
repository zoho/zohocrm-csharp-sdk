using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BluePrint
{

	public class ProcessInfo : Model
	{
		private string fieldId;
		private bool? isContinuous;
		private string apiName;
		private bool? continuous;
		private string fieldLabel;
		private string name;
		private string columnName;
		private string fieldValue;
		private long? id;
		private string fieldName;
		private string escalation;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string FieldId
		{
			/// <summary>The method to get the fieldId</summary>
			/// <returns>string representing the fieldId</returns>
			get
			{
				return  this.fieldId;

			}
			/// <summary>The method to set the value to fieldId</summary>
			/// <param name="fieldId">string</param>
			set
			{
				 this.fieldId=value;

				 this.keyModified["field_id"] = 1;

			}
		}

		public bool? IsContinuous
		{
			/// <summary>The method to get the isContinuous</summary>
			/// <returns>bool? representing the isContinuous</returns>
			get
			{
				return  this.isContinuous;

			}
			/// <summary>The method to set the value to isContinuous</summary>
			/// <param name="isContinuous">bool?</param>
			set
			{
				 this.isContinuous=value;

				 this.keyModified["is_continuous"] = 1;

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

		public bool? Continuous
		{
			/// <summary>The method to get the continuous</summary>
			/// <returns>bool? representing the continuous</returns>
			get
			{
				return  this.continuous;

			}
			/// <summary>The method to set the value to continuous</summary>
			/// <param name="continuous">bool?</param>
			set
			{
				 this.continuous=value;

				 this.keyModified["continuous"] = 1;

			}
		}

		public string FieldLabel
		{
			/// <summary>The method to get the fieldLabel</summary>
			/// <returns>string representing the fieldLabel</returns>
			get
			{
				return  this.fieldLabel;

			}
			/// <summary>The method to set the value to fieldLabel</summary>
			/// <param name="fieldLabel">string</param>
			set
			{
				 this.fieldLabel=value;

				 this.keyModified["field_label"] = 1;

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

		public string ColumnName
		{
			/// <summary>The method to get the columnName</summary>
			/// <returns>string representing the columnName</returns>
			get
			{
				return  this.columnName;

			}
			/// <summary>The method to set the value to columnName</summary>
			/// <param name="columnName">string</param>
			set
			{
				 this.columnName=value;

				 this.keyModified["column_name"] = 1;

			}
		}

		public string FieldValue
		{
			/// <summary>The method to get the fieldValue</summary>
			/// <returns>string representing the fieldValue</returns>
			get
			{
				return  this.fieldValue;

			}
			/// <summary>The method to set the value to fieldValue</summary>
			/// <param name="fieldValue">string</param>
			set
			{
				 this.fieldValue=value;

				 this.keyModified["field_value"] = 1;

			}
		}

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

		public string FieldName
		{
			/// <summary>The method to get the fieldName</summary>
			/// <returns>string representing the fieldName</returns>
			get
			{
				return  this.fieldName;

			}
			/// <summary>The method to set the value to fieldName</summary>
			/// <param name="fieldName">string</param>
			set
			{
				 this.fieldName=value;

				 this.keyModified["field_name"] = 1;

			}
		}

		public string Escalation
		{
			/// <summary>The method to get the escalation</summary>
			/// <returns>string representing the escalation</returns>
			get
			{
				return  this.escalation;

			}
			/// <summary>The method to set the value to escalation</summary>
			/// <param name="escalation">string</param>
			set
			{
				 this.escalation=value;

				 this.keyModified["escalation"] = 1;

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
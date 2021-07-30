using Com.Zoho.Crm.API.Fields;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BluePrint
{

	public class Transition : Model
	{
		private List<NextTransition> nextTransitions;
		private double? percentPartialSave;
		private Record.Record data;
		private string nextFieldValue;
		private string name;
		private bool? criteriaMatched;
		private long? id;
		private List<Field> fields;
		private string criteriaMessage;
		private string type;
		private DateTimeOffset? executionTime;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<NextTransition> NextTransitions
		{
			/// <summary>The method to get the nextTransitions</summary>
			/// <returns>Instance of List<NextTransition></returns>
			get
			{
				return  this.nextTransitions;

			}
			/// <summary>The method to set the value to nextTransitions</summary>
			/// <param name="nextTransitions">Instance of List<NextTransition></param>
			set
			{
				 this.nextTransitions=value;

				 this.keyModified["next_transitions"] = 1;

			}
		}

		public double? PercentPartialSave
		{
			/// <summary>The method to get the percentPartialSave</summary>
			/// <returns>double? representing the percentPartialSave</returns>
			get
			{
				return  this.percentPartialSave;

			}
			/// <summary>The method to set the value to percentPartialSave</summary>
			/// <param name="percentPartialSave">double?</param>
			set
			{
				 this.percentPartialSave=value;

				 this.keyModified["percent_partial_save"] = 1;

			}
		}

		public Record.Record Data
		{
			/// <summary>The method to get the data</summary>
			/// <returns>Instance of Record</returns>
			get
			{
				return  this.data;

			}
			/// <summary>The method to set the value to data</summary>
			/// <param name="data">Instance of Record</param>
			set
			{
				 this.data=value;

				 this.keyModified["data"] = 1;

			}
		}

		public string NextFieldValue
		{
			/// <summary>The method to get the nextFieldValue</summary>
			/// <returns>string representing the nextFieldValue</returns>
			get
			{
				return  this.nextFieldValue;

			}
			/// <summary>The method to set the value to nextFieldValue</summary>
			/// <param name="nextFieldValue">string</param>
			set
			{
				 this.nextFieldValue=value;

				 this.keyModified["next_field_value"] = 1;

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

		public bool? CriteriaMatched
		{
			/// <summary>The method to get the criteriaMatched</summary>
			/// <returns>bool? representing the criteriaMatched</returns>
			get
			{
				return  this.criteriaMatched;

			}
			/// <summary>The method to set the value to criteriaMatched</summary>
			/// <param name="criteriaMatched">bool?</param>
			set
			{
				 this.criteriaMatched=value;

				 this.keyModified["criteria_matched"] = 1;

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

		public string CriteriaMessage
		{
			/// <summary>The method to get the criteriaMessage</summary>
			/// <returns>string representing the criteriaMessage</returns>
			get
			{
				return  this.criteriaMessage;

			}
			/// <summary>The method to set the value to criteriaMessage</summary>
			/// <param name="criteriaMessage">string</param>
			set
			{
				 this.criteriaMessage=value;

				 this.keyModified["criteria_message"] = 1;

			}
		}

		public string Type
		{
			/// <summary>The method to get the type</summary>
			/// <returns>string representing the type</returns>
			get
			{
				return  this.type;

			}
			/// <summary>The method to set the value to type</summary>
			/// <param name="type">string</param>
			set
			{
				 this.type=value;

				 this.keyModified["type"] = 1;

			}
		}

		public DateTimeOffset? ExecutionTime
		{
			/// <summary>The method to get the executionTime</summary>
			/// <returns>DateTimeOffset? representing the executionTime</returns>
			get
			{
				return  this.executionTime;

			}
			/// <summary>The method to set the value to executionTime</summary>
			/// <param name="executionTime">DateTimeOffset?</param>
			set
			{
				 this.executionTime=value;

				 this.keyModified["execution_time"] = 1;

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
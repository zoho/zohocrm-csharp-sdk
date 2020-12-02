using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.BluePrint
{

	public class BluePrint : Model
	{
		private long? transitionId;
		private Record.Record data;
		private ProcessInfo processInfo;
		private List<Transition> transitions;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public long? TransitionId
		{
			/// <summary>The method to get the transitionId</summary>
			/// <returns>long? representing the transitionId</returns>
			get
			{
				return  this.transitionId;

			}
			/// <summary>The method to set the value to transitionId</summary>
			/// <param name="transitionId">long?</param>
			set
			{
				 this.transitionId=value;

				 this.keyModified["transition_id"] = 1;

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

		public ProcessInfo ProcessInfo
		{
			/// <summary>The method to get the processInfo</summary>
			/// <returns>Instance of ProcessInfo</returns>
			get
			{
				return  this.processInfo;

			}
			/// <summary>The method to set the value to processInfo</summary>
			/// <param name="processInfo">Instance of ProcessInfo</param>
			set
			{
				 this.processInfo=value;

				 this.keyModified["process_info"] = 1;

			}
		}

		public List<Transition> Transitions
		{
			/// <summary>The method to get the transitions</summary>
			/// <returns>Instance of List<Transition></returns>
			get
			{
				return  this.transitions;

			}
			/// <summary>The method to set the value to transitions</summary>
			/// <param name="transitions">Instance of List<Transition></param>
			set
			{
				 this.transitions=value;

				 this.keyModified["transitions"] = 1;

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
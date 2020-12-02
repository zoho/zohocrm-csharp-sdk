using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Tags
{

	public class RecordActionWrapper : Model, RecordActionHandler
	{
		private List<RecordActionResponse> data;
		private bool? wfScheduler;
		private string successCount;
		private int? lockedCount;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<RecordActionResponse> Data
		{
			/// <summary>The method to get the data</summary>
			/// <returns>Instance of List<RecordActionResponse></returns>
			get
			{
				return  this.data;

			}
			/// <summary>The method to set the value to data</summary>
			/// <param name="data">Instance of List<RecordActionResponse></param>
			set
			{
				 this.data=value;

				 this.keyModified["data"] = 1;

			}
		}

		public bool? WfScheduler
		{
			/// <summary>The method to get the wfScheduler</summary>
			/// <returns>bool? representing the wfScheduler</returns>
			get
			{
				return  this.wfScheduler;

			}
			/// <summary>The method to set the value to wfScheduler</summary>
			/// <param name="wfScheduler">bool?</param>
			set
			{
				 this.wfScheduler=value;

				 this.keyModified["wf_scheduler"] = 1;

			}
		}

		public string SuccessCount
		{
			/// <summary>The method to get the successCount</summary>
			/// <returns>string representing the successCount</returns>
			get
			{
				return  this.successCount;

			}
			/// <summary>The method to set the value to successCount</summary>
			/// <param name="successCount">string</param>
			set
			{
				 this.successCount=value;

				 this.keyModified["success_count"] = 1;

			}
		}

		public int? LockedCount
		{
			/// <summary>The method to get the lockedCount</summary>
			/// <returns>int? representing the lockedCount</returns>
			get
			{
				return  this.lockedCount;

			}
			/// <summary>The method to set the value to lockedCount</summary>
			/// <param name="lockedCount">int?</param>
			set
			{
				 this.lockedCount=value;

				 this.keyModified["locked_count"] = 1;

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
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class PickListValue : Model
	{
		private string displayValue;
		private int? sequenceNumber;
		private string expectedDataType;
		private List<object> maps;
		private string actualValue;
		private string sysRefName;
		private string type;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

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

		public string ExpectedDataType
		{
			/// <summary>The method to get the expectedDataType</summary>
			/// <returns>string representing the expectedDataType</returns>
			get
			{
				return  this.expectedDataType;

			}
			/// <summary>The method to set the value to expectedDataType</summary>
			/// <param name="expectedDataType">string</param>
			set
			{
				 this.expectedDataType=value;

				 this.keyModified["expected_data_type"] = 1;

			}
		}

		public List<object> Maps
		{
			/// <summary>The method to get the maps</summary>
			/// <returns>Instance of List<Object></returns>
			get
			{
				return  this.maps;

			}
			/// <summary>The method to set the value to maps</summary>
			/// <param name="maps">Instance of List<object></param>
			set
			{
				 this.maps=value;

				 this.keyModified["maps"] = 1;

			}
		}

		public string ActualValue
		{
			/// <summary>The method to get the actualValue</summary>
			/// <returns>string representing the actualValue</returns>
			get
			{
				return  this.actualValue;

			}
			/// <summary>The method to set the value to actualValue</summary>
			/// <param name="actualValue">string</param>
			set
			{
				 this.actualValue=value;

				 this.keyModified["actual_value"] = 1;

			}
		}

		public string SysRefName
		{
			/// <summary>The method to get the sysRefName</summary>
			/// <returns>string representing the sysRefName</returns>
			get
			{
				return  this.sysRefName;

			}
			/// <summary>The method to set the value to sysRefName</summary>
			/// <param name="sysRefName">string</param>
			set
			{
				 this.sysRefName=value;

				 this.keyModified["sys_ref_name"] = 1;

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
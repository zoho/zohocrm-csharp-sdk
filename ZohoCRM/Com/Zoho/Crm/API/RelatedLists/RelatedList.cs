using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.RelatedLists
{

	public class RelatedList : Model
	{
		private long? id;
		private string sequenceNumber;
		private string displayLabel;
		private string apiName;
		private string module;
		private string name;
		private string action;
		private string href;
		private string type;
		private string connectedmodule;
		private string linkingmodule;
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

		public string SequenceNumber
		{
			/// <summary>The method to get the sequenceNumber</summary>
			/// <returns>string representing the sequenceNumber</returns>
			get
			{
				return  this.sequenceNumber;

			}
			/// <summary>The method to set the value to sequenceNumber</summary>
			/// <param name="sequenceNumber">string</param>
			set
			{
				 this.sequenceNumber=value;

				 this.keyModified["sequence_number"] = 1;

			}
		}

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

		public string Module
		{
			/// <summary>The method to get the module</summary>
			/// <returns>string representing the module</returns>
			get
			{
				return  this.module;

			}
			/// <summary>The method to set the value to module</summary>
			/// <param name="module">string</param>
			set
			{
				 this.module=value;

				 this.keyModified["module"] = 1;

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

		public string Action
		{
			/// <summary>The method to get the action</summary>
			/// <returns>string representing the action</returns>
			get
			{
				return  this.action;

			}
			/// <summary>The method to set the value to action</summary>
			/// <param name="action">string</param>
			set
			{
				 this.action=value;

				 this.keyModified[Constants.REQUEST_CATEGORY_ACTION] = 1;

			}
		}

		public string Href
		{
			/// <summary>The method to get the href</summary>
			/// <returns>string representing the href</returns>
			get
			{
				return  this.href;

			}
			/// <summary>The method to set the value to href</summary>
			/// <param name="href">string</param>
			set
			{
				 this.href=value;

				 this.keyModified["href"] = 1;

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

		public string Connectedmodule
		{
			/// <summary>The method to get the connectedmodule</summary>
			/// <returns>string representing the connectedmodule</returns>
			get
			{
				return  this.connectedmodule;

			}
			/// <summary>The method to set the value to connectedmodule</summary>
			/// <param name="connectedmodule">string</param>
			set
			{
				 this.connectedmodule=value;

				 this.keyModified["connectedmodule"] = 1;

			}
		}

		public string Linkingmodule
		{
			/// <summary>The method to get the linkingmodule</summary>
			/// <returns>string representing the linkingmodule</returns>
			get
			{
				return  this.linkingmodule;

			}
			/// <summary>The method to set the value to linkingmodule</summary>
			/// <param name="linkingmodule">string</param>
			set
			{
				 this.linkingmodule=value;

				 this.keyModified["linkingmodule"] = 1;

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
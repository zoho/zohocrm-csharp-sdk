using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Modules
{

	public class BodyWrapper : Model
	{
		private List<Module> modules;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<Module> Modules
		{
			/// <summary>The method to get the modules</summary>
			/// <returns>Instance of List<Module></returns>
			get
			{
				return  this.modules;

			}
			/// <summary>The method to set the value to modules</summary>
			/// <param name="modules">Instance of List<Module></param>
			set
			{
				 this.modules=value;

				 this.keyModified["modules"] = 1;

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
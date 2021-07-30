using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.ContactRoles
{

	public class ResponseWrapper : Model, ResponseHandler
	{
		private List<ContactRole> contactRoles;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public List<ContactRole> ContactRoles
		{
			/// <summary>The method to get the contactRoles</summary>
			/// <returns>Instance of List<ContactRole></returns>
			get
			{
				return  this.contactRoles;

			}
			/// <summary>The method to set the value to contactRoles</summary>
			/// <param name="contactRoles">Instance of List<ContactRole></param>
			set
			{
				 this.contactRoles=value;

				 this.keyModified["contact_roles"] = 1;

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
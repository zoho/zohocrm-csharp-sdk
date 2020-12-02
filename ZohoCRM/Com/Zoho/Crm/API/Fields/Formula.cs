using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Fields
{

	public class Formula : Model
	{
		private string returnType;
		private string expression;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string ReturnType
		{
			/// <summary>The method to get the returnType</summary>
			/// <returns>string representing the returnType</returns>
			get
			{
				return  this.returnType;

			}
			/// <summary>The method to set the value to returnType</summary>
			/// <param name="returnType">string</param>
			set
			{
				 this.returnType=value;

				 this.keyModified["return_type"] = 1;

			}
		}

		public string Expression
		{
			/// <summary>The method to get the expression</summary>
			/// <returns>string representing the expression</returns>
			get
			{
				return  this.expression;

			}
			/// <summary>The method to set the value to expression</summary>
			/// <param name="expression">string</param>
			set
			{
				 this.expression=value;

				 this.keyModified["expression"] = 1;

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
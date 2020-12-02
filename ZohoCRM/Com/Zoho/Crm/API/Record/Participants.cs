using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.Crm.API.Record
{

	public class Participants : Record , Model
	{

		public string Name
		{
			/// <summary>The method to get the name</summary>
			/// <returns>string representing the name</returns>
			get
			{
				if((( this.GetKeyValue("name")) != (null)))
				{
					return (string) this.GetKeyValue("name");

				}
					return null;


			}
			/// <summary>The method to set the value to name</summary>
			/// <param name="name">string</param>
			set
			{
				 this.AddKeyValue("name", value);

			}
		}

		public string Email
		{
			/// <summary>The method to get the email</summary>
			/// <returns>string representing the email</returns>
			get
			{
				if((( this.GetKeyValue("Email")) != (null)))
				{
					return (string) this.GetKeyValue("Email");

				}
					return null;


			}
			/// <summary>The method to set the value to email</summary>
			/// <param name="email">string</param>
			set
			{
				 this.AddKeyValue("Email", value);

			}
		}

		public bool? Invited
		{
			/// <summary>The method to get the invited</summary>
			/// <returns>bool? representing the invited</returns>
			get
			{
				if((( this.GetKeyValue("invited")) != (null)))
				{
					return (bool?) this.GetKeyValue("invited");

				}
					return null;


			}
			/// <summary>The method to set the value to invited</summary>
			/// <param name="invited">bool?</param>
			set
			{
				 this.AddKeyValue("invited", value);

			}
		}

		public string Type
		{
			/// <summary>The method to get the type</summary>
			/// <returns>string representing the type</returns>
			get
			{
				if((( this.GetKeyValue("type")) != (null)))
				{
					return (string) this.GetKeyValue("type");

				}
					return null;


			}
			/// <summary>The method to set the value to type</summary>
			/// <param name="type">string</param>
			set
			{
				 this.AddKeyValue("type", value);

			}
		}

		public string Participant
		{
			/// <summary>The method to get the participant</summary>
			/// <returns>string representing the participant</returns>
			get
			{
				if((( this.GetKeyValue("participant")) != (null)))
				{
					return (string) this.GetKeyValue("participant");

				}
					return null;


			}
			/// <summary>The method to set the value to participant</summary>
			/// <param name="participant">string</param>
			set
			{
				 this.AddKeyValue("participant", value);

			}
		}

		public string Status
		{
			/// <summary>The method to get the status</summary>
			/// <returns>string representing the status</returns>
			get
			{
				if((( this.GetKeyValue("status")) != (null)))
				{
					return (string) this.GetKeyValue("status");

				}
					return null;


			}
			/// <summary>The method to set the value to status</summary>
			/// <param name="status">string</param>
			set
			{
				 this.AddKeyValue("status", value);

			}
		}


	}
}
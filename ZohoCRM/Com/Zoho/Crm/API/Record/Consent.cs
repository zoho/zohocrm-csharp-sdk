using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;

namespace Com.Zoho.Crm.API.Record
{

	public class Consent : Record , Model
	{

		public User Owner
		{
			/// <summary>The method to get the owner</summary>
			/// <returns>Instance of User</returns>
			get
			{
				if((( this.GetKeyValue("Owner")) != (null)))
				{
					return (User) this.GetKeyValue("Owner");

				}
					return null;


			}
			/// <summary>The method to set the value to owner</summary>
			/// <param name="owner">Instance of User</param>
			set
			{
				 this.AddKeyValue("Owner", value);

			}
		}

		public bool? ContactThroughEmail
		{
			/// <summary>The method to get the contactThroughEmail</summary>
			/// <returns>bool? representing the contactThroughEmail</returns>
			get
			{
				if((( this.GetKeyValue("Contact_Through_Email")) != (null)))
				{
					return (bool?) this.GetKeyValue("Contact_Through_Email");

				}
					return null;


			}
			/// <summary>The method to set the value to contactThroughEmail</summary>
			/// <param name="contactThroughEmail">bool?</param>
			set
			{
				 this.AddKeyValue("Contact_Through_Email", value);

			}
		}

		public bool? ContactThroughSocial
		{
			/// <summary>The method to get the contactThroughSocial</summary>
			/// <returns>bool? representing the contactThroughSocial</returns>
			get
			{
				if((( this.GetKeyValue("Contact_Through_Social")) != (null)))
				{
					return (bool?) this.GetKeyValue("Contact_Through_Social");

				}
					return null;


			}
			/// <summary>The method to set the value to contactThroughSocial</summary>
			/// <param name="contactThroughSocial">bool?</param>
			set
			{
				 this.AddKeyValue("Contact_Through_Social", value);

			}
		}

		public bool? ContactThroughSurvey
		{
			/// <summary>The method to get the contactThroughSurvey</summary>
			/// <returns>bool? representing the contactThroughSurvey</returns>
			get
			{
				if((( this.GetKeyValue("Contact_Through_Survey")) != (null)))
				{
					return (bool?) this.GetKeyValue("Contact_Through_Survey");

				}
					return null;


			}
			/// <summary>The method to set the value to contactThroughSurvey</summary>
			/// <param name="contactThroughSurvey">bool?</param>
			set
			{
				 this.AddKeyValue("Contact_Through_Survey", value);

			}
		}

		public bool? ContactThroughPhone
		{
			/// <summary>The method to get the contactThroughPhone</summary>
			/// <returns>bool? representing the contactThroughPhone</returns>
			get
			{
				if((( this.GetKeyValue("Contact_Through_Phone")) != (null)))
				{
					return (bool?) this.GetKeyValue("Contact_Through_Phone");

				}
					return null;


			}
			/// <summary>The method to set the value to contactThroughPhone</summary>
			/// <param name="contactThroughPhone">bool?</param>
			set
			{
				 this.AddKeyValue("Contact_Through_Phone", value);

			}
		}

		public DateTimeOffset? MailSentTime
		{
			/// <summary>The method to get the mailSentTime</summary>
			/// <returns>DateTimeOffset? representing the mailSentTime</returns>
			get
			{
				if((( this.GetKeyValue("Mail_Sent_Time")) != (null)))
				{
					return (DateTimeOffset?) this.GetKeyValue("Mail_Sent_Time");

				}
					return null;


			}
			/// <summary>The method to set the value to mailSentTime</summary>
			/// <param name="mailSentTime">DateTimeOffset?</param>
			set
			{
				 this.AddKeyValue("Mail_Sent_Time", value);

			}
		}

		public DateTime? ConsentDate
		{
			/// <summary>The method to get the consentDate</summary>
			/// <returns>DateTime? representing the consentDate</returns>
			get
			{
				if((( this.GetKeyValue("Consent_Date")) != (null)))
				{
					return (DateTime?) this.GetKeyValue("Consent_Date");

				}
					return null;


			}
			/// <summary>The method to set the value to consentDate</summary>
			/// <param name="consentDate">DateTime?</param>
			set
			{
				 this.AddKeyValue("Consent_Date", value);

			}
		}

		public string ConsentRemarks
		{
			/// <summary>The method to get the consentRemarks</summary>
			/// <returns>string representing the consentRemarks</returns>
			get
			{
				if((( this.GetKeyValue("Consent_Remarks")) != (null)))
				{
					return (string) this.GetKeyValue("Consent_Remarks");

				}
					return null;


			}
			/// <summary>The method to set the value to consentRemarks</summary>
			/// <param name="consentRemarks">string</param>
			set
			{
				 this.AddKeyValue("Consent_Remarks", value);

			}
		}

		public string ConsentThrough
		{
			/// <summary>The method to get the consentThrough</summary>
			/// <returns>string representing the consentThrough</returns>
			get
			{
				if((( this.GetKeyValue("Consent_Through")) != (null)))
				{
					return (string) this.GetKeyValue("Consent_Through");

				}
					return null;


			}
			/// <summary>The method to set the value to consentThrough</summary>
			/// <param name="consentThrough">string</param>
			set
			{
				 this.AddKeyValue("Consent_Through", value);

			}
		}

		public string DataProcessingBasis
		{
			/// <summary>The method to get the dataProcessingBasis</summary>
			/// <returns>string representing the dataProcessingBasis</returns>
			get
			{
				if((( this.GetKeyValue("Data_Processing_Basis")) != (null)))
				{
					return (string) this.GetKeyValue("Data_Processing_Basis");

				}
					return null;


			}
			/// <summary>The method to set the value to dataProcessingBasis</summary>
			/// <param name="dataProcessingBasis">string</param>
			set
			{
				 this.AddKeyValue("Data_Processing_Basis", value);

			}
		}


	}
}
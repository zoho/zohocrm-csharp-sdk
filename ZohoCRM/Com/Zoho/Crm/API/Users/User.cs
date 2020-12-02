using Com.Zoho.Crm.API.Profiles;
using Com.Zoho.Crm.API.Roles;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Users
{

	public class User : Record.Record , Model
	{

		public string Country
		{
			/// <summary>The method to get the country</summary>
			/// <returns>string representing the country</returns>
			get
			{
				if((( this.GetKeyValue("country")) != (null)))
				{
					return (string) this.GetKeyValue("country");

				}
					return null;


			}
			/// <summary>The method to set the value to country</summary>
			/// <param name="country">string</param>
			set
			{
				 this.AddKeyValue("country", value);

			}
		}

		public CustomizeInfo CustomizeInfo
		{
			/// <summary>The method to get the customizeInfo</summary>
			/// <returns>Instance of CustomizeInfo</returns>
			get
			{
				if((( this.GetKeyValue("customize_info")) != (null)))
				{
					return (CustomizeInfo) this.GetKeyValue("customize_info");

				}
					return null;


			}
			/// <summary>The method to set the value to customizeInfo</summary>
			/// <param name="customizeInfo">Instance of CustomizeInfo</param>
			set
			{
				 this.AddKeyValue("customize_info", value);

			}
		}

		public Role Role
		{
			/// <summary>The method to get the role</summary>
			/// <returns>Instance of Role</returns>
			get
			{
				if((( this.GetKeyValue("role")) != (null)))
				{
					return (Role) this.GetKeyValue("role");

				}
					return null;


			}
			/// <summary>The method to set the value to role</summary>
			/// <param name="role">Instance of Role</param>
			set
			{
				 this.AddKeyValue("role", value);

			}
		}

		public string Signature
		{
			/// <summary>The method to get the signature</summary>
			/// <returns>string representing the signature</returns>
			get
			{
				if((( this.GetKeyValue("signature")) != (null)))
				{
					return (string) this.GetKeyValue("signature");

				}
					return null;


			}
			/// <summary>The method to set the value to signature</summary>
			/// <param name="signature">string</param>
			set
			{
				 this.AddKeyValue("signature", value);

			}
		}

		public string City
		{
			/// <summary>The method to get the city</summary>
			/// <returns>string representing the city</returns>
			get
			{
				if((( this.GetKeyValue("city")) != (null)))
				{
					return (string) this.GetKeyValue("city");

				}
					return null;


			}
			/// <summary>The method to set the value to city</summary>
			/// <param name="city">string</param>
			set
			{
				 this.AddKeyValue("city", value);

			}
		}

		public string NameFormat
		{
			/// <summary>The method to get the nameFormat</summary>
			/// <returns>string representing the nameFormat</returns>
			get
			{
				if((( this.GetKeyValue("name_format")) != (null)))
				{
					return (string) this.GetKeyValue("name_format");

				}
					return null;


			}
			/// <summary>The method to set the value to nameFormat</summary>
			/// <param name="nameFormat">string</param>
			set
			{
				 this.AddKeyValue("name_format", value);

			}
		}

		public bool? PersonalAccount
		{
			/// <summary>The method to get the personalAccount</summary>
			/// <returns>bool? representing the personalAccount</returns>
			get
			{
				if((( this.GetKeyValue("personal_account")) != (null)))
				{
					return (bool?) this.GetKeyValue("personal_account");

				}
					return null;


			}
			/// <summary>The method to set the value to personalAccount</summary>
			/// <param name="personalAccount">bool?</param>
			set
			{
				 this.AddKeyValue("personal_account", value);

			}
		}

		public string DefaultTabGroup
		{
			/// <summary>The method to get the defaultTabGroup</summary>
			/// <returns>string representing the defaultTabGroup</returns>
			get
			{
				if((( this.GetKeyValue("default_tab_group")) != (null)))
				{
					return (string) this.GetKeyValue("default_tab_group");

				}
					return null;


			}
			/// <summary>The method to set the value to defaultTabGroup</summary>
			/// <param name="defaultTabGroup">string</param>
			set
			{
				 this.AddKeyValue("default_tab_group", value);

			}
		}

		public string Language
		{
			/// <summary>The method to get the language</summary>
			/// <returns>string representing the language</returns>
			get
			{
				if((( this.GetKeyValue("language")) != (null)))
				{
					return (string) this.GetKeyValue("language");

				}
					return null;


			}
			/// <summary>The method to set the value to language</summary>
			/// <param name="language">string</param>
			set
			{
				 this.AddKeyValue("language", value);

			}
		}

		public string Locale
		{
			/// <summary>The method to get the locale</summary>
			/// <returns>string representing the locale</returns>
			get
			{
				if((( this.GetKeyValue("locale")) != (null)))
				{
					return (string) this.GetKeyValue("locale");

				}
					return null;


			}
			/// <summary>The method to set the value to locale</summary>
			/// <param name="locale">string</param>
			set
			{
				 this.AddKeyValue("locale", value);

			}
		}

		public bool? Microsoft
		{
			/// <summary>The method to get the microsoft</summary>
			/// <returns>bool? representing the microsoft</returns>
			get
			{
				if((( this.GetKeyValue("microsoft")) != (null)))
				{
					return (bool?) this.GetKeyValue("microsoft");

				}
					return null;


			}
			/// <summary>The method to set the value to microsoft</summary>
			/// <param name="microsoft">bool?</param>
			set
			{
				 this.AddKeyValue("microsoft", value);

			}
		}

		public bool? Isonline
		{
			/// <summary>The method to get the isonline</summary>
			/// <returns>bool? representing the isonline</returns>
			get
			{
				if((( this.GetKeyValue("Isonline")) != (null)))
				{
					return (bool?) this.GetKeyValue("Isonline");

				}
					return null;


			}
			/// <summary>The method to set the value to isonline</summary>
			/// <param name="isonline">bool?</param>
			set
			{
				 this.AddKeyValue("Isonline", value);

			}
		}

		public string Street
		{
			/// <summary>The method to get the street</summary>
			/// <returns>string representing the street</returns>
			get
			{
				if((( this.GetKeyValue("street")) != (null)))
				{
					return (string) this.GetKeyValue("street");

				}
					return null;


			}
			/// <summary>The method to set the value to street</summary>
			/// <param name="street">string</param>
			set
			{
				 this.AddKeyValue("street", value);

			}
		}

		public string Currency
		{
			/// <summary>The method to get the currency</summary>
			/// <returns>string representing the currency</returns>
			get
			{
				if((( this.GetKeyValue("Currency")) != (null)))
				{
					return (string) this.GetKeyValue("Currency");

				}
					return null;


			}
			/// <summary>The method to set the value to currency</summary>
			/// <param name="currency">string</param>
			set
			{
				 this.AddKeyValue("Currency", value);

			}
		}

		public string Alias
		{
			/// <summary>The method to get the alias</summary>
			/// <returns>string representing the alias</returns>
			get
			{
				if((( this.GetKeyValue("alias")) != (null)))
				{
					return (string) this.GetKeyValue("alias");

				}
					return null;


			}
			/// <summary>The method to set the value to alias</summary>
			/// <param name="alias">string</param>
			set
			{
				 this.AddKeyValue("alias", value);

			}
		}

		public Theme Theme
		{
			/// <summary>The method to get the theme</summary>
			/// <returns>Instance of Theme</returns>
			get
			{
				if((( this.GetKeyValue("theme")) != (null)))
				{
					return (Theme) this.GetKeyValue("theme");

				}
					return null;


			}
			/// <summary>The method to set the value to theme</summary>
			/// <param name="theme">Instance of Theme</param>
			set
			{
				 this.AddKeyValue("theme", value);

			}
		}

		public string State
		{
			/// <summary>The method to get the state</summary>
			/// <returns>string representing the state</returns>
			get
			{
				if((( this.GetKeyValue("state")) != (null)))
				{
					return (string) this.GetKeyValue("state");

				}
					return null;


			}
			/// <summary>The method to set the value to state</summary>
			/// <param name="state">string</param>
			set
			{
				 this.AddKeyValue("state", value);

			}
		}

		public string Fax
		{
			/// <summary>The method to get the fax</summary>
			/// <returns>string representing the fax</returns>
			get
			{
				if((( this.GetKeyValue("fax")) != (null)))
				{
					return (string) this.GetKeyValue("fax");

				}
					return null;


			}
			/// <summary>The method to set the value to fax</summary>
			/// <param name="fax">string</param>
			set
			{
				 this.AddKeyValue("fax", value);

			}
		}

		public string CountryLocale
		{
			/// <summary>The method to get the countryLocale</summary>
			/// <returns>string representing the countryLocale</returns>
			get
			{
				if((( this.GetKeyValue("country_locale")) != (null)))
				{
					return (string) this.GetKeyValue("country_locale");

				}
					return null;


			}
			/// <summary>The method to set the value to countryLocale</summary>
			/// <param name="countryLocale">string</param>
			set
			{
				 this.AddKeyValue("country_locale", value);

			}
		}

		public string FirstName
		{
			/// <summary>The method to get the firstName</summary>
			/// <returns>string representing the firstName</returns>
			get
			{
				if((( this.GetKeyValue("first_name")) != (null)))
				{
					return (string) this.GetKeyValue("first_name");

				}
					return null;


			}
			/// <summary>The method to set the value to firstName</summary>
			/// <param name="firstName">string</param>
			set
			{
				 this.AddKeyValue("first_name", value);

			}
		}

		public string Email
		{
			/// <summary>The method to get the email</summary>
			/// <returns>string representing the email</returns>
			get
			{
				if((( this.GetKeyValue("email")) != (null)))
				{
					return (string) this.GetKeyValue("email");

				}
					return null;


			}
			/// <summary>The method to set the value to email</summary>
			/// <param name="email">string</param>
			set
			{
				 this.AddKeyValue("email", value);

			}
		}

		public User ReportingTo
		{
			/// <summary>The method to get the reportingTo</summary>
			/// <returns>Instance of User</returns>
			get
			{
				if((( this.GetKeyValue("Reporting_To")) != (null)))
				{
					return (User) this.GetKeyValue("Reporting_To");

				}
					return null;


			}
			/// <summary>The method to set the value to reportingTo</summary>
			/// <param name="reportingTo">Instance of User</param>
			set
			{
				 this.AddKeyValue("Reporting_To", value);

			}
		}

		public string DecimalSeparator
		{
			/// <summary>The method to get the decimalSeparator</summary>
			/// <returns>string representing the decimalSeparator</returns>
			get
			{
				if((( this.GetKeyValue("decimal_separator")) != (null)))
				{
					return (string) this.GetKeyValue("decimal_separator");

				}
					return null;


			}
			/// <summary>The method to set the value to decimalSeparator</summary>
			/// <param name="decimalSeparator">string</param>
			set
			{
				 this.AddKeyValue("decimal_separator", value);

			}
		}

		public string Zip
		{
			/// <summary>The method to get the zip</summary>
			/// <returns>string representing the zip</returns>
			get
			{
				if((( this.GetKeyValue("zip")) != (null)))
				{
					return (string) this.GetKeyValue("zip");

				}
					return null;


			}
			/// <summary>The method to set the value to zip</summary>
			/// <param name="zip">string</param>
			set
			{
				 this.AddKeyValue("zip", value);

			}
		}

		public string Website
		{
			/// <summary>The method to get the website</summary>
			/// <returns>string representing the website</returns>
			get
			{
				if((( this.GetKeyValue("website")) != (null)))
				{
					return (string) this.GetKeyValue("website");

				}
					return null;


			}
			/// <summary>The method to set the value to website</summary>
			/// <param name="website">string</param>
			set
			{
				 this.AddKeyValue("website", value);

			}
		}

		public string TimeFormat
		{
			/// <summary>The method to get the timeFormat</summary>
			/// <returns>string representing the timeFormat</returns>
			get
			{
				if((( this.GetKeyValue("time_format")) != (null)))
				{
					return (string) this.GetKeyValue("time_format");

				}
					return null;


			}
			/// <summary>The method to set the value to timeFormat</summary>
			/// <param name="timeFormat">string</param>
			set
			{
				 this.AddKeyValue("time_format", value);

			}
		}

		public long? Offset
		{
			/// <summary>The method to get the offset</summary>
			/// <returns>long? representing the offset</returns>
			get
			{
				if((( this.GetKeyValue("offset")) != (null)))
				{
					return (long?) this.GetKeyValue("offset");

				}
					return null;


			}
			/// <summary>The method to set the value to offset</summary>
			/// <param name="offset">long?</param>
			set
			{
				 this.AddKeyValue("offset", value);

			}
		}

		public Profile Profile
		{
			/// <summary>The method to get the profile</summary>
			/// <returns>Instance of Profile</returns>
			get
			{
				if((( this.GetKeyValue("profile")) != (null)))
				{
					return (Profile) this.GetKeyValue("profile");

				}
					return null;


			}
			/// <summary>The method to set the value to profile</summary>
			/// <param name="profile">Instance of Profile</param>
			set
			{
				 this.AddKeyValue("profile", value);

			}
		}

		public string Mobile
		{
			/// <summary>The method to get the mobile</summary>
			/// <returns>string representing the mobile</returns>
			get
			{
				if((( this.GetKeyValue("mobile")) != (null)))
				{
					return (string) this.GetKeyValue("mobile");

				}
					return null;


			}
			/// <summary>The method to set the value to mobile</summary>
			/// <param name="mobile">string</param>
			set
			{
				 this.AddKeyValue("mobile", value);

			}
		}

		public string LastName
		{
			/// <summary>The method to get the lastName</summary>
			/// <returns>string representing the lastName</returns>
			get
			{
				if((( this.GetKeyValue("last_name")) != (null)))
				{
					return (string) this.GetKeyValue("last_name");

				}
					return null;


			}
			/// <summary>The method to set the value to lastName</summary>
			/// <param name="lastName">string</param>
			set
			{
				 this.AddKeyValue("last_name", value);

			}
		}

		public string TimeZone
		{
			/// <summary>The method to get the timeZone</summary>
			/// <returns>string representing the timeZone</returns>
			get
			{
				if((( this.GetKeyValue("time_zone")) != (null)))
				{
					return (string) this.GetKeyValue("time_zone");

				}
					return null;


			}
			/// <summary>The method to set the value to timeZone</summary>
			/// <param name="timeZone">string</param>
			set
			{
				 this.AddKeyValue("time_zone", value);

			}
		}

		public string Zuid
		{
			/// <summary>The method to get the zuid</summary>
			/// <returns>string representing the zuid</returns>
			get
			{
				if((( this.GetKeyValue("zuid")) != (null)))
				{
					return (string) this.GetKeyValue("zuid");

				}
					return null;


			}
			/// <summary>The method to set the value to zuid</summary>
			/// <param name="zuid">string</param>
			set
			{
				 this.AddKeyValue("zuid", value);

			}
		}

		public bool? Confirm
		{
			/// <summary>The method to get the confirm</summary>
			/// <returns>bool? representing the confirm</returns>
			get
			{
				if((( this.GetKeyValue("confirm")) != (null)))
				{
					return (bool?) this.GetKeyValue("confirm");

				}
					return null;


			}
			/// <summary>The method to set the value to confirm</summary>
			/// <param name="confirm">bool?</param>
			set
			{
				 this.AddKeyValue("confirm", value);

			}
		}

		public string FullName
		{
			/// <summary>The method to get the fullName</summary>
			/// <returns>string representing the fullName</returns>
			get
			{
				if((( this.GetKeyValue("full_name")) != (null)))
				{
					return (string) this.GetKeyValue("full_name");

				}
					return null;


			}
			/// <summary>The method to set the value to fullName</summary>
			/// <param name="fullName">string</param>
			set
			{
				 this.AddKeyValue("full_name", value);

			}
		}

		public List<Territory> Territories
		{
			/// <summary>The method to get the territories</summary>
			/// <returns>Instance of List<Territory></returns>
			get
			{
				if((( this.GetKeyValue("territories")) != (null)))
				{
					return (List<Territory>) this.GetKeyValue("territories");

				}
					return null;


			}
			/// <summary>The method to set the value to territories</summary>
			/// <param name="territories">Instance of List<Territory></param>
			set
			{
				 this.AddKeyValue("territories", value);

			}
		}

		public string Phone
		{
			/// <summary>The method to get the phone</summary>
			/// <returns>string representing the phone</returns>
			get
			{
				if((( this.GetKeyValue("phone")) != (null)))
				{
					return (string) this.GetKeyValue("phone");

				}
					return null;


			}
			/// <summary>The method to set the value to phone</summary>
			/// <param name="phone">string</param>
			set
			{
				 this.AddKeyValue("phone", value);

			}
		}

		public string Dob
		{
			/// <summary>The method to get the dob</summary>
			/// <returns>string representing the dob</returns>
			get
			{
				if((( this.GetKeyValue("dob")) != (null)))
				{
					return (string) this.GetKeyValue("dob");

				}
					return null;


			}
			/// <summary>The method to set the value to dob</summary>
			/// <param name="dob">string</param>
			set
			{
				 this.AddKeyValue("dob", value);

			}
		}

		public string DateFormat
		{
			/// <summary>The method to get the dateFormat</summary>
			/// <returns>string representing the dateFormat</returns>
			get
			{
				if((( this.GetKeyValue("date_format")) != (null)))
				{
					return (string) this.GetKeyValue("date_format");

				}
					return null;


			}
			/// <summary>The method to set the value to dateFormat</summary>
			/// <param name="dateFormat">string</param>
			set
			{
				 this.AddKeyValue("date_format", value);

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


	}
}
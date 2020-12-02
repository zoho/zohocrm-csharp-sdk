using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Org
{

	public class Org : Model
	{
		private string country;
		private string photoId;
		private string city;
		private string description;
		private bool? mcStatus;
		private bool? gappsEnabled;
		private string domainName;
		private bool? translationEnabled;
		private string street;
		private string alias;
		private string currency;
		private long? id;
		private string state;
		private string fax;
		private string employeeCount;
		private string zip;
		private string website;
		private string currencySymbol;
		private string mobile;
		private string currencyLocale;
		private string primaryZuid;
		private string ziaPortalId;
		private string timeZone;
		private string zgid;
		private string countryCode;
		private LicenseDetails licenseDetails;
		private string phone;
		private string companyName;
		private bool? privacySettings;
		private string primaryEmail;
		private string isoCode;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Country
		{
			/// <summary>The method to get the country</summary>
			/// <returns>string representing the country</returns>
			get
			{
				return  this.country;

			}
			/// <summary>The method to set the value to country</summary>
			/// <param name="country">string</param>
			set
			{
				 this.country=value;

				 this.keyModified["country"] = 1;

			}
		}

		public string PhotoId
		{
			/// <summary>The method to get the photoId</summary>
			/// <returns>string representing the photoId</returns>
			get
			{
				return  this.photoId;

			}
			/// <summary>The method to set the value to photoId</summary>
			/// <param name="photoId">string</param>
			set
			{
				 this.photoId=value;

				 this.keyModified["photo_id"] = 1;

			}
		}

		public string City
		{
			/// <summary>The method to get the city</summary>
			/// <returns>string representing the city</returns>
			get
			{
				return  this.city;

			}
			/// <summary>The method to set the value to city</summary>
			/// <param name="city">string</param>
			set
			{
				 this.city=value;

				 this.keyModified["city"] = 1;

			}
		}

		public string Description
		{
			/// <summary>The method to get the description</summary>
			/// <returns>string representing the description</returns>
			get
			{
				return  this.description;

			}
			/// <summary>The method to set the value to description</summary>
			/// <param name="description">string</param>
			set
			{
				 this.description=value;

				 this.keyModified["description"] = 1;

			}
		}

		public bool? McStatus
		{
			/// <summary>The method to get the mcStatus</summary>
			/// <returns>bool? representing the mcStatus</returns>
			get
			{
				return  this.mcStatus;

			}
			/// <summary>The method to set the value to mcStatus</summary>
			/// <param name="mcStatus">bool?</param>
			set
			{
				 this.mcStatus=value;

				 this.keyModified["mc_status"] = 1;

			}
		}

		public bool? GappsEnabled
		{
			/// <summary>The method to get the gappsEnabled</summary>
			/// <returns>bool? representing the gappsEnabled</returns>
			get
			{
				return  this.gappsEnabled;

			}
			/// <summary>The method to set the value to gappsEnabled</summary>
			/// <param name="gappsEnabled">bool?</param>
			set
			{
				 this.gappsEnabled=value;

				 this.keyModified["gapps_enabled"] = 1;

			}
		}

		public string DomainName
		{
			/// <summary>The method to get the domainName</summary>
			/// <returns>string representing the domainName</returns>
			get
			{
				return  this.domainName;

			}
			/// <summary>The method to set the value to domainName</summary>
			/// <param name="domainName">string</param>
			set
			{
				 this.domainName=value;

				 this.keyModified["domain_name"] = 1;

			}
		}

		public bool? TranslationEnabled
		{
			/// <summary>The method to get the translationEnabled</summary>
			/// <returns>bool? representing the translationEnabled</returns>
			get
			{
				return  this.translationEnabled;

			}
			/// <summary>The method to set the value to translationEnabled</summary>
			/// <param name="translationEnabled">bool?</param>
			set
			{
				 this.translationEnabled=value;

				 this.keyModified["translation_enabled"] = 1;

			}
		}

		public string Street
		{
			/// <summary>The method to get the street</summary>
			/// <returns>string representing the street</returns>
			get
			{
				return  this.street;

			}
			/// <summary>The method to set the value to street</summary>
			/// <param name="street">string</param>
			set
			{
				 this.street=value;

				 this.keyModified["street"] = 1;

			}
		}

		public string Alias
		{
			/// <summary>The method to get the alias</summary>
			/// <returns>string representing the alias</returns>
			get
			{
				return  this.alias;

			}
			/// <summary>The method to set the value to alias</summary>
			/// <param name="alias">string</param>
			set
			{
				 this.alias=value;

				 this.keyModified["alias"] = 1;

			}
		}

		public string Currency
		{
			/// <summary>The method to get the currency</summary>
			/// <returns>string representing the currency</returns>
			get
			{
				return  this.currency;

			}
			/// <summary>The method to set the value to currency</summary>
			/// <param name="currency">string</param>
			set
			{
				 this.currency=value;

				 this.keyModified["currency"] = 1;

			}
		}

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

		public string State
		{
			/// <summary>The method to get the state</summary>
			/// <returns>string representing the state</returns>
			get
			{
				return  this.state;

			}
			/// <summary>The method to set the value to state</summary>
			/// <param name="state">string</param>
			set
			{
				 this.state=value;

				 this.keyModified["state"] = 1;

			}
		}

		public string Fax
		{
			/// <summary>The method to get the fax</summary>
			/// <returns>string representing the fax</returns>
			get
			{
				return  this.fax;

			}
			/// <summary>The method to set the value to fax</summary>
			/// <param name="fax">string</param>
			set
			{
				 this.fax=value;

				 this.keyModified["fax"] = 1;

			}
		}

		public string EmployeeCount
		{
			/// <summary>The method to get the employeeCount</summary>
			/// <returns>string representing the employeeCount</returns>
			get
			{
				return  this.employeeCount;

			}
			/// <summary>The method to set the value to employeeCount</summary>
			/// <param name="employeeCount">string</param>
			set
			{
				 this.employeeCount=value;

				 this.keyModified["employee_count"] = 1;

			}
		}

		public string Zip
		{
			/// <summary>The method to get the zip</summary>
			/// <returns>string representing the zip</returns>
			get
			{
				return  this.zip;

			}
			/// <summary>The method to set the value to zip</summary>
			/// <param name="zip">string</param>
			set
			{
				 this.zip=value;

				 this.keyModified["zip"] = 1;

			}
		}

		public string Website
		{
			/// <summary>The method to get the website</summary>
			/// <returns>string representing the website</returns>
			get
			{
				return  this.website;

			}
			/// <summary>The method to set the value to website</summary>
			/// <param name="website">string</param>
			set
			{
				 this.website=value;

				 this.keyModified["website"] = 1;

			}
		}

		public string CurrencySymbol
		{
			/// <summary>The method to get the currencySymbol</summary>
			/// <returns>string representing the currencySymbol</returns>
			get
			{
				return  this.currencySymbol;

			}
			/// <summary>The method to set the value to currencySymbol</summary>
			/// <param name="currencySymbol">string</param>
			set
			{
				 this.currencySymbol=value;

				 this.keyModified["currency_symbol"] = 1;

			}
		}

		public string Mobile
		{
			/// <summary>The method to get the mobile</summary>
			/// <returns>string representing the mobile</returns>
			get
			{
				return  this.mobile;

			}
			/// <summary>The method to set the value to mobile</summary>
			/// <param name="mobile">string</param>
			set
			{
				 this.mobile=value;

				 this.keyModified["mobile"] = 1;

			}
		}

		public string CurrencyLocale
		{
			/// <summary>The method to get the currencyLocale</summary>
			/// <returns>string representing the currencyLocale</returns>
			get
			{
				return  this.currencyLocale;

			}
			/// <summary>The method to set the value to currencyLocale</summary>
			/// <param name="currencyLocale">string</param>
			set
			{
				 this.currencyLocale=value;

				 this.keyModified["currency_locale"] = 1;

			}
		}

		public string PrimaryZuid
		{
			/// <summary>The method to get the primaryZuid</summary>
			/// <returns>string representing the primaryZuid</returns>
			get
			{
				return  this.primaryZuid;

			}
			/// <summary>The method to set the value to primaryZuid</summary>
			/// <param name="primaryZuid">string</param>
			set
			{
				 this.primaryZuid=value;

				 this.keyModified["primary_zuid"] = 1;

			}
		}

		public string ZiaPortalId
		{
			/// <summary>The method to get the ziaPortalId</summary>
			/// <returns>string representing the ziaPortalId</returns>
			get
			{
				return  this.ziaPortalId;

			}
			/// <summary>The method to set the value to ziaPortalId</summary>
			/// <param name="ziaPortalId">string</param>
			set
			{
				 this.ziaPortalId=value;

				 this.keyModified["zia_portal_id"] = 1;

			}
		}

		public string TimeZone
		{
			/// <summary>The method to get the timeZone</summary>
			/// <returns>string representing the timeZone</returns>
			get
			{
				return  this.timeZone;

			}
			/// <summary>The method to set the value to timeZone</summary>
			/// <param name="timeZone">string</param>
			set
			{
				 this.timeZone=value;

				 this.keyModified["time_zone"] = 1;

			}
		}

		public string Zgid
		{
			/// <summary>The method to get the zgid</summary>
			/// <returns>string representing the zgid</returns>
			get
			{
				return  this.zgid;

			}
			/// <summary>The method to set the value to zgid</summary>
			/// <param name="zgid">string</param>
			set
			{
				 this.zgid=value;

				 this.keyModified["zgid"] = 1;

			}
		}

		public string CountryCode
		{
			/// <summary>The method to get the countryCode</summary>
			/// <returns>string representing the countryCode</returns>
			get
			{
				return  this.countryCode;

			}
			/// <summary>The method to set the value to countryCode</summary>
			/// <param name="countryCode">string</param>
			set
			{
				 this.countryCode=value;

				 this.keyModified["country_code"] = 1;

			}
		}

		public LicenseDetails LicenseDetails
		{
			/// <summary>The method to get the licenseDetails</summary>
			/// <returns>Instance of LicenseDetails</returns>
			get
			{
				return  this.licenseDetails;

			}
			/// <summary>The method to set the value to licenseDetails</summary>
			/// <param name="licenseDetails">Instance of LicenseDetails</param>
			set
			{
				 this.licenseDetails=value;

				 this.keyModified["license_details"] = 1;

			}
		}

		public string Phone
		{
			/// <summary>The method to get the phone</summary>
			/// <returns>string representing the phone</returns>
			get
			{
				return  this.phone;

			}
			/// <summary>The method to set the value to phone</summary>
			/// <param name="phone">string</param>
			set
			{
				 this.phone=value;

				 this.keyModified["phone"] = 1;

			}
		}

		public string CompanyName
		{
			/// <summary>The method to get the companyName</summary>
			/// <returns>string representing the companyName</returns>
			get
			{
				return  this.companyName;

			}
			/// <summary>The method to set the value to companyName</summary>
			/// <param name="companyName">string</param>
			set
			{
				 this.companyName=value;

				 this.keyModified["company_name"] = 1;

			}
		}

		public bool? PrivacySettings
		{
			/// <summary>The method to get the privacySettings</summary>
			/// <returns>bool? representing the privacySettings</returns>
			get
			{
				return  this.privacySettings;

			}
			/// <summary>The method to set the value to privacySettings</summary>
			/// <param name="privacySettings">bool?</param>
			set
			{
				 this.privacySettings=value;

				 this.keyModified["privacy_settings"] = 1;

			}
		}

		public string PrimaryEmail
		{
			/// <summary>The method to get the primaryEmail</summary>
			/// <returns>string representing the primaryEmail</returns>
			get
			{
				return  this.primaryEmail;

			}
			/// <summary>The method to set the value to primaryEmail</summary>
			/// <param name="primaryEmail">string</param>
			set
			{
				 this.primaryEmail=value;

				 this.keyModified["primary_email"] = 1;

			}
		}

		public string IsoCode
		{
			/// <summary>The method to get the isoCode</summary>
			/// <returns>string representing the isoCode</returns>
			get
			{
				return  this.isoCode;

			}
			/// <summary>The method to set the value to isoCode</summary>
			/// <param name="isoCode">string</param>
			set
			{
				 this.isoCode=value;

				 this.keyModified["iso_code"] = 1;

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
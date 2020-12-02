using System;

namespace Com.Zoho.Crm.API.Dc
{
    /// <summary>
    /// This class represents the properties of Zoho CRM in US Domain.
    /// </summary>
    public class USDataCenter : DataCenter
    {
        private static readonly USDataCenter US = new USDataCenter();

        private USDataCenter()
        {
        }

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Production Environment in US Domain.
        /// </summary>
        public static readonly Environment PRODUCTION = new Environment("https://www.zohoapis.com", US.GetIAMUrl(), US.GetFileUploadUrl());

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Sandbox Environment in US Domain.
        /// </summary>
        public static readonly Environment SANDBOX = new Environment("https://sandbox.zohoapis.com", US.GetIAMUrl(), US.GetFileUploadUrl());

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Developer Environment in US Domain.
        /// </summary>
        public static readonly Environment DEVELOPER = new Environment("https://developer.zohoapis.com", US.GetIAMUrl(), US.GetFileUploadUrl());

        public override string GetIAMUrl()
        {
            return "https://accounts.zoho.com/oauth/v2/token";
        }

        public override string GetFileUploadUrl()
        {
            return "https://content.zohoapis.com";
        }
    }
}

using System;

namespace Com.Zoho.Crm.API.Dc
{
    /// <summary>
    /// This class represents the properties of Zoho CRM in AU Domain.
    /// </summary>
    public class AUDataCenter : DataCenter
    {
        private static readonly AUDataCenter AU = new AUDataCenter();

        private AUDataCenter()
        {
        }

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Production Environment in AU Domain.
        /// </summary>
        public static readonly Environment PRODUCTION = new Environment("https://www.zohoapis.com.au", AU.GetIAMUrl(), AU.GetFileUploadUrl());

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Sandbox Environment in AU Domain.
        /// </summary>
        public static readonly Environment SANDBOX = new Environment("https://sandbox.zohoapis.com.au", AU.GetIAMUrl(), AU.GetFileUploadUrl());

        /// <summary>
        /// This Environment class instance represents the Zoho CRM Developer Environment in AU Domain.
        /// </summary>
        public static readonly Environment DEVELOPER = new Environment("https://developer.zohoapis.com.au", AU.GetIAMUrl(), AU.GetFileUploadUrl());

        public override string GetIAMUrl()
        {
            return "https://accounts.zoho.com.au/oauth/v2/token";
        }

        public override string GetFileUploadUrl()
        {
            return "https://content.zohoapis.com.au";
        }
    }
}

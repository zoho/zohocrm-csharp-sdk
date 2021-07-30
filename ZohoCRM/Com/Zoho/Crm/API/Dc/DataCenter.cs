using System;

namespace Com.Zoho.Crm.API.Dc
{
    /// <summary>
    /// The abstract class represents the properties of Zoho CRM DataCenter.
    /// </summary>
    public abstract class DataCenter
    {
        /// <summary>
        /// This method to get accounts URL. URL to be used when calling an OAuth accounts.
        /// </summary>
        /// <returns>A String representing the accounts URL.</returns>
        public abstract string GetIAMUrl();

        /// <summary>
        /// This method to get File Upload URL.
        /// </summary>
        /// <returns>A String representing the FileUpload URL.</returns>
        public abstract string GetFileUploadUrl();

        /// <summary>
        /// The abstract class represents the properties of Zoho CRM Environment.
        /// </summary>
        public class Environment
        {
            private string url;

            private string accountsUrl;

            private string fileUploadUrl;
           
            public Environment(string url, string accountsUrl, string fileUploadUrl)
            {
                this.accountsUrl = accountsUrl;

                this.url = url;

                this.fileUploadUrl = fileUploadUrl;
            }

            /// <summary>
            /// This method to get Zoho CRM API URL.
            /// </summary>
            /// <returns>A String representing the Zoho CRM API URL.</returns>
            public string GetUrl()
            {
                return this.url;
            }

            /// <summary>
            /// This method to get Zoho CRM Accounts URL.
            /// </summary>
            /// <returns>A String representing the accounts URL.</returns>
            public string GetAccountsUrl()
            {
                return this.accountsUrl;
            }

            /// <summary>
            /// This method to get Zoho CRM File Upload URL.
            /// </summary>
            /// <returns>A String representing the FileUpload URL.</returns>
            public string GetFileUploadUrl()
            {
                return this.fileUploadUrl;
            }
        }
    }
}

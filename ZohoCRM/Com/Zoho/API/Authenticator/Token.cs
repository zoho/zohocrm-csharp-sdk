
using Com.Zoho.Crm.API.Util;

namespace Com.Zoho.API.Authenticator
{
    /// <summary>
    /// This interface verifies and sets token to APIHTTPConnector instance.
    /// </summary>
    public interface Token
    {
        /// <summary>
        /// This method to set authentication token to APIHTTPConnector instance.
        /// </summary>
        /// <param name="urlConnection">A APIHTTPConnector class instance.</param>
        void Authenticate(APIHTTPConnector urlConnection);

        /// <summary>
        /// The method to remove the current token from the Store.
        /// </summary>
        /// <returns></returns>
        public bool Remove();
    }
}

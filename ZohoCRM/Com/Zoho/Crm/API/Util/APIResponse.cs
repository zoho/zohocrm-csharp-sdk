using System;

using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class is the common API response object.
    /// </summary>
    /// <typeparam name="T">A T is POJO class type</typeparam>
    public class APIResponse<T>
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        private int statusCode;

        private Model @object;

        private bool isExpected;

        /// <summary>
        /// Creates an APIResponse&lt;T&gt; class instance with the specified parameters.
        /// </summary>
        /// <param name="headers">A Dictionary&lt;string, string&gt; containing the API response headers. </param>
        /// <param name="statusCode">A int containing the API response HTTP status code.</param>
        /// <param name="Object">A object containing the API response POJO class instance.</param>
        /// <param name="exe">A bool containing the API response instance expected type or not.</param>
        public APIResponse(Dictionary<string, string> headers, int statusCode, Model Object,bool exe)
        {
            this.headers = headers;

            this.statusCode = statusCode;

            this.@object = Object;

            this.isExpected = exe;
        }

        /// <summary>
        /// Gets or sets the API response headers.
        /// </summary>
        /// <value>A Dictionary&lt;string, string&gt; containing the API response headers.</value>
        /// <returns>A Dictionary&lt;string, string&gt; representing the API response headers.</returns>
        public Dictionary<string, string> Headers
        {
            get
            {
                return this.headers;
            }
        }

        /// <summary>
        /// This is a getter method to get the API response HTTP status code.
        /// </summary>
        /// <returns>A int representing the API response HTTP status code.</returns>
        public int StatusCode
        {
            get
            {
                return this.statusCode;
            }
        }

        /// <summary>
        /// This is a getter method to get an API response instance that is the expected type or not.
        /// </summary>
        /// <returns>A bool representing the instance is expected type or not.</returns>
        public bool IsExpected
        {
            get
            {
                return this.isExpected;
            }
        }

        /// <summary>
        /// This is a getter method to get the API response Model Interface instance.
        /// </summary>
        /// <returns>A Model Interface instance.</returns>
        public Model Model
        {
            get
            {
                return this.@object;
            }
        }

        /// <summary>
        /// This method to get an API response POJO class instance.
        /// </summary>
        /// <returns>A POJO class instance.</returns>
        public T Object
        {
            get
            {
                try
                {
                    if(@object.GetType() == typeof(T))
                    {
                        return (T)Convert.ChangeType(this.@object, typeof(T));
                    }

                    return (T)@object;
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }
        }
    }
}

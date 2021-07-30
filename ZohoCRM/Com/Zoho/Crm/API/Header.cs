using System;

namespace Com.Zoho.Crm.API
{
    /// <summary>
    /// This class represents the HTTP header.
    /// </summary>
    /// <typeparam name="T">A CSharp DataType</typeparam>
    public class Header<T>
    {
        private string name;

        private string className;

        /// <summary>
        /// Creates an Header class instance with the specified header name.
        /// </summary>
        /// <param name="name">A string containing the header name.</param>
        /// <param name="className"> A string containing the header class name.</param>
        public Header(string name, string className)
        {
            this.name = name;

            this.className = className;
        }

        /// <summary>
        /// This is a getter method to get header name.
        /// </summary>
        /// <returns>A string representing the header name.</returns>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// This is a getter method to get header class name.
        /// </summary>
        /// <returns>A string representing the header class name.</returns>
        public string ClassName
        {
            get
            {
                return this.className;
            }
        }
    }
}

using System;

namespace Com.Zoho.Crm.API
{
    /// <summary>
    /// This class representing the HTTP parameter.
    /// </summary>
    /// <typeparam name="T">A CSharp DataType</typeparam>
    public class Param<T>
    {
        private string name;

        private string className;

        /// <summary>
        /// Creates an Param class instance with the specified parameter name.
        /// </summary>
        /// <param name="name">A string containing the parameter name.</param>
        /// <param name="className"> A string containing the parameter class name.</param>
        public Param(string name, string className)
        {
            this.name = name;

            this.className = className;
        }

        /// <summary>
        /// This is a getter method to get parameter name.
        /// </summary>
        /// <returns>A string representing the parameter name</returns>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// This is a getter method to get parameter class name.
        /// </summary>
        /// <returns>A string representing the parameter class name.</returns>
        public string ClassName
        {
            get
            {
                return this.className;
            }
        }
    }
}

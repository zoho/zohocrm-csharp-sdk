using System;
using System.IO;
using Com.Zoho.API.Exception;

namespace Com.Zoho.Crm.API.Util
{
    /// <summary>
    /// This class handles the file stream and name. 
    /// </summary>
    public class StreamWrapper : Model
    {
        private string name;

        private Stream stream;

        /// <summary>
        /// Creates a StreamWrapper class instance with the specified parameters.
        /// </summary>
        /// <param name="name">A string containing the file name.</param>
        /// <param name="stream">A stream containing the file stream.</param>
        public StreamWrapper(string name, Stream stream)
        {
            this.name = name;

            this.stream = stream;
        }

        /// <summary>
        /// Creates a StreamWrapper class instance with the specified file path.
        /// </summary>
        /// <param name="filePath">A string containing the absolute file path.</param>
        public StreamWrapper(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                this.name = fileInfo.Name;

                this.stream = fileInfo.OpenRead();
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.FILE_ERROR, Constants.FILE_DOES_NOT_EXISTS + " " + filePath, ex);
            }
        }

        /// <summary>
        /// This is a getter method to get the file name.
        /// </summary>
        /// <value>A string representing the file name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// This is a getter method to get the file input stream.
        /// </summary>
        /// <value>A Stream representing the file input stream.</value>
        public Stream Stream
        {
            get
            {
                return this.stream;
            }
        }
    }
}

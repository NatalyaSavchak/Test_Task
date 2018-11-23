using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHierarchyToJSONConverter
{
    /// <summary>
    /// Defines ConvertToJson method exceptions.
    /// </summary>
    public class ConvertToJsonMethodException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of class System.ApplicationException.ConvertToJsonMethodException.
        /// </summary>
        public ConvertToJsonMethodException() { }
        /// <summary>
        /// Initializes a new instance of class System.ApplicationException.ConvertToJsonMethodException 
        /// with the specified error message.
        /// 
        /// Parameters:
        ///     message:
        ///         A message describing the error.
        /// </summary>
        public ConvertToJsonMethodException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of class System.ApplicationException.ConvertToJsonMethodException 
        /// with the specified error message and a link to the internal exception that triggered this exception.
        /// 
        /// Parameters:
        ///     message:
        ///         A message describing the error.
        ///     inner:
        ///         Exception that is the reason for the current exception. If the innerException parameter
        ///         is not a NULL pointer, the current exception occurred in the catch block that is being processed
                ///         internal exception.
        /// </summary>
        public ConvertToJsonMethodException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the System.ApplicationException.ConvertToJsonMethodException class 
        /// with serializations data
        ///
        /// Parameters:
        ///     info:
        ///         Object containing serialized object data.
        ///     context:
        ///         Context information about the source or destination.
        /// </summary>
        protected ConvertToJsonMethodException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

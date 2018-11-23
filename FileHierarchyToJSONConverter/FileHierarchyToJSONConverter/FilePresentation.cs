using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace FileHierarchyToJSONConverter
{
    /// <summary>
    /// Represents a file in the directory. Contains name, size and path of the file.
    /// </summary>
    [DataContract]
    public class FilePresentation
    {
        /// <summary>
        /// Gets the name of a current instance of the FileHierarchy.File class.
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the size of a current instance of the FileHierarchy.File class.
        /// </summary>
        [DataMember]
        public long Size { get; private set; }

        /// <summary>
        /// Gets the path of a current instance of the FileHierarchy.File class.
        /// </summary>
        [DataMember]
        public string Path { get; private set; }

        /// <summary>
        /// Initializes a new instance of the FileHierarchy.File class, which  has initial values by default.
        /// </summary>
        public FilePresentation() { }

        /// <summary>
        /// Initializes a new instance of the FileHierarchy.File class with value in parameters.
        /// 
        /// Parameters:
        ///     name:
        ///         A name of a current instance of the FileHierarchy.File class.
        ///     size:
        ///         A Size of a current instance of the FileHierarchy.File class.
        ///     path:
        ///         A path of a current instance of the FileHierarchy.File class.
        /// </summary>
        public FilePresentation(string name, long size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }
    }
}

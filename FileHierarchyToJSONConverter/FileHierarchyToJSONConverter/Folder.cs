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
    /// Represents the folder in the directory. Contains name, date of creation, inner files and folders of the current folder.
    /// </summary>
    [DataContract]
    public class Folder
    {
        /// <summary>
        /// Gets the name of the current instance of the FileHierarchy.Folder class.
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the date of creation of the current instance of the FileHierarchy.Folder class.
        /// </summary>
        [DataMember]
        public string DateCreated { get; private set; }

        [DataMember]
        private List<FilePresentation> filesList = null;

        [DataMember]
        private List<Folder> foldersList = null;

        /// <summary>
        /// Initializes a new instance of the FileHierarchy.Folder class, which has initial values by default.
        /// </summary>
        public Folder() { }

        /// <summary>
        /// Initializes a new instance of the FileHierarchy.Folder class with value in parameters.
        /// 
        /// Parameters:
        ///     name:
        ///         A name of the current instance of the FileHierarchy.Folder class.
        ///     dateCreated:
        ///         A date of creation of the current instance of the FileHierarchy.Folder class.
        /// </summary>
        public Folder(string name, string dateCreated)
        {
            Name = name;
            DateCreated = dateCreated;
        }

        /// <summary>
        /// Adds another instance of the FileHierarchy.Folder class as a child to the current instance.
        /// 
        /// parameters:
        ///      folder:
        ///         An instance of the FileHierarchy.Folder class, which is need to add to the current 
        ///         instance as a child.
        /// </summary>
        public void AddFolder(Folder folder)
        {
            if (foldersList == null)
            {
                foldersList = new List<Folder>();
            }
            foldersList.Add(folder);
        }

        /// <summary>
        /// Adds the instance of the FileHierarchy.File class to the current instance.
        /// 
        /// parameters:
        ///      file:
        ///         An inctance of the FileHierarchy.File class, which is need to add to the current instance.
        /// </summary>
        public void AddFile(FilePresentation file)
        {
            if (filesList == null)
            {
                filesList = new List<FilePresentation>();
            }
            filesList.Add(file);
        }

        /// <summary>
        /// Converts the directory to JSON format file and saves it in the folder with exe-file of program.
        /// 
        /// parameters:
        ///      path:
        ///         A path to the directory, which has to be converted.
        ///  
        /// exceptions:
        ///      ConvertToJsonMethodException:
        ///         The directory at the specified path does not exist.
        /// 
        /// </summary>
        public static void ToConvertToJson(string path)
        {
            ToConvertToJsonInner(path, "folderHierarchy.json");
        }

        /// <summary>
        /// Converts the directory to JSON format file and saves it in the specified folder.
        /// 
        /// parameters:
        ///      path:
        ///         A path to the directory, which has to be converted.
        ///      destinationPath:
        ///         A path to the directory, where the JSON-file has to be saved.
        ///  
        /// exceptions:
        ///      ConvertToJsonMethodException:
        ///         The directory at the specified path does not exist.
        /// 
        /// </summary>
        public static void ToConvertToJson(string path, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                throw new ConvertToJsonMethodException("The directory for destination of JSON-file at the specified path does not exist!");
            }
            string pathOfJSONFile = destinationPath + "\\folderHierarchy.json";
            ToConvertToJsonInner(path, pathOfJSONFile);
        }

        private static void ToConvertToJsonInner (string path, string pathOfJSONFile)
        {
            Folder folder = ToBuildFileHierarchy(path);
            if (folder != null)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Folder));
                using (FileStream fs = new FileStream(pathOfJSONFile, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, folder);
                }
            }
            else
            {
                throw new ConvertToJsonMethodException("The directory at the specified path, which you want to convert, does not exist!");
            }
        }

        private static Folder ToBuildFileHierarchy(string path)
        {
            if (!Directory.Exists(path))
            {
                return null;
            }
            DirectoryInfo d = new DirectoryInfo(path);
            string name = d.Name;
            string dateCreated = d.CreationTime.ToLongDateString();
            Folder folder = new Folder(name, dateCreated);
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    FileInfo fileInf = new FileInfo(files[i]);
                    folder.AddFile(new FilePresentation(fileInf.Name, fileInf.Length, fileInf.DirectoryName));
                }
            }

            string[] childrenFolders = Directory.GetDirectories(path);
            if (childrenFolders != null)
            {
                for (int i = 0; i < childrenFolders.Length; ++i)
                {
                    folder.AddFolder(ToBuildFileHierarchy(childrenFolders[i]));
                }
            }
            else
            {
                return null;
            }
            return folder;
        }
    }
}


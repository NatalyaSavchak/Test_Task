using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHierarchyToJSONConverter;

namespace Test
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.Write("Enter the directory path...");
            string path = Console.ReadLine();
            Console.WriteLine("By default the the JSON-file will be saved at the folder with .exe file\nof program.");
            Console.WriteLine("To choose the destination folder for saving JSON-file - enter \"1\"");
            Console.WriteLine("To use destination by default - enter \"2\"");
            Console.Write("Choose action...");
            try
            {
                int action = int.Parse(Console.ReadLine());
                try
                {
                    switch (action)
                    {
                        case 1:
                            {
                                Console.Write("Enter the JSON-file destination directory path...");
                                string pathDestination = Console.ReadLine();
                                Folder.ToConvertToJson(path, pathDestination);
                            }
                            break;
                        case 2:
                            {
                                Folder.ToConvertToJson(path);
                            }
                            break;
                        default: Console.WriteLine("You enter uncorrect number of action"); break;
                    }
                    if (action == 1 || action == 2)
                    {
                        Console.WriteLine("File hierarchy representation of the selected path\nis sucssesfully saved in JSON format.");
                    }
                }
                catch (ConvertToJsonMethodException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 1;
        }
    }
}

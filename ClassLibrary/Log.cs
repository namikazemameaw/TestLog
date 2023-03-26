using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary
{
    public class Log
    {
        string _Namespace;
        string _NameMethod;
        string _DirectoryPath;
        string _FirstNamefile;
        public Log(string NamespaceName, string MethodName, string Part, string firstNamefile)
        {
            _Namespace = NamespaceName;
            _NameMethod = MethodName;
            _DirectoryPath = Part;
            _FirstNamefile = firstNamefile;
        }
        public void Info(string message)
        {
            string log = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + "[INFO]" + " " + _NameMethod + " " + _Namespace + " " + ":" + " " + message;


            string fileName = _FirstNamefile + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            // Combine the directory path and file name to create the full file path
            string filePath = Path.Combine(_DirectoryPath, fileName);

            // Check if the file already exists and its size is less than 10MB
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists && fileInfo.Length < 1 * 1024)
            {
                // Append text to the file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(log);
                }
            }
            else if (fileInfo.Exists && fileInfo.Length > 1 * 1024)
            {
                int counter = 2;

                while (fileInfo.Exists)
                {
                    
                    string newfilePath = Path.Combine(_DirectoryPath, _FirstNamefile + DateTime.Now.ToString("yyyyMMdd") +"[" + counter + "]"+ ".txt");
                    FileInfo test = new FileInfo(newfilePath);

                    if (test.Exists && test.Length < 1 * 1024)
                    {
                        using (StreamWriter writer = File.AppendText(newfilePath))
                        {
                            writer.WriteLine(log);
                            break;
                        }
                    }
                    else if (test.Exists && test.Length > 1 * 1024)
                    { 
                        counter++;
                    }
                    else
                    {
                        using (StreamWriter writer = File.AppendText(newfilePath))
                        {
                            writer.WriteLine(log);
                            break;
                        }
                    }
                }
                
            }
            else
            {
                // Create a new file and write text to it
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(log);
                }
            }

            // Display a message to indicate that the file was created or appended to
            // Console.WriteLine($"The file '{filePath}' has been created or appended to.");

        }
        //public string Error(string message)
        //{
        //    string log = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + "[ERROE]" + " " + _NameMethod + " " + _Namespace + " " + ":" + " " + message;

        //    return (log);

        //}
        //public string Debug(string message)
        //{
        //    string log = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + "[DEBUG]" + " " + myNameMethod + " " + myNamespace + " " + ":" + " " + message;

        //    return (log);

        //}


    }


}

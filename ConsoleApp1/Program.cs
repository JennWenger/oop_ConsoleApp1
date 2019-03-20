using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CatchMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a path to browse: ");
            string path = Console.ReadLine();

            // Should handle System.ArugmentException
            // Should also handle System.IO.DirectoryNotFoundException
            // try / catch, or try / finally, or try / catch^n / finally
            //try
            //{
            //    // dangerous stuff
            //}
            //catch
            //{
            //    // handle the exceptions
            //}

            // FROM: "tryf" snippet
            //try
            //{

            //}
            //finally
            //{

            //}

            // FROM: "try" snippet
            //try
            //{

            //}
            //catch (DirectoryNotFoundException)
            //{

            //    throw;
            //}

            StreamWriter logFile = null;
            try
            {
                logFile = new StreamWriter(@"C:\demo\mylog.txt");
                string[] dirs = Directory.EnumerateDirectories(path).ToArray();
                Console.WriteLine("Report for " + path);
                logFile.WriteLine("Report for " + path);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    logFile.WriteLine(dir);
                }
            }
            catch (DirectoryNotFoundException dnf)
            {
                Console.WriteLine(
                    "Directory not found! Message = {0}\nHResult={1:D} (0x{1:X})\nToString={2}",
                    dnf.Message, dnf.HResult, dnf);
                // not yet: throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some other error: message={0},\nToString={1}",
                    ex.Message, ex.ToString());
            }
            finally
            {
                // 1. runs if the entire try{} block contents run successfully.
                // 2. runs if any of the catch blocks had run.
                // do cleanup - closing files, network connections, database connections, etc.
                if (logFile != null)
                    logFile.Close();
            }

            Console.Write("Press any key to exit. ");
            Console.ReadKey();
        }
    }
}

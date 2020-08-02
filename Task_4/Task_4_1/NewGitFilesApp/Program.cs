using NewGitFilesApp.utils;
using System;
using System.Globalization;
using System.IO;

namespace NewGitFilesApp
{
    class Program
    {
        private static string _checker;
        static void Main(string[] args)
        {
            DirectoryInfo folder = new DirectoryInfo(@"C:\temp");

            Console.WriteLine("Enter: \n1. Watching mode \n2. Changing information\n After input press 'Enter'");

            string userChoice = Console.ReadLine();

            if (userChoice.Equals("1"))
            {
                Console.WriteLine("Current folder under watching: ");
                FileWatcher.CheckFolder(folder);
                FileWatcher.Watcher();
            }
            if (userChoice.Equals("2"))
            {
                Console.WriteLine("Information of all chenges. ");
                Backup.DisplayXmlInfo();
                Console.WriteLine("Enter the backup date in format dd.MM.yyyy HH:mm:ss");
                _checker = Console.ReadLine();
                if (DateTime.TryParseExact(_checker, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var inputDate)) 
                {
                    if (Backup.CheckDate(inputDate))
                    {
                        Backup.BackUpMaker(inputDate);
                        Console.WriteLine("Backup has been done");
                    }
                    else
                    {
                        Console.WriteLine("Date has not been found in logs");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect date");
                }
                Console.ReadLine();
            }
        }
    }
}

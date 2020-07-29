using NewGitFilesApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGitFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Backup getFile = new Backup();

            Console.WriteLine("Enter path: ");
            getFile.directory = Console.ReadLine();

            string path = getFile.directory;

            getFile.GetFolder();
            Console.WriteLine("*****************************");

            FileWatcher.Run(path);
        }
    }
}

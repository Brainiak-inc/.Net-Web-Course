using NewGitFilesApp.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGitFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Console.ReadLine();
            FileWatcher.Watcher();
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            FileWatcher.CheckFolder(directoryInfo);
            Console.ReadKey();
        }
    }
}

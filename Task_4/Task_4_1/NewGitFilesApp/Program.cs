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
            FilesGetter getFile = new FilesGetter();

            Console.WriteLine("Enter path: ");
            getFile.directory = Console.ReadLine();
            getFile.GetFolder();    
        }
    }
}

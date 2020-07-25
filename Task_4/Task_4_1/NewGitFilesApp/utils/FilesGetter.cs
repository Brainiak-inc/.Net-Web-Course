using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace NewGitFilesApp.utils
{
    class FilesGetter
    {
        private string _directory { get; set; }

        public string directory
        {
            get
            {
                return _directory;
            }
            set
            {
                _directory = value;
            }
        }
        public void GetFolder()
        {
            if (Directory.Exists(directory))
            {
                Console.WriteLine("Subdirectories: ");
                string[] dirs = Directory.GetDirectories(directory);
                foreach (var item in dirs)
                {
                    Console.WriteLine("\n"+item);
                }
                string[] files = Directory.GetFiles(directory);
                foreach (var item in files)
                {
                    Console.WriteLine("\n"+item);
                }
            }
        }
    }
}

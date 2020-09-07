using System;
using System.Security.Permissions;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace NewGitFilesApp.utils
{
    
    class FileWatcher
    {
        private static FileSystemWatcher _watcher = new FileSystemWatcher();
        private static int _counter = 1;
        private static XDocument _changeReport = new XDocument();
        private static XElement _head = new XElement("ChangeReport");

        public static void CheckFolder(DirectoryInfo directoryInfo)
        {
            foreach (var item in directoryInfo.GetDirectories())
            {
                Console.WriteLine(item.Name);
                CheckFolder(directoryInfo);
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Watcher()
        {
            using (_watcher)
            {
                _watcher.IncludeSubdirectories = true;
                _watcher.Path = @"C:\temp";
                _watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;
                _watcher.Filter = "*.txt";
                _watcher.Changed += OnChanged;
                _watcher.Created += OnChanged;
                _watcher.Deleted += OnChanged;
                _watcher.Renamed += OnRenamed;

                _watcher.EnableRaisingEvents = true;
                Console.WriteLine("Press 'Q' to leave watching mode.\n");

                while (Console.ReadKey().Key != ConsoleKey.Q) ;
                _changeReport.Add(_head);
                _changeReport.Save(@"C:\temp\temp.xml");    
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType.ToString().Equals("Changed"))
            {
                while (true)
                {
                    try
                    {
                        DateTime dt = File.GetLastWriteTime(e.FullPath);

                        using (StreamReader streamReader = new StreamReader(e.FullPath))
                        {
                            if (streamReader != null)
                            {
                                XElement note = new XElement("Note");
                                XElement id = new XElement("ID", _counter);
                                XElement name = new XElement("Name", e.Name);
                                XElement lastWritten = new XElement("LastWritten", dt.ToString("dd.MM.yyyy,HH.mm.ss"));
                                XElement fullPath = new XElement("FullPath", e.FullPath);
                                XElement text = new XElement("Text", streamReader.ReadToEnd());
                                note.Add(id);
                                note.Add(name);
                                note.Add(lastWritten);
                                note.Add(fullPath);
                                note.Add(text);
                                _head.Add(note);
                                _counter++;
                                break;
                            }
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Waiting for the file logging...");
                    }
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine($"File: {e.FullPath} has been to {e.ChangeType.ToString().ToLower()}");
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        }
    }

}

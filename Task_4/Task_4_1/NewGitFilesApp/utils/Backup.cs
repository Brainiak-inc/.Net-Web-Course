using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using System.Globalization;
using System.Security.Permissions;

namespace NewGitFilesApp.utils
{
    
    class Backup
    {
        private static Dictionary<int, Tuple<string, DateTime, string, string>> _dict = new Dictionary<int, Tuple<string, DateTime, string, string>>();

        private static void XmlInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\temp\temp.xml"); 

            XmlNodeList noteList = xmlDoc.GetElementsByTagName("Note");
            foreach (XmlNode note in noteList)
            {
                int id = Int32.Parse(note["ID"].InnerText);
                string name = note["Name"].InnerText;
                DateTime date = DateTime.ParseExact(note["LastWritten"].InnerText, "dd.MM.yyyy,HH.mm.ss", CultureInfo.InvariantCulture);
                string path = note["FullPath"].InnerText;
                string text = note["Text"].InnerText;
                _dict.Add(id, new Tuple<string, DateTime, string, string>(name, date, path, text));

            }
        }
        public static void DisplayXmlInfo()
        {
            XmlInfo();
            for (int i = 0; i < _dict.Count; i++)
            {
                var value = _dict[i + 1];
                Console.WriteLine($"\nNote {_dict.Keys.ElementAt(i)}. \nFilse's name: {value.Item1}. " +
                    $"Changed: {value.Item2}. Path {value.Item3}. Inner text: \n{value.Item4}");
            }
        }
        public static bool CheckDate(DateTime inputDate)
        {
            bool chek = false;
            for (int i = 0; i < _dict.Count; i++)
            {
                if (_dict[i + 1].Item2.Equals(inputDate))
                {
                    chek = true;
                }
            }
            return chek;
        }
        public static void BackUpMaker(DateTime inputDate)
        {
            for (int i = 0; i < _dict.Count; i++)
            {
                if (_dict[i + 1].Item2.Equals(inputDate))
                {
                    using (StreamWriter streamWriter = File.CreateText(_dict[i + 1].Item3)) streamWriter.WriteLine(_dict[i + 1].Item4);
                }
            }
        }
    }
}

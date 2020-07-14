using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Text_analysis
    {
        private Dictionary<string, int> words;
        public Text_analysis(string str)
        {
            words = new Dictionary<string, int>();
            CheckWords(str);
            SetStatus();
        }
        private void CheckWords(string str)
        {
            string[] array = str.ToLower().Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in array)
            {
                if (words.ContainsKey(item))
                {
                    words[item]++;
                }
                else
                {
                    words[item] = 1;
                }
            }
        }
        public void SetStatus()
        {
            double count = words.Sum(d => d.Value);

            if (count / words.Count < 1.2)
            {
                Console.WriteLine("The text is deverse, no repetion.");
            }
            else if (count / words.Count > 1.2)
            {
                Console.WriteLine("The text is monotonous, many repetitions.");
            }
            else if(count / words.Count <= 0)
            {
                Console.WriteLine("No text.");
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in words)
            {
                stringBuilder.AppendLine($"{item.Key} ({item.Value})");
            }
            return stringBuilder.ToString();
        }
    }
}

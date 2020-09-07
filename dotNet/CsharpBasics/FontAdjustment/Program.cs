using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFonts fonts = MyFonts.none;
            while (true)
            {
                
                Console.WriteLine($"Label optins: {fonts}");
                Console.WriteLine("Enter: ");
                Console.WriteLine("\t1: bold");
                Console.WriteLine("\t2: italic");
                Console.WriteLine("\t3: underline");
                int FontNumber = int.Parse(Console.ReadLine());
                switch (FontNumber)
                {
                    case 1:
                        fonts ^= MyFonts.bold;
                        break;
                    case 2:
                        fonts ^= MyFonts.italic;
                        break;
                    case 3:
                        fonts ^= MyFonts.underline;
                        break;
                }
            }
        }
    }
    [Flags]
    public enum MyFonts : byte
    {
        none = 0,
        bold = 1,
        italic = 2,
        underline = 4

    }
}

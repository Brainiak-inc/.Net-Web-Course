using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;

namespace Task_2._1._2_Custom_Paint
{
    class Program
    {
        static Figure figure;
        static User user;
        static void Main(string[] args)
        {
            int userChose;
            bool userChoseValidator;
            bool exit = false;

            user = ValueSetter.constructUser();
            Console.WriteLine(user);


            while (!exit)
            {
                Console.Write("Chose figure: ");
                Console.WriteLine("\n1.Circle \n2.Round \n3.Ring \n4.Rectangle \n5. Line \n6.Square \n7.Triangle \n8.Change user \n9. Exit");
                Console.Write("\nFigure: ");
                userChoseValidator = int.TryParse(Console.ReadLine(), out userChose);

                if (userChoseValidator == false)
                {
                    Console.WriteLine("Enter integer value: ");
                    userChoseValidator = int.TryParse(Console.ReadLine(), out userChose);
                }

                switch (userChose)
                {
                    case 1:
                        figure = ValueSetter.constructCircle();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 2:
                        figure = ValueSetter.constructRound();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 3:
                        figure = ValueSetter.constructRing();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 4:
                        figure = ValueSetter.constructRectangle();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 5:
                        figure = ValueSetter.constructLine();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 6:
                        figure = ValueSetter.constructSquare();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 7:
                        figure = ValueSetter.constructTriangle();
                        Console.WriteLine(figure + "\n");
                        break;
                    case 8:
                        user = ValueSetter.constructUser();
                        Console.WriteLine(user);
                        break;
                    case 9:
                        exit = true;
                        break;
                }
            }
        }
    }
    
}

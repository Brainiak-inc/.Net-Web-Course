using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Task_3
{

    class RussianRoulette
    {
        public void GameLogic()
        {
            while (true)
            {
                int listLenght = 0;
                int number = 0;
                List<int> peopleList = new List<int>();

                Console.Write("Enter number of the people in the circle: ");
                int.TryParse(Console.ReadLine(), out listLenght);



                Console.Write("Enter number of the person, who's gonna be killed each round: ");
                int.TryParse(Console.ReadLine(), out number);

                CreateList(peopleList, listLenght);

                Console.WriteLine($"List of people has been generated: {listLenght}. Each round will be killed every {number} man.");

                DeleteElements(peopleList, number);

                Console.WriteLine("Game over. There's no anymore people to terminate.");

            }
        }
        
         private void CreateList(List<int> peopleList, int length)
         {
            for (int i = 0; i < length; i++)
            {
                peopleList.Add(i);
            }
         }
        private static void DeleteElements<T>(List<T> peopleList, int number)
        {

            for (int round = 0, i = 0, count = 0; number <= peopleList.Count; i++, count++)
            {
                if (count == number -1)
                {
                    round++;
                    peopleList.RemoveAt(i);
                    count = -1;
                    Console.WriteLine($"Round {round}. Killed man. People left {peopleList.Count}");
                }
                if (i >= peopleList.Count - 1)
                {
                    i = -1;
                }
            }
        }
        
    }
}

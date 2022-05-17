using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Input
    {
        public static int TotalPlayers()
        {
            string input = "";
            int Players = 0;
            bool Check = false;
            while (Check == false)
            {
                Console.WriteLine("Please enter the number of player who will be playing in the game? ");
                input = Console.ReadLine();
                Check = int.TryParse(input, out Players);
                if (Check == false)
                {
                    Console.WriteLine("The value inputted was not an integer and therefore is not an accurate number of players. Please enter again. ");
                }
                else if (Check == true)
                {
                    Console.WriteLine("Thank you.");
                }
            }
            return Players;
        }
        public static int TotalScore()
        {
            string input = "";
            int Score = 0;
            bool Check = false;
            while (Check == false)
            {
                Console.WriteLine("Please enter what score you would like to play to. ");
                input = Console.ReadLine();
                Check = int.TryParse(input, out Score);
                if (Check == false)
                {
                    Console.WriteLine("The value inputted was not an integer and therefore is not an accurate score to play to. Please enter again. ");
                }
                else if (Check == true)
                {
                    Console.WriteLine("Thank you.");
                }
            }
            return Score;
        }
        public static void IRoll()
        {
            Console.WriteLine("Press Enter to roll your die: ");
            bool check = false;
            ConsoleKeyInfo cki;
            while (check == false)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please make sure you press the correct key to make your roll:");
                }
            }
            return;
        }
        //Should add more exception handling functions for the other inputs.

        //Could make a function that will take a parameter for the type of input that is needed
        //If that type of input is not made then there will be an error
    }

}

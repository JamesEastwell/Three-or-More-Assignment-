using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Output
    {
        public static void StartGame()
        {
            Console.WriteLine("Hello and welcome to the game Three or More");
            Console.WriteLine("In this game you will be asked to pick a number of players and total score you would like to play to");
            Console.WriteLine("All players will then take turns rolling 5 die and seeing who can match the most amount of die.");
            Console.WriteLine("If a player matches 0 or 1 dice then their turn is over and they get no points.");
            Console.WriteLine("If a player matches 2 die, then the player will get the chance to roll again to match at least 3");
            Console.WriteLine("If a player matches 3 die, then they will get 3 points added to their total");
            Console.WriteLine("If a player matches 4 die, then they will get 6 points added to their total");
            Console.WriteLine("If a player matches all 5 die, then they will get the maximum 12 points added to their total");
            Console.WriteLine("The game will end when anyone of the players reaches the predetermined total");
        }
        public static int NextPlayer(int Counter)
        {
            Counter++;
            Console.WriteLine("Player "+ Counter +" has now completed their turn.");
            return Counter; 
        }
        public static bool EndRound(int[] PlayersScores, int NumPoints)
        {
            bool RoundOver = Game.CheckScore(PlayersScores, NumPoints);
            if (RoundOver == false)
            {
                Console.WriteLine("All players have now completed their turns in this round.");
                Console.WriteLine("Here are the current totals for all the players: ");
                //loop to print all the players scores
                int Counter = 1;
                foreach(int i in PlayersScores)
                {
                    Console.WriteLine("Player " + Counter + ":" + i);
                    Counter++;
                }
            }
            return RoundOver;
        }
        public static void EndGame(int[] PlayersScores, int NumPlayers)
        {

        }
    }
}

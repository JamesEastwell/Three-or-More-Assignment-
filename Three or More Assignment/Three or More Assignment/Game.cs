using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Game
    {
        public static void Run()
        {
            Output.StartGame();
            int NumPlayers =Input.TotalPlayers();
            int NumPoints = Input.TotalScore();
            int[] MatchingDie = new int[2];
            int[] PlayersScores = new int[NumPlayers];
            int[] PlayersDie = new int[5];
            bool GameOver = false;
            while (GameOver == false)
            {
                int Counter = 0;
                while (Counter < NumPlayers)
                {
                    Console.WriteLine("It is now Player " + (Counter+1) + "s turn.");
                    //Roll the Players Die
                    PlayersDie = Die.Roll(PlayersDie, 5);
                    //Check to see how many of the die match and then add the scores for what they rolled
                    MatchingDie = CheckDie(PlayersDie);
                    PlayersScores[Counter] = AddScore(PlayersScores[Counter], MatchingDie, PlayersDie);
                    Counter = Output.NextPlayer(Counter);

                }
                GameOver = Output.EndRound(PlayersScores, NumPoints);
            }
            Output.EndGame(PlayersScores, NumPlayers);
            Console.ReadKey();
        }
        public static int[] CheckDie(int[] PlayersDie)
        {
            int[] MatchingDie = new int[2];
            int Saved = 0;
            int Biggest = 0;
            int[] Matched = new int[6];
            Array.Sort(PlayersDie);
            Console.WriteLine("Die Ordered: " + String.Join(",", PlayersDie));

            foreach(int i in PlayersDie)
            {
                if (i == 1) { Matched[0]++; }
                else if(i == 2) { Matched[1]++; }
                else if(i == 3) { Matched[2]++; }
                else if(i == 4) { Matched[3]++; }
                else if(i == 5) { Matched[4]++; }
                else if(i == 6) { Matched[5]++; }
            }
            for (int i = 0; i < Matched.Length; i++)
            {
                if(Matched[i] > Biggest)
                {
                    Biggest = Matched[i];
                }
            }
            Saved = (Array.IndexOf(Matched, Biggest))+1;
            //Put the two values into a list 
            MatchingDie[0] = Biggest;
            MatchingDie[1] = Saved;
            Console.WriteLine("Matched:" + String.Join(",", Matched));
            Console.WriteLine("MatchingDie:" + String.Join(",", MatchingDie));
            return MatchingDie;
        }
        public static int AddScore(int PlayersScores, int[] MatchingDie, int[] PlayersDie)
        {
            bool check = false;
            while (check == false)
            {
                check = true;
                if (MatchingDie[0] == 2)
                {
                    //reroll
                    check = false;
                    PlayersDie = Die.Reroll(PlayersDie, MatchingDie);
                    MatchingDie = CheckDie(PlayersDie);
                    if(MatchingDie[0] == 2)
                    {
                        return PlayersScores;
                    }
                }
                else if (MatchingDie[0] == 3)
                {
                    PlayersScores = PlayersScores + 3;
                }
                else if (MatchingDie[0] == 4)
                {
                    PlayersScores = PlayersScores + 6;
                }
                else if (MatchingDie[0] == 5)
                {
                    PlayersScores = PlayersScores + 12;
                }
                else
                {
                    Console.WriteLine("Unfortunately you didn't get atleast two matching die.");
                }
            }
            return PlayersScores;
        }
        public static bool CheckScore(int[] PlayersScores, int NumPoints)
        {
            //True means the game is over
            //False means the game should continue
            foreach(int i in PlayersScores)
            {
                if(i == NumPoints)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

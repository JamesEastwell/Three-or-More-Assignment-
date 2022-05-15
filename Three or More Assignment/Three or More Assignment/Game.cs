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
            int[] PlayersScores = new int[NumPlayers];
            int[] PlayersDie = new int[5];
            bool GameOver = false;
            while (GameOver == false)
            {
                int Counter = 0;
                while (Counter < NumPlayers)
                {
                    //Roll the Players Die
                    PlayersDie = Die.Roll(PlayersDie, 5);
                    //Check to see how many of the die match and then add the scores for what they rolled
                    int MatchingDie = Game.CheckDie(PlayersDie);
                    PlayersScores[Counter] = Game.AddScore(PlayersScores[Counter], MatchingDie, PlayersDie);
                    Counter = Output.NextPlayer(Counter);

                }
                Output.EndRound(PlayersScores, NumPoints);
            }
            Output.EndGame(PlayersScores, NumPlayers);
        }
        public static int CheckDie(int[] PlayersDie)
        {
            int MatchingDie = 0;
            foreach (int i in PlayersDie)
            {
                foreach (int j in PlayersDie)
                {
                    if (i == j)
                    {
                        MatchingDie++;
                    }
                }
            }
            return MatchingDie;
        }
        public static int AddScore(int PlayersScores, int MatchingDie, int[] PlayersDie)
        {
            if (MatchingDie == 2)
            {
                //reroll
                PlayersDie = Die.Roll(PlayersDie, 3);
                MatchingDie = Game.CheckDie(PlayersDie);
                if (MatchingDie == 2)
                {
                    return PlayersScores;
                }
                Game.AddScore(PlayersScores, MatchingDie, PlayersDie);
            }
            else if (MatchingDie == 3)
            {
                PlayersScores = PlayersScores + 3;
            }
            else if (MatchingDie == 4)
            {
                PlayersScores = PlayersScores + 6;
            }
            else if (MatchingDie == 5)
            {
                PlayersScores = PlayersScores + 12;
            }
            return PlayersScores;
        }
        public static bool CheckScore(int[] PlayersScores, int NumPoints)
        {
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

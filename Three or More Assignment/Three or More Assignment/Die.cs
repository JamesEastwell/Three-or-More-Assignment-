using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_or_More_Assignment
{
    class Die
    {
        public static int[] Roll(int[] PlayersDie, int NumDie)
        {
            //Create a list with NumDie amount of elements.
            //This allows for if there is a reroll
            int[] RolledDie = new int[5];
            //Then call the RNG for the amount of elements there are in the list 
            Input.IRoll();
            RolledDie = RNG(PlayersDie, NumDie);
            Console.WriteLine("You Rolled: "+ String.Join(",", RolledDie));
            return RolledDie;
        }
        public static int[] Reroll(int[] PlayersDie, int[] MatchingDie)
        {
            for(int i = 0; i < PlayersDie.Length; i++)
            {
                if (PlayersDie[i] < MatchingDie[1])
                {
                    PlayersDie[i] = 0;
                }
                else if (PlayersDie[i] > MatchingDie[1])
                {
                    PlayersDie[i] = 0;
                }
            }
            Array.Sort(PlayersDie);
            Input.IRoll();
            PlayersDie = RNG(PlayersDie, 3);
            Console.WriteLine("PlayersDie: " + String.Join(",", PlayersDie));
            return PlayersDie;
        }
        public static int[] RNG(int[] PlayersDie, int NumDie)
        {
            Random rnd = new Random();
            for(int i = 0; i < NumDie; i++)
            {
                PlayersDie[i] = rnd.Next(1, 7);
            }
            return PlayersDie;
        }
    }
}

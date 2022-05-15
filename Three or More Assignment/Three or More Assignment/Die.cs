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
            RolledDie = Die.RNG(PlayersDie, NumDie);
            foreach(int i in RolledDie) { Console.WriteLine(i); };
            return RolledDie;
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

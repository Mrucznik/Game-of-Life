using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Universe universe = new Universe();

            Random rand = new Random();
            for (int i=25; i<50; i++)
            {
                for(int j = 25; j < 50; j++)
                {
                    universe.setAlive(new Point(i, j), rand.Next(0, 2)==1);
                }
            }

            universe.startGame();
        }
    }
}

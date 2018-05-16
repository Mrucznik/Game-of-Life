using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game_of_Life
{
    public class Universe
    {
        private Dictionary<Point, bool> Map;

        public void setAlive(Point coordinates, bool alive)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if(!Map.ContainsKey(new Point(coordinates.X + i, coordinates.Y + j)))
                    {
                        Map.Add(new Point(coordinates.X + i, coordinates.Y + j), false);
                    }
                }
            }

            Map[coordinates] = alive;
        }

        public bool isAlive(Point coordinates)
        {
            bool value;
            Map.TryGetValue(coordinates, out value);
            return value;
        }

        public int countNeighbourhoods(Point coordinates)
        {
            int neighbourhoods=0;
            for(int i=-1; i<=1; i++)
            {
                for(int j=-1; j<=1; j++)
                {
                    if( !(i==0 && j==0) )
                        neighbourhoods += isAlive(new Point(coordinates.X + i, coordinates.Y + j)) ?1:0;
                }
            }

            return neighbourhoods;
        }

        public void refreshUniverse(Universe newUniverse)
        {
            Map = newUniverse.Map;
        }

        public void nextGeneration()
        {
            Universe newUniverse = new Universe();

            foreach (KeyValuePair<Point, bool> cell in Map)
            {
                int neighbourhoods = countNeighbourhoods(cell.Key);
                if(cell.Value)
                {
                    if (neighbourhoods == 2 || neighbourhoods == 3)
                        newUniverse.setAlive(cell.Key, true); //przetrwanie
                    else
                        newUniverse.setAlive(cell.Key, false); //śmierć
                }
                else
                {
                    if(neighbourhoods == 3)
                        newUniverse.setAlive(cell.Key, true); //narodzenie
                }
            }

            refreshUniverse(newUniverse);
        }

        public void drawUniverse()
        {
            System.Console.Clear();
            foreach (KeyValuePair<Point, bool> cell in Map)
            {
                if ((cell.Key.Y < System.Console.BufferHeight  && cell.Key.Y >= 0) && (cell.Key.X < System.Console.BufferWidth && cell.Key.X >= 0))
                {
                    System.Console.SetCursorPosition(cell.Key.X, cell.Key.Y);
                    if (cell.Value == true)
                    {
                        System.Console.Write("X");
                    }
                }
            }
        }

        public void startGame()
        {
            while (true)
            {
                drawUniverse();
                nextGeneration();
                System.Console.ReadKey();
            }
        }

        //Konstruktor
        public Universe()
        {
            Map = new Dictionary<Point, bool>();
        }
    }
}

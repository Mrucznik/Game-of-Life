using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    public class Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}

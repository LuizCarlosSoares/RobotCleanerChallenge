using System;
using System.Diagnostics;
namespace Office
{
    [DebuggerDisplay("({X}, {Y})")]
    public struct Coordinate : IEquatable<Coordinate>
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.X + b.X, a.Y + b.Y);
        }

        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.X - b.X, a.Y - b.Y);
        }
        public override bool Equals(object obj)
        {
            if (obj is Coordinate)
            {
                return Equals((Coordinate)obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * X.GetHashCode();
            hash = hash * Y.GetHashCode();
            return hash;
        }

        public bool Equals(Coordinate other)
        {
            return other.X == X && other.Y == Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
using System;
using System.Diagnostics;

namespace Office
{
[DebuggerDisplay("Location: {Location}, Cost: {Cost}")]

    public sealed class OfficeTile : IEquatable<OfficeTile>
    {
        internal OfficeTile(Coordinate location, int? cost = null)
        {
            Location = location;
            Cost = cost;
        }

        internal Coordinate Location { get; }

        internal int? Cost { get; }

        public bool Equals(OfficeTile other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return Location.Equals(other.Location) && Cost == other.Cost;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OfficeTile);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * Location.GetHashCode();
            hash = hash * Cost.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"Location: {Location}, Cost: {Cost}";
        }
    }
}
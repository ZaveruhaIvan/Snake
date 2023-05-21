using System;

namespace DataStructures
{
    public readonly struct GridPosition
    {
        public int X { get; }
        public int Y { get; }
        
        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static GridPosition operator +(GridPosition a, MoveDirection b) => new(a.X + b.X, a.Y + b.Y);
        public static bool operator ==(GridPosition a, GridPosition b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(GridPosition a, GridPosition b) => !(a == b);

        public override int GetHashCode() => 
            HashCode.Combine(X, Y);

        public override bool Equals(object obj) => 
            obj is GridPosition other && Equals(other);

        private bool Equals(GridPosition other) => 
            this == other;
    }
}
namespace DataStructures
{
    public class MoveDirection
    {
        public static readonly MoveDirection Up = new(0, 1);
        public static readonly MoveDirection Right = new(1, 0);
        public static readonly MoveDirection Down = new(0, -1);
        public static readonly MoveDirection Left = new(-1, 0);
        
        public int X { get; }
        public int Y { get; }

        private MoveDirection(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
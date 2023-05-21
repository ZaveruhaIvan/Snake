using DataStructures;

namespace Game
{
    public static class GameConfig
    {
        public const int GameFieldLength = 12;
        public const int GameFieldHeight = 7;
        
        public static readonly MoveDirection StartMoveDirection = MoveDirection.Right;
        public static readonly (GridPosition head, GridPosition body, GridPosition tail) StartSnakePositions = (new GridPosition(2, 2), new GridPosition(1, 2), new GridPosition(0, 2));

        public const float GameUpdateTs = 0.2f;
    }
}
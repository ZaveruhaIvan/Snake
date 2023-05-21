using DataStructures;
using GameInput;
using Grid;
using Snake;

namespace Game
{
    public interface IGameModel
    {
        bool IsGameOver { get; }
        GridPosition FoodPosition { get; }
        IGameInput GameInput { get; }
        IGridModel GridModel { get; }
        ISnakeModel SnakeModel { get; }
        void Update();
        void Disable();
    }
}
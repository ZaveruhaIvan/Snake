using DataStructures;
using GameInput;
using GameServices;
using Grid;
using Node;
using Snake;

namespace Game
{
    public class GameModel : IGameModel
    {
        public bool IsGameOver { get; private set; }
        public IGameInput GameInput { get; }
        public IGridModel GridModel { get; }
        public ISnakeModel SnakeModel { get; }
        public GridPosition FoodPosition { get; private set; }

        private bool _isDisabled;

        public GameModel(IServices services)
        {
            GameInput = services.ApplicationType == ApplicationType.Mobile ? new MobileGameInput(GameConfig.StartMoveDirection) : new PcGameInput(GameConfig.StartMoveDirection);
            GridModel = new GridModel(GameConfig.GameFieldLength, GameConfig.GameFieldHeight, GameConfig.StartSnakePositions);
            SnakeModel = new SnakeModel(GameConfig.StartSnakePositions.head, GameConfig.StartSnakePositions.body, GameConfig.StartSnakePositions.tail);
            
            FoodPosition = GridModel.GetRandomEmptyPosition();
            GridModel.SetNode(FoodPosition, NodeType.Food);
        }

        public void Update()
        {
            if (_isDisabled)
            {
                return;
            }
            
            var newSnakeHeadPosition = SnakeModel.HeadGridPosition + GameInput.MoveDirection;
            var newGridNode = GridModel.GetNode(newSnakeHeadPosition);

            if (newSnakeHeadPosition == SnakeModel.TailGridPosition || newGridNode == NodeType.Empty)
            {
                GridModel.SetNode(SnakeModel.TailGridPosition, NodeType.Empty);
                SnakeModel.RemoveTail();

                GridModel.SetNode(newSnakeHeadPosition, NodeType.Snake);
                SnakeModel.AddHead(newSnakeHeadPosition);
            }

            if (newGridNode is NodeType.Outside or NodeType.Snake)
            {
                IsGameOver = true;
                return;
            }

            if (newGridNode == NodeType.Food)
            {
                GridModel.SetNode(newSnakeHeadPosition, NodeType.Snake);
                SnakeModel.AddHead(newSnakeHeadPosition);

                FoodPosition = GridModel.GetRandomEmptyPosition();
                GridModel.SetNode(FoodPosition, NodeType.Food);
            }
            
            GameInput.IsChangedInCurrentTick = false;
        }

        public void Disable()
        {
            _isDisabled = true;
        }
    }
}
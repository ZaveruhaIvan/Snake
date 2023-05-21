using Core.Updater;
using DataStructures;
using Game;
using GameServices;
using GameServices.NodePositionProvider;
using UnityEngine;

namespace Food
{
    public class FoodUpdater : IUpdater
    {
        private readonly IGameModel _gameModel;
        private readonly FoodView _foodView;
        private readonly Vector2 _nodeColliderSize;
        private readonly INodePositionProvider _nodePositionProvider;

        private GridPosition _foodGridPosition;
        
        public FoodUpdater(IGameModel gameModel, IServices services)
        {
            _gameModel = gameModel;
            _foodView = services.ViewGenerator.GenerateView(services.Assets.FoodView);
            _nodeColliderSize = services.Assets.NodeView.ColliderSize;
            _nodePositionProvider = services.NodePositionProvider;

            UpdateFoodPosition(_gameModel.FoodPosition);
        }
        
        public void Update(float ts)
        {
            var foodGridPosition = _gameModel.FoodPosition;

            if (foodGridPosition != _foodGridPosition)
            {
                UpdateFoodPosition(foodGridPosition);
            }
        }

        private void UpdateFoodPosition(GridPosition foodGridPosition)
        {
            var position2D = _nodePositionProvider.GetNodePosition(_nodeColliderSize.x, _nodeColliderSize.y, _gameModel.FoodPosition, _gameModel.GridModel);
            _foodView.SetPosition(position2D);

            _foodGridPosition = foodGridPosition;
        }
    }
}
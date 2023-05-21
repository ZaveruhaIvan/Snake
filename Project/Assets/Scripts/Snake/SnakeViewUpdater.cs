using System.Collections.Generic;
using System.Linq;
using Core.DisposableRegistrar;
using Core.Updater;
using DataStructures;
using Game;
using GameServices;
using GameServices.NodePositionProvider;
using GameServices.ViewPool;
using Grid;
using Node;

namespace Snake
{
    public class SnakeViewUpdater : IUpdater
    {
        private readonly ISnakeModel _snakeModel;
        private readonly IGridModel _gridModel;
        private readonly ViewPool<SnakeElementView> _snakeElementViewPool;
        private readonly INodePositionProvider _nodePositionProvider;
        private readonly NodeView _nodeAsset;
        private readonly List<SnakeElementView> _snakeElementViews;

        public SnakeViewUpdater(IGameModel gameModel, IServices services, IDisposableRegistrar disposableRegistrar)
        {
            _snakeModel = gameModel.SnakeModel;
            _gridModel = gameModel.GridModel;
            _snakeElementViewPool = services.SnakeElementViewPool;
            _nodePositionProvider = services.NodePositionProvider;
            _nodeAsset = services.Assets.NodeView;
            _snakeElementViews = new List<SnakeElementView>();

            InitSnakeElementViews();
            
            disposableRegistrar.Register(() =>
            {
                foreach (var snakeElementView in _snakeElementViews.Where(snakeElementView => snakeElementView != null))
                {
                    _snakeElementViewPool.Release(snakeElementView);
                }
            });
        }

        public void Update(float ts)
        {
            foreach (var snakeElementView in _snakeElementViews)
            {
                _snakeElementViewPool.Release(snakeElementView);
            }
            
            _snakeElementViews.Clear();

            foreach (var snakeGridPosition in _snakeModel.SnakeGridPositions)
            {
                AddNewSnakeElementView(snakeGridPosition);
            }
        }

        private void InitSnakeElementViews()
        {
            foreach (var snakeGridPosition in _snakeModel.SnakeGridPositions)
            {
                AddNewSnakeElementView(snakeGridPosition);
            }
        }

        private void AddNewSnakeElementView(GridPosition snakeHeadPosition)
        {
            var position2D = _nodePositionProvider.GetNodePosition(_nodeAsset.ColliderSize.x, _nodeAsset.ColliderSize.y, snakeHeadPosition, _gridModel);
            var snakeElementView = _snakeElementViewPool.GetView();
            
            snakeElementView.SetPosition(position2D);
            _snakeElementViews.Add(snakeElementView);
        }
    }
}
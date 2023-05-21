using System.Collections.Generic;
using Core.DisposableRegistrar;
using Core.Updater;
using Food;
using GameServices;
using Grid;
using Snake;
using Views;

namespace Game
{
    public class GameUpdater : IUpdater
    {
        private readonly IUpdater _updaters;

        public GameUpdater(IGameModel gameModel, IServices services, GameOverView gameOverView, IDisposableRegistrar disposableRegistrar)
        {
            var unused = new GridUpdater(gameModel.GridModel, services);
            
            _updaters = new MultiUpdater(new List<IUpdater>
            {
                new GameModelUpdater(gameModel),
                new FoodUpdater(gameModel, services),
                new SnakeViewUpdater(gameModel, services, disposableRegistrar),
                new IsGameOverUpdater(gameModel, gameOverView),
            });
        }
        
        public void Update(float ts)
        {
            _updaters.Update(ts);
        }
    }
}
using Core.Updater;

namespace Game
{
    public class GameModelUpdater : IUpdater
    {
        private readonly IGameModel _gameModel;

        public GameModelUpdater(IGameModel gameModel)
        {
            _gameModel = gameModel;
        }
        
        public void Update(float ts)
        {
            _gameModel.Update();
        }
    }
}
using Core.Updater;
using GameInput;
using Views;

namespace Game
{
    public class IsGameOverUpdater : IUpdater
    {
        private readonly IGameModel _gameModel;
        private readonly IGameInput _gameInput;
        private readonly GameOverView _gameOverView;

        private bool _isGameOver;

        public IsGameOverUpdater(IGameModel gameModel, GameOverView gameOverView)
        {
            _gameModel = gameModel;
            _gameInput = _gameModel.GameInput;
            _gameOverView = gameOverView;

            _isGameOver = _gameModel.IsGameOver;
        }
        
        public void Update(float ts)
        {
            var isGameOver = _gameModel.IsGameOver;

            if (isGameOver != _isGameOver)
            {
                if (isGameOver)
                {
                    _gameInput.Disable();
                    _gameModel.Disable();
                    _gameOverView.PlayAnim();
                }
                
                _isGameOver = isGameOver;
            }
        }
    }
}
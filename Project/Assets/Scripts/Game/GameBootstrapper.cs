using Core.DisposableRegistrar;
using Core.Updater;
using GameInput;
using GameServices;
using UnityEngine;
using Views;

namespace Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const float DefaultCounter = 0f;

        [SerializeField] private BackgroundBorderView _backgroundBorderView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private MobileInputView _mobileInputView;

        private readonly IDisposableRegistrar _disposableRegistrar = new DisposableRegistrar();
        
        private IUpdater _gameUpdater;
        private IUpdater _gameInputUpdater;
        private ApplicationType _applicationType;
        private float _counter;

        private void Start()
        {
            _backgroundBorderView.SetScale();
            
            var services = Project.Instance.Services;
        
            IGameModel gameModel = new GameModel(services);
            _gameUpdater = new GameUpdater(gameModel, services, _gameOverView, _disposableRegistrar);
            _applicationType = services.ApplicationType;
            
            if (_applicationType == ApplicationType.Mobile)
            {
                _mobileInputView.Construct(gameModel.GameInput).Enable();
            }
            else
            {
                _gameInputUpdater = new PcGameInputUpdater(gameModel.GameInput);
            }
        }
    
        private void Update()
        {
            if (_applicationType == ApplicationType.Pc)
            {
                _gameInputUpdater.Update(GameConfig.GameUpdateTs);
            }
            
            _counter += Time.deltaTime;

            if (_counter >= GameConfig.GameUpdateTs)
            {
                _gameUpdater.Update(GameConfig.GameUpdateTs);
                _counter = DefaultCounter;
            }
        }

        private void OnDestroy()
        {
            _disposableRegistrar.Dispose();
        }
    }
}
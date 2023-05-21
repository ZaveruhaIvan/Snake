using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _quitButton.onClick.AddListener(Quit);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(Restart);
            _quitButton.onClick.RemoveListener(Quit);
        }

        public void PlayAnim()
        {
            _animation.Play();
        }

        private static void Restart() => 
            Project.Instance.Services.SceneLoader.LoadGameScene();

        private static void Quit() => 
            Project.Instance.Services.SceneLoader.LoadStartMenuScene();
    }
}
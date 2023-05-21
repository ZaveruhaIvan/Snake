using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainMenuCanvasView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(Play);
            _quitButton.onClick.AddListener(Quit);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(Play);
            _quitButton.onClick.RemoveListener(Quit);
        }

        private static void Play()
        {
            Project.Instance.Services.SceneLoader.LoadGameScene();
        }

        private static void Quit()
        {
            Application.Quit();
        }
    }
}
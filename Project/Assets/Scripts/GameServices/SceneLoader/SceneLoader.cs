using UnityEngine.SceneManagement;

namespace GameServices.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private const string StartMenu = "StartMenu";
        private const string Game = "Game";

        public void LoadStartMenuScene()
        {
            SceneManager.LoadScene(StartMenu);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(Game);
        }
    }
}
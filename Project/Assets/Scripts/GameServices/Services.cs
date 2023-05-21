using Game;
using GameServices.NodePositionProvider;
using GameServices.SceneLoader;
using GameServices.ViewGenerator;
using GameServices.ViewPool;
using Snake;
using UnityEngine;

namespace GameServices
{
    public class Services : IServices
    {
        public Assets.Assets Assets { get; }
        public INodePositionProvider NodePositionProvider { get; }
        public IViewGenerator ViewGenerator { get; }
        public ViewPool<SnakeElementView> SnakeElementViewPool { get; }
        public ISceneLoader SceneLoader { get; }
        public ApplicationType ApplicationType { get; }

        public Services(Assets.Assets assets)
        {
            Assets = assets;

            NodePositionProvider = new NodePositionProvider.NodePositionProvider();
            ViewGenerator = new ViewGenerator.ViewGenerator();
            SnakeElementViewPool = new ViewPool<SnakeElementView>(GameConfig.GameFieldHeight * GameConfig.GameFieldLength / 2, Assets.SnakeElementView, ViewGenerator);
            SceneLoader = new SceneLoader.SceneLoader();

            ApplicationType = Application.platform switch
            {
                RuntimePlatform.IPhonePlayer => ApplicationType.Mobile,
                RuntimePlatform.Android => ApplicationType.Mobile,
                _ => ApplicationType.Pc
            };
        }
    }
}
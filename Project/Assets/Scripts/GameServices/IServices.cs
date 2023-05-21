using GameServices.NodePositionProvider;
using GameServices.SceneLoader;
using GameServices.ViewGenerator;
using GameServices.ViewPool;
using Snake;

namespace GameServices
{
    public interface IServices
    {
        Assets.Assets Assets { get; }
        INodePositionProvider NodePositionProvider { get; }
        IViewGenerator ViewGenerator { get; }
        ViewPool<SnakeElementView> SnakeElementViewPool { get; }
        ISceneLoader SceneLoader { get; }
        ApplicationType ApplicationType { get; }
    }
}
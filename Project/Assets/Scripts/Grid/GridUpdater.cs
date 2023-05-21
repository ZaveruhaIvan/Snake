using DataStructures;
using GameServices;

namespace Grid
{
    public class GridUpdater
    {
        public GridUpdater(IGridModel gridModel, IServices services)
        {
            var nodeViewAsset = services.Assets.NodeView;

            for (var x = 0; x < gridModel.Length; x++)
            for (var y = 0; y < gridModel.Height; y++)
            {
                var nodeView = services.ViewGenerator.GenerateView(nodeViewAsset);
                var position2D = services.NodePositionProvider.GetNodePosition(nodeViewAsset.ColliderSize.x, nodeViewAsset.ColliderSize.y, new GridPosition(x, y), gridModel);
                nodeView.SetPosition(position2D);
            }
        }
    }
}
using DataStructures;
using Grid;

namespace GameServices.NodePositionProvider
{
    public class NodePositionProvider : INodePositionProvider
    {
        public Position2D GetNodePosition(float nodeColliderLength, float nodeColliderHeight, GridPosition gridPosition, IGridModel gridModel)
        {
            var offset = GetOffset(nodeColliderLength, nodeColliderHeight, gridModel);
            var x = GetPositionItem(offset.x, gridPosition.X, nodeColliderLength);
            var y = GetPositionItem(offset.y, gridPosition.Y, nodeColliderHeight);

            return new Position2D(x, y);
        }

        private static (float x, float y) GetOffset(float colliderLength, float colliderHeight, IGridModel gridModel)
        {
            var xOffset = GetOffsetItem(gridModel.Length, colliderLength);
            var yOffset = GetOffsetItem(gridModel.Height, colliderHeight);

            return (-xOffset, -yOffset);
        }
        
        private static float GetOffsetItem(int gridSizeItem, float colliderSizeItem) =>
            (gridSizeItem - 1) * colliderSizeItem / 2f;

        private static float GetPositionItem(float originItem, int coordItem, float colliderSizeItem) => 
            originItem + coordItem * colliderSizeItem;
    }
}
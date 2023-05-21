using DataStructures;
using Grid;

namespace GameServices.NodePositionProvider
{
    public interface INodePositionProvider
    {
        Position2D GetNodePosition(float nodeColliderLength, float nodeColliderHeight, GridPosition gridPosition, IGridModel gridModel);
    }
}
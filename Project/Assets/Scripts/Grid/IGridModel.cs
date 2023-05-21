using DataStructures;
using Node;

namespace Grid
{
    public interface IGridModel
    {
        int Length { get; }
        int Height { get; }
        NodeType GetNode(GridPosition gridPosition);
        void SetNode(GridPosition gridPosition, NodeType nodeType);
        GridPosition GetRandomEmptyPosition();
    }
}
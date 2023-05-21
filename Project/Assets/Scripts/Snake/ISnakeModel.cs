using System.Collections.Generic;
using DataStructures;

namespace Snake
{
    public interface ISnakeModel
    {
        IEnumerable<GridPosition> SnakeGridPositions { get; }
        GridPosition HeadGridPosition { get; }
        GridPosition TailGridPosition { get; }
        void AddHead(GridPosition headGridPosition);
        void RemoveTail();
    }
}
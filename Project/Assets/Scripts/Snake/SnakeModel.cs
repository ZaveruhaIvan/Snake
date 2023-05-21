using System.Collections.Generic;
using DataStructures;

namespace Snake
{
    public class SnakeModel : ISnakeModel
    {
        public IEnumerable<GridPosition> SnakeGridPositions => _snakeGridPositions;
        public GridPosition HeadGridPosition => _snakeGridPositions.First.Value;
        public GridPosition TailGridPosition => _snakeGridPositions.Last.Value;
        
        private readonly LinkedList<GridPosition> _snakeGridPositions;

        public SnakeModel(GridPosition headGridPosition, GridPosition bodyGridPosition, GridPosition tailGridPosition)
        {
            _snakeGridPositions = new LinkedList<GridPosition>();
            _snakeGridPositions.AddFirst(tailGridPosition);
            _snakeGridPositions.AddFirst(bodyGridPosition);
            _snakeGridPositions.AddFirst(headGridPosition);
        }

        public void AddHead(GridPosition headGridPosition)
        {
            _snakeGridPositions.AddFirst(headGridPosition);
        }

        public void RemoveTail()
        {
            _snakeGridPositions.RemoveLast();
        }
    }
}
using System.Collections.Generic;
using DataStructures;
using Node;
using UnityEngine;

namespace Grid
{
    public class GridModel : IGridModel
    {
        private const int MinGridNodeIndex = 0;
        
        public int Length { get; }
        public int Height { get; }

        private readonly NodeType[,] _field;

        public GridModel(int length, int height, (GridPosition head, GridPosition body, GridPosition tail) snakePositions)
        {
            Length = length;
            Height = height;

            _field = new NodeType[Length, Height];

            _field[snakePositions.tail.X, snakePositions.tail.Y] = NodeType.Snake;
            _field[snakePositions.body.X, snakePositions.body.Y] = NodeType.Snake;
            _field[snakePositions.head.X, snakePositions.head.Y] = NodeType.Snake;
        }

        public NodeType GetNode(GridPosition gridPosition)
        {
            var insideGrid = gridPosition.X >= MinGridNodeIndex && gridPosition.X < Length && gridPosition.Y >= MinGridNodeIndex && gridPosition.Y < Height;
            return insideGrid ? _field[gridPosition.X, gridPosition.Y] : NodeType.Outside;
        }

        public void SetNode(GridPosition gridPosition, NodeType nodeType)
        {
            _field[gridPosition.X, gridPosition.Y] = nodeType;
        }

        public GridPosition GetRandomEmptyPosition()
        {
            var empty = new List<GridPosition>();
            
            for (var x = 0; x < Length; x++)
            for (var y = 0; y < Height; y++)
            {
                if (_field[x, y] == NodeType.Empty)
                {
                    empty.Add(new GridPosition(x, y));
                }
            }

            return empty[Random.Range(0, empty.Count)];
        }
    }
}
using DataStructures;
using GameServices.ViewGenerator;
using GameServices.ViewPool;
using UnityEngine;

namespace Snake
{
    public class SnakeElementView : MonoBehaviour, IPooledRelease
    {
        public void SetPosition(Position2D position2D)
        {
            transform.position = new Vector3(position2D.X, position2D.Y, transform.position.z);
        }

        public void Release()
        {
            var position2D = new Position2D(ViewGenerator.DefaultSpawnPosition.x, ViewGenerator.DefaultSpawnPosition.y);
            SetPosition(position2D);
        }
    }
}
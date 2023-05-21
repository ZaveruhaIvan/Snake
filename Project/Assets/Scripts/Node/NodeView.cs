using DataStructures;
using UnityEngine;

namespace Node
{
    public class NodeView : MonoBehaviour
    {
        public Vector2 ColliderSize => _spriteRenderer.sprite.bounds.size;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetPosition(Position2D position2D)
        {
            transform.position = new Vector3(position2D.X, position2D.Y, transform.position.z);
        }
    }
}
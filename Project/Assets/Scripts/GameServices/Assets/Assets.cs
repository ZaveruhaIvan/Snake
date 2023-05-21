using Food;
using Node;
using Snake;
using UnityEngine;

namespace GameServices.Assets
{
    public class Assets : MonoBehaviour
    {
        [field: SerializeField] public SnakeElementView SnakeElementView { get; private set; }
        [field: SerializeField] public NodeView NodeView { get; private set; }
        [field: SerializeField] public FoodView FoodView { get; private set; }
    }
}
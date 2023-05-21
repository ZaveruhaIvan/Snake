using DataStructures;
using UnityEngine;

namespace Food
{
    public class FoodView : MonoBehaviour
    {
        public void SetPosition(Position2D position2D)
        {
            transform.position = new Vector3(position2D.X, position2D.Y, transform.position.z);
        }
    }
}
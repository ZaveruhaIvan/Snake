using UnityEngine;

namespace Views
{
    public class RotationView : MonoBehaviour
    {
        private const float ZeroRotation = 0f;
    
        [SerializeField, Header("Settings")] private float _rotationSpeed;
        [SerializeField, Header("Refs")] private Transform _rotatedObject;

        private void Update()
        {
            _rotatedObject.Rotate(ZeroRotation, ZeroRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
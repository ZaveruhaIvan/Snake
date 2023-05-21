using Game;
using UnityEngine;

namespace Views
{
    public class BackgroundBorderView : MonoBehaviour
    {
        private const int Offset = 2;
    
        public void SetScale()
        {
            var colliderSize = Project.Instance.Services.Assets.NodeView.ColliderSize;
            var newX = (GameConfig.GameFieldLength + Offset) * colliderSize.x;
            var newY = (GameConfig.GameFieldHeight + Offset) * colliderSize.y;

            transform.localScale = new Vector3(newX, newY, transform.localScale.z);
        }
    }
}
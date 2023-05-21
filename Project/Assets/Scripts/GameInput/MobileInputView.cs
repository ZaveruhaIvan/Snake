using DataStructures;
using UnityEngine;
using UnityEngine.UI;

namespace GameInput
{
    public class MobileInputView : MonoBehaviour
    {
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _downButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private Button _leftButton;

        private IGameInput _gameInput;
        private bool _isConstructed;
        
        public MobileInputView Construct(IGameInput gameInput)
        {
            if (_isConstructed) return this; _isConstructed = true;

            _gameInput = gameInput;
            return this;
        }
        
        private void Awake()
        {
            _upButton.onClick.AddListener(Up);
            _downButton.onClick.AddListener(Down);
            _rightButton.onClick.AddListener(Right);
            _leftButton.onClick.AddListener(Left);
        }

        private void OnDestroy()
        {
            _upButton.onClick.RemoveListener(Up);
            _downButton.onClick.RemoveListener(Down);
            _rightButton.onClick.RemoveListener(Right);
            _leftButton.onClick.RemoveListener(Left);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void Up()
        {
            if (!_isConstructed || _gameInput.IsChangedInCurrentTick || GetIsVerticalMovement(_gameInput.MoveDirection))
            {
                return;
            }

            _gameInput.MoveDirection = MoveDirection.Up;
            _gameInput.IsChangedInCurrentTick = true;
        }
        
        private void Down()
        {
            if (!_isConstructed || _gameInput.IsChangedInCurrentTick || GetIsVerticalMovement(_gameInput.MoveDirection))
            {
                return;
            }

            _gameInput.MoveDirection = MoveDirection.Down;
            _gameInput.IsChangedInCurrentTick = true;
        }
        
        private void Right()
        {
            if (!_isConstructed || _gameInput.IsChangedInCurrentTick || GetIsHorizontalMovement(_gameInput.MoveDirection))
            {
                return;
            }

            _gameInput.MoveDirection = MoveDirection.Right;
            _gameInput.IsChangedInCurrentTick = true;
        }
        
        private void Left()
        {
            if (!_isConstructed || _gameInput.IsChangedInCurrentTick || GetIsHorizontalMovement(_gameInput.MoveDirection))
            {
                return;
            }

            _gameInput.MoveDirection = MoveDirection.Left;
            _gameInput.IsChangedInCurrentTick = true;
        }

        private static bool GetIsVerticalMovement(MoveDirection moveDirection) => 
            moveDirection == MoveDirection.Down || moveDirection == MoveDirection.Up;
        
        private bool GetIsHorizontalMovement(MoveDirection moveDirection) => 
            moveDirection == MoveDirection.Right || moveDirection == MoveDirection.Left;
    }
}
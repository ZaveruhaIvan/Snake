using Core.Updater;
using DataStructures;
using UnityEngine;

namespace GameInput
{
    public class PcGameInputUpdater : IUpdater
    {
        private readonly IGameInput _gameInput;

        public PcGameInputUpdater(IGameInput gameInput)
        {
            _gameInput = gameInput;
        }
        
        public void Update(float ts)
        {
            if (_gameInput.IsDisabled || _gameInput.IsChangedInCurrentTick)
            {
                return;
            }
            
            var isUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            var isRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            var isDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            var isLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            
            var moveDirection = _gameInput.MoveDirection;
            var isNotVerticalMovement = moveDirection != MoveDirection.Down && moveDirection != MoveDirection.Up;
            var isNotHorizontalMovement = moveDirection != MoveDirection.Right && moveDirection != MoveDirection.Left;

            if (isUp && isNotVerticalMovement)
            {
                _gameInput.MoveDirection = MoveDirection.Up;
                _gameInput.IsChangedInCurrentTick = true;
            }
            else if (isRight && isNotHorizontalMovement)
            {
                _gameInput.MoveDirection = MoveDirection.Right;
                _gameInput.IsChangedInCurrentTick = true;
            }
            else if (isDown && isNotVerticalMovement)
            {
                _gameInput.MoveDirection = MoveDirection.Down;
                _gameInput.IsChangedInCurrentTick = true;
            }
            else if (isLeft && isNotHorizontalMovement)
            {
                _gameInput.MoveDirection = MoveDirection.Left;
                _gameInput.IsChangedInCurrentTick = true;
            }
        }
    }
}
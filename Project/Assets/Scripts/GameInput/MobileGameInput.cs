using DataStructures;

namespace GameInput
{
    public class MobileGameInput : IGameInput
    {
        public bool IsDisabled { get; private set; }
        public bool IsChangedInCurrentTick { get; set; }
        public MoveDirection MoveDirection { get; set; }

        public MobileGameInput(MoveDirection moveDirection)
        {
            MoveDirection = moveDirection;
        }

        public void Disable()
        {
            IsDisabled = true;
        }
    }
}
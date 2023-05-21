using DataStructures;

namespace GameInput
{
    public interface IGameInput
    {
        bool IsDisabled { get; }
        bool IsChangedInCurrentTick { get; set; }
        MoveDirection MoveDirection { get; set; }
        void Disable();
    }
}

namespace Game.Model.Criminal.State
{
    public interface ICriminalState
    {
        CriminalState State { get; }
        void Enter();
        void Exit();
    }

    public enum CriminalState
    {
        Idle,
        MoveToCenter,
        ScanningFront,
        ScanningBack,
        GoOut
    }
}
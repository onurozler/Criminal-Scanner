using System;
using Game.Model.HiddenObject;

namespace Game.Model.Player
{
    public interface IPlayerData
    {
        int CollectedCount { get; }
        float Process { get; }
        PlayerState State { get; set; }
        
        event Action<float> OnHiddenObjectProcess;
        event Action<IHiddenObject> OnHiddenObjectFound;
        event Action<PlayerState> OnStateChanged;

        void SetProcess(float process);
        void AddHiddenObject(IHiddenObject hiddenObject);
        void Reset();
    }

    public enum PlayerState
    {
        None,
        Scanning
    }
}

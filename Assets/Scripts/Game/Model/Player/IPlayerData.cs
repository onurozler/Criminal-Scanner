using System;
using Game.Model.HiddenObject;

namespace Game.Model.Player
{
    public interface IPlayerData
    {
        float Process { get; }
        event Action<float> OnHiddenObjectProcess;
        event Action<IHiddenObject> OnHiddenObjectFound;
        event Action<PlayerState> OnStateChanged;

        void SetProcess(float process);
        void AddHiddenObject(IHiddenObject hiddenObject);
        PlayerState State { get; set; }
    }

    public enum PlayerState
    {
        None,
        Scanning
    }
}

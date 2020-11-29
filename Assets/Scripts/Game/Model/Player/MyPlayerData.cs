using System;
using Game.Model.HiddenObject;

namespace Game.Model.Player
{
    public class MyPlayerData : IPlayerData
    {
        private float _process;
        private PlayerState _playerState;
        private int _collected;

        public int CollectedCount => _collected;
        public float Process => _process;

        public PlayerState State
        {
            get => _playerState;
            set
            {
                _playerState = value;
                OnStateChanged?.Invoke(_playerState);
            }
        }
        public event Action<float> OnHiddenObjectProcess;
        public event Action<IHiddenObject> OnHiddenObjectFound;
        public event Action<PlayerState> OnStateChanged;
        
        public void SetProcess(float process)
        {
            if(_process + process > 100 || _process + process < 0)
                return;
            
            _process += process;

            OnHiddenObjectProcess?.Invoke(_process);
        }

        public void AddHiddenObject(IHiddenObject hiddenObject)
        {
            _collected++;
            OnHiddenObjectFound?.Invoke(hiddenObject);
        }

        public void Reset()
        {
            _collected = 0;
            _playerState = PlayerState.None;
            _process = 0;
        }
    }
}

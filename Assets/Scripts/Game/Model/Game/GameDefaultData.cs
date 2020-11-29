using System;
using Random = UnityEngine.Random;

namespace Game.Model.Game
{
    public class GameDefaultData : IGameData
    {
        private GameState _currentState;
        private int _hiddenCount;
        private int _level;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                var hiddenCount = GameConstants.MinHiddenObjectCount + _level;
                hiddenCount = hiddenCount >= GameConstants.MaxHiddenObjectCount
                    ? GameConstants.MaxHiddenObjectCount
                    : hiddenCount;
                _hiddenCount = hiddenCount;
            }
        }

        public int HiddenTotalCount => _hiddenCount;
        public int HiddenFrontCount => _hiddenCount / 2;
        public event Action<GameState> OnGameStateChanged;

        public GameState State
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnGameStateChanged?.Invoke(_currentState);
            }
        }
    }
}

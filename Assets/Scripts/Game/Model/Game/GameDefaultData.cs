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
                var min = GameConstants.MinHiddenObjectCount + _level;
                _hiddenCount = Random.Range(min >= GameConstants.MaxHiddenObjectCount ? 
                    GameConstants.MinHiddenObjectCount : min, GameConstants.MaxHiddenObjectCount);
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

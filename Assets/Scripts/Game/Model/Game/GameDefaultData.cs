using System;

namespace Game.Model.Game
{
    public class GameDefaultData : IGameData
    {
        private GameState _currentState;
        
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

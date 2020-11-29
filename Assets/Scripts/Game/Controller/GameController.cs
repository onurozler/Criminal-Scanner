using System;
using Game.Model.Criminal.State;
using Game.Model.Game;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;
using Zenject;

namespace Game.Controller
{
    public class GameController : IInitializable, IDisposable
    {
        private IPlayerData _playerData;
        private IGameData _gameData;
        
        public GameController(IPlayerData playerData,IGameData gameData)
        {
            _playerData = playerData;
            _gameData = gameData;
            _gameData.OnGameStateChanged += OnGameStateChanged;
        }
        
        public void Initialize()
        {
            _gameData.State = GameState.Started;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Started:
                    _gameData.Level++;
                    _playerData.Reset();
                    break;
                case GameState.Finished:
                    _playerData.State = PlayerState.None;
                    break;
            }
        }
        public void Dispose()
        {
            _gameData.OnGameStateChanged -= OnGameStateChanged;
        }
    }
}

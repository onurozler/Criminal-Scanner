using System;
using Game.Behaviour.Criminal;
using Game.Behaviour.HiddenObject;
using Game.Model.Game;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;
using Zenject;

namespace Game.Controller
{
    public class CriminalController : IInitializable, ITickable, IDisposable
    {
        private CriminalBehaviourBase _currentCriminal;
        private HiddenObjectPoolController _hiddenObjectPoolController;
        private CriminalPoolController _criminalPoolController;
        private IGameData _gameData;

        [Inject]
        private void Initialize(IGameData gameData, IPlayerData playerData, CriminalPoolController criminalPoolController,
            HiddenObjectPoolController hiddenObjectPoolController)
        {
            _hiddenObjectPoolController = hiddenObjectPoolController;
            _criminalPoolController = criminalPoolController;
            _gameData = gameData;
            _gameData.OnGameStateChanged += OnGameStateChanged;
        }
        
        public void Initialize()
        {
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Started)
            {
                _currentCriminal = _criminalPoolController.Spawn();
                _currentCriminal.InitializeState();
            }
        }

        public void Tick()
        {

        }

        public void Dispose()
        {
            _gameData.OnGameStateChanged -= OnGameStateChanged;
        }
    }
}

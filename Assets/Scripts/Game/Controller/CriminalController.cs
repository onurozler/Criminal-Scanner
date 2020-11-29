using System;
using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.State;
using Game.Model.Game;
using Game.Model.HiddenObject;
using Game.Model.Player;
using Zenject;

namespace Game.Controller
{
    public class CriminalController : IInitializable, IDisposable
    {
        private CriminalBehaviourBase _currentCriminal;
        private CriminalPoolController _criminalPoolController;
        private IGameData _gameData;
        private IPlayerData _playerData;

        [Inject]
        private void Initialize(IGameData gameData, IPlayerData playerData, CriminalPoolController criminalPoolController)
        {
            _criminalPoolController = criminalPoolController;
            _gameData = gameData;
            _playerData = playerData;
            _playerData.OnHiddenObjectFound += OnHiddenObjectFound;
            _gameData.OnGameStateChanged += OnGameStateChanged;
        }

        public void Initialize()
        {
        }

        private void OnGameStateChanged(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Started:
                {
                    _currentCriminal = _criminalPoolController.Spawn();
                    _currentCriminal.InitializeState();
                    _currentCriminal.CriminalData.OnStateChanged += OnCurrentCriminalStateChanged;
                    break;
                }
                case GameState.Finished:
                    _currentCriminal.CriminalData.OnStateChanged -= OnCurrentCriminalStateChanged;
                    _currentCriminal.ChangeState(CriminalState.GoOut);
                    _gameData.State = GameState.Started;
                    break;
            }
        }
        
        private void OnCurrentCriminalStateChanged(CriminalState criminalState)
        {
            switch (criminalState)
            {
                case CriminalState.ScanningBack:
                case CriminalState.ScanningFront:
                    _playerData.State = PlayerState.Scanning;
                    break;
                case CriminalState.MoveToCenter:
                case CriminalState.GoOut:
                    _playerData.State = PlayerState.None;
                    break;
            }
        }
        
        private void OnHiddenObjectFound(IHiddenObject hiddenObject)
        {
            if (_currentCriminal.CriminalData.CriminalState == CriminalState.ScanningFront && 
            _playerData.CollectedCount >= _gameData.HiddenFrontCount)
            {
                DOVirtual.DelayedCall(2f, ()=>_currentCriminal.ChangeState(CriminalState.ScanningBack));
            }
        }

        public void Dispose()
        {
            _gameData.OnGameStateChanged -= OnGameStateChanged;
            _playerData.OnHiddenObjectFound -= OnHiddenObjectFound;
        }
    }
}

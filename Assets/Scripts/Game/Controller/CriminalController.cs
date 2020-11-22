using System;
using Game.Behaviour.Criminal;
using Game.Model.Criminal;
using Game.Model.Game;
using UnityEngine;
using Zenject;

namespace Game.Controller
{
    public class CriminalController : IInitializable, ITickable
    {
        private static readonly Vector3 MiddlePosition = new Vector3();
        
        private CriminalBehaviourBase _currentCriminal;
        private Vector3 _currentTarget; 
        private CriminalPool _criminalPool;
        private IGameData _gameData;

        [Inject]
        private void Initialize(IGameData gameData, CriminalPool criminalPool)
        {
            _criminalPool = criminalPool;
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
                _currentCriminal = _criminalPool.Spawn();
                _currentCriminal.CriminalData.State = CriminalState.Walking;
            }
        }

        public void Tick()
        {
        }
    }
    
    public class CriminalPool : MonoMemoryPool<CriminalBehaviourBase>
    {}
}

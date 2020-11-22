using System;
using Game.Behaviour.Criminal;
using Game.Model.Criminal;
using Game.Model.Criminal.Appearance;
using Game.Model.Game;
using Helpers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Controller
{
    public class CriminalController : IInitializable, ITickable
    {
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
                _currentTarget = CriminalConstants.TargetMiddle;
            }
        }

        public void Tick()
        {
            
            /*
            if (_currentCriminal.CriminalData.State == CriminalState.Walking)
            {
                if ((_currentCriminal.Transform.position.x - _currentTarget.x).
                    IsBetween(-0.2f,0.2f,true))
                {
                    _currentCriminal.CriminalData.State = CriminalState.Turning;
                    return;
                }
                _currentCriminal.Transform.Translate(Vector3.forward * Time.deltaTime,Space.Self);
            }
            else if (_currentCriminal.CriminalData.State == CriminalState.Turning)
            {
                if (_currentCriminal.Transform.eulerAngles.y < -90f)
                {
                    _currentCriminal.CriminalData.State = CriminalState.APose;
                    return;
                }
                
                _currentCriminal.Transform.Rotate(Vector3.up, Time.deltaTime * 30f);
            }*/
        }
    }

    public class CriminalPool : MonoMemoryPool<CriminalBehaviourBase>
    {
        protected override void OnSpawned(CriminalBehaviourBase criminal)
        {
            base.OnSpawned(criminal);
            var hairRandom = Random.Range(0, Enum.GetNames(typeof(CriminalHairKey)).Length);
            var beardRandom = Random.Range(0, 2) > 0;
            criminal.CriminalData.SetAppearance((CriminalHairKey)hairRandom,beardRandom);
        }

        protected override void OnDespawned(CriminalBehaviourBase criminal)
        {
            base.OnDespawned(criminal);
            criminal.CriminalData.State = CriminalState.APose;
            criminal.transform.eulerAngles = new Vector3(0,-180,0);
        }
    }
}

using System;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using Game.Model.Game;
using Game.Model.HiddenObject;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Controller
{
    public class CriminalPoolController : MonoMemoryPool<CriminalBehaviourBase>
    {
        private readonly IGameData _gameData;
        private readonly HiddenObjectPoolController _hiddenObjectPoolController;
        
        public CriminalPoolController(IGameData gameData, HiddenObjectPoolController hiddenObjectPoolController)
        {
            _gameData = gameData;
            _hiddenObjectPoolController = hiddenObjectPoolController;
        }
        
        protected override void OnCreated(CriminalBehaviourBase criminal)
        {
            base.OnCreated(criminal);
            criminal.CriminalSkeleton.Reset();
        }

        protected override void OnSpawned(CriminalBehaviourBase criminal)
        {
            base.OnSpawned(criminal);
            var hairRandom = Random.Range(0, Enum.GetNames(typeof(CriminalHairKey)).Length);
            var beardRandom = Random.Range(0, 2) > 0;
            criminal.CriminalData.SetAppearance((CriminalHairKey)hairRandom,beardRandom);
            for (int i = 0; i < _gameData.HiddenTotalCount; i++)
            {
                var hiddenRandom = Random.Range(0, Enum.GetNames(typeof(HiddenType)).Length);
                var front = i < _gameData.HiddenFrontCount;
                    
                var hiddenObjectBase = _hiddenObjectPoolController.Spawn((HiddenType) hiddenRandom);
                criminal.CriminalSkeleton.SetOnPoint(hiddenObjectBase.transform,front);
            }
        }

        protected override void OnDespawned(CriminalBehaviourBase criminal)
        {
            base.OnDespawned(criminal);
            criminal.CriminalSkeleton.Reset();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Game.Behaviour.Criminal;
using Game.Behaviour.HiddenObject;
using Game.Behaviour.Player;
using Game.Controller;
using Game.Model.Criminal;
using Game.Model.Criminal.State;
using Game.Model.Game;
using Game.Model.Player;
using Game.Model.Player.Input;
using Game.View.Player;
using Helpers;
using UnityEngine;
using Zenject;

namespace Game.Injection
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerView _playerView;
        
        [SerializeField]
        private PlayerBehaviourBase _playerBehaviourBase;
        
        [SerializeField] 
        private CriminalBehaviourBase _criminalPrefab;

        [SerializeField] 
        private Transform _criminalPool;

        [SerializeField] 
        private Transform _hiddenPool;

        private const string HiddenObjectsPath = "HiddenObjects/Prefabs";
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main);
            Container.BindInstance(_playerBehaviourBase);
            Container.BindInstance(_playerView);
            var hiddenObjectPool = new HiddenObjectPoolController();
            hiddenObjectPool.SetParentAndInitialObjects(_hiddenPool,Resources.LoadAll<HiddenObjectBase>(HiddenObjectsPath).ToList());
            Container.BindInstance(hiddenObjectPool);

            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CriminalController>().AsSingle().NonLazy();

            
            Container.BindMemoryPool<CriminalBehaviourBase, CriminalPoolController>().WithInitialSize(2)
                .FromComponentInNewPrefab(_criminalPrefab).UnderTransform(_criminalPool);
                
            Container.Bind<IGameData>().To<GameDefaultData>().AsSingle().NonLazy();
            Container.Bind<ICriminalData>().To<CriminalDefaultData>().AsTransient().NonLazy();
            Container.Bind<IPlayerData>().To<MyPlayerData>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MousePlayerInput>().AsSingle().NonLazy();

            SetupSignals();
        }

        private void SetupSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CriminalState>();
            
            Container.BindSignal<CriminalState>().
                ToMethod<GameController>(x => x.OnCurrentCriminalStateChanged).FromResolve();

        }
    }
}
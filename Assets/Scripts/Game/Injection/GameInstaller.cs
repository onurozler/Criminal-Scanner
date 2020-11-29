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

        [SerializeField] 
        private Material _hiddenMaterial;

        [SerializeField] 
        private Transform _boxTransform;

        private const string HiddenObjectsPath = "HiddenObjects/Prefabs";
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main);
            Container.BindInstance(_playerBehaviourBase);
            Container.BindInstance(_playerView);
            var hiddenObjectPool = new HiddenObjectPoolController(_hiddenPool,
                Resources.LoadAll<HiddenObjectBase>(HiddenObjectsPath).ToList(),_hiddenMaterial);
            Container.BindInstance(hiddenObjectPool);
            Container.BindInstance(_boxTransform).WithId("box");
            
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CriminalController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HiddenObjectController>().AsSingle().NonLazy();

            
            Container.BindMemoryPool<CriminalBehaviourBase, CriminalPoolController>().WithInitialSize(3)
                .FromComponentInNewPrefab(_criminalPrefab).UnderTransform(_criminalPool);
                
            Container.Bind<IGameData>().To<GameDefaultData>().AsSingle().NonLazy();
            Container.Bind<ICriminalData>().To<CriminalDefaultData>().AsTransient().NonLazy();
            Container.Bind<IPlayerData>().To<MyPlayerData>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MousePlayerInput>().AsSingle().NonLazy();
        }
        
    }
}
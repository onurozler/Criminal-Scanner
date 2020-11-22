using Game.Behaviour.Criminal;
using Game.Controller;
using Game.Model.Criminal;
using Game.Model.Game;
using Game.Model.Player;
using Game.Model.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Injection
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] 
        private CriminalBehaviourBase _criminalPrefab;

        [SerializeField] 
        private Transform _criminalPool;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main);

            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CriminalController>().AsSingle().NonLazy();

            Container.BindMemoryPool<CriminalBehaviourBase, CriminalPool>().WithInitialSize(2)
                .FromComponentInNewPrefab(_criminalPrefab).UnderTransform(_criminalPool);
                
            Container.Bind<IGameData>().To<GameDefaultData>().AsSingle().NonLazy();
            Container.Bind<ICriminalData>().To<CriminalDefaultData>().AsTransient().NonLazy();
            Container.Bind<IPlayerData>().To<MyPlayerData>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MousePlayerInput>().AsSingle().NonLazy();
        }
    }
}
using DG.Tweening;
using Game.Model.Player;
using Game.Model.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Player
{
    public abstract class PlayerBehaviourBase : MonoBehaviour
    {
        private Vector3 _machinePosition;
        private float _machineZPosition;
        private IPlayerInput _playerInput;

        public Transform Transform { get; private set; }
        protected IPlayerData PlayerData { get; private set; }
        protected Camera MainCamera { get; private set; }

        
        [Inject]
        private void Initialize(Camera mainCamera, IPlayerInput ınput, IPlayerData playerData)
        {
            MainCamera = mainCamera;
            _playerInput = ınput;

            Transform = transform;
            
            PlayerData = playerData;      

            _playerInput.OnHoldingDown += OnHoldingDown;
            _playerInput.OnHoldingUp += OnHoldingUp;
            _machineZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
        }
        

        private void OnHoldingDown()
        {
            if(PlayerData.State != PlayerState.Scanning)
                return;
            
            _machinePosition.Set(_playerInput.Position.x,_playerInput.Position.y,_machineZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(_machinePosition);

            if (!ProcessScanning())
            {
                PlayerData.SetProcess(-1);
            }
        }
        
        private void OnHoldingUp()
        {
            if(PlayerData.State != PlayerState.Scanning)
                return;
            
            if (!ProcessScanning())
            {
                PlayerData.SetProcess(-1);
            }
        }

        protected abstract bool ProcessScanning();

        private void OnDestroy()
        {
            _playerInput.OnHoldingDown -= OnHoldingDown;
            _playerInput.OnHoldingUp -= OnHoldingUp;
        }
    }
}

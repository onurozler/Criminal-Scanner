using Game.Model.Player;
using Game.Model.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Player
{
    public abstract class PlayerBehaviourBase : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _machinePosition;
        private float _machineZPosition;
        private IPlayerInput _playerInput;

        public Transform Transform { get; private set; }
        protected IPlayerData PlayerData { get; private set; }
        
        [Inject]
        private void Initialize(Camera mainCamera, IPlayerInput ınput, IPlayerData playerData)
        {
            _mainCamera = mainCamera;
            _playerInput = ınput;

            Transform = transform;
            
            PlayerData = playerData;      
            PlayerData.OnStateChanged += OnStateChanged;

            _playerInput.OnHoldingDown += OnHoldingDown;
            _playerInput.OnHoldingUp += OnHoldingUp;
            _machineZPosition = _mainCamera.WorldToScreenPoint(transform.position).z;
        }

        private void OnStateChanged(PlayerState newState)
        {
            
        }

        private void OnHoldingDown()
        {
            if(PlayerData.State != PlayerState.Scanning)
                return;
            
            _machinePosition.Set(_playerInput.Position.x,_playerInput.Position.y,_machineZPosition);
            transform.position = _mainCamera.ScreenToWorldPoint(_machinePosition);

            if (!ProcessScanning())
            {
                PlayerData.SetProcess(-1);
            }
        }
        
        private void OnHoldingUp()
        {
            PlayerData.SetProcess(-1);
        }

        protected abstract bool ProcessScanning();

        private void OnDestroy()
        {
            PlayerData.OnStateChanged -= OnStateChanged;

            _playerInput.OnHoldingDown -= OnHoldingDown;
            _playerInput.OnHoldingUp -= OnHoldingUp;
        }
    }
}

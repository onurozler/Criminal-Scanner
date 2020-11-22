using Game.Model.Player;
using Game.Model.Player.Input;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Player
{
    public class PlayerBehaviourBase : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _machinePosition;
        private float _machineZPosition;
        private IPlayerInput _playerInput;
        private IPlayerData _playerData;
        
        [Inject]
        private void Initialize(Camera mainCamera, IPlayerInput ınput, IPlayerData playerData)
        {
            _mainCamera = mainCamera;
            _playerInput = ınput;
            _playerData = playerData;
            _playerInput.OnHoldingDown += OnHoldingDown;
            _machineZPosition = _mainCamera.WorldToScreenPoint(transform.position).z;
        }

        private void OnHoldingDown()
        {
            if(_playerData.State != PlayerState.Scanning)
                return;
            
            _machinePosition.Set(_playerInput.Position.x,_playerInput.Position.y,_machineZPosition);
            transform.position = _mainCamera.ScreenToWorldPoint(_machinePosition);
        }

        private void OnDestroy()
        {
            _playerInput.OnHoldingDown -= OnHoldingDown;
        }
    }
}

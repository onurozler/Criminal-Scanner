using Game.Behaviour.Player;
using Game.Model.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private Button StartButton;

        [SerializeField] 
        private Image _processBar;
        
        private IPlayerData _playerData;
        private PlayerBehaviourBase _playerBehaviourBase;
        private Camera _camera;
        
        [Inject]
        private void Initialize(IPlayerData playerData, PlayerBehaviourBase playerBehaviourBase, Camera mainCamera)
        {
            _camera = mainCamera;
            _playerBehaviourBase = playerBehaviourBase;
            _playerData = playerData;
            _playerData.OnHiddenObjectProcess += OnHiddenObjectProcess;
        }

        private void Update()
        {
            _processBar.transform.position = 
                _camera.WorldToScreenPoint(_playerBehaviourBase.Transform.position + Vector3.up * 0.15f);
        }

        private void OnHiddenObjectProcess(float process)
        {
            _processBar.fillAmount = process * 0.01f;
        }
    }
}

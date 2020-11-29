using System;
using DG.Tweening;
using Game.Behaviour.Player;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private Image _processBar;

        [SerializeField]
        private Text _scanText;

        [SerializeField] 
        private Text _hiddenName;
        
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
            _playerData.OnStateChanged += OnPlayerStateChanged;
            _playerData.OnHiddenObjectFound += OnHiddenObjectFound;
        }

        private void Update()
        {
            _processBar.transform.parent.position = 
                _camera.WorldToScreenPoint(_playerBehaviourBase.Transform.position + Vector3.up * 0.15f);
        }
        
        private void OnPlayerStateChanged(PlayerState playerState)
        {
            switch (playerState)
            {
                case PlayerState.None:
                    _processBar.transform.parent.gameObject.SetActive(false);
                    break;
                case PlayerState.Scanning:
                    _processBar.transform.parent.gameObject.SetActive(true);
                    break;
            }
        }
        
        private void OnHiddenObjectFound(IHiddenObject hiddenObject)
        {
            _hiddenName.text = $"{hiddenObject.HiddenType.ToString()} Found!";
            _hiddenName.transform.localScale = Vector3.zero;
            DOTween.Sequence()
                .AppendInterval(0.5f)
                .Append(_hiddenName.DOFade(1, 2f))
                .Join(_hiddenName.transform.DOScale(Vector3.one, 2f))
                .Append(_hiddenName.DOFade(0, 0.5f))
                .Join(_hiddenName.transform.DOScale(Vector3.zero,0.5f)).SetEase(Ease.OutCubic);
        }

        private void OnHiddenObjectProcess(float process)
        {
            _processBar.fillAmount = process * 0.01f;
            _scanText.text = _processBar.fillAmount > 0 ? "Scanning" : "Waiting";
        }

        private void OnDestroy()
        {
            _playerData.OnHiddenObjectProcess -= OnHiddenObjectProcess;
            _playerData.OnStateChanged -= OnPlayerStateChanged;
            _playerData.OnHiddenObjectFound -= OnHiddenObjectFound;        }
         }
}

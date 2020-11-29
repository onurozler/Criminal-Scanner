using System;
using DG.Tweening;
using Game.Model.Game;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;

namespace Game.Controller
{
    public class HiddenObjectController : IDisposable
    {
        private readonly Camera _camera;
        private readonly IGameData _gameData;
        private readonly IPlayerData _playerData;
        private readonly HiddenObjectPoolController _hiddenObjectPoolController;
        
        public HiddenObjectController(IPlayerData playerData, HiddenObjectPoolController hiddenObjectPoolController
            ,Camera mainCamera, IGameData gameData)
        {
            _playerData = playerData;
            _camera = mainCamera;
            _gameData = gameData;
            
            _hiddenObjectPoolController = hiddenObjectPoolController;
            _playerData.OnHiddenObjectFound += OnHiddenObjectFound;
        }

        private void OnHiddenObjectFound(IHiddenObject hiddenObject)
        {
            var hiddenObjectBase = _hiddenObjectPoolController.GetHiddenObject(hiddenObject);
            
            DOTween.Sequence()
                .Append(hiddenObjectBase.Transform.DOMove(_camera.transform.position + _camera.transform.forward,0.75f))
                .Join(hiddenObjectBase.Transform.DORotate(hiddenObjectBase.Transform.eulerAngles + Vector3.up * 180, 1.5f))
                .OnComplete(()=>
                {
                    _playerData.State = PlayerState.Scanning;
                    _hiddenObjectPoolController.Despawn(hiddenObjectBase);
                    if (_playerData.CollectedCount >= _gameData.HiddenTotalCount)
                    {
                        _gameData.State = GameState.Finished;
                    }
                });
        }

        public void Dispose()
        {
            _playerData.OnHiddenObjectFound -= OnHiddenObjectFound;
        }
    }
}
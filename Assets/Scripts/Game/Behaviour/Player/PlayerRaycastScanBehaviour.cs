using Game.Behaviour.HiddenObject;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Player
{
    public class PlayerRaycastScanBehaviour : PlayerBehaviourBase
    {
        private SignalBus _signalBus;
        
        [Inject]
        private void Initialize(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        protected override bool ProcessScanning()
        {
            VisualizeScanning();
            
            if(Physics.Raycast(Transform.position,Transform.forward,out var hitInfo,
                PlayerConstants.MaxScanningDistance,HiddenObjectConstants.Layer))
            {
                if (Vector2.Distance(Transform.position, hitInfo.collider.transform.position) 
                    < PlayerConstants.HiddenObjectInteractionThreshold)
                {
                    PlayerData.SetProcess(1);
                    
                    if (PlayerData.Process >= 100 && hitInfo.collider.TryGetComponent(out HiddenObjectBase hiddenObjectBase))
                    {
                        PlayerData.State = PlayerState.None;
                        //_signalBus.Fire(hiddenObjectBase.HiddenData);
                    }

                    return true;
                }
            }

            return false;
        }

        private void VisualizeScanning()
        {
            Debug.DrawRay(Transform.position,Transform.forward * PlayerConstants.MaxScanningDistance);
        }
    }
}
using Game.Behaviour.HiddenObject;
using Game.Model.HiddenObject;
using Game.Model.Player;
using UnityEngine;

namespace Game.Behaviour.Player
{
    public class PlayerRaycastScanBehaviour : PlayerBehaviourBase
    {
        protected override bool ProcessScanning()
        {
            VisualizeScanning();
            var direction = (Transform.position - MainCamera.transform.position).normalized;
            if(Physics.Raycast(MainCamera.transform.position,direction,out var hitInfo,
                PlayerConstants.MaxScanningDistance,HiddenObjectConstants.Layer))
            {
                if (Vector2.Distance(hitInfo.point, hitInfo.collider.bounds.center) 
                    < PlayerConstants.HiddenObjectInteractionThreshold)
                {
                    PlayerData.SetProcess(1);
                    if (PlayerData.Process >= 100 && hitInfo.collider.TryGetComponent(out HiddenObjectBase hiddenObjectBase))
                    {
                        PlayerData.SetProcess(-100);
                        PlayerData.State = PlayerState.None;
                        PlayerData.AddHiddenObject(hiddenObjectBase.HiddenData);
                    }

                    return true;
                }
            }
            
            return false;
        }

        private void VisualizeScanning()
        {
            Debug.DrawRay(MainCamera.transform.position,
                (Transform.position - MainCamera.transform.position).normalized  * PlayerConstants.MaxScanningDistance);
        }
    }
}
using System;
using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;

namespace Game.Model.Criminal.State
{
    public class CriminalRotateState : ICriminalState
    {
        public CriminalState State => CriminalState.Rotate;

        private const float RotationThreshold = 0.5f;
        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;
        private bool _turnToCamera;

        public CriminalRotateState(BasicCriminalBehaviour basicCriminalBehaviour)
        {
            _basicCriminalBehaviour = basicCriminalBehaviour;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimTurning,true);
            
            _turnToCamera = Math.Abs(_basicCriminalBehaviour.Transform.eulerAngles.y - CriminalConstants.Targets.FirstYRotation) < RotationThreshold;
            
            _basicCriminalBehaviour.Transform.DORotate(Vector3.up * (_turnToCamera ? 
                CriminalConstants.Targets.LookToCameraYRotation : CriminalConstants.Targets.FirstYRotation), 1f)
                .OnComplete(()=>
                {
                    if(_turnToCamera)
                        _basicCriminalBehaviour.ChangeCurrentState<CriminalScanState>();
                    else
                        _basicCriminalBehaviour.ChangeCurrentState<CriminalGoOutState>();
                });
        }

        public void Exit()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimTurning,false);
        }
    }
}
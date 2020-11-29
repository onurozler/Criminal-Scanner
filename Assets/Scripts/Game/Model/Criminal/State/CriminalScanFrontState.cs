using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;

namespace Game.Model.Criminal.State
{
    public class CriminalScanFrontState : ICriminalState
    {
        public virtual CriminalState State => CriminalState.ScanningFront;


        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;
        
        public CriminalScanFrontState(BasicCriminalBehaviour criminalBehaviourBase)
        {
            _basicCriminalBehaviour = criminalBehaviourBase;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimTurning,true);
            
            _basicCriminalBehaviour.Transform.DORotate(Vector3.up * (State == CriminalState.ScanningFront 
                ? CriminalConstants.Targets.FrontYRotation : CriminalConstants.Targets.BackYRotation), 1f)
                .OnComplete(()=>
                {
                    _basicCriminalBehaviour.CriminalSkeleton.ActivateHidden(State);
                    _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimTurning,false);
                    _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimAPose, true);
                });
        }

        public void Exit()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimAPose,false);
        }
        
    }
}
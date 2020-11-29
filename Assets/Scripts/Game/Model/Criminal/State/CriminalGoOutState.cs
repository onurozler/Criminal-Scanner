using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;

namespace Game.Model.Criminal.State
{
    public class CriminalGoOutState : ICriminalState
    {
        public CriminalState State => CriminalState.GoOut;

        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;
        
        public CriminalGoOutState(BasicCriminalBehaviour criminalBehaviourBase)
        {
            _basicCriminalBehaviour = criminalBehaviourBase;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimWalk,true);
            
            DOTween.Sequence()
                .Append(_basicCriminalBehaviour.Transform.DORotate(Vector3.up * CriminalConstants.Targets.FirstYRotation, 1f))
                .Append(_basicCriminalBehaviour.Transform.DOMove(CriminalConstants.Targets.Out, 2.5f)).SetEase(Ease.Linear)
                .OnComplete(()=> _basicCriminalBehaviour.ChangeState(CriminalState.Idle));
        }

        public void Exit()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimWalk,false);
        }
    }
}
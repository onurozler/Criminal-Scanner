using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;

namespace Game.Model.Criminal.State
{
    public class CriminalMoveToCenterState : ICriminalState
    {
        public CriminalState State => CriminalState.MoveToCenter;

        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;
        
        public CriminalMoveToCenterState(BasicCriminalBehaviour basicCriminalBehaviour)
        {
            _basicCriminalBehaviour = basicCriminalBehaviour;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimWalk,true);
            _basicCriminalBehaviour.Transform.DOMove(CriminalConstants.Targets.Middle, 2.5f).SetEase(Ease.Linear)
                .OnComplete(() => _basicCriminalBehaviour.ChangeState(CriminalState.ScanningFront));
        }
        
        public void Exit()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimWalk,false);
        }
    }
}
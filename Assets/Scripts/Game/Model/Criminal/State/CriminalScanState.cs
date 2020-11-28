using DG.Tweening;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;

namespace Game.Model.Criminal.State
{
    public class CriminalScanState : ICriminalState
    {
        public CriminalState State => CriminalState.Scanning;

        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;
        
        public CriminalScanState(BasicCriminalBehaviour criminalBehaviourBase)
        {
            _basicCriminalBehaviour = criminalBehaviourBase;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimAPose,true);
            //DOVirtual.DelayedCall(1f, () => _basicCriminalBehaviour.ChangeCurrentState<CriminalRotateState>());
        }

        public void LogicUpdate()
        {

        }

        public void Exit()
        {
            _basicCriminalBehaviour.Animator.SetBool(CriminalConstants.Animations.AnimAPose,false);
        }
    }
}
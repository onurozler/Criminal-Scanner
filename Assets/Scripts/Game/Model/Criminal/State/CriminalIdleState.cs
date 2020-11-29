using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;

namespace Game.Model.Criminal.State
{
    public class CriminalIdleState : ICriminalState
    {
        public CriminalState State => CriminalState.Idle;
        
        private readonly BasicCriminalBehaviour _basicCriminalBehaviour;

        public CriminalIdleState(BasicCriminalBehaviour basicCriminalBehaviour)
        {
            _basicCriminalBehaviour = basicCriminalBehaviour;
        }
        
        public void Enter()
        {
            _basicCriminalBehaviour.Transform.position = CriminalConstants.Targets.First;
            _basicCriminalBehaviour.Transform.eulerAngles = new Vector3(0,CriminalConstants.Targets.FirstYRotation,0);
        }

        public void Exit()
        {
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Game.Model.Criminal.State;

namespace Game.Behaviour.Criminal
{
    public class BasicCriminalBehaviour : CriminalBehaviourBase
    {
        private ICriminalState _currentState;
        private IList<ICriminalState> _criminalStates;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _criminalStates = new List<ICriminalState>
            {
                new CriminalIdleState(this),
                new CriminalMoveToCenterState(this),
                new CriminalScanFrontState(this),
                new CriminalScanBackState(this),
                new CriminalGoOutState(this)
            };
        }

        public override void InitializeState()
        {
            _currentState = _criminalStates[1];
            _currentState.Enter();
            
            CriminalData.CriminalState = _currentState.State;
        }

        public override void ChangeState(CriminalState criminalState)
        {
            _currentState.Exit();
            _currentState = _criminalStates.FirstOrDefault(x=> x.State == criminalState);
            _currentState?.Enter();

            if (_currentState != null)
            {
                CriminalData.CriminalState = _currentState.State;
            }
        }
    }
}
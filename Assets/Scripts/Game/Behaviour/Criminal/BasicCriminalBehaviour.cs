using System.Collections.Generic;
using System.Linq;
using Game.Model.Criminal.State;
using Zenject;

namespace Game.Behaviour.Criminal
{
    public class BasicCriminalBehaviour : CriminalBehaviourBase
    {
        private SignalBus _signalBus;
        private ICriminalState _currentState;
        private IList<ICriminalState> _criminalStates;

        [Inject]
        private void Initialize(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            _criminalStates = new List<ICriminalState>
            {
                new CriminalMoveToCenterState(this),
                new CriminalRotateState(this),
                new CriminalScanState(this),
                new CriminalGoOutState(this)
            };
        }

        public override void InitializeState()
        {
            _currentState = _criminalStates[0];
            _currentState.Enter();
        }

        public void ChangeCurrentState<T>() where T : ICriminalState
        {
            _currentState.Exit();
            _currentState = _criminalStates.FirstOrDefault(x=> x.GetType() == typeof(T));
            _currentState?.Enter();

            if (_currentState != null)
            {
                _signalBus.Fire(_currentState.State);
            }
        }
    }
}
using Game.Behaviour.Criminal;

namespace Game.Model.Criminal.State
{
    public class CriminalScanBackState : CriminalScanFrontState
    {
        public override CriminalState State => CriminalState.ScanningBack;
        
        public CriminalScanBackState(BasicCriminalBehaviour criminalBehaviourBase) : base(criminalBehaviourBase)
        {
        }
    }
}
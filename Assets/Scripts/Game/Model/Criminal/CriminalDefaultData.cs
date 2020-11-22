using System;
using Game.Model.Criminal.Appearance;

namespace Game.Model.Criminal
{
    public class CriminalDefaultData : ICriminalData
    {
        private CriminalState _criminalState;
        public event Action<CriminalHairKey,bool> OnEquipmentsChanged;
        public event Action<CriminalState, CriminalState> OnStateChanged;

        public CriminalState State
        {
            get => _criminalState;
            set
            {
                var oldState = _criminalState;
                _criminalState = value;
                OnStateChanged?.Invoke(oldState,_criminalState);
            }
        }

        public CriminalDefaultData()
        {
        }

        public void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard)
        {
            OnEquipmentsChanged?.Invoke(criminalHairKey,hasBeard);
        }
    }
}

using System;
using Game.Model.Criminal.Helpers;
using Game.Model.Criminal.State;

namespace Game.Model.Criminal
{
    public class CriminalDefaultData : ICriminalData
    {
        private CriminalState _criminalState;
        
        public CriminalState CriminalState
        {
            get => _criminalState;
            set
            {
                _criminalState = value;
                OnStateChanged?.Invoke(_criminalState);
            } 
        }

        public event Action<CriminalState> OnStateChanged;
        public event Action<CriminalHairKey,bool> OnEquipmentsChanged;

        public CriminalDefaultData()
        {
        }

        public void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard)
        {
            OnEquipmentsChanged?.Invoke(criminalHairKey,hasBeard);
        }
    }
}

using System;
using Game.Model.Criminal.Helpers;
using Game.Model.Criminal.State;

namespace Game.Model.Criminal
{
    public interface ICriminalData
    {
        CriminalState CriminalState { get; set; }
        event Action<CriminalState> OnStateChanged;
        event Action<CriminalHairKey,bool> OnEquipmentsChanged;

        void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard);
    }
    
}

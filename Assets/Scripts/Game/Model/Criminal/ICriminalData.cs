using System;
using Game.Model.Criminal.Appearance;

namespace Game.Model.Criminal
{
    public interface ICriminalData
    {
        event Action<CriminalHairKey,bool> OnEquipmentsChanged;
        event Action<CriminalState, CriminalState> OnStateChanged;
        
        CriminalState State { get; set; }
        void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard);
    }

    public enum CriminalState
    {
        Walking,
        Turning,
        APose
    }
    
}

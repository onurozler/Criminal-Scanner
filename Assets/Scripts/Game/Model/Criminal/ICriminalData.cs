using System;
using Game.Model.Criminal.Helpers;
using Game.Model.HiddenObject;

namespace Game.Model.Criminal
{
    public interface ICriminalData
    {
        event Action OnHiddenObjectSet;
        event Action<CriminalHairKey,bool> OnEquipmentsChanged;

        void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard);
        void SetHiddenObjects(HiddenType hiddenType);
    }
    
}

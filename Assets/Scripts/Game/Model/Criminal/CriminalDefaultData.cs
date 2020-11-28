using System;
using System.Collections.Generic;
using Game.Model.Criminal.Helpers;
using Game.Model.HiddenObject;

namespace Game.Model.Criminal
{
    public class CriminalDefaultData : ICriminalData
    {
        private List<IHiddenObject> _hiddenObjects;

        public event Action OnHiddenObjectSet;
        public event Action<CriminalHairKey,bool> OnEquipmentsChanged;

        public CriminalDefaultData()
        {
        }

        public void SetAppearance(CriminalHairKey criminalHairKey,bool hasBeard)
        {
            OnEquipmentsChanged?.Invoke(criminalHairKey,hasBeard);
        }

        public void SetHiddenObjects(HiddenType hiddenType)
        {
            
        }
    }
}

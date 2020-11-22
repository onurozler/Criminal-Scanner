using System;
using System.Collections.Generic;

namespace Game.Model.Criminal
{
    public class CriminalDefaultData : ICriminalData
    {
        private readonly List<CriminalEquipmentKey> _criminalItems;
        private CriminalState _criminalState;
        
        public event Action<List<CriminalEquipmentKey>> OnItemsChanged;
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
            _criminalItems = new List<CriminalEquipmentKey>();
        }

        public void SetItems(params CriminalEquipmentKey[] items)
        {
            _criminalItems.Clear();
            foreach (var item in items)
            {
                _criminalItems.Add(item);
            }
            
            OnItemsChanged?.Invoke(_criminalItems);
        }
    }
}

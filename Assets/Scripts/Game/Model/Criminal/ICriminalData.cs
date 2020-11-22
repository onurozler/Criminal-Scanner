using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model.Criminal
{
    public interface ICriminalData
    {
        event Action<List<CriminalEquipmentKey>> OnItemsChanged;
        event Action<CriminalState, CriminalState> OnStateChanged;
        
        CriminalState State { get; set; }
        void SetItems(params CriminalEquipmentKey[] items);
    }

    public enum CriminalState
    {
        Walking,
        Turning,
        APose
    }

    public enum CriminalEquipmentKey
    {
        None,
        Hat,
        
    }
    
    [Serializable]
    public class CriminalEquipments
    {
        public CriminalEquipmentKey Key;
        public Transform Value;
    }
    
}

using System;
using UnityEngine;

namespace Game.Model.Criminal.Helpers
{
    [Serializable]
    public class CriminalHair
    {
        public CriminalHairKey Key;
        public GameObject Value;
    }
    
    public enum CriminalHairKey
    {
        None,
        Default,
        Hat,
        Stache,
        Mohawk,
        Wavy
    }
}
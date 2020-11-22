using System;
using UnityEngine;

namespace Game.Model.Criminal.Appearance
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
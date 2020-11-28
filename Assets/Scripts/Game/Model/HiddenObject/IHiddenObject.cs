using UnityEngine;

namespace Game.Model.HiddenObject
{
    public interface IHiddenObject
    {
        Sprite Icon { get; }
        HiddenType HiddenType { get; }
    }
    
        
    public enum HiddenType
    {
        Knife,
    }
}
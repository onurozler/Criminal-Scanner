using UnityEngine;

namespace Game.Model.HiddenObject
{
    public interface IHiddenObject
    {
        Sprite Icon { get; set; }
        HiddenType HiddenType { get; set; }
    }
    
    public enum HiddenType
    {
        Knife,
    }
}
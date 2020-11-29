using UnityEngine;

namespace Game.Model.HiddenObject
{
    public interface IHiddenObject
    {
        Sprite Icon { get; set; }
        HiddenType HiddenType { get; set; }
        Material Material { get; set; }
        Vector3 InitialRotation { get; set; }
    }
    
    public enum HiddenType
    {
        Gun,
        FlashBang,
        Smoke,
        Phone,
        Briefcase,
        PlantPot
    }
}
using UnityEngine;

namespace Game.Model.HiddenObject
{
    public class HiddenObjectData : IHiddenObject
    {
        public Sprite Icon { get; set; }
        public HiddenType HiddenType { get; set; }
    }
}
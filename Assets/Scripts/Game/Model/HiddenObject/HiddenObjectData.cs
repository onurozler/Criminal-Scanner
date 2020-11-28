using UnityEngine;

namespace Game.Model.HiddenObject
{
    [CreateAssetMenu(fileName = "HiddenObject", menuName = "Hidden Object/Create Instance", order = 1)]
    public class HiddenObjectData : ScriptableObject,IHiddenObject
    {
        [SerializeField] 
        private HiddenType _hiddenType;

        [SerializeField] 
        private Sprite _icon;

        public HiddenType HiddenType => _hiddenType;
        public Sprite Icon => _icon;
    }

}

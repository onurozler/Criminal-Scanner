using UnityEngine;

namespace Game.Model.HiddenObject
{
    [CreateAssetMenu(fileName = "HiddenObject", menuName = "Hidden Object/Create Instance", order = 1)]
    public class HiddenScriptableObject : ScriptableObject
    {
        [SerializeField] 
        private HiddenType _hiddenType;

        [SerializeField] 
        private Material _material;

        public HiddenType HiddenType => _hiddenType;
        public Material Material => _material;
    }

}

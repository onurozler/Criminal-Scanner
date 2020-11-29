using Game.Model.HiddenObject;
using UnityEngine;

namespace Game.Behaviour.HiddenObject
{
    public class HiddenObjectBase : MonoBehaviour
    {
        [SerializeField] 
        private HiddenScriptableObject _hiddenScriptableObject;

        private Transform _transform;
        private HiddenObjectData _hiddenObjectData;
        
        public Transform Transform => _transform ? _transform : _transform = transform;

        public IHiddenObject HiddenData => _hiddenObjectData ?? (_hiddenObjectData =  new HiddenObjectData
        {
            Icon = _hiddenScriptableObject.Icon,
            HiddenType = _hiddenScriptableObject.HiddenType
        });
    }
}

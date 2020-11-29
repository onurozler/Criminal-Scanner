using Game.Model.HiddenObject;
using UnityEngine;

namespace Game.Behaviour.HiddenObject
{
    public class HiddenObjectBase : MonoBehaviour
    {
        [SerializeField] 
        private HiddenScriptableObject _hiddenScriptableObject;

        private Transform _transform;
        private MeshRenderer _meshRenderer;
        private HiddenObjectData _hiddenObjectData;
        
        public Transform Transform => _transform ? _transform : _transform = transform;
        public MeshRenderer MeshRenderer => _meshRenderer ? _meshRenderer : _meshRenderer = GetComponent<MeshRenderer>();

        public IHiddenObject HiddenData => _hiddenObjectData ?? (_hiddenObjectData =  new HiddenObjectData
        {
            HiddenType = _hiddenScriptableObject.HiddenType,
            Material = _hiddenScriptableObject.Material
        });
    }
}

using Game.Model.HiddenObject;
using UnityEngine;

namespace Game.Behaviour.HiddenObject
{
    public class HiddenObjectBase : MonoBehaviour
    {
        [SerializeField] 
        private HiddenObjectData _hiddenObjectData;

        public IHiddenObject HiddenData => _hiddenObjectData;
    }
}

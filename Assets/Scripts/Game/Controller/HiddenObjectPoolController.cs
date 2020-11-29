using System.Collections.Generic;
using System.Linq;
using Game.Behaviour.HiddenObject;
using Game.Model.HiddenObject;
using UnityEngine;

namespace Game.Controller
{
    public class HiddenObjectPoolController
    {
        private List<HiddenObjectBase> _poolableItemKinds;
        private List<HiddenObjectBase> _poolableItems;
        private Material _hiddenMaterial;
        private Transform _parent;

        public HiddenObjectPoolController(Transform parent, List<HiddenObjectBase> poolableItems,Material hiddenMaterial)
        {
            _parent = parent;
            _poolableItemKinds = poolableItems;
            _poolableItems = new List<HiddenObjectBase>();
            _hiddenMaterial = hiddenMaterial;
        }

        public HiddenObjectBase Spawn(HiddenType type)
        {
            var item = _poolableItems.FirstOrDefault(x => x.HiddenData.HiddenType == type);

            if(item != null && !item.gameObject.activeSelf)
            {
                item.gameObject.SetActive(true);
                return item;
            }
            else
            {
                var instantiateItem = Object.Instantiate(_poolableItemKinds.
                    FirstOrDefault(x=>x.HiddenData.HiddenType == type),_parent);
                instantiateItem.HiddenData.InitialRotation = instantiateItem.Transform.eulerAngles;
                _poolableItems.Add(instantiateItem);
                return instantiateItem;
            }
        }

        public HiddenObjectBase GetHiddenObject(IHiddenObject hiddenObject)
        {
            return _poolableItems.FirstOrDefault(x=>x.HiddenData == hiddenObject);
        }

        public void Despawn(HiddenObjectBase instance)
        {
            if (_poolableItems.Contains(instance))
            {
                instance.MeshRenderer.material = _hiddenMaterial;
                instance.gameObject.transform.SetParent(_parent);
                instance.gameObject.SetActive(false);
            }
        }
    }
}

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
        private Transform _parent;
        
        public void SetParentAndInitialObjects(Transform parent, List<HiddenObjectBase> poolableItems)
        {
            _parent = parent;
            _poolableItemKinds = poolableItems;
            _poolableItems = new List<HiddenObjectBase>();
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
                instance.gameObject.transform.SetParent(_parent);
                instance.gameObject.SetActive(false);
            }
        }
    }
}

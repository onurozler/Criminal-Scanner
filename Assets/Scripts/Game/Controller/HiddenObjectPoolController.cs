using System.Collections.Generic;
using System.Linq;
using Game.Behaviour.HiddenObject;
using Game.Model.HiddenObject;
using UnityEngine;

namespace Game.Controller
{
    public class HiddenObjectPoolController
    {
        private List<HiddenObjectBase> _poolableItems;
        private Transform _parent;
        
        public void SetParentAndInitialObjects(Transform parent, List<HiddenObjectBase> poolableItems)
        {
            _parent = parent;
            _poolableItems = poolableItems;
        }
        
        public HiddenObjectBase Spawn(HiddenType type)
        {
            var item = _poolableItems.FirstOrDefault(x => x.HiddenData.HiddenType == type);

            if(!item.gameObject.activeSelf)
            {
                item.gameObject.SetActive(true);
                return item;
            }
            else
            {
                var instantiateItem = Object.Instantiate(item,_parent) as HiddenObjectBase;
                _poolableItems.Add(instantiateItem);
                return instantiateItem;
            }
        }

        public void Despawn(HiddenObjectBase instance)
        {
            if (_poolableItems.Contains(instance))
            {
                instance.gameObject.SetActive(false);
            }
        }
    }
}

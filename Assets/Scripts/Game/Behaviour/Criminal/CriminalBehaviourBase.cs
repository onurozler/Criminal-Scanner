using System.Collections.Generic;
using System.Linq;
using Game.Model.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Criminal
{
    public abstract class CriminalBehaviourBase : MonoBehaviour
    {
        [SerializeField] 
        private List<CriminalHair> _hairModels;

        [SerializeField] 
        private GameObject _beard;

        public Animator Animator { get; private set; }
        public Transform Transform { get; private set; }
        public ICriminalData CriminalData { get; private set; }

        [Inject]
        private void Initialize(ICriminalData criminalData)
        {
            CriminalData = criminalData;
            Transform = transform;
            Animator = GetComponent<Animator>();
            
            CriminalData.OnEquipmentsChanged += OnItemsChanged;
        }

        public abstract void InitializeState();
        
        protected void OnItemsChanged(CriminalHairKey criminalHair, bool hasBeard)
        {
            _hairModels.ForEach(x=> x.Value.SetActive(false));
            _hairModels.FirstOrDefault(x=> x.Key == criminalHair)?.Value.SetActive(true);
            _beard.SetActive(hasBeard);
        }

        protected void OnDestroy()
        {
            CriminalData.OnEquipmentsChanged -= OnItemsChanged;
        }
    }
}

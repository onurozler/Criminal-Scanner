using System.Collections.Generic;
using System.Linq;
using Game.Controller;
using Game.Model.Criminal;
using Game.Model.Criminal.Helpers;
using Game.Model.Criminal.State;
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

        [SerializeField] 
        private CriminalSkeleton _criminalSkeleton;

        private CriminalPoolController _criminalPoolController;

        public Animator Animator { get; private set; }
        public Transform Transform { get; private set; }
        public ICriminalData CriminalData { get; private set; }
        public CriminalSkeleton CriminalSkeleton => _criminalSkeleton;

        [Inject]
        private void Initialize(ICriminalData criminalData,CriminalPoolController criminalPoolController)
        {
            CriminalData = criminalData;
            Transform = transform;
            Animator = GetComponent<Animator>();
            _criminalPoolController = criminalPoolController;
            
            CriminalData.OnEquipmentsChanged += OnItemsChanged;
            CriminalData.OnStateChanged += OnStateChanged;
            
            OnInitialized();
        }
        
        protected virtual void OnInitialized(){}
        public abstract void InitializeState();
        public abstract void ChangeState(CriminalState criminalState);
        
        protected void OnItemsChanged(CriminalHairKey criminalHair, bool hasBeard)
        {
            _hairModels.ForEach(x=> x.Value.SetActive(false));
            _hairModels.FirstOrDefault(x=> x.Key == criminalHair)?.Value.SetActive(true);
            _beard.SetActive(hasBeard);
        }
        
        private void OnStateChanged(CriminalState currentState)
        {
            if (currentState == CriminalState.Idle)
            {
                _criminalPoolController.Despawn(this);
            }
        }
        
        protected void OnDestroy()
        {
            CriminalData.OnEquipmentsChanged -= OnItemsChanged;
            CriminalData.OnStateChanged -= OnStateChanged;
        }
    }
}

using System.Collections.Generic;
using Game.Model.Criminal;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Criminal
{
    public class CriminalBehaviourBase : MonoBehaviour
    {
        [SerializeField] 
        private CriminalEquipments criminalEquipments;
        private Animator _animator;
        
        public ICriminalData CriminalData { get; private set; }

        [Inject]
        private void Initialize(ICriminalData criminalData)
        {
            CriminalData = criminalData;
            _animator = GetComponent<Animator>();
            
            CriminalData.OnStateChanged += OnOnStateChanged;
            CriminalData.OnItemsChanged += OnItemsChanged;
        }

        private void OnItemsChanged(List<CriminalEquipmentKey> criminalItems)
        {
            
        }

        private void OnOnStateChanged(CriminalState oldState, CriminalState newState)
        {
            _animator.SetBool(oldState.ToString(),false);
            _animator.SetBool(newState.ToString(),true);
        }

        private void OnDestroy()
        {
            CriminalData.OnStateChanged -= OnOnStateChanged;
            CriminalData.OnItemsChanged -= OnItemsChanged;
        }
    }
}

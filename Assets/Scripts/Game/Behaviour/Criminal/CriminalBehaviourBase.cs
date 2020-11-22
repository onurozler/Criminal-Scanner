using System.Collections.Generic;
using System.Linq;
using Game.Model.Criminal;
using Game.Model.Criminal.Appearance;
using UnityEngine;
using Zenject;

namespace Game.Behaviour.Criminal
{
    public class CriminalBehaviourBase : MonoBehaviour
    {
        [SerializeField] 
        private List<CriminalHair> _hairModels;

        [SerializeField] 
        private GameObject _beard;

        private Animator _animator;
        public Transform Transform { get; private set; }
        public ICriminalData CriminalData { get; private set; }

        [Inject]
        private void Initialize(ICriminalData criminalData)
        {
            CriminalData = criminalData;
            Transform = transform;
            _animator = GetComponent<Animator>();
            
            CriminalData.OnStateChanged += OnOnStateChanged;
            CriminalData.OnEquipmentsChanged += OnItemsChanged;
        }

        private void OnItemsChanged(CriminalHairKey criminalHair, bool hasBeard)
        {
            _hairModels.ForEach(x=> x.Value.SetActive(false));
            _hairModels.FirstOrDefault(x=> x.Key == criminalHair)?.Value.SetActive(true);
            _beard.SetActive(hasBeard);
        }

        private void OnOnStateChanged(CriminalState oldState, CriminalState newState)
        {
            _animator.SetBool(oldState.ToString(),false);
            _animator.SetBool(newState.ToString(),true);
        }

        private void OnDestroy()
        {
            CriminalData.OnStateChanged -= OnOnStateChanged;
            CriminalData.OnEquipmentsChanged -= OnItemsChanged;
        }
    }
}

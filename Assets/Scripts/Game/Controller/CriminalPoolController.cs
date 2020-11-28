using System;
using Game.Behaviour.Criminal;
using Game.Model.Criminal.Helpers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Controller
{
    public class CriminalPoolController : MonoMemoryPool<CriminalBehaviourBase>
    {
        protected override void OnSpawned(CriminalBehaviourBase criminal)
        {
            base.OnSpawned(criminal);
            var hairRandom = Random.Range(0, Enum.GetNames(typeof(CriminalHairKey)).Length);
            var beardRandom = Random.Range(0, 2) > 0;
            criminal.CriminalData.SetAppearance((CriminalHairKey)hairRandom,beardRandom);
        }

        protected override void OnDespawned(CriminalBehaviourBase criminal)
        {
            base.OnDespawned(criminal);
            criminal.transform.eulerAngles = new Vector3(0,-180,0);
        }
    }
}
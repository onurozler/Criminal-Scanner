using System;
using System.Collections.Generic;
using System.Linq;
using Game.Behaviour.HiddenObject;
using Game.Model.Criminal.State;
using UnityEngine;

namespace Game.Model.Criminal.Helpers
{
    [Serializable]
    public class CriminalSkeleton
    {
        [SerializeField] 
        private Transform _skeletonBody;

        private List<SkeletonHiddenPoint> _skeletonHiddenPoints;
        
        public void ActivateHidden(CriminalState criminalState)
        {
            _skeletonHiddenPoints.ForEach(x=>
            {
                x.Transform.gameObject.SetActive(x.Direction == criminalState);
            });
        }

        public void SetOnPoint(Transform target, bool front)
        {
            var point = _skeletonHiddenPoints.FirstOrDefault(x => x.IsAvailable);
            if (point != null)
            {
                target.SetParent(point.Transform);
                target.localPosition = Vector3.zero;
                point.Direction = front ? CriminalState.ScanningFront : CriminalState.ScanningBack;
                point.Transform.gameObject.SetActive(false);
                point.IsAvailable = false;
            }
        }

        public void Reset()
        {
            if (_skeletonHiddenPoints == null)
            {
                _skeletonHiddenPoints = new List<SkeletonHiddenPoint>();
                foreach (Transform point in _skeletonBody)
                {
                    _skeletonHiddenPoints.Add(new SkeletonHiddenPoint
                    {
                        Transform = point,
                        IsAvailable = true
                    });
                }
            }
            else
            {
                _skeletonHiddenPoints.ForEach(x=>x.IsAvailable = true);
            }
        }
    }

    public class SkeletonHiddenPoint
    {
        public Transform Transform;
        public bool IsAvailable;
        public CriminalState Direction;
    }
}

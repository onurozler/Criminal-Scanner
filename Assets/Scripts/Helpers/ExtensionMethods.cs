using UnityEngine;

namespace Helpers
{
    public static class ExtensionMethods
    {
        public static void SetLocalPositionZ(this Transform transform, float zPos)
        {
            var position = transform.localPosition;
            position.z = zPos;
            transform.localPosition = position;
        }
    }
}
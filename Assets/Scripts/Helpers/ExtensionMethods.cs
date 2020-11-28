using Game.Model.Criminal;
using UnityEngine;

namespace Helpers
{
    public static class ExtensionMethods
    {
        public static bool IsBetween(this float value, float lower, float top, bool absolute = false)
        {
            value = absolute ? Mathf.Abs(value) : value;
            return value >= lower && value <= top;
        }
    }
}
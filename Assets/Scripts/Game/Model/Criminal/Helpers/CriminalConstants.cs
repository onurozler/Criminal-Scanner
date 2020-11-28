using UnityEngine;

namespace Game.Model.Criminal.Helpers
{
    public static class CriminalConstants
    {
        public const float Speed = 3f;
        
        public static class Targets
        {
            public static readonly float FirstYRotation = 90f;
            public static readonly float LookToCameraYRotation = 180f;
            
            public static readonly Vector3 First = new Vector3();
            public static readonly Vector3 Middle = new Vector3(0f,-0.3f,1f);
            public static readonly Vector3 Out = new Vector3(2f,-0.3f,1f);
        }
        
        public static class Animations
        {
            public const string AnimWalk = "Walking";
            public const string AnimAPose = "APose";
            public const string AnimTurning = "Turning";
        }
    }
}

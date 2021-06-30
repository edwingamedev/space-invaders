using UnityEngine;

namespace EdwinGameDev.Movement
{
    [CreateAssetMenu(menuName = "Settings/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {        
        public AnimationCurve horizontalSpeed;
        public float verticalSpeed;
    }
}
using UnityEngine;

namespace EdwinGameDev.Movement
{
    [CreateAssetMenu(menuName = "Settings/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {
        public float moveDistanceHorizontal;
        public float moveDistanceVertical;
        public float movementFrequency;
    }
}
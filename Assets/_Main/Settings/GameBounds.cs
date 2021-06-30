using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Settings
{
    [CreateAssetMenu(menuName = "Settings/GameBounds")]
    public class GameBounds : ScriptableObject
    {
        [SerializeField] private float MIN_X;
        [SerializeField] private float MAX_X; 
        [SerializeField] private float MIN_Y;
        [SerializeField] private float MAX_Y;

        public float GetMinX => Camera.main.ViewportToWorldPoint(Vector3.zero).x + MIN_X;
        public float GetMaxX => Camera.main.ViewportToWorldPoint(Vector3.one).x - MAX_X;
        public float GetMinY => Camera.main.ViewportToWorldPoint(Vector3.zero).y + MIN_Y;
        public float GetMaxY => Camera.main.ViewportToWorldPoint(Vector3.one).y - MAX_Y;

        public Vector2 ConvertToInBoundsPositon(Vector2 coordToTest)
        {
            coordToTest.x = Mathf.Clamp(coordToTest.x, GetMinX, GetMaxX);
            coordToTest.y = Mathf.Clamp(coordToTest.y, GetMinY, GetMaxY);

            return coordToTest;
        }

        public bool IsInVerticalBounds(Vector2 coordToTest)
        {
            if (coordToTest.y < GetMinY || coordToTest.y > GetMaxY)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsInHorizontalBounds(Vector2 coordToTest)
        {
            if (coordToTest.x < GetMinX || coordToTest.x > GetMaxX)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
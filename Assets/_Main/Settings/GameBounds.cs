using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Settings
{
    [CreateAssetMenu(menuName = "Settings/GameBounds")]
    public class GameBounds : ScriptableObject
    {
        public float MIN_X;
        public float MAX_X;

        public float MIN_Y;
        public float MAX_Y;

        public Vector2 ConvertToInBoundsPositon(Vector2 coordToTest)
        {
            coordToTest.x = Mathf.Clamp(coordToTest.x, MIN_X, MAX_X);
            coordToTest.y = Mathf.Clamp(coordToTest.y, MIN_Y, MAX_Y);                        

            return coordToTest;
        }

        public bool IsInVerticalBounds(Vector2 coordToTest)
        {
            if (coordToTest.y < MIN_Y || coordToTest.y > MAX_Y)
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
            if (coordToTest.x < MIN_X || coordToTest.x > MAX_X)
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
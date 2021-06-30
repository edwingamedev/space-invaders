using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMovement
    {
        bool IsValidHorizontalMovement(Transform movable, Vector2 movementVector);        
        bool IsValidVerticalMovement(Transform movable, Vector2 movementVector);
        void Move(Transform movable, Vector2 movementVector);
    }
}
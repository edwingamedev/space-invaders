using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMovement
    {
        bool IsValidMovement(Transform movable, Vector2 movementVector);
        void Move(Transform movable, Vector2 movementVector);
    }
}
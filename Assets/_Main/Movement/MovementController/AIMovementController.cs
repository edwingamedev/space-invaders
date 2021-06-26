using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class AIMovementController : AMovementController
    {
        public override bool IsValidMovement(Vector2 movementVector)
        {
            return movement.IsValidMovement(transform, movementVector);
        }

        public override void Move(Vector2 movementVector)
        {            
            movement.Move(transform, movementVector);
        }

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
        }
    }
}
using EdwinGameDev.Enemies;
using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class AIMovementController : AMovementController, IMovable
    {
        public override bool IsValidMovement(Vector2 movementVector)
        {
            return movement.IsValidMovement(transform, movementVector * moveSpeed);
        }

        public override void Move(Vector2 movementVector)
        {
            if (canMove)
                movement.Move(transform, movementVector * moveSpeed);
        }

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
        }
    }
}
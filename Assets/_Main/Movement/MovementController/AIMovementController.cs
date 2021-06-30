using EdwinGameDev.Enemies;
using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class AIMovementController : AMovementController, IMovable
    {
        public override bool IsValidVerticalMovement(Vector2 movementVector)
        {
            return movement.IsValidVerticalMovement(transform, movementVector * moveSpeed);
        }

        public override bool IsValidHorizontalMovement(Vector2 movementVector)
        {
            return movement.IsValidHorizontalMovement(transform, movementVector * moveSpeed);
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
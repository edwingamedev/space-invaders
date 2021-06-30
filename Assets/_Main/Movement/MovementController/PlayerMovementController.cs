using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class PlayerMovementController : AMovementController
    {
        private IInputProcessor inputProcessor;

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new KeyboardMovementProcessor();
        }

        public override bool IsValidVerticalMovement(Vector2 movementVector)
        {
            return movement.IsValidVerticalMovement(transform, inputProcessor.InputVector(movementVector));
        }

        public override bool IsValidHorizontalMovement(Vector2 movementVector)
        {
            return movement.IsValidHorizontalMovement(transform, inputProcessor.InputVector(movementVector));
        }

        public override void Move(Vector2 movementVector)
        {
            // Validates Movement
            movement.Move(transform, inputProcessor.InputVector(movementVector * moveSpeed));
        }
    }
}
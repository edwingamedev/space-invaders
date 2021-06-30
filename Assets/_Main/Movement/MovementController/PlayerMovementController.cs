using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class PlayerMovementController : AMovementController
    {
        private IInputProcessor inputProcessor;

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
            if (IsValidHorizontalMovement(movementVector) && 
                IsValidVerticalMovement(movementVector))
                movement.Move(transform, inputProcessor.InputVector(movementVector * moveSpeed));
        }

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new KeyboardMovementProcessor();
        }
    }
}
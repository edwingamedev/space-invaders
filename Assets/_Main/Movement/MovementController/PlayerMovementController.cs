using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class PlayerMovementController : AMovementController
    {
        private IMovementProcessor inputProcessor;

        public override bool IsValidMovement(Vector2 movementVector)
        {
            return movement.IsValidMovement(transform, inputProcessor.MovementVector(movementVector));            
        }

        public override void Move(Vector2 movementVector)
        {
            movement.Move(transform, inputProcessor.MovementVector(movementVector));
        }

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new KeyboardMovementProcessor();
        }
    }
}
﻿using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class PlayerMovementController : AMovementController
    {
        private IInputProcessor inputProcessor;

        public override bool IsValidMovement(Vector2 movementVector)
        {
            return movement.IsValidMovement(transform, inputProcessor.InputVector(movementVector));            
        }

        public override void Move(Vector2 movementVector)
        {
            movement.Move(transform, inputProcessor.InputVector(movementVector * moveSpeed));
        }

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new KeyboardMovementProcessor();
        }
    }
}
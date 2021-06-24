using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class PlayerMovementController : AMovementController
    {
        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new KeyboardMovementProcessor(horizontalMovement, verticalMovement);
        }
    }
}
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class AIMovementController : AMovementController
    {        

        private void Awake()
        {
            movement = new MoveWithBounds(gameBounds);
            inputProcessor = new AIMovementProcessor(horizontalMovement, verticalMovement);
        }
    }
}
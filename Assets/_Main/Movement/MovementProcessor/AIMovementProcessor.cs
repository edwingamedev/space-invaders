using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class AIMovementProcessor : IMovementProcessor
    {
        private MovementAxis movementAxis;

        public AIMovementProcessor(MovementAxis movementAxis)
        {
            this.movementAxis = movementAxis;
        }

        public Vector2 MovementVector(float moveSpeed)
        {
            return new Vector2(HorizontalMovement(moveSpeed), VerticalMovement(moveSpeed));
        }

        private float VerticalMovement(float moveSpeed)
        {
            return movementAxis.verticalMovement ? moveSpeed : 0;
        }

        private float HorizontalMovement(float moveSpeed)
        {
            return movementAxis.horizontalMovement ? moveSpeed : 0;
        }
    }
}
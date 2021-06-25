using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class KeyboardMovementProcessor : IMovementProcessor
    {
        private MovementAxis movementAxis;

        public KeyboardMovementProcessor(MovementAxis movementAxis)
        {
            this.movementAxis = movementAxis;
        }

        public Vector2 MovementVector(float moveSpeed)
        {
            return new Vector2(HorizontalMovement(moveSpeed), VerticalMovement(moveSpeed));
        }

        private float VerticalMovement(float moveSpeed)
        {
            return movementAxis.verticalMovement ? Input.GetAxisRaw("Vertical") * moveSpeed : 0;
        }

        private float HorizontalMovement(float moveSpeed)
        {
            return movementAxis.horizontalMovement ? Input.GetAxisRaw("Horizontal") * moveSpeed : 0;
        }
    }
}
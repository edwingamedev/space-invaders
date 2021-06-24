using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class KeyboardMovementProcessor : IMovementProcessor
    {
        private bool horizontalMovement;
        private bool verticalMovement;

        public KeyboardMovementProcessor(bool horizontalMovement, bool verticalMovement)
        {
            this.horizontalMovement = horizontalMovement;
            this.verticalMovement = verticalMovement;
        }

        public Vector2 MovementVector(float moveSpeed)
        {
            return new Vector2(HorizontalMovement(moveSpeed), VerticalMovement(moveSpeed));
        }

        private float VerticalMovement(float moveSpeed)
        {
            return verticalMovement ? Input.GetAxisRaw("Vertical") * moveSpeed : 0;
        }

        private float HorizontalMovement(float moveSpeed)
        {
            return horizontalMovement ? Input.GetAxisRaw("Horizontal") * moveSpeed : 0;
        }
    }
}
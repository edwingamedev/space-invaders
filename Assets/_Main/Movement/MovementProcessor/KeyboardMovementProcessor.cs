using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class KeyboardMovementProcessor : IMovementProcessor
    {

        public Vector2 MovementVector(Vector2 movementVector)
        {
            return new Vector2(HorizontalMovement(movementVector.x), VerticalMovement(movementVector.y));
        }

        private float VerticalMovement(float moveAmount)
        {
            return Input.GetAxisRaw("Vertical") * moveAmount;
        }

        private float HorizontalMovement(float moveAmount)
        {
            return Input.GetAxisRaw("Horizontal") * moveAmount;
        }
    }
}
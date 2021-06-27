using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class KeyboardMovementProcessor : IInputProcessor
    {
        public Vector2 InputVector(Vector2 movementVector)
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
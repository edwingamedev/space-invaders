using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMovable
    {
        bool IsValidVerticalMovement(Vector2 movementVector);

        bool IsValidHorizontalMovement(Vector2 movementVector);

        void Move(Vector2 movementVector);
    }
}
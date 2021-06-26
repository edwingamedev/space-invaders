using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMovable
    {
        bool IsValidMovement(Vector2 movementVector);

        void Move(Vector2 movementVector);
    }
}
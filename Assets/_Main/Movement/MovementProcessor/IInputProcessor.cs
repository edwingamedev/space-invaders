using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IInputProcessor
    {
        Vector2 InputVector(Vector2 movementVector);
    }
}
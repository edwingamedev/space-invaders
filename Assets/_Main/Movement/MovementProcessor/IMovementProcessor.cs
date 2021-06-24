using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMovementProcessor
    {
        Vector2 MovementVector(float moveSpeed);
    }
}
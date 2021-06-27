using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public abstract class AMovementController : MonoBehaviour
    {

        protected IMovement movement;

        [SerializeField] protected GameBounds gameBounds;

        [SerializeField] protected float moveSpeed;

        public bool canMove;

        public abstract bool IsValidMovement(Vector2 movementVector);
        public abstract void Move(Vector2 movementVector);
    }
}
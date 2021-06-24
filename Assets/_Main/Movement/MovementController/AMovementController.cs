using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public abstract class AMovementController : MonoBehaviour
    {
        protected IMovement movement;
        protected IMovementProcessor inputProcessor;
        
        [SerializeField] protected GameBounds gameBounds;

        [SerializeField] protected float moveSpeed;

        [SerializeField] protected bool horizontalMovement;
        [SerializeField] protected bool verticalMovement;
        
        [SerializeField] protected bool canMove;

        public void Move(float deltaTime)
        {
            if (canMove)
            {
                movement.Move(transform, inputProcessor.MovementVector(deltaTime * moveSpeed));
            }
        }
    }
}
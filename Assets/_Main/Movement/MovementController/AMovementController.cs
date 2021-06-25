using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public abstract class AMovementController : MonoBehaviour
    {
        public AMovementController()
        {
            movementAxis = new MovementAxis();
        }

        protected IMovement movement;
        protected IMovementProcessor inputProcessor;

        [SerializeField] protected GameBounds gameBounds;

        [SerializeField] protected float moveSpeed;

        public MovementAxis movementAxis;

        [SerializeField] protected bool canMove;

        public bool IsValidMovement(float deltaTime) => movement.IsValidMovement(transform, inputProcessor.MovementVector(deltaTime * moveSpeed));
        public void Move(float deltaTime) => movement.Move(transform, inputProcessor.MovementVector(deltaTime * moveSpeed));
    }

    [System.Serializable]
    public class MovementAxis
    {
        public bool horizontalMovement;
        public bool verticalMovement;
    }
}
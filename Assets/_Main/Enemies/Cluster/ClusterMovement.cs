using EdwinGameDev.Enemies;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class ClusterMovement : MonoBehaviour
    {
        [SerializeField] private MovementSettings movementSettings;

        private float nextMovement;
        private int currentIndex = 0;
        private bool canMove;

        private void Start()
        {
            SetNextMovement();
        }

        private void EnemyReachedBorder(IEnemy[,] enemies)
        {
            movementSettings.moveDistanceHorizontal *= -1;
            currentIndex = -1;

            MoveDown(enemies, movementSettings.moveDistanceVertical);
        }

        public void Move(IEnemy[,] enemies, float deltaTime)
        {
            if (enemies == null)
                return;

            if (Time.time > nextMovement)
            {
                SetNextMovement();

                MoveRow(enemies, deltaTime * movementSettings.moveDistanceHorizontal, currentIndex);

                currentIndex++;

                if (currentIndex >= enemies.GetLength(1))
                {
                    //canMove = false;
                    currentIndex = 0;
                }
            }
        }

        private void MoveRow(IEnemy[,] enemies, float deltaTime, int rowToMove)
        {
            //Validate movement
            int rows = enemies.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                canMove = enemies[i, rowToMove].Movable.IsValidMovement(deltaTime * Vector2.right);

                if (!canMove)
                    break;
            }

            // Move
            if (canMove)
            {
                for (int i = 0; i < rows; i++)
                {
                    enemies[i, rowToMove].Movable.Move(deltaTime * Vector2.right);
                }
            }
            else
            {
                EnemyReachedBorder(enemies);
            }
        }

        public void MoveDown(IEnemy[,] enemies, float moveSpeed)
        {
            int rows = enemies.GetLength(0);
            int columns = enemies.GetLength(1) - 1;

            for (int j = columns; j >= 0; j--)
            {
                for (int i = 0; i < rows; i++)
                {
                    enemies[i, j].Movable.Move(moveSpeed * Vector2.down);
                }
            }
        }

        private void SetNextMovement()
        {
            nextMovement = Time.time + movementSettings.movementFrequency;
        }
    }
}
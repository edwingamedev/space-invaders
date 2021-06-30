using EdwinGameDev.Enemies;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class ClusterMovement : MonoBehaviour
    {
        [SerializeField] private MovementSettings movementSettings;

        private bool canMove;
        private int direction = 1;

        private void EnemyReachedBorder(IEnemy[,] enemies)
        {
            direction *= -1;

            MoveDown(enemies, movementSettings.verticalSpeed);
        }

        public void Move(IEnemy[,] enemies, float deltaTime, int enemiesDead)
        {
            if (enemies == null)
                return;

            float killPercentage = (float)enemiesDead / (float)enemies.Length;

            MoveSideways(enemies,  deltaTime * direction * movementSettings.horizontalSpeed.Evaluate(killPercentage));
        }

        private void MoveSideways(IEnemy[,] enemies, float deltaTime)
        {
            //Validate movement
            int rows = enemies.GetLength(0) - 1;
            int columns = enemies.GetLength(1) - 1;

            for (int j = columns; j >= 0; j--)
            {
                for (int i = rows; i >= 0; i--)
                {
                    if (enemies[i, j].gameObject.activeInHierarchy)
                    {
                        canMove = enemies[i, j].Movable.IsValidHorizontalMovement(deltaTime * Vector2.right);

                        if (!canMove)
                            break;
                    }
                }

                if (!canMove)
                    break;
            }

            // Move
            if (canMove)
            {
                for (int j = columns; j >= 0; j--)
                {
                    for (int i = rows; i >= 0; i--)
                    {
                        if (enemies[i, j].gameObject.activeInHierarchy)
                        {
                            enemies[i, j].Movable.Move(deltaTime * Vector2.right);
                        }
                    }
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
            int columns = enemies.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (enemies[i, j].gameObject.activeInHierarchy)
                        enemies[i, j].Movable.Move(moveSpeed * Vector2.down);
                }
            }
        }
    }
}
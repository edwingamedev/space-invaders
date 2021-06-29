using EdwinGameDev.Enemies;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class ClusterMovement : MonoBehaviour
    {
        [SerializeField] private MovementSettings movementSettings;

        private float nextMovement;
        private bool canMove;
        [SerializeField] private float moveRatio;

        private void Start()
        {
            SetNextMovement(1, 0);
        }

        private void EnemyReachedBorder(IEnemy[,] enemies)
        {
            movementSettings.moveDistanceHorizontal *= -1;

            Debug.Log("EnemyReachedBorder");

            MoveDown(enemies, movementSettings.moveDistanceVertical);
        }

        public void Move(IEnemy[,] enemies, float deltaTime, int enemiesDead)
        {
            if (enemies == null)
                return;

            if (Time.time > nextMovement)
            {
                SetNextMovement(enemies.Length, enemiesDead);

                MoveSideways(enemies, deltaTime * movementSettings.moveDistanceHorizontal);
            }
        }

        private void MoveSideways(IEnemy[,] enemies, float deltaTime)
        {
            //Validate movement
            int rows = enemies.GetLength(0);
            int columns = enemies.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (!enemies[i, j].gameObject.activeInHierarchy)
                        continue;

                    canMove = enemies[i, j].Movable.IsValidMovement(deltaTime * Vector2.right);

                    if (!canMove)
                        break;
                }
            }

            // Move
            if (canMove)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (!enemies[i, j].gameObject.activeInHierarchy)
                            continue;

                        enemies[i, j].Movable.Move(deltaTime * Vector2.right);
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
                    if (!enemies[i, j].gameObject.activeInHierarchy)
                        continue;

                    enemies[i, j].Movable.Move(moveSpeed * Vector2.down);
                }
            }
        }

        private void SetNextMovement(int numOfEnemies, int enemiesDead)
        {
            moveRatio = (movementSettings.movementFrequency - ((0.019f / numOfEnemies) * enemiesDead));
            nextMovement = Time.time + moveRatio;
        }
    }
}
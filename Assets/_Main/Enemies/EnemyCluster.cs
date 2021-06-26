using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class EnemyCluster : MonoBehaviour
    {
        public List<Enemy> enemies;
        private bool canMove;

        private Action onReachedBorder;

        public void SetEnemyBehaviourOnReachBorder(Action OnReachedBorder)
        {
            onReachedBorder = OnReachedBorder;
        }

        public void MoveDown(float moveSpeed)
        {
            foreach (var enemy in enemies)
            {
                enemy.movementController.Move(moveSpeed * Vector2.down);
            }
        }

        public void Move(float deltaTime)
        {
            //Validate movement
            foreach (var enemy in enemies)
            {
                canMove = enemy.movementController.IsValidMovement(deltaTime * Vector2.right);

                if (!canMove)
                    break;
            }

            // Move
            if (canMove)
            {
                foreach (var enemy in enemies)
                {
                    enemy.movementController.Move(deltaTime * Vector2.right);
                }
            }
            else
            {
                onReachedBorder?.Invoke();
            }
        }
    }
}
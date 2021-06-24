using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class EnemyCluster : MonoBehaviour
    {
        public List<Enemy> enemies;
        public bool canMove;

        public void StartMovement()
        {
            canMove = true;
        }

        private void Update()
        {
            if (canMove)
                Move(Time.deltaTime);
        }

        public void Move(float deltaTime)
        {
            foreach (var enemy in enemies)
            {
                enemy.movementController.Move(deltaTime);
            }
        }
    }
}
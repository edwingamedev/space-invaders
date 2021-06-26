using EdwinGameDev.Movement;
using EdwinGameDev.Settings;
using System;
using System.Collections;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class EnemyCluster : MonoBehaviour
    {
        [SerializeField] private ClusterSetup clusterSetup;        
        [SerializeField] private GameBounds gameBounds;
        [SerializeField] private ClusterMovement clusterMovement;
        public bool canMove;

        private IEnemy[,] enemies;
        private EnemySpawner enemySpawner;        

        private void Start()
        {
            enemySpawner = new EnemySpawner(gameBounds);
            SpawnRows();
        }

        private void FixedUpdate()
        {
            if (canMove)
                clusterMovement.Move(enemies, Time.deltaTime);
        }

        private void SpawnRows()
        {
            enemies = enemySpawner.SpawnEnemies(clusterSetup);
        }
    }
}
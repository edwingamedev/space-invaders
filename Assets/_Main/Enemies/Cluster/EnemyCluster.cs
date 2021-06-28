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
        [SerializeField] private IClusterWeaponController clusterWeapon = new BottomClusterWeapon(2);
        public bool canMove;

        private IEnemy[,] enemies;
        private IEnemySpawner enemySpawner;

        private void Start()
        {
            enemySpawner = new ClusterEnemySpawner(gameBounds);
            SpawnRows();
        }

        private void FixedUpdate()
        {
            if (canMove)
                clusterMovement.Move(enemies, Time.deltaTime);
        }

        private void Update()
        {
            clusterWeapon?.Shoot(enemies);
        }

        private void SpawnRows()
        {
            enemies = enemySpawner.SpawnEnemies(clusterSetup);
        }
    }
}
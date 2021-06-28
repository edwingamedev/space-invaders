using EdwinGameDev.Movement;
using EdwinGameDev.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class BottomClusterWeapon : IClusterWeaponController
    {
        private List<IEnemy> shooters = new List<IEnemy>();
        private float fireRate;
        private float nextShoot;

        public BottomClusterWeapon(float fireRate)
        {
            this.fireRate = fireRate;
        }

        public void Shoot(IEnemy[,] enemies)
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + fireRate;

                int rows = enemies.GetLength(0);
                int columns = enemies.GetLength(1);

                SelectShooters(enemies, rows, columns);

                Shoot();
            }
        }

        private void SelectShooters(IEnemy[,] enemies, int rows, int columns)
        {
            shooters.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var unit = enemies[i, j] as Enemy;

                    if (unit.gameObject.activeInHierarchy)
                    {
                        shooters.Add(unit);
                        break;
                    }
                }

                if (shooters.Count >= rows)
                {
                    break;
                }
            }
        }

        private void Shoot()
        {
            // Shoots
            foreach (var shooter in shooters)
            {
                Debug.Log((shooter as Enemy).name);

                shooter.GetWeapons.Shoot();
            }
        }
    }

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
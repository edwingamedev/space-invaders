using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class BottomClusterWeapon : IClusterWeaponController
    {
        public class Shooter
        {
            public IEnemy enemy;
            public float shootDelay;

            public Shooter(IEnemy enemy, float shootDelay)
            {
                this.enemy = enemy;
                this.shootDelay = shootDelay;
            }

            public bool Shoot()
            {
                if (Time.time > shootDelay)
                {
                    enemy.GetWeapons.Shoot();

                    return true;
                }

                return false;
            }
        }

        private List<Shooter> shooters = new List<Shooter>();

        private float fireRate;
        private float nextShoot;

        private float shootChance = 30;
        private float secondsBetweenShoots = 1f;

        public BottomClusterWeapon(float fireRate)
        {
            this.fireRate = fireRate;
        }

        public void ResetWeapon()
        {
            nextShoot = Time.time + fireRate;
            shooters.Clear();
        }

        public void Shoot(IEnemy[,] enemies)
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + fireRate;

                int rows = enemies.GetLength(0);
                int columns = enemies.GetLength(1);

                SelectShooters(enemies, rows, columns);
            }

            Shoot();
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
                        shooters.Add(new Shooter(unit, Time.time + secondsBetweenShoots + Random.value)); ;
                        break;
                    }
                }

                if (shooters.Count >= rows)
                {
                    break;
                }
            }

            // Add shoot change
            for (int i = shooters.Count - 1; i >= 0; i--)
            {
                if (Random.Range(0, 100) > shootChance)
                {
                    shooters.Remove(shooters[i]);
                }
            }
        }

        private void Shoot()
        {
            // Shoots
            for (int i = shooters.Count - 1; i >= 0; i--)
            {
                if (shooters[i].Shoot())
                {
                    shooters.Remove(shooters[i]);
                }
            }
        }
    }
}
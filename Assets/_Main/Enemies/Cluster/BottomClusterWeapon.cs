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
}
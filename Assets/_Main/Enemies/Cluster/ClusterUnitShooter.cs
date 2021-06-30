using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class ClusterUnitShooter
    {
        public IEnemy enemy;
        public float shootDelay;

        public ClusterUnitShooter(IEnemy enemy, float shootDelay)
        {
            this.enemy = enemy;
            this.shootDelay = shootDelay;
        }

        public bool Shoot()
        {
            if (Time.time > shootDelay)
            {
                if (enemy.gameObject.activeInHierarchy)
                    enemy.GetWeapons.Shoot();

                return true;
            }

            return false;
        }
    }
}
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public abstract class AWeaponController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public abstract IWeapon GetWeapon();
        [SerializeField] protected int poolSize = 30;

        private Pooling bulletPool;
        protected GameObject currentBullet;

        public abstract void Shoot();

        protected void ShootFromPosition(Transform shootingPoint)
        {
            if (bulletPool == null)
            {
                CreateBulletPool(poolSize);
            }
            else
            {
                // Get bullet from pool
                currentBullet = bulletPool.GetFromPool();

                if (currentBullet != null)
                {
                    // Assign shooting point values
                    currentBullet.transform.position = shootingPoint.position;
                    currentBullet.transform.rotation = shootingPoint.rotation;

                    // Reset        
                    currentBullet = null;
                }
            }
        }

        protected void CreateBulletPool(int poolSize)
        {
            // Instantiate gameobject
            GameObject poolGo = new GameObject("Pool_" + GetWeapon().GetType().ToString());

            // Create specialized pool
            bulletPool = poolGo.AddComponent<Pooling>();
            bulletPool.CreatePool(bulletPrefab, poolSize);
        }
    }
}
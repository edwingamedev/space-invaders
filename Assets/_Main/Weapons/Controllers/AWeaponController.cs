using EdwinGameDev.Projectile;
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public abstract class AWeaponController : MonoBehaviour, IObserver
    {
        public GameObject bulletPrefab;
        protected AProjectile projectile;

        public abstract IWeapon GetWeapon();
        [SerializeField] protected int poolSize = 30;

        private Pooling projectilePool;

        public abstract void Shoot();
        public virtual void ReceiveNotification(ISubject subject) { }

        protected void ShootFromPosition(Transform shootingPoint)
        {
            if (projectilePool == null)
            {
                CreateBulletPool(poolSize);
            }

            // Get bullet from pool
            projectile = projectilePool.GetFromPool() as AProjectile;

            if (projectile != null)
            {
                projectile.Attach(this);

                // Assign shooting point values
                projectile.transform.position = shootingPoint.position;
                projectile.transform.rotation = shootingPoint.rotation;

                // Reset        
                projectile = null;
            }
        }

        protected void CreateBulletPool(int poolSize)
        {
            // Instantiate gameobject
            GameObject poolGo = new GameObject("Pool_" + GetWeapon().GetType().ToString());

            // Create specialized pool
            projectilePool = poolGo.AddComponent<Pooling>();
            projectile = bulletPrefab.GetComponent<AProjectile>();

            projectilePool.CreatePool(projectile, poolSize);
        }
    }
}
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    [System.Serializable]
    public class BulletStatus
    {
        public int damage;

        public void ApplyDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(damage);
        }
    }
}
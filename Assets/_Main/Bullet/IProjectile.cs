using System;

namespace EdwinGameDev.Projectile
{
    public interface IProjectile
    {
        void ApplyDamage(IDamageable damageable);
    }
}
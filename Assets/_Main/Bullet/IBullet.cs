namespace EdwinGameDev.Projectile
{
    public interface IBullet
    {
        void ApplyDamage(IDamageable damageable);
    }
}
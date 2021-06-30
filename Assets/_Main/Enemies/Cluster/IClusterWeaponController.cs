namespace EdwinGameDev.Enemies
{
    public interface IClusterWeaponController
    {
        void ResetWeapon();
        void Shoot(IEnemy[,] enemies);
    }
}
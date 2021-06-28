namespace EdwinGameDev.Enemies
{
    public interface IClusterWeaponController
    {
        void Shoot(IEnemy[,] enemies);
    }
}
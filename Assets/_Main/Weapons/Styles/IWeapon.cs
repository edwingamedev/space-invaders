namespace EdwinGameDev.Weapons
{
    public interface IWeapon
    {
        void AddPower();
        void RemovePower();
        void Shoot();
        void AddController(AWeaponController weaponController);
    }
}
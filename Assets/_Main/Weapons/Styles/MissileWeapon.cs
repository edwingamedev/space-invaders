namespace EdwinGameDev.Weapons
{
    public class MissileWeapon : AWeapon
    {
        protected override float FireRate { get; set; }
        protected override int PowerLevel { get; set; }
        protected override int MaxPower { get; set; }

        public MissileWeapon(AWeaponController weaponController) : base(weaponController)
        {
            FireRate = 0;
            PowerLevel = 2;
            MaxPower = 3;
        }
    }
}
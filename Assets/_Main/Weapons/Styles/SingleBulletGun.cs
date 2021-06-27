namespace EdwinGameDev.Weapons
{
    public class SingleBulletGun : AWeapon
    {
        protected override float FireRate { get; set; }
        protected override int PowerLevel { get; set; }
        protected override int MaxPower { get; set; }

        public SingleBulletGun(AWeaponController weaponController) : base(weaponController)
        {
            FireRate = 0f;
            PowerLevel = 1;
            MaxPower = 1;
        }
    }
}
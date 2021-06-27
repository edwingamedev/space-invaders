namespace EdwinGameDev.Weapons
{

    public class SimpleGun : AWeapon
    {
        protected override float FireRate { get; set; }
        protected override int PowerLevel { get; set; }
        protected override int MaxPower { get; set; }

        public SimpleGun(AWeaponController weaponController) : base(weaponController)
        {
            FireRate = 1;
            PowerLevel = 1;
            MaxPower = 3;
        }
    }
}
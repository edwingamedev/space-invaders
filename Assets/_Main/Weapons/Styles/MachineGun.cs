namespace EdwinGameDev.Weapons
{
    public class MachineGun : AWeapon
    {
        protected override float FireRate { get; set; }
        protected override int PowerLevel { get; set; }
        protected override int MaxPower { get; set; }

        public MachineGun(AWeaponController weaponController) : base(weaponController)
        {
            FireRate = .25f;
            PowerLevel = 1;
            MaxPower = 3;
        }
    }
}
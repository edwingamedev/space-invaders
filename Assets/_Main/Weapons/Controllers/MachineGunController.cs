using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class MachineGunController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        public override IWeapon GetWeapon()
        {
            if(weapon == null)
                weapon = new MachineGun(this);

            return weapon;
        }

        public override void Shoot()
        {
            ShootFromPosition(shootingPoint);
        }
    }
}
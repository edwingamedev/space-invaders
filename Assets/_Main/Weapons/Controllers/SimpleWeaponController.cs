using UnityEngine;

namespace EdwinGameDev.Weapons
{

    public class SimpleWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        public override IWeapon GetWeapon()
        {
            if (weapon == null)
                weapon = new SimpleGun(this);

            return weapon;
        }

        public override void Shoot()
        {
            ShootFromPosition(shootingPoint);
        }
    }
}
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class MissileWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        public override IWeapon GetWeapon()
        {
            if (weapon == null)
                weapon = new MissileWeapon(this);

            return weapon;
        }

        public override void Shoot()
        {
            if (canShoot && Input.GetButtonDown("Fire1"))
            {
                canShoot = false;

                ShootFromPosition(shootingPoint);
            }
        }
    }
}
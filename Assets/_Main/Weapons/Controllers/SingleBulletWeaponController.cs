using EdwinGameDev.Events;
using EdwinGameDev.Projectile;
using System;
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class SingleBulletWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        private void Awake()
        {
            EnableShoot();
        }

        private void EnableShoot()
        {
            canShoot = true;
        }

        public override IWeapon GetWeapon()
        {
            if (weapon == null)
                weapon = new SingleBulletGun(this);

            return weapon;
        }

        public override void Shoot()
        {
            if (canShoot && Input.GetButtonDown("Jump"))
            {
                canShoot = false;

                ShootFromPosition(shootingPoint);
            }
        }

        public override void ReceiveNotification(ISubject subject)
        {
            if ((subject as IProjectile) != null)
            {
                EnableShoot();
            }
        }
    }
}
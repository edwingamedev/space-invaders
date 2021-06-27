using EdwinGameDev.Projectile;
using System;
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class SingleBulletWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;
        private bool canShoot = true;

        private void Start()
        {
            weapon = new SingleBulletGun(this);
        }

        private void EnableShoot()
        {
            Debug.Log("Enable shoot");

            canShoot = true;
        }

        public override IWeapon GetWeapon()
        {
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
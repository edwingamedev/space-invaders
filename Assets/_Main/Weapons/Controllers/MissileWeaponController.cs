using EdwinGameDev.Events;
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class MissileWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        public ScriptableEvent<bool> onMissileEnabled;
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
                onMissileEnabled.Notify(false);
                ShootFromPosition(shootingPoint);
            }
        }
    }
}
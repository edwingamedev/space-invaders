using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class SingleBulletWeaponController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        private void Start()
        {
            weapon = new SingleBulletGun(this);
        }

        public override IWeapon GetWeapon()
        {
            return weapon;
        }

        public override void Shoot()
        {
            if (Input.GetButtonDown("Jump"))
                ShootFromPosition(shootingPoint);
        }
    }
}
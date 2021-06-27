using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class MachineGunController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        private void Start()
        {
            weapon = new MachineGun(this);
        }

        public override IWeapon GetWeapon()
        {
            return weapon;
        }

        public override void Shoot()
        {
            ShootFromPosition(shootingPoint);
        }
    }
}
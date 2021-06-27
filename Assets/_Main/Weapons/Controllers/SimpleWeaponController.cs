using UnityEngine;

namespace EdwinGameDev.Weapons
{

    public class SimpleWeaponController : AWeaponController
    {        
        [SerializeField] private Transform shootingPoint;
        private IWeapon weapon;

        private void Start()
        {
            weapon = new SimpleGun(this);
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
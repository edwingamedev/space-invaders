using UnityEngine;

namespace EdwinGameDev.Weapons
{
    [System.Serializable]
    public abstract class AWeapon : IWeapon
    {
        protected abstract float FireRate { get; set; }
        protected float FirePower { get { return FireRate / (float)PowerLevel; } }
        protected float nextShoot = 0;
        protected abstract int MaxPower { get; set; }
        protected abstract int PowerLevel { get; set; }
        protected AWeaponController weaponController;

        public AWeapon(AWeaponController weaponController)
        {
            AddController(weaponController);
        }

        public virtual void AddController(AWeaponController weaponController)
        {
            this.weaponController = weaponController;
        }

        public virtual void AddPower()
        {
            if (PowerLevel < MaxPower)
            {
                PowerLevel++;
                Debug.Log("Added power " + PowerLevel);
            }
            else
            {
                Debug.Log("Weapon already at max level" + PowerLevel);
            }
        }

        public virtual void RemovePower()
        {
            if (PowerLevel > 2)
            {
                PowerLevel--;
            }
            else
            {
                Debug.Log("Cannot remove power, already at minimum. ");
            }
        }

        public virtual void Shoot()
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + FirePower;

                weaponController.Shoot();
            }
        }
    }
}
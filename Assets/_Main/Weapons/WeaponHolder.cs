using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        private List<IWeapon> weapons = new List<IWeapon>();
        public bool canShoot;

        private void Start()
        {
            // Add the weapons that are already at the prefab
            InitialWeapons();
        }

        private void InitialWeapons()
        {
            // Get weapon controllers at the children
            AWeaponController[] wc = GetComponentsInChildren<AWeaponController>();

            for (int i = 0; i < wc.Length; i++)
            {
                // Add weapon to weapons list
                AddWeapon(wc[i].GetWeapon());
            }
        }

        /// <summary>
        /// Adds a single weapon
        /// </summary>
        /// <param name="weapon"></param>
        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
            Debug.Log("Added " + weapon);
        }

        public void AddMultipleWeapons(AWeaponController[] weapons)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                // Add Weapon
                AddWeapon(weapons[i].GetWeapon());
            }
        }

        /// <summary>
        /// Shoots with every weapon
        /// </summary>
        public void Shoot()
        {
            if (!canShoot)
                return;

            foreach (var weapon in weapons)
            {
                weapon?.Shoot();
            }
        }

    }
}
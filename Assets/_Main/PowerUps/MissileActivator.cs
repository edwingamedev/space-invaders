using EdwinGameDev.Events;
using EdwinGameDev.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.PowerUps
{
    public class MissileActivator : MonoBehaviour
    {
        [SerializeField] private int killsToActivate;
        private int currentKills;

        public ScriptableEvent<int> onEnemyDied;
        public ScriptableEvent<bool> onMissileEnabled;

        public AWeaponController weapon;

        private bool activated;

        private void Awake()
        {
            onEnemyDied.Subscribe(AddGauge);
            onMissileEnabled.Subscribe(DisableWeapon);
        }

        private void AddGauge(int value)
        {
            // Don't count enemies when missile is activated
            if (activated)
                return;

            currentKills++;

            if (currentKills >= killsToActivate)
            {
                Activate();
            }
        }
        private void DisableWeapon(bool value)
        {
            if (!value)
            {
                currentKills = 0;
                activated = false;
            }

        }

        private void Activate()
        {
            activated = true;

            onMissileEnabled.Notify(true);

            // Single shot
            weapon.canShoot = true;
        }
    }
}
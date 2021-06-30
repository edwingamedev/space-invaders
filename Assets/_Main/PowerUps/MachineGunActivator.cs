using EdwinGameDev.Events;
using EdwinGameDev.Weapons;
using UnityEngine;

namespace EdwinGameDev.PowerUps
{
    public class MachineGunActivator : MonoBehaviour
    {
        [SerializeField] private int killsToActivate;
        private int currentKills;

        public ScriptableEvent<int> onEnemyDied;
        public ScriptableEvent<int> onMachineGunEnabled;

        public AWeaponController weapon;
                
        [SerializeField] private float shootingTime;
        private float cooldown;
        private bool activated;

        private void Awake()
        {
            onEnemyDied?.Subscribe(AddGauge);
            DisableWeapon();
        }

        private void AddGauge(int value)
        {
            if (activated)
                return;

            currentKills++;

            if (currentKills >= killsToActivate)
            {
                Activate();
            }
        }

        private void Update()
        {
            if (Time.time > cooldown)
            {
                DisableWeapon();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Activate();
            }
        }

        public void DisableWeapon()
        {
            activated = false;            

            weapon.canShoot = false;
        }

        public void Activate()
        {
            currentKills = 0;

            cooldown = Time.time + shootingTime;

            onMachineGunEnabled?.Notify(Mathf.FloorToInt(shootingTime));

            activated = true;                        
            weapon.canShoot = true;
        }
    }
}
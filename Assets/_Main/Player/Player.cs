using EdwinGameDev.Events;
using EdwinGameDev.Movement;
using EdwinGameDev.Projectile;
using EdwinGameDev.Settings;
using EdwinGameDev.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Players
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;
        private int maxHealth;
        [SerializeField] private AMovementController movementController;
        [SerializeField] private WeaponHolder weapons;

        [SerializeField] private ScriptableEvent<bool> onPlayerDied;
        [SerializeField] private ScriptableEvent<int> onPlayerDamaged;

        private void Awake()
        {
            gameObject.tag = Tags.PLAYER;
            maxHealth = health;
        }

        private void Update()
        {
            movementController?.Move(Time.deltaTime * Vector2.right);
            weapons?.Shoot();
        }

        public void Respawn()
        {
            transform.position = Vector3.zero;

            // Reset health
            health = maxHealth;

            gameObject.SetActive(true);
        }

        public void ReceiveDamage(int value)
        {
            Debug.Log("player Damage: " + value);
            health -= value;

            // Notifies when player is damaged
            onPlayerDamaged?.Notify(value);

            // Notifies when player is dead
            if (health <= 0)
            {
                onPlayerDied?.Notify(true);
            }
                
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.BULLET))
            {
                col.GetComponent<IProjectile>().ApplyDamage(this);
            }
        }
    }
}
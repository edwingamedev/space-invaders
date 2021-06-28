using EdwinGameDev.Movement;
using EdwinGameDev.Projectile;
using EdwinGameDev.Settings;
using EdwinGameDev.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable, IEnemy
    {
        private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] private AIMovementController movementController;
        [SerializeField] private WeaponHolder weapons;
        public WeaponHolder GetWeapons => weapons;
        public IMovable Movable => movementController;

        private void Awake()
        {
            gameObject.tag = Tags.ENEMY;

            Setup();
        }

        private void Setup()
        {
            health = maxHealth;
        }

        public void ReceiveDamage(int value)
        {            
            if (health > 0)
                health -= value;

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
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
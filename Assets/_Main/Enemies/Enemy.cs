using EdwinGameDev.Movement;
using EdwinGameDev.Projectile;
using EdwinGameDev.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable, IEnemy
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] private AIMovementController movementController;

        public IMovable movable => movementController;

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
            Debug.Log("Enemy Damage: " + value);

            if (health > 0)
                health -= value;

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.BULLET))
            {
                col.GetComponent<IBullet>().ApplyDamage(this);
            }
        }
    }
}
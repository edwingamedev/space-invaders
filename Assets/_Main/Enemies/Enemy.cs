using EdwinGameDev.Events;
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
    public class Enemy : MonoBehaviour, IDamageable, IEnemy, ISubject
    {
        [SerializeField] private int health;
        [SerializeField] private int scoreValue;
        private int maxHealth;
        [SerializeField] private AIMovementController movementController;
        [SerializeField] private WeaponHolder weapons;
        public WeaponHolder GetWeapons => weapons;
        public IMovable Movable => movementController;

        public int ScoreValue => scoreValue;        

        protected List<IObserver> observers = new List<IObserver>();

        private void Awake()
        {
            gameObject.tag = Tags.ENEMY;

            Setup();
        }

        private void Setup()
        {
            maxHealth = health;
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

            //Reset health
            health = maxHealth;

            Notify();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.BULLET))
            {
                col.GetComponent<IProjectile>().ApplyDamage(this);
            }

            if (col.CompareTag(Tags.PLAYER))
            {
                col.GetComponent<IDamageable>().ReceiveDamage(1);
            }
        }
                
        public void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void UnSubscribe(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
                
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer?.ReceiveNotification(this);
            }
        }
    }
}
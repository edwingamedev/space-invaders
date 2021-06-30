using EdwinGameDev.Events;
using EdwinGameDev.Projectile;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Barriers
{
    public class Barrier : MonoBehaviour, IDamageable, ISubject
    {
        [SerializeField] private int life;
        private int maxLife;

        public int GetLife => life;

        private List<IObserver> observers = new List<IObserver>();

        private void Awake()
        {
            maxLife = life;
        }

        public void ReceiveDamage(int value)
        {
            SetLives(--life);
        }

        private void SetLives(int value)
        {
            life = value;

            if (life <= 0)
            {
                life = 0;

                Die();
            }

            Notify();
        }

        public void Initialize()
        {
            SetLives(maxLife);
            gameObject.SetActive(true);
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ReceiveDamage(0);
        }

        // The subscription management methods.
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

        // Trigger an update in each subscriber.
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer?.ReceiveNotification(this);
            }
        }
    }
}
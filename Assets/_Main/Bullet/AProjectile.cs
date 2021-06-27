using EdwinGameDev.Movement;
using EdwinGameDev.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public abstract class AProjectile : MonoBehaviour, IProjectile, IDamageable, IPool, ISubject
    {
        [SerializeField] protected BulletStatus bulletStatus;
        [SerializeField] protected AMovementController movementController;

        protected List<IObserver> observers = new List<IObserver>();

        public virtual bool isEnabled()
        {
            return gameObject.activeInHierarchy;
        }

        public virtual void DisableObject()
        {
            movementController.canMove = false;
            Notify();

            gameObject.SetActive(false);
        }

        public virtual void EnableObject()
        {
            movementController.canMove = true;

            gameObject.SetActive(true);
        }

        public virtual GameObject GetObject()
        {
            return gameObject;
        }

        public virtual void ApplyDamage(IDamageable damageable)
        {
            bulletStatus.ApplyDamage(damageable);
        }

        public virtual void ReceiveDamage(int value)
        {
            DisableObject();
        }

        // The subscription management methods.
        public virtual void Attach(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public virtual void Detach(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        // Trigger an update in each subscriber.
        public virtual void Notify()
        {
            foreach (var observer in observers)
            {
                observer?.ReceiveNotification(this);
            }
        }
    }
}
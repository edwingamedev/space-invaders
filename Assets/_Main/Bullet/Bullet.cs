using EdwinGameDev.Movement;
using EdwinGameDev.Settings;
using System.Collections;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public class Bullet : MonoBehaviour, IBullet, IDamageable
    {
        [SerializeField] private int damage;
        [SerializeField] private AMovementController movementController;

        private void Awake()
        {
            gameObject.tag = Tags.BULLET;
        }

        private void Update()
        {
            movementController?.Move(Time.deltaTime);
        }

        public void ApplyDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(damage);
            DisableBullet();
        }

        private void DisableBullet()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            ReceiveDamage(damage);
        }

        public void ReceiveDamage(int value)
        {
            DisableBullet();
        }
    }
}
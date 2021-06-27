using EdwinGameDev.Movement;
using EdwinGameDev.Settings;
using EdwinGameDev.Weapons;
using System.Collections;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public class SimpleBullet : MonoBehaviour, IProjectile, IDamageable, IPool
    {
        [SerializeField] private BulletStatus bulletStatus;
        [SerializeField] private AMovementController movementController;

        private void Awake()
        {
            gameObject.tag = Tags.BULLET;
        }

        private void FixedUpdate()
        {
            movementController?.Move(Vector2.up * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            ReceiveDamage(bulletStatus.damage);
        }

        public bool isEnabled()
        {
            return gameObject.activeInHierarchy;
        }

        public void EnableObject()
        {
            movementController.canMove = true;

            Invoke("DisableObject", 1);

            gameObject.SetActive(true);
        }

        public void DisableObject()
        {
            movementController.canMove = false;

            gameObject.SetActive(false);
        }

        public GameObject GetObject()
        {
            return gameObject;
        }

        public void ApplyDamage(IDamageable damageable)
        {
            bulletStatus.ApplyDamage(damageable);
        }

        public void ReceiveDamage(int value)
        {
            gameObject.SetActive(false);
        }
    }
}
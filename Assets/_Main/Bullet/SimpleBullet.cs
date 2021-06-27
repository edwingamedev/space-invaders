using EdwinGameDev.Settings;
using System.Collections;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public class SimpleBullet : AProjectile
    {
        private void Awake()
        {
            gameObject.tag = Tags.BULLET;
        }

        private void FixedUpdate()
        {
            if (movementController != null && movementController.IsValidMovement(Vector2.up * Time.deltaTime))
            {
                movementController?.Move(Vector2.up * Time.deltaTime);
            }
            else
            {
                DisableObject();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            ReceiveDamage(bulletStatus.damage);
        }
    }
}
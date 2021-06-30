using EdwinGameDev.Enemies;
using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public class MissileBullet : AProjectile
    {
        public Transform target;

        private void Awake()
        {
            gameObject.tag = Tags.BULLET;
        }

        private void FixedUpdate()
        {
            // Follow new target
            if (target != null)
            {
                // Look for new target
                if (!target.gameObject.activeInHierarchy)
                {
                    target = null;
                    return;
                }

                var dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                Debug.DrawLine(transform.position, target.position, Color.red);
            }

            // Move
            if (movementController != null && movementController.IsValidVerticalMovement(Vector2.up * Time.deltaTime) && movementController.IsValidHorizontalMovement(Vector2.up * Time.deltaTime))
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
            // Sets Target  
            target = null;

            ReceiveDamage(bulletStatus.damage);
        }
    }
}
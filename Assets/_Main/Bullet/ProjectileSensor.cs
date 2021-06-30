using EdwinGameDev.Settings;
using UnityEngine;

namespace EdwinGameDev.Projectile
{
    public class ProjectileSensor : MonoBehaviour
    {        
        public MissileBullet aProjectile;
        private const string tagToTrack = Tags.ENEMY;

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Sets Target
            if (aProjectile.target == null && col.CompareTag(tagToTrack))
            {
                aProjectile.target = col.transform;
            }
        }
    }
}
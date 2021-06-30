using UnityEngine;

namespace EdwinGameDev.Weapons
{
    public class MachineGunController : AWeaponController
    {
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private AnimationCurve shootingPatternX;
        [SerializeField] private int numOfPointsX;
        private int frameX;

        [SerializeField] private AnimationCurve shootingPatternY;
        [SerializeField] private int numOfPointsY;
        private int frameY;

        private IWeapon weapon;

        public override IWeapon GetWeapon()
        {
            if (weapon == null)
                weapon = new MachineGun(this);

            return weapon;
        }

        public override void Shoot()
        {
            if (canShoot)
            {
                shootingPoint.localPosition = EvaluateShootingPoints();

                ShootFromPosition(shootingPoint);
            }
        }

        private Vector2 EvaluateShootingPoints()
        {
            frameX = (frameX + 1) % numOfPointsX;
            frameY = (frameY + 1) % numOfPointsY;

            return new Vector2(shootingPatternX.Evaluate(frameX / (float)numOfPointsX), shootingPatternY.Evaluate(frameY / (float)numOfPointsY)); ;
        }
    }
}
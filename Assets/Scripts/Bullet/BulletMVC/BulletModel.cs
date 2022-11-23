using UnityEngine;

namespace Tanks.bullet
{

    public class BulletModel
    {
        public BulletModel(float bulletSpeed, float bulletDamage, Transform bulletTransform, ParticleSystem shellExplosion)
        {
            BulletSpeed = bulletSpeed;
            BulletDamage = bulletDamage;
            BulletTransform = bulletTransform;
            ShellExplosion = shellExplosion;
        }

        public float BulletSpeed
        {
            get;
        }

        public float BulletDamage
        {
            get;
        }

        public Transform BulletTransform
        {
            get;
        }

        public ParticleSystem ShellExplosion
        {
            get;
        }

    }
}
using UnityEngine;
using ObjectPool;
using Tanks.Tank;
using Tanks.Enemy;

namespace Tanks.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private TankType tankType;
        private Rigidbody rigidBody;
        private CapsuleCollider capsuleCollider;
        private MeshRenderer meshRenderer;
        private ParticleSystem particleSystem;
        public BulletController(BulletView _bulletView, BulletModel _bulletModel, TankType _tankType)
        {
            bulletModel = _bulletModel;
            bulletView = GameObject.Instantiate<BulletView>(_bulletView, bulletModel.BulletTransform.position, bulletModel.BulletTransform.rotation);
            bulletView.SetBulletViewController(this);
            tankType = _tankType;
            capsuleCollider = bulletView.GetComponent<CapsuleCollider>();
            rigidBody = bulletView.GetComponent<Rigidbody>();
            meshRenderer = bulletView.GetComponent<MeshRenderer>();
            particleSystem = bulletView.GetComponent<ParticleSystem>();
        }

        public void UpdateBulletMovement()
        {
            rigidBody.AddForce(bulletModel.BulletTransform.forward
                * bulletModel.BulletSpeed);
        }
        public void DisableBullet(Collision col)
        {
            if (col.gameObject.GetComponent<BulletView>() != null)
                return;
            if (!((tankType == TankType.player && col.gameObject.GetComponent<TankView>() != null)
                || (tankType == TankType.enemy && col.gameObject.GetComponent<EnemyView>() != null)))
            {
                MimicBulletDestroy();
            }
        }

        private void MimicBulletDestroy()
        {
            rigidBody.isKinematic = true;
            capsuleCollider.enabled = false;
            meshRenderer.enabled = false;
            particleSystem.Play();
        }

        public void ReturnBulletToBulletPool()
        {
            particleSystem.Stop();
            GenericPoolScript<BulletController>.Instance.Enqueue(this);
        }

        public void SetObjectActive()
        {
            rigidBody.isKinematic = false;
            capsuleCollider.enabled = true;
            meshRenderer.enabled = true;
            UpdateBulletMovement();
        }

        public void ChangeSpawnLocation(Transform _transform)
        {
            bulletView.gameObject.transform.position = _transform.position;
            bulletView.gameObject.transform.rotation = _transform.rotation;
            SetObjectActive();
        }

    }
}
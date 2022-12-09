using System.Collections.Generic;
using UnityEngine;
using System;
using ObjectPool;
using Tanks.Bullet;

namespace TankServices
{
    public class BulletManager : MonoBehaviour
    {
        int bulletFireCount = 0;
        BulletController bulletController;
        [Header("Bullet Scriptable Object List")]
        [SerializeField] List<BulletScriptableObject> bulletSpecsList;
        [Header("Bullet Models with BulletView List")]
        [SerializeField] List<BulletView> bulletViewList;
        [Header("Number of Bullets for the Pool")]
        [SerializeField] int bulletPoolCount = 20;
        [SerializeField] ParticleSystem shellExplosion;
        public void InstantiateBullet(int spawnIndex, TankType tankType)
        {
            if(tankType==TankType.player)
                ServiceEvents.Instance.OnShoot?.Invoke(++bulletFireCount);
            if (bulletFireCount < bulletPoolCount)
            {
                BulletModel bulletModel = new BulletModel(bulletSpecsList[spawnIndex].bulletSpeed,
                bulletSpecsList[spawnIndex].bulletDamage, this.transform, shellExplosion);
                bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel, tankType);
            }
            else
            {
                bulletController = GenericPoolScript<BulletController>.Instance.Dequeue();
                bulletController.ChangeSpawnLocation(this.transform);
            }
        }
    }
}
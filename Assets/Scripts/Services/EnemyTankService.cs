using System.Collections.Generic;
using UnityEngine;
using Tanks.enemy;

namespace TankServices
{
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        [SerializeField] EnemyView enemyView;
        [SerializeField] List<Vector3> spawnPoints;
        //[SerializeField] float EnemyChaseSpeed; to be used in future
        private void Start()
        {
            EnemyModel enemyModel = new EnemyModel(spawnPoints);
            int a = Random.Range(0, spawnPoints.Count);
            new EnemyController(spawnPoints[a], enemyView, enemyModel);
        }

    }

}
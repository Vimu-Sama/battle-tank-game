using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using TankServices;

namespace Tanks.Enemy
{
    public class EnemyController
    {
        EnemyView enemyView;
        EnemyModel enemyModel;
        NavMeshAgent navMeshAgent;
        int tempIndex = 0;
        Vector3 currDestination;
        public TankStateEnum tankStateEnum;

        public EnemyController(Vector3 spawnPoint, EnemyView _enemyView, EnemyModel _enemyModel)
        {
            enemyView = _enemyView;
            Vector3 tempPos = enemyView.gameObject.transform.position;
            enemyView = GameObject.Instantiate<EnemyView>(_enemyView, spawnPoint, Quaternion.identity);
            enemyModel = _enemyModel;
            enemyView.GetComponent<PatrolState>().OnEnterState();
            enemyView.LinkController(this);
            
            tankStateEnum = TankStateEnum.Patrol;
        }
        
        
        public void DestroyEnemy()
        {
            GameObject.Destroy(enemyView.gameObject);
        }
    }
}
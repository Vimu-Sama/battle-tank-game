using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.bullet;
using TankServices;

namespace Tanks.enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
        [SerializeField] private BulletView bulletSpeed ;
        private EnemyController enemyController;
        private WaitForSeconds WaitBeforeDestroy = new WaitForSeconds(4f);
        private ChaseState chaseState;
        private PatrolState patrolState;
        private IdleState idleState;
        private AttackState attackState;

        private void Start()
        {
            chaseState = GetComponent<ChaseState>();
            patrolState = GetComponent<PatrolState>();
            idleState = GetComponent<IdleState>();
            ServiceEvents.Instance.ChasePlayer += ChasePlayer;
            ServiceEvents.Instance.StopChase += StopChasePlayer;
            ServiceEvents.Instance.ShootPlayer += StartShootPlayer;
            ServiceEvents.Instance.StopShoot += StopShootPlayer;
        }

        public void StopChasePlayer()
        {
            chaseState.OnExitState();
            patrolState.OnEnterState();
        }
        public void ChasePlayer()
        {
            idleState.OnExitState();
            patrolState.OnExitState();
            chaseState.OnEnterState();
        }

        public void StartShootPlayer()
        {
            chaseState.OnExitState();
            attackState.OnEnterState();
        }

        public void StopShootPlayer()
        {
            chaseState.OnEnterState();
            attackState.OnExitState();
        }


        public void LinkController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<BulletView>() != null)
            {
                enemyController.DisableEnemy(meshRenderers);
                StartCoroutine(DestroyAfterWait());
            }
        }
        IEnumerator DestroyAfterWait()
        {
            yield return WaitBeforeDestroy;
            enemyController.DestroyEnemy();
        }
    }
}
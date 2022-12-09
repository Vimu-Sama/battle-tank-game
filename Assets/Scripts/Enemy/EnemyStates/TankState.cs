using UnityEngine;
using UnityEngine.AI;
using Tanks.Tank;
using TankServices;

namespace Tanks.Enemy
{
    public class TankState : MonoBehaviour
    {
        protected PatrolState patrolState;
        protected NavMeshAgent navMeshAgent;
        protected TankView tankView;
        protected BulletManager bulletManager;
        protected ChaseState chaseState;
        private void Awake()
        {
            patrolState = GetComponent<PatrolState>();
            navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
            tankView= TankView.Instance;
            bulletManager = GetComponent<BulletManager>();
            chaseState = GetComponent<ChaseState>();
        }

        public virtual void OnEnterState()
        {
            this.enabled = true;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}
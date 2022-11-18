using UnityEngine;
using System.Collections.Generic;
using Tanks.tank;
using UnityEngine.AI;

namespace Tanks.enemy
{
    public class PatrolState : TankState
    {
        private NavMeshAgent navMeshAgent;
        private Vector3 currDestination;
        private int tempIndex;
        [SerializeField] List<Vector3> spawnPoints;
        public override void OnEnterState()
        {
            base.OnEnterState();
            navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if (this.transform.position.z == currDestination.z && this.transform.position.x == currDestination.x)
            {
                tempIndex = Random.Range(0, spawnPoints.Count);
                currDestination = spawnPoints[tempIndex];
                GetComponent<IdleState>().OnEnterState();
                OnExitState();
            }
            navMeshAgent.destination = currDestination;
        }
        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}
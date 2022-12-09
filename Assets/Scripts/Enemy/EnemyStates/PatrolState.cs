using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Enemy
{
    public class PatrolState : TankState
    {
        private Vector3 currDestination;
        private int tempIndex;
        [SerializeField] private List<Vector3> spawnPoints;

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
    }
}
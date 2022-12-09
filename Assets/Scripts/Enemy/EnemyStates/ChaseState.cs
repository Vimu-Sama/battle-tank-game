using UnityEngine;
using Tanks.Tank;
using UnityEngine.AI;

namespace Tanks.Enemy
{
    public class ChaseState : TankState
    {
        private void Update()
        {
            if (tankView != null)
                navMeshAgent.destination = tankView.transform.position;
        }
    }
}
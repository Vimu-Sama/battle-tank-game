using UnityEngine;
using Tanks.tank;
using UnityEngine.AI;

namespace Tanks.enemy
{
    public class ChaseState : TankState
    {
        private TankView tankView;
        private NavMeshAgent navmeshAgent;
        public override void OnEnterState()
        {
            base.OnEnterState();
            tankView = TankView.Instance;
            navmeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(tankView!=null)
                navmeshAgent.destination = tankView.transform.position;
        }


        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}
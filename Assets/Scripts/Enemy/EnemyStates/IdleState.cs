using UnityEngine;
using Tanks.Tank;
using UnityEngine.AI;

namespace Tanks.Enemy
{
    public class IdleState : TankState
    {
        [SerializeField] float waitTime = 5f;
        float timePassed = 0f;

        public override void OnEnterState()
        {
            base.OnEnterState();
            timePassed = 0f;
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            if (timePassed > waitTime)
            {
                OnExitState();
            }
        }

        public override void OnExitState()
        {
            patrolState.OnEnterState();
            base.OnExitState();
        }

    }
}
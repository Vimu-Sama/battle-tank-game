using UnityEngine;
using TankServices;

namespace Tanks.Enemy
{
    public class AttackState : TankState
    {
        private float timePassed;
        [SerializeField] private float timeGapToFire = 2f;

        public override void OnEnterState()
        {
            base.OnEnterState();
            bulletManager.InstantiateBullet(0, TankType.enemy);
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            if (timePassed > timeGapToFire)
            {
                bulletManager.InstantiateBullet(0, TankType.enemy);
                timePassed = 0;
            }
        }

        public override void OnExitState()
        {
            chaseState.OnEnterState();
            base.OnExitState();
        }

    }
}
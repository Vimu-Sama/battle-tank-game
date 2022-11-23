using UnityEngine;
using Tanks.tank;
using Tanks.bullet;
using TankServices;

namespace Tanks.enemy
{
    public class AttackState : TankState
    {
        private BulletManager BulletManager;
        private float timePassed;
        [SerializeField] private float timeGapToFire=2f ;
        
        private void Awake()
        {
            BulletManager = GetComponent<BulletManager>();
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            BulletManager.InstantiateBullet(0, TankType.enemy);
        }

        private void Update()
        {
            timePassed+= Time.deltaTime;
            if(timePassed>timeGapToFire)
            {
                BulletManager.InstantiateBullet(0, TankType.enemy);
                timePassed = 0;
            }
        }

        public override void OnExitState()
        {
            GetComponent<ChaseState>().OnEnterState();
            base.OnExitState();
        }

    }
}
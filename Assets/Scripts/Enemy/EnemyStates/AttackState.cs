using UnityEngine;
using Tanks.tank;
using Tanks.bullet;
using TankServices;

namespace Tanks.enemy
{
    public class AttackState : TankState
    {
        private BulletService bulletService;
        private float timePassed;
        [SerializeField] private float timeGapToFire=2f ;
        
        private void Awake()
        {
            bulletService = GetComponent<BulletService>();
            Debug.Log("Got the component");
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            bulletService.InstantiateBullet(0, TankType.enemy);
        }

        private void Update()
        {
            timePassed+= Time.deltaTime;
            if(timePassed>timeGapToFire)
            {
                bulletService.InstantiateBullet(0, TankType.enemy);
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
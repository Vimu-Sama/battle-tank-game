using System;

namespace TankServices
{
    public class ServiceEvents : GenericSingleton<ServiceEvents>
    {
        public Action<int> OnShoot;
        public Action OnPlayerDeath;
        public Action ChasePlayer;
        public Action StopChase;
        public Action ShootPlayer;
        public Action StopShoot;
    }

}


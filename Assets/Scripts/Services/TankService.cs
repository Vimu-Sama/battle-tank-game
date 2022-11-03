using UnityEngine;
using Cinemachine;
using Tanks.tank;

namespace TankServices
{
    public class TankService : GenricSingleton<TankService>
    {
        TankController tankController;
        [SerializeField] TankView tankView;
        [SerializeField] Joystick joystick;
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        [SerializeField] TankScriptableObjectList tanksList;
        [SerializeField] int spawnIndex;
        private bool shouldDestroy = false;
        private void Start()
        {
            if (tanksList.tanks.Count <= spawnIndex)
            {
                Debug.LogError("Wrong Index entered. Check the index for " +
                    "spawning the tank!!!");
                spawnIndex = 0;
            }
            TankModel tankModel = new TankModel(tanksList.tanks[spawnIndex], spawnIndex);
            tankView.materialFromScriptableObject = tanksList.tanks[spawnIndex].tankMaterial;
            tankView.joystick = joystick;
            tankController = new TankController(tankView, tankModel, spawnIndex);
        }

        private void Update()
        {
            if (tankController == null)
            {
                shouldDestroy = true;
            }

        }

        public bool ShouldDestroy
        {
            get { return shouldDestroy; }
        }


    }
}
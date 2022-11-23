using UnityEngine;
using Cinemachine;
using Tanks.tank;
using UnityEngine.UI;

namespace TankServices
{
    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] TankView tankView;
        [SerializeField] Joystick joystick;
        [SerializeField] Button shootButton;
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        [SerializeField] TankScriptableObjectList tanksList;
        [SerializeField] int spawnIndex;
        private bool shouldDestroy = false;
        private void Start()
        {
            if (tanksList.tanks.Length <= spawnIndex)
            {
                Debug.LogError("Wrong Index entered. Check the index for " +
                    "spawning the tank!!!");
                spawnIndex = 0;
            }
            TankModel tankModel = new TankModel(tanksList.tanks[spawnIndex], spawnIndex);
            tankView.materialFromScriptableObject = tanksList.tanks[spawnIndex].tankMaterial;
            tankView.joystick = joystick;
            tankView.button = shootButton;
            new TankController(tankView, tankModel, spawnIndex);
            ServiceEvents.Instance.OnPlayerDeath+= PlayerDestroyed;
        }

        private void PlayerDestroyed()
        {
            shouldDestroy = true;
        }

        public bool ShouldDestroy
        {
            get { return shouldDestroy; }
        }


    }
}
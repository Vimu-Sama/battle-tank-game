using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cinemachine;
using TankServices;
using Tanks.enemy;

namespace Tanks.tank
{
    public class TankView : GenericSingleton<TankView>
    {
        private TankController tankController;
        WaitForSeconds waitForSeconds = new WaitForSeconds(2f); //can be serialized in case of making it more easier for designers
        [HideInInspector]
        public Joystick joystick;
        [HideInInspector]
        public Button button;
        [HideInInspector]
        public CinemachineVirtualCamera virtualCamera;
        [HideInInspector]
        public Material materialFromScriptableObject;
        [SerializeField] MeshRenderer tankTurretMaterial;
        [SerializeField] MeshRenderer tankBodyMaterial;
        public BulletManager BulletManager;
        public void SetTankController(TankController _tankController)
        {
            virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            virtualCamera.Follow = this.transform;
            tankController = _tankController;
            tankTurretMaterial.material = materialFromScriptableObject;
            tankBodyMaterial.material = materialFromScriptableObject;
            button.onClick.AddListener(ShootBullet);
        }

        private void Update()
        {

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                tankController.UpdateMovementAndRotation(joystick.Horizontal, joystick.Vertical);
            }
            if (Input.GetKeyDown(KeyCode.Space))
                ShootBullet();
        }

        private void ShootBullet()
        {
            tankController.Shoot();
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<EnemyView>())
            {
                tankController.DisableTank();
                this.GetComponent<ParticleSystem>().Play();
                tankTurretMaterial.enabled = false;
                tankBodyMaterial.enabled = false;
                StartCoroutine(WaitBeforeDestroy());
            }
        }

        private IEnumerator WaitBeforeDestroy()
        {
            yield return waitForSeconds;
            ServiceEvents.Instance.OnPlayerDeath?.Invoke();
            tankController.DestroyTank();
        }

    }
}
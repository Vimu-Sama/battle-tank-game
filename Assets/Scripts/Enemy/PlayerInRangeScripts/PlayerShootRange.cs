using UnityEngine;
using System.Collections;
using TankServices;
using Tanks.tank;

namespace Tanks.enemy
{
    public class PlayerShootRange : MonoBehaviour
    {
        WaitForSeconds waitSeconds;
        TankStateEnum tankStateBeforeChase;
        private void Awake()
        {
            waitSeconds = new WaitForSeconds(2f);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                ServiceEvents.Instance.ShootPlayer?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                StartCoroutine(StopAfterALittleWhile());
            }
        }

        private IEnumerator StopAfterALittleWhile()
        {
            yield return waitSeconds;
            ServiceEvents.Instance.StopShoot?.Invoke();
        }
    }
}

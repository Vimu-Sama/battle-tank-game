using UnityEngine;
using System.Collections;
using TankServices;
using Tanks.tank;

namespace Tanks.enemy
{
    public class CheckRange : MonoBehaviour
    {
        WaitForSeconds waitForSeconds;
        TankStateEnum tankStateBeforeChase;
        private void Awake()
        {
            waitForSeconds = new WaitForSeconds(3f);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                ServiceEvents.Instance.ChasePlayer?.Invoke();
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
            yield return waitForSeconds;
            ServiceEvents.Instance.StopChase?.Invoke();
        }
    }
}

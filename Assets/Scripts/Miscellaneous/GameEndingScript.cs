using System.Collections;
using UnityEngine;
using TankServices;

namespace Tanks.Tank
{
    public class GameEndingScript : GenericSingleton<GameEndingScript>
    {
        [SerializeField] float DestroyVFXDuration = 4f;
        WaitForSeconds waitForDestroy;
        bool playerDestroy = true;
        private void OnEnable()
        {
            ServiceEvents.Instance.OnPlayerDeath += DisableGameObjects;
            waitForDestroy = new WaitForSeconds(DestroyVFXDuration);
        }

        private void OnDisable()
        {
            ServiceEvents.Instance.OnPlayerDeath -= DisableGameObjects;
        }

        public void DisableGameObjects()
        {
            StartCoroutine(DeleteAllGameObjects());
        }

        private IEnumerator DeleteAllGameObjects() //cinematic destruction of the GameObjects after player death
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("LevelArt");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<MeshRenderer>().enabled = false;
                if (gameObjects[i].GetComponent<ParticleSystem>() != null)
                    gameObjects[i].GetComponent<ParticleSystem>().Play();
                yield return waitForDestroy;
                GameObject.Destroy(gameObjects[i]);
            }
        }

    }
}
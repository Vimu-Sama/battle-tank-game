using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.bullet;

namespace Tanks.enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
        public PatrolState patrolState;
        public ChaseState chaseState;
        [SerializeField] private BulletView bulletSpeed ;

        private EnemyController enemyController;
        WaitForSeconds WaitBeforeDestroy = new WaitForSeconds(4f);

        public void LinkController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<BulletView>() != null)
            {
                enemyController.DisableEnemy(meshRenderers);
                StartCoroutine(DestroyAfterWait());
            }
        }
        IEnumerator DestroyAfterWait()
        {
            yield return WaitBeforeDestroy;
            enemyController.DestroyEnemy();
        }
    }
}
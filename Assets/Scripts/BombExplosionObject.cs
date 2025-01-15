using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BombExplosionObject : MonoBehaviour, IPoolable
    {
        public void RegisterType()
        {
            throw new System.NotImplementedException();
        }

        public void OnPooled(string tag)
        {
            StartCoroutine(BombExplosionRoutine());
        }

        private IEnumerator BombExplosionRoutine()
        {
            yield return new WaitForSeconds(3f);
            ObjectPoolManager.Instance.Unpool("bomb_explosion", this);
            
            var players = PlayerManager.Instance.PlayerMains.ConvertAll((pm) => pm.gameObject);

            var directions = new []{ Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            
            foreach(var direction in directions)
            {
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 3f))
                {
                    if(players.Contains(hit.transform.gameObject))
                    {
                        PlayerManager.Instance
                            .PlayerMains[players.IndexOf(hit.transform.gameObject)]
                            .PlayerHealthBehaviour
                            .LooseHealth();
                    }
                }
                
            }

            yield return null;
        }

        public void OnUnPooled()
        {
            // Respawn a pickup object.
            ObjectPoolManager.Instance.Pool("bomb_pickup");
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BombExplosionObject : MonoBehaviour, IPoolable
    {
        private bool[] _playerTouched = new bool[2];
        public event Action<Vector3> OnExplode;
        
        [SerializeField]
        private Animator _animator;
        
        public void RegisterType()
        {
            throw new System.NotImplementedException();
        }

        public void OnPooled(string tag)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            _playerTouched = new bool[2] {false, false};
            
            _animator.Play("BombExplosion");
            
            StartCoroutine(BombExplosionRoutine());
        }

        private IEnumerator BombExplosionRoutine()
        {
            yield return new WaitForSeconds(3f);
            ObjectPoolManager.Instance.Unpool("bomb_explosion", this);
            
            var players = PlayerManager.Instance.PlayerMains.ConvertAll((pm) => pm.gameObject);

            var directions = new []{ Vector3.forward, Vector3.back, Vector3.left, Vector3.right };

            foreach (var direction in directions)
            {
                for (int i = 0; i < 3; i++)
                {
                    var center = transform.position + direction * (i*2);
                    CustomDebug.DrawSphere(center, 1.5f, Color.red, 3f);
                    var hits = Physics.SphereCastAll(center, 1.5f, direction, 1.5f);
                    
                    OnExplode?.Invoke(center);
                    
                    bool wallHit = false;
                    foreach (var hit in hits)
                    {
                        if (players.Contains(hit.transform.gameObject) && !_playerTouched[players.IndexOf(hit.transform.gameObject)])
                        {
                            _playerTouched[players.IndexOf(hit.transform.gameObject)] = true;
                            PlayerManager.Instance
                                .PlayerMains[players.IndexOf(hit.transform.gameObject)]
                                .PlayerHealthBehaviour
                                .LooseHealth();
                            
                            wallHit = true;
                        }
                    }

                    if (Physics.Raycast(center, direction, out RaycastHit hitWall, 2.0f))
                    {
                        if (hitWall.collider.CompareTag("Wall"))
                        {
                            wallHit = true;
                        }
                    }

                    if (wallHit) break;
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
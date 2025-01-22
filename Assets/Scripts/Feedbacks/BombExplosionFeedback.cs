using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BombExplosionFeedback : MonoBehaviour
{
    private BombExplosionObject _object;

    private void Start()
    {
        _object = GetComponent<BombExplosionObject>();
        _object.OnExplode += OnExplosion;
    }

    private void OnExplosion(Vector3 center)
    {
        var e = ObjectPoolManager.Instance.Pool("bomb_fx");
        e.gameObject.transform.position = center;
    }
}

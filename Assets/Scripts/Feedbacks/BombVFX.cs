using System;
using System.Collections.Generic;
using UnityEngine;

public class BombVFX : MonoBehaviour, IPoolable
{
    [SerializeField]
    private List<ParticleSystem> _ps;

    private List<bool> _isCancelled;
    
    public void RegisterType()
    {
    }

    public void OnPooled(string tag)
    {
        foreach (ParticleSystem p in _ps)
        {
            p.Play();
        }
    }

    private void Update()
    {
        foreach (ParticleSystem p in _ps)
        {
            if (p.isPlaying)
            {
                return;
            }
        }
        ObjectPoolManager.Instance.Unpool("bomb_fx", this);
    }

    public void OnUnPooled()
    {
    }
}
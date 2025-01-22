using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BombVFX : MonoBehaviour, IPoolable
{
    [SerializeField]
    private List<ParticleSystem> _ps;

    [SerializeField]
    private Light _light;
    
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

        _light.intensity = 100000;
        _light.DOIntensity(0, 0.5f);
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
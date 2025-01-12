using System;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public event Action<int, int> OnHealthChange;
    private PlayerMain _main;
    [SerializeField]
    private bool _lostHealthDebug;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();
    }

    private void Update()
    {
        if( _lostHealthDebug)
        {
            _lostHealthDebug = false;
            LooseHealth();
        }
    }

    public void LooseHealth()
    {
        _main.Health--;
        OnHealthChange?.Invoke(_main.Health, _main.Id);
    }
}

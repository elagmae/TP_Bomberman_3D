using System;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public event Action<int, int> OnHealthChange;
    private PlayerMain _main;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();
    }

    public void LooseHealth()
    {
        _main.Health--;
        OnHealthChange?.Invoke(_main.Health, _main.Id);
    }
}

using System;
using UnityEngine;

public class PlayerBombDetection : MonoBehaviour
{
    public event Action<int, GameObject> OnBombDetection;
    private PlayerInventoryBehaviour _inventory;
    private PlayerMain _main;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventoryBehaviour>();
        _main = GetComponent<PlayerMain>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            var bomb = other.gameObject;
            OnBombDetection?.Invoke(_main.Id, bomb);
        }
    }
}

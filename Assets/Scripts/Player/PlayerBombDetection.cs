using System;
using UnityEngine;

public class PlayerBombDetection : MonoBehaviour
{
    public event Action<int, BombPickupObject> OnBombDetection;
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
            var bomb = other.GetComponent<BombPickupObject>();
            OnBombDetection?.Invoke(_main.Id, bomb);
        }
    }
}

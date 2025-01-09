using System;
using UnityEngine;

public class BombDetectionBehaviour : MonoBehaviour
{
    public event Action OnBombDetection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            var bomb = other.gameObject;

            // Lyta sort la bombe de la pool stp.

            bomb.SetActive(false);
            OnBombDetection?.Invoke();
        }
    }
}

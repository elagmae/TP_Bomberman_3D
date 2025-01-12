using System;
using UnityEngine;

public class PlayerHealthFeedbackBehaviour : MonoBehaviour
{
    public event Action<int> OnGameFinished;
    private PlayerHealthBehaviour _healthBehaviour;

    private void Start()
    {
        _healthBehaviour = GetComponent<PlayerHealthBehaviour>();
        _healthBehaviour.OnHealthChange += HealthFeedback;
    }

    public void HealthFeedback(int health, int id)
    {
        PlayerManager.Instance.PlayerHealthSliders[id].value = health;
        PlayerManager.Instance.ImpulseSource.GenerateImpulse();

        if (health <= 0)
        {
            OnGameFinished?.Invoke(id);
        }
    }
}

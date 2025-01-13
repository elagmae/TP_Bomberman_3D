using DG.Tweening;
using System;
using UnityEngine;

public class PlayerHealthFeedbackBehaviour : MonoBehaviour
{
    public event Action<int> OnGameFinished;
    private PlayerHealthBehaviour _healthBehaviour;
    private Animator _animator;

    private void Start()
    {
        _healthBehaviour = GetComponent<PlayerHealthBehaviour>();
        _healthBehaviour.OnHealthChange += HealthFeedback;
    }

    public void HealthFeedback(int health, int id)
    {

        if (_animator == null)
        {
            _animator = PlayerManager.Instance.PlayerHealthSliders[id].gameObject.GetComponent<Animator>();
        }

        _animator.SetTrigger("Shake");

        PlayerManager.Instance.PlayerHealthSliders[id].DOValue(health, 0.1f);

        PlayerManager.Instance.ImpulseSource.GenerateImpulse();

        if (health <= 0)
        {
            OnGameFinished?.Invoke(id);
        }

    }
}

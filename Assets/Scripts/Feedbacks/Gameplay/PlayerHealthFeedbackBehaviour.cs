using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerHealthFeedbackBehaviour : MonoBehaviour
{
    public event Action<int> OnGameFinished;
    private PlayerHealthBehaviour _healthBehaviour;
    private Animator _animator;
    private Vignette _vignette;
    private ChromaticAberration _chromatic;

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

        if(PlayerManager.Instance.Volume.TryGet(out _vignette))
        {
            DOTween.To(() => _vignette.intensity.value, x => _vignette.intensity.value = x, 0.2f, 0.3f).SetUpdate(true).onComplete += () =>
            {
                DOTween.To(() => _vignette.intensity.value, x => _vignette.intensity.value = x, 0f, 0.3f);
            };
        }

        if (PlayerManager.Instance.Volume.TryGet(out _chromatic))
        {
            DOTween.To(() => _chromatic.intensity.value, x => _chromatic.intensity.value = x, 0.2f, 0.3f).SetUpdate(true).onComplete += () =>
            {
                DOTween.To(() => _chromatic.intensity.value, x => _chromatic.intensity.value = x, 0f, 0.3f);
            };
        }

        if (health <= 0)
        {
            OnGameFinished?.Invoke(id);
        }

    }
}

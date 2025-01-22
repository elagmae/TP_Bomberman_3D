using DG.Tweening;
using System;
using System.Collections;
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
        VibrationsBehaviour.Vibrate(10f, 0.5f);

        if (_animator == null)
        {
            _animator = PlayerManager.Instance.PlayerHealthSliders[id].gameObject.GetComponent<Animator>();
        }

        _animator.SetTrigger("Shake");
        PlayerManager.Instance.PlayerMains[id].HitPart.Play();

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
            DOTween.To(() => _chromatic.intensity.value, x => _chromatic.intensity.value = x, 0.35f, 0.3f).SetUpdate(true).onComplete += () =>
            {
                DOTween.To(() => _chromatic.intensity.value, x => _chromatic.intensity.value = x, 0f, 0.3f);
            };
        }

        if(health > 0 && health < 2)
        {
            _animator.SetTrigger("Flash");
        }

        if (health <= 0)
        {
            PlayerManager.Instance.PlayerMains[id].DeathPart.Play();
            StartCoroutine(Die(id));
        }
    }

    public IEnumerator Die(int id)
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0.2f;
        PlayerManager.Instance.PlayerMains[id].Render.enabled = false;

        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.25f).SetDelay(0.6f).SetUpdate(true).onComplete += () =>
        {
            OnGameFinished?.Invoke(id);
        };
    }
}

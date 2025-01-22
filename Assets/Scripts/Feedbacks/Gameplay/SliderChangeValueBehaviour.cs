using DG.Tweening;
using UnityEngine;

public class SliderChangeValueBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform _fillDefaultRect;
    [SerializeField]
    private RectTransform _fillBackgroundRect;

    public void DecrementValue()
    {
        var defaultAnchorMax = _fillDefaultRect.anchorMax;
        _fillBackgroundRect.DOAnchorMax(defaultAnchorMax, 0.45f).SetDelay(0.2f).SetEase(Ease.InFlash).SetUpdate(true);
    }
}

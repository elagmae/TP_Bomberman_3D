using UnityEngine;
using DG.Tweening;

public class PanelOpeningBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.transform.localScale = Vector3.zero;
        this.gameObject.transform.DOBlendableScaleBy(Vector3.one, 0.5f).SetEase(Ease.OutBounce).SetUpdate(true);
    }
}

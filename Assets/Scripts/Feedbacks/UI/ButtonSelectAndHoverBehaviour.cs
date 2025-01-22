using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectAndHoverBehaviour : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IDeselectHandler, IPointerExitHandler
{
    [SerializeField]
    private Material _shineMat;
    private Image _img;
    private Material _defaultMat;
    private Animator _animator;

    private void Awake()
    {
        _img = GetComponent<Image>();
        _defaultMat = GetComponent<Material>();
        _animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectAndHoverFeedbacks();
    }

    public void OnSelect(BaseEventData eventData)
    {
        SelectAndHoverFeedbacks();
    }

    public void SelectAndHoverFeedbacks()
    {
        _img.material = _shineMat;
        _animator.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StopFeedbacks();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopFeedbacks();
    }

    public void StopFeedbacks()
    {
        _img.material = _defaultMat;
        _animator.enabled = false;
        gameObject.transform.localScale = Vector3.one;
    }
}

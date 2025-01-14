using DG.Tweening;
using UnityEngine;

public class PlayerInventoryFeedbackBehaviour : MonoBehaviour
{
    private PlayerInventoryBehaviour _inventoryBehaviour;

    private void Start()
    {
        _inventoryBehaviour = GetComponent<PlayerInventoryBehaviour>();
        _inventoryBehaviour.OnItemRemoved += RemoveItemFeedback;
        _inventoryBehaviour.OnItemAdded += AddItemFeedback;
    }

    private void AddItemFeedback(GameObject item)
    {
        item.transform.parent.transform.DOBlendableScaleBy(Vector3.one * 0.2f, 0.5f);

        item.transform.localScale = Vector3.zero;
        item.SetActive(true);
        item.transform.DOBlendableScaleBy(Vector3.one, 0.5f).SetEase(Ease.InBounce);
    }

    private void RemoveItemFeedback(GameObject item)
    {
        item.transform.parent.transform.DOBlendableScaleBy(Vector3.one * -0.2f, 0.5f);

        item.transform.DOBlendableScaleBy(Vector3.one * -1, 0.5f).SetEase(Ease.OutBounce).onComplete += () =>
        {
            item.SetActive(false);
        };
    }
}

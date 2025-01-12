using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Button _firstSelected;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(_firstSelected.gameObject);
        Time.timeScale = 0f;
    }
}

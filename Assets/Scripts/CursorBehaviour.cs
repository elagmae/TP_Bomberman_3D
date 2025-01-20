using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _showCursor;
    private void Awake()
    {
        Cursor.visible = _showCursor;
    }
}

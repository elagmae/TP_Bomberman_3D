using UnityEditor;
using UnityEngine;

public class VFXSpawner : EditorWindow
{
    [MenuItem("MENUITEM/MENUITEMCOMMAND")]
    private static void ShowWindow()
    {
        var window = GetWindow<VFXSpawner>();
        window.titleContent = new GUIContent("TITLE");
        window.Show();
    }

    private void CreateGUI()
    {
            
    }
}

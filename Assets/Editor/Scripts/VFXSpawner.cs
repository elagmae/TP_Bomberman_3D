using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class VFXSpawner : EditorWindow
{
    private GameObject _VFXold;
    private VisualEffectAsset _VFXnew;

    private bool _toggle;
    
    [MenuItem("Window/VFX Spawner")]
    private static void ShowWindow()
    {
        var window = GetWindow<VFXSpawner>();
        window.titleContent = new GUIContent("VFX");
        window.Show();
    }

    private void OnGUI()
    {
        _toggle = EditorGUILayout.Toggle("Is it a VFX Graph?", _toggle);
        if (_toggle)
        {
            _VFXnew = EditorGUILayout.ObjectField("VFX new", _VFXnew, typeof(VisualEffectAsset), false) as VisualEffectAsset;
        }
        else {
            _VFXold = EditorGUILayout.ObjectField("VFX old", _VFXold, typeof(GameObject), false) as GameObject;
        }

        if (GUILayout.Button("Spawn VFX"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (_toggle)
                {
                    GameObject child = new GameObject();
                    var vfx = obj.AddComponent<VisualEffect>();
                    vfx.visualEffectAsset = _VFXnew;
                    
                    child.transform.SetParent(obj.transform);
                }
                else
                {
                    var go = Instantiate(_VFXold, obj.transform, false);
                }
            }
        }
    }
}


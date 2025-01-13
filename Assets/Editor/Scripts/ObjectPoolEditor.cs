using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*[CustomEditor(typeof(ObjectPoolManager), true)]
public class ObjectPoolEditor : Editor
{
    private ObjectPoolManager _PoolManager;
    
    private SerializedProperty _MaxValue;
    private SerializedProperty _PrefabPool;

    private string _newId = "";
    private GameObject _prefabObject = null;
    private int _newMaxValue = 200;

    private bool showPos;

    void OnEnable()
    {
        _PoolManager = (ObjectPoolManager)target;
        _PrefabPool = serializedObject.FindProperty("_prefabPool");
        _MaxValue = serializedObject.FindProperty("_maxValue");
    }

    public override void OnInspectorGUI()
    {
        
        _newId = EditorGUILayout.TextField("ID: ", _newId);
        _prefabObject = (GameObject)EditorGUILayout.ObjectField("Prefab: ", _prefabObject, typeof(GameObject), true);
        _newMaxValue = EditorGUILayout.IntField("Max number of instance: ", _newMaxValue);

        GUI.enabled = !((ObjectDictionnary)_PrefabPool.boxedValue).ContainsKey(_newId);

        if (((ObjectDictionnary)_PrefabPool.boxedValue).ContainsKey(_newId))
        {
            EditorGUILayout.LabelField("Object already exist, you can't add it in the pool");
        }

        if (GUILayout.Button("Add"))
        {
            ((ObjectDictionnary)_PrefabPool.boxedValue).Add(_newId, _prefabObject);
            ((IntDictionnary)_MaxValue.boxedValue).Add(_newId, _newMaxValue);

            _newId = "";
            _prefabObject = null;
            _newMaxValue = 200;
        }

        GUI.enabled = true;

        showPos = EditorGUILayout.BeginFoldoutHeaderGroup(showPos, "Current Pool");
        if(showPos){
            foreach (string id in new List<string>(((ObjectDictionnary)_PrefabPool.boxedValue).Keys))
            {
                var rect = EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(id, new[] { GUILayout.MaxWidth(150) });

                ((ObjectDictionnary)_PrefabPool.boxedValue)[id] = (GameObject)EditorGUILayout.ObjectField(((ObjectDictionnary)_PrefabPool.boxedValue)[id], typeof(GameObject), true); ;
                ((IntDictionnary)_MaxValue.boxedValue)[id] = EditorGUILayout.IntField("", ((IntDictionnary)_MaxValue.boxedValue)[id], new[] { GUILayout.MaxWidth(70) });

                if (GUILayout.Button("X", new[] { GUILayout.MaxWidth(50) }))
                {
                    ((ObjectDictionnary)_PrefabPool.boxedValue).Remove(id);
                    ((IntDictionnary)_MaxValue.boxedValue).Remove(id);
                }

                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        _PrefabPool.boxedValue = _PrefabPool.boxedValue;
        _MaxValue.boxedValue = _MaxValue.boxedValue;
        
        serializedObject.ApplyModifiedProperties();
    }
}*/

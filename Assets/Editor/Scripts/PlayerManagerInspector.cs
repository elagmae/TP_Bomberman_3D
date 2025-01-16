using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(PlayerManager))]
[CanEditMultipleObjects]

public class PlayerManagerInspector : Editor
{
    PlayerManager manager;
    SerializedProperty playerPositions;

    Object positionR;
    Object positionB;

    private void OnEnable()
    {
        manager = (PlayerManager)target;
        playerPositions = serializedObject.FindProperty("_playerPositions");
        GetList(out positionR, out positionB);
    }

    public override void OnInspectorGUI()
    {
        var selected = Selection.activeObject;

        if (selected != null)
        {
            switch (selected.name)
            {
                case "Player_R":

                    manager.PlayerColors[0] = EditorGUILayout.ColorField("Player Color", manager.PlayerColors[0]);
                    manager.PlayerHealthSliders[0] = (Slider)EditorGUILayout.ObjectField("Player Slider", manager.PlayerHealthSliders[0], typeof(Slider), false);

                    GUILayout.Space(20);
                    GUILayout.Label("PlayerInventory");
                    GUILayout.Space(5);
                    for (int i = 0; i < manager.InventoriesUI[0].Count; i++)
                    {
                        manager.InventoriesUI[0][i] = (GameObject)EditorGUILayout.ObjectField($"item {i}", manager.InventoriesUI[0][i], typeof(GameObject), false);
                    }

                    GUILayout.Space(20);
                    EditorGUILayout.ObjectField("Player Position", positionR, typeof(GameObject), false);

                    break;

                case "Player_B":
                
                    manager.PlayerColors[1] = EditorGUILayout.ColorField("Player Color", manager.PlayerColors[1]);
                    manager.PlayerHealthSliders[1] = (Slider)EditorGUILayout.ObjectField("Player Slider", manager.PlayerHealthSliders[1], typeof(Slider), false);
                    
                    GUILayout.Space(20);
                    GUILayout.Label("Player Inventory");
                    GUILayout.Space(5);

                    for (int i = 0; i < manager.InventoriesUI[1].Count; i++)
                    {
                        manager.InventoriesUI[1][i] = (GameObject)EditorGUILayout.ObjectField($"item {i}", manager.InventoriesUI[1][i], typeof(GameObject), false);
                    }

                    GUILayout.Space(20);
                    EditorGUILayout.ObjectField("Player Position", positionB, typeof(GameObject), false);

                    break;

                default:

                    GUILayout.Space(10);
                    GUILayout.Label("Lock the manager and select a player in play mode");
                    GUILayout.Space(20);
                    base.OnInspectorGUI();
                    
                    break;
            }
        }
    }

    public void GetList(out Object positionR, out Object positionB)
    {
        positionR = null;
        positionB = null;

        SerializedProperty sp = playerPositions.Copy(); // copy so we don't iterate the original

        if (sp.isArray)
        {
            int arrayLength;

            sp.Next(true); // skip generic field
            sp.Next(true); // advance to array size field

            // Get the array size
            arrayLength = sp.intValue;

            sp.Next(true); // advance to first array index

            // Write values to list
            int lastIndex = arrayLength - 1;
            for (int i = 0; i < arrayLength; i++)
            {
                if(positionR == null) positionR = sp.objectReferenceValue;
                else positionB = sp.objectReferenceValue;
                if (i < lastIndex) sp.Next(false); // advance without drilling into children
            }
        }
    }
}

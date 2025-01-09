using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ColorizeWindow : EditorWindow
{
    public GameObject Source;
    public static Color Color;

    [MenuItem("Window/Colorizer Window")]
    public static void ShowWindow()
    {
        GetWindow<ColorizeWindow>("Colorizer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select objects to colorize in your scene !");

        GUILayout.Space(5);

        Color = EditorGUILayout.ColorField("Choose Color", Color);

        GUILayout.Space(2);

        if (GUILayout.Button("Colorize !"))
        {
            // Prend en compte chaque objet que le joueur aura sélectionner dans l'inspecteur et lui change sa couleur par rapport à son type.

            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<MeshRenderer>() != null)
                {
                    obj.GetComponent<MeshRenderer>().material.color = Color;
                }

                if(obj.GetComponent<Image>() != null)
                {
                    obj.GetComponent <Image>().color = Color;
                }

                if(obj.GetComponent<SpriteRenderer>() != null)
                {
                    obj.GetComponent<SpriteRenderer>().color = Color;
                }
            }
        }
    }
}

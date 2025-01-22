using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ColorizeWindow : EditorWindow
{
    public GameObject Source;
    public Color Color;

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
            // Prend en compte chaque objet que le joueur aura s�lectionner dans l'inspecteur et lui change sa couleur par rapport � son type.

            foreach (GameObject obj in Selection.gameObjects)
            {
                ChangeColor(Color, obj);
            }
        }
    }

    public Color ChangeColor(Color color, GameObject obj)
    {
        var objColor = Color.black;

        if (obj.GetComponent<MeshRenderer>() != null)
        {
            objColor = obj.GetComponent<MeshRenderer>().material.color = color;
        }

        if (obj.GetComponent<Image>() != null)
        {
            objColor = obj.GetComponent<Image>().color = color;
        }

        if (obj.GetComponent<SpriteRenderer>() != null)
        {
            objColor = obj.GetComponent<SpriteRenderer>().color = color;
        }

        return objColor;
    }
}

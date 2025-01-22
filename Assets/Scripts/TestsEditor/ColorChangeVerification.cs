using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class ColorChangeVerification
{
    [UnityTest]
    public IEnumerator TestColorChange()
    {
        ColorizeWindow window = new();
        GameObject obj = new();
        obj.AddComponent<Image>();

        Color color = Color.red;
        var objColor = window.ChangeColor(color, obj);
        yield return null;

        Assert.That(color, Is.EqualTo(objColor));
    }
}

using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

public class UpdateStringTest
{
    [Test]
    public void NewTestScriptSimplePasses()
    {
        GameObject obj = new ();
        StringUpdate stringUpdate = obj.AddComponent<StringUpdate>();

        string text = "hello000@-#%~~~~";
        string finalText = "hello000";
        var returnedString = stringUpdate.UpdateString(text);

        Assert.That(returnedString, Is.EqualTo(finalText));
    }
}

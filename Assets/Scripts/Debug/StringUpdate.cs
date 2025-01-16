using System.Text;
using UnityEngine;

public class StringUpdate : MonoBehaviour
{
    public string UpdateString(string text)
    {
        var finalText = "";
        foreach(var letter in text)
        {

            if (char.IsLetterOrDigit(letter))
            {
                finalText += letter;
            }
        }
        
        return finalText;
    }
}

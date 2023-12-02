using TMPro;
using UnityEngine;

public class WinText : MonoBehaviour
{
    public TextMeshPro textMesh;
    

    public void UpdateText(string newText)
    {
        if (textMesh != null)
        {
            textMesh.text = newText;
        }
    }
}
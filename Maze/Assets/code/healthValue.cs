using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TextMeshPro textMesh;
    private float value = 5;

    public void UpdateText(float changeValue)
    {
        value += changeValue;
        string newText = "Health Value:" + value.ToString();
        if (textMesh != null)
        {
            textMesh.text = newText;
        }
    }
}
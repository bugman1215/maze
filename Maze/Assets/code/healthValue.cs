using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TextMeshPro textMesh;
    public float value = 5;
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }
    public void UpdateText(float changeValue)
    {
        value += changeValue;
        if (changeValue < 0)
        {
            audioSources = GetComponents<AudioSource>();
            audioSources[1].Play();
        }
        if (changeValue > 0)
        {
            audioSources = GetComponents<AudioSource>();
            audioSources[0].Play();
        }


        string newText = "Health Value:" + value.ToString();
        if (textMesh != null)
        {
            textMesh.text = newText;
        }
    }

    public float getValue()
    {
        return value;
    }
}
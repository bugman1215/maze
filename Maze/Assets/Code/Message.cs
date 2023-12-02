using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Message : MonoBehaviour
{
    private static TMP_Text gameText;
    
    // Use this for initialization
    internal void Start()
    {
        gameText = GetComponent<TMP_Text>();
    }
    public static void UpdateMessage(string txt)
    {
        gameText.text = txt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{

    public Boss bossPrefab;
    private float lastMessageTime = 0;
    private AudioSource audioSource;
    private bool hasBoss = false;
    private void Start() {

        audioSource = GetComponent<AudioSource>();
    }

    private void SpawnBoss()
    {
        
        Instantiate(bossPrefab, bossPrefab.transform.position, bossPrefab.transform.rotation);
    }



    // Update is called once per frame
    void Update()
    {
        bool hasMonster = FindObjectOfType<Monster>();
        
        if (!hasMonster && !hasBoss) {
            SpawnBoss();
            Message.UpdateMessage("Boss is coming!");
            hasBoss = true;
            audioSource.Play();

        }
        if (Time.time - lastMessageTime >= 5)
        {
            Message.UpdateMessage("");
            lastMessageTime = Time.time;
          
        }


    }
}

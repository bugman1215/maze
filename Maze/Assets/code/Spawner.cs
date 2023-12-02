using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{

    public Monster monsterPrefab; 
    public float spawnRadius = 10f; 
    public int maxMonsters = 3; 

    void Update()
    {
        
        if (GameObject.FindGameObjectsWithTag("Monster").Length < maxMonsters)
        {
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = transform.position.y;

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}

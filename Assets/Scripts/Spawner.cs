using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public Vector2 spawnCooldownRange = new Vector2(3f, 6f);
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            
            yield return new WaitForSeconds(Random.Range(spawnCooldownRange.x, spawnCooldownRange.y));
        }
    }
}

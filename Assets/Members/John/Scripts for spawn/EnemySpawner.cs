using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float spawnTimer;

    private float currentSpawnTimer;

    
    void Start()
    {
        currentSpawnTimer = spawnTimer;
    }

    void Update()
    {

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (currentSpawnTimer > 0)
        {
            currentSpawnTimer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            currentSpawnTimer = spawnTimer;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using TowersNoDragons.Pathing;
using TowersNoDragons.Waves;
using UnityEngine;

namespace TowersNoDragons.AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Wave wave = null;
        [SerializeField] private Enemy enemyToSpawn;
        [SerializeField] private Path path = null; //TODO: Pull this value from a scriptable object "Wave"
        [SerializeField] private float spawnTimer;

        public int amount = 0; //remove


        private float currentSpawnTimer;


        void Start()
        {
            currentSpawnTimer = spawnTimer;
            amount = wave.GetFirstTypeEnemy().GetAmount();
        }


        void Update()
        {
            ProcessSpawning();
        }

        private void ProcessSpawning()
        {
            if (currentSpawnTimer > 0) //The timer
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
            if (amount == 0) { return; }
            //var instance = Instantiate(enemyToSpawn, transform.position, transform.rotation); //spawn it
            //instance.AssignPath(path.GetPath());

        }
    }
}



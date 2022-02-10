using System.Collections;
using TowersNoDragons.Pathing;
using TowersNoDragons.Waves;
using UnityEngine;

namespace TowersNoDragons.AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Wave wave = null;
        [SerializeField] private Path path = null; //should choose a path closest to the spawner
        [SerializeField] private float spawnCooldown = 1f;

        private Wave.EnemiesToSpawn[] EnemiesToSpawns;


        private void Start()
        {
            EnemiesToSpawns = wave.GetEnemiesToSpawns();
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            StartCoroutine(SpawnProcess());
        }

        private IEnumerator SpawnProcess()
		{
            int count = 0;
            while(count < EnemiesToSpawns.Length)
			{
                yield return SpawnEnemyType(EnemiesToSpawns[count]);
                count++;
			}
		}

        private IEnumerator SpawnEnemyType(Wave.EnemiesToSpawn enemiesToSpawn)
		{
            int enemiesSpawned = 0;

            while (enemiesSpawned < enemiesToSpawn.GetAmount())
            {
                var instance = Instantiate(enemiesToSpawn.GetEnemy(), transform);
                instance.AssignPath(this.path.GetPath());
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnCooldown);
            }
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Enemy Spawner controls the flow and spawning of enemies.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        /// <summary>
        /// How long the wave goes.
        /// </summary>
        public float waveLength = 30.0f;

        /// <summary>
        /// The current time of the wave.
        /// </summary>
        public float currentWaveLength = 0;

        /// <summary>
        /// Amount of time between enemies being spawned.
        /// </summary>
        public float timeBetweenSpawns = 2.0f;

        /// <summary>
        /// How much time until next enemy is spawned.
        /// </summary>
        public float currentSpawnTime;

        /// <summary>
        /// All the enemies that are able to be spawned.
        /// </summary>
        public List<Enemy> enemiesForLevel = new List<Enemy>();

        /// <summary>
        /// Spawns and enemy.
        /// </summary>
        /// <param name="enemy">The enemy that will be spawned</param>
        /// <param name="spawnPos">Position the enemy will spawn</param>
        public void SpawnEnemy(Enemy enemy, List<GameObject> path)
        {
            Enemy newEnemy = Instantiate(enemy);
            newEnemy.transform.position = path[0].transform.position;
            newEnemy.pathToFollow = path;
            currentSpawnTime = timeBetweenSpawns + Time.time;
            newEnemy.transform.SetParent(this.transform);
        }

        /// <summary>
        /// Sets up the wave.
        /// </summary>
        public void SetUpWave()
        {
            currentWaveLength = waveLength + Time.time;
        }
    }
}

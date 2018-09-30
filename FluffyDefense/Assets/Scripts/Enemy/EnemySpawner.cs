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
        /// Setting for enemy waves.
        /// </summary>
        public EnemySpawnerSettings enemySpawnerSettings;

        /// <summary>
        /// GameObject that holds the enemies being spawned.
        /// </summary>
        public Transform emenyContainer;

        /// <summary>
        /// Spawns and enemy.
        /// </summary>
        /// <param name="enemy">The enemy that will be spawned</param>
        /// <param name="spawnPos">Position the enemy will spawn</param>
        public void SpawnEnemy(Enemy enemy, List<GameObject> path)
        {
            Enemy newEnemy = Instantiate(enemy);

            //We are using functions to return the correct values and setting them.
            newEnemy.SetLifeAndGold(enemySpawnerSettings.GetEnemyLife(),enemySpawnerSettings.GetEnemyGold()); 

            newEnemy.transform.position = path[0].transform.position;
            newEnemy.pathToFollow = path;
            currentSpawnTime = timeBetweenSpawns + Time.time;
            newEnemy.transform.SetParent(emenyContainer);
        }

        /// <summary>
        /// Sets up the wave.
        /// </summary>
        public void SetUpWave()
        {
            timeBetweenSpawns = enemySpawnerSettings.enemyWaveSpawnTime[enemySpawnerSettings.currentWave];
            currentWaveLength = enemySpawnerSettings.enemyWaveLength[enemySpawnerSettings.currentWave] + Time.time;
        }

        /// <summary>
        /// Handles end of wave for spawning enemies.
        /// </summary>
        /// <returns>If there are more waves to come.</returns>
        public bool EndOfWave()
        {
            enemySpawnerSettings.currentWave++;
            if (enemySpawnerSettings.currentWave < enemySpawnerSettings.enemyLifePerWave.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

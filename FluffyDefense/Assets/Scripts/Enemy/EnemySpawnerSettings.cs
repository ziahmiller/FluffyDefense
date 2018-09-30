using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Controls the difficulty of enemies spawning.
    /// </summary>
    public class EnemySpawnerSettings : MonoBehaviour
    {
        /// <summary>
        /// Life of enemy per wave.
        /// </summary>
        public int[] enemyLifePerWave = new int[0];

        /// <summary>
        /// Life of enemy per wave.
        /// </summary>
        public int[] enemyGoldPerWave = new int[0];

        /// <summary>
        /// Length of waves
        /// </summary>
        public float[] enemyWaveLength = new float[0];

        /// <summary>
        /// Enemy time between spawns per wave.
        /// </summary>
        public float[] enemyWaveSpawnTime = new float[0];

        /// <summary>
        /// Number of the current wave of enemies.
        /// </summary>
        public int currentWave;

        /// <summary>
        /// Gets current life for enemies being spawned.
        /// </summary>
        /// <returns>Amount of life.</returns>
        public int GetEnemyLife()
        {

            return enemyLifePerWave[currentWave];
            
        }

        /// <summary>
        /// Gets the current amount of gold for enemies being spawned.
        /// </summary>
        /// <returns>Amount of gold.</returns>
        public int GetEnemyGold()
        {

            return enemyGoldPerWave[currentWave];

        }
    }
}

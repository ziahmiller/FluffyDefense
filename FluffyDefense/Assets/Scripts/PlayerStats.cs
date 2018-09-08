using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense {
    public class PlayerStats : MonoBehaviour, ILife {

        /// <summary>
        /// Current life of player.
        /// </summary>
        public int currentLife;

        /// <summary>
        /// Current life of player, what other scripts effect.
        /// </summary>
        public int CurrentLife
        {
            get
            {
                return currentLife;
            }

            set
            {
                currentLife = value;
            }
        }

        /// <summary>
        /// Max life of player.
        /// </summary>
        public int maxLife;

        /// <summary>
        /// Max life of player, what other scripts effect.
        /// </summary>
        public int MaxLife
        {
            get
            {
                return maxLife;
            }

            set
            {
                maxLife = value;
            }
        }

        /// <summary>
        /// Amount of rewards the player currently has.
        /// </summary>
        public int currentRewordAmount;

        /// <summary>
        /// CAlled when player takes daamge
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            currentLife -= amount;
        }

        public void AddReward(int amount)
        {
            currentRewordAmount += amount;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Protection the enemy is using.
    /// </summary>
    public class EnemyProtection : MonoBehaviour
    {

        /// <summary>
        /// Parent enemy script.
        /// </summary>
        public Enemy parentEnemy;

        /// <summary>
        /// The order of swipes needed to remove protection.
        /// </summary>
        public List<SwipeDirection> swipesNeeded = new List<SwipeDirection>();

        /// <summary>
        /// Acceptable swipe directions.
        /// </summary>
        public enum SwipeDirection
        {
            tap,
            up,
            down,
            right,
            left,
        }

        /// <summary>
        /// Handles when player swipes enemy when it has protection.
        /// </summary>
        /// <param name="direction">The direction the player swiped</param>
        public void SwipedByPlayer(SwipeDirection direction)
        {
            if (direction == swipesNeeded[0])
            {
                swipesNeeded.RemoveAt(0);
            }

            if (swipesNeeded.Count == 0)
            {
                RemoveProtection();
            }
        }


        public void RemoveProtection()
        {
            parentEnemy.canTakeDamage = true;
            Destroy(this.gameObject);
        }
    }
}

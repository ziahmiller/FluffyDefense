using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyDefense
{
    /// <summary>
    /// Stores and send the image of the direction needed to swipe on an enemy.
    /// </summary>
    public class SwipeDirectionDisplay : MonoBehaviour
    {
        /// <summary>
        /// Image for siwping up.
        /// </summary>
        public Sprite swipeUp;

        /// <summary>
        /// Image for siwping down.
        /// </summary>
        public Sprite swipeDown;

        /// <summary>
        /// Image for siwping right.
        /// </summary>
        public Sprite swipeRight;

        /// <summary>
        /// Image for siwping left.
        /// </summary>
        public Sprite swipeLeft;

        /// <summary>
        /// Image for tapping.
        /// </summary>
        public Sprite tap;

        /// <summary>
        /// Returns a sprite that represetns a swipe direction
        /// </summary>
        /// <param name="swipe">The direction of swipe</param>
        /// <returns>Siwpe sprite</returns>
        public Sprite GetSwipeDirectionSprite(EnemyProtection.SwipeDirection swipe)
        {
            if (swipe == EnemyProtection.SwipeDirection.up)
            {
                return swipeUp;
            }
            else if (swipe == EnemyProtection.SwipeDirection.down)
            {
                return swipeDown;
            }
            else if (swipe == EnemyProtection.SwipeDirection.right)
            {
                return swipeRight;
            }
            else if (swipe == EnemyProtection.SwipeDirection.left)
            {
                return swipeLeft;
            }
            else
            {
                return tap;
            }
        }

    }
}

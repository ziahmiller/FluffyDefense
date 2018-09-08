using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyDefense
{
    /// <summary>
    /// Displays the enemy stats.
    /// </summary>
    public class EnemyInfo : MonoBehaviour
    {

        /// <summary>
        /// Enemy displaying stats for.
        /// </summary>
        public Enemy enemy;

        /// <summary>
        /// Life bar that shows amount current life of enemy.
        /// </summary>
        public Image lifeBar;

        /// <summary>
        /// Text that displays current life of enemy.
        /// </summary>
        public Text currentLifeText;

        /// <summary>
        /// Displays the next in line swipe direction of enemy's protection.
        /// </summary>
        public Image swipeDirection;

        /// <summary>
        /// Displays the enemy's name.
        /// </summary>
        public Text enemyNameText;

        // Use this for initialization
        void Start()
        {
            UpdateUI();
            enemy.beenHit.AddListener(UpdateUI);
        }

        /// <summary>
        /// Displays the current stats of the enemy.
        /// </summary>
        public void UpdateUI()
        {
            //gets the percent missing from max.
            lifeBar.fillAmount = ((float)enemy.CurrentLife / (float)enemy.MaxLife);

            currentLifeText.text = enemy.CurrentLife.ToString();

            enemyNameText.text = enemy.enemyName;

            if (enemy.enemyProtection.swipesNeeded.Count > 0)
            {
                swipeDirection.sprite = GameController.GetInstance().GetSwipeDirectionSprite(enemy.enemyProtection.swipesNeeded[0]);
            }
            else
            {
                swipeDirection.sprite = GameController.GetInstance().GetSwipeDirectionSprite(EnemyProtection.SwipeDirection.tap);
            }
        }

       
    }
}

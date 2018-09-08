using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyDefense
{
    public class GameUI : MonoBehaviour
    {
        /// <summary>
        /// Bar that shows the players life.
        /// </summary>
        public Image playerLifeBar;

        /// <summary>
        /// Displays player's current life.
        /// </summary>
        public Text currentPlayersLifeText;

        /// <summary>
        /// Current amount of rewards player has.
        /// </summary>
        public Text currentRewardsText;

        /// <summary>
        /// Time remaining in wave.
        /// </summary>
        public Text curentWaveTimeText;

        /// <summary>
        /// Button that spawns a way.
        /// </summary>
        public Button spawnButton;

        // Use this for initialization
        void Start()
        {
            GameController.GetInstance().endOfWave.AddListener(ResetUI);
            ResetUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ResetUI()
        {
            spawnButton.gameObject.SetActive(true);
            curentWaveTimeText.gameObject.SetActive(false);
            UpdatePlayersStats();
        }

        public void UpdateRemainingTime(float currentWaveTime)
        {
            //Trying to get the current wave time as an int though it is a float. (int) placed in front of the equation will cast it as an int.
            int theTime = (int)(currentWaveTime - Time.time + 0.5f);
            curentWaveTimeText.text = theTime.ToString();
        }

        public void UpdatePlayersStats()
        {
            playerLifeBar.fillAmount = ((float)GameController.GetInstance().playerStats.CurrentLife / (float)GameController.GetInstance().playerStats.MaxLife);
            currentPlayersLifeText.text = GameController.GetInstance().playerStats.currentLife.ToString();
            currentRewardsText.text = GameController.GetInstance().playerStats.currentRewordAmount.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyDefense
{
    /// <summary>
    /// The cell that holds the towers info and displays it to the player.
    /// </summary>
    public class TowerCellInfo : MonoBehaviour
    {
        /// <summary>
        /// Displays the image of tower type.
        /// </summary>
        public Image towerIcon;

        /// <summary>
        /// Displays the title of the tower.
        /// </summary>
        public Text towerTitle;

        /// <summary>
        /// Displays the discription of the tower.
        /// </summary>
        public Text towerDiscription;

        /// <summary>
        /// Displays the price of the tower.
        /// </summary>
        public Text towerPrice;

        /// <summary>
        /// The tower prefab for this cell.
        /// </summary>
        public Tower tower;

        /// <summary>
        /// Called when you tap on TowerCellInfo;
        /// </summary>
        public Button selectTowerButton;

        /// <summary>
        /// Parent TowerBuilder Script.
        /// </summary>
        public TowerBuilder towerBuilder;

        /// <summary>
        /// Sets the values of a new tower to the cell
        /// </summary>
        /// <param name="newTower">The tower for this cell</param>
        public void SetUpTowerCellInfo(Tower newTower)
        {
            tower = newTower;
            selectTowerButton.onClick.AddListener(SelectThisTower);
            towerIcon.sprite = tower.towerIcon;
            towerTitle.text = tower.title;
            towerDiscription.text = tower.discription;
            towerPrice.text = "Cost : " + tower.price.ToString();
        }

        public void SelectThisTower()
        {
            towerBuilder.SelectTower(tower);

            //if (GameController.GetInstance().playerStats.currentRewordAmount >= tower.price)
            //{
            //  GameController.GetInstance().towerBuilder.SelectTower(tower);
            //}
        }
    }
}

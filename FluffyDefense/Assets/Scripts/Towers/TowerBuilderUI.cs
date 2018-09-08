using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyDefense
{
    /// <summary>
    /// The interface the user interacts with.
    /// </summary>
    public class TowerBuilderUI : MonoBehaviour
    {
        /// <summary>
        /// The cell that displays tower info.
        /// </summary>
        public TowerCellInfo towerCellPrefab;

        /// <summary>
        /// Object that holds all the tower cells to select towers to build.
        /// </summary>
        public GameObject towerCellContainer;

        /// <summary>
        /// Scroll bar that is used in selecting towers.
        /// </summary>
        public Scrollbar scrollBar;

        /// <summary>
        /// The screen that confirms the tower selection.
        /// </summary>
        public GameObject confirmTowerSelection;

        /// <summary>
        /// Shows all the tower the player can build
        /// </summary>
        public void DisplayTowers(List<Tower> allTowers)
        {
            
            if (allTowers.Count > towerCellContainer.transform.childCount)
            {
                SetUpAllTowers(allTowers);
            }

            this.gameObject.SetActive(true);

        }

        /// <summary>
        /// Sets up all towers that can be built.
        /// </summary>
        public void SetUpAllTowers(List<Tower> allTowers)
        {
           
            //Need to get rid of whatever TowerInfoCell that are already there to avoid making duplicates.
            foreach (Transform child in towerCellContainer.transform)
            {
                Destroy(child.gameObject);
            }

            ///This goes through all the towers and creates a UI object for them.
            foreach (Tower tower in allTowers)
            {
                TowerCellInfo newCell = Instantiate(towerCellPrefab);
                newCell.SetUpTowerCellInfo(tower);
                newCell.transform.SetParent(towerCellContainer.transform, false);
            }

            //If there are enough towers to use the scroll bar we turn it on, else turn it off.
            if (towerCellContainer.transform.childCount > 4)
            {
                scrollBar.gameObject.SetActive(true);
            }
            else
            {
                scrollBar.gameObject.SetActive(false);
            }
        }

    }
}

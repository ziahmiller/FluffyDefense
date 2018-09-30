using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Controls the tower building.
    /// </summary>
    public class TowerBuilder : MonoBehaviour
    {
        /// <summary>
        /// UI that displays what towers the player can build.
        /// </summary>
        public TowerBuilderUI towerBuilderUI;

        /// <summary>
        /// All the Towers the builder can spawn.
        /// </summary>
        public List<Tower> allAvailableTower = new List<Tower>();

        /// <summary>
        /// The tower selected to build.
        /// </summary>
        public Tower selectedTowerToBuild;

        /// <summary>
        /// The PlotNode selected to biuld a new tower on.
        /// </summary>
        public PlotNode selectedNodeToBuildOn;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Displays all the tower selection.
        /// </summary>
        public void DisplayTowerSelection()
        {
            towerBuilderUI.DisplayTowers(allAvailableTower);
        }

        /// <summary>
        /// Builds a tower on selected PlotNode.
        /// </summary>
        public void BuildTower()
        {
            if (GameController.GetInstance().PurchaseTower(selectedTowerToBuild)) {
                Tower newTower = Instantiate(selectedTowerToBuild);
                newTower.transform.position = selectedNodeToBuildOn.transform.position;
                selectedNodeToBuildOn.tower = newTower;
                newTower.transform.SetParent(this.transform);
                towerBuilderUI.gameObject.SetActive(false);
            }
            else
            {

            }
        }

        /// <summary>
        /// Called when player selcts a PlotNode to build on.
        /// </summary>
        /// <param name="plot">The PlotNode selected.</param>
        public void SlectedPlotToBuild(PlotNode plot)
        {
            selectedNodeToBuildOn = plot;
            DisplayTowerSelection();
        }

        /// <summary>
        /// When player selcted a tower to build.
        /// </summary>
        /// <param name="tower">Selected tower</param>
        public void SelectTower(Tower tower)
        {
            selectedTowerToBuild = tower;
            towerBuilderUI.confirmTowerSelection.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Plot Node controls the area a tower is built.
    /// </summary>
    public class PlotNode : MonoBehaviour
    {

        /// <summary>
        /// The asset that displays the plot area.
        /// </summary>
        public GameObject currentPlotAsset;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Replaces the current Plot Node Asset with a new asset.
        /// </summary>
        public void SpawnNewPlotNodeAsset(GameObject newDesign)
        {
            //If we already have one, we destroy it to place the new one. Deleting the old design helps not to have multiple assets in one area.
            if (currentPlotAsset != null)
            {

            }
        }
    }
}

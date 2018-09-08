using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Node Container keeps tracks off all nodes.
    /// </summary>
    public class NodeContainer : MonoBehaviour
    {

        /// <summary>
        /// Field Container Node holds all the filed nodes.
        /// </summary>
        public Transform fieldNodesContainer;

        /// <summary>
        /// Path Nodes Container holds all the path nodes.
        /// </summary>
        public Transform pathNodesContainer;

        /// <summary>
        /// Start Point is where the path begins that the enemies to follows.
        /// </summary>
        public Transform startPoint;

        /// <summary>
        /// End Point is where the path end that the enemies to follows.
        /// </summary>
        public Transform endPoint;

        /// <summary>
        /// Set Path are the Field Nodes you want changed into Path Nodes at runtime.
        /// </summary>
        public List<GameObject> setPath = new List<GameObject>();

        /// <summary>
        /// Final Path is the Set Path with Start and End Point added. This is the path the enemy will follow.
        /// </summary>
        [HideInInspector]//Hide in inspector since you do not need to assign anything. Still needs to be public since other scripts will try and use it.
        public List<GameObject> finalPath = new List<GameObject>();

        // Use this for initialization
        void Awake()
        {
            ClearAndAssignPath();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClearAndAssignPath()
        {
            finalPath = setPath;

            foreach (GameObject child in setPath)//foreach loops through each GameObject in setPath.
            {
                child.SetActive(false);//We turn off the nodes we are using for the path so the player does not see them or interact with them.
            }

            finalPath.Add(endPoint.gameObject);//Places endPoint at the end.
            finalPath.Insert(0, startPoint.gameObject);//Places startPoint in the postion "0" which is the first position of a list in C#.
        }
    }
}

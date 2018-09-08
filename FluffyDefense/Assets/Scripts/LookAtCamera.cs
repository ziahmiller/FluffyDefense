using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Turns object to look at camera.
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {
        public Transform target;

        private void Start()
        {
            target = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(target);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Keeps the rotation of a transform to a set value.
    /// </summary>
    public class KeepRotation : MonoBehaviour
    {
        /// <summary>
        /// The rotation to keep to.
        /// </summary>
        public Quaternion rotationToKeep;

        // Update is called once per frame
        void Update()
        {
            transform.rotation = rotationToKeep;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// ILife manages the life of enemies, distrcutable object, or player.
    /// </summary>
    interface ILife
    {
        /// <summary>
        /// Current life of entity.
        /// </summary>
        int CurrentLife { get; set; }

        /// <summary>
        /// Max life of entity.
        /// </summary>
        int MaxLife { get; set; }

        /// <summary>
        /// When object takes damage.
        /// </summary>
        void TakeDamage(int amount);

    }
}

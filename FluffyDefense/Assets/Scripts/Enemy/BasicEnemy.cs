using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    public class BasicEnemy : Enemy
    {
        public override void Vanish()
        {
            Destroy(this.gameObject);
        }

        public override void EndOfPath()
        {
            GameController.GetInstance().PlayerTakesDamage(damageIDo);
            Vanish();
        }

        public override void BeenKilled()
        {
            GameController.GetInstance().AddRewaord(rewardValue);
            Vanish();
        }
    }
}

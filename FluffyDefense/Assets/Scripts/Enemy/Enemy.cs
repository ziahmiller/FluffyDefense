using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FluffyDefense
{
    /// <summary>
    /// Enemy that the player has to defeat.
    /// </summary>
    public abstract class Enemy : MonoBehaviour, ILife
    {
        /// <summary>
        /// How much the player is reworded when defeating enemy.
        /// </summary>
        public int rewardValue = 1;

        /// <summary>
        /// Name of the enemy.
        /// </summary>
        public string enemyName; 

        /// <summary>
        /// Path the enemy follows.
        /// </summary>
        public List<GameObject> pathToFollow = new List<GameObject>();

        /// <summary>
        /// What point of the path the enemy is on.
        /// </summary>
        private int currentPathPoint = 0;// we incroment this number as the enemy moves, keeping them on track to reach the end.

        /// <summary>
        /// Current amount of life for the enemy.
        /// </summary>
        public int currentLife;

        /// <summary>
        /// Acceptable distance needed to move to next point in path.
        /// </summary>
        public float acceptableDistance = 0.01f;

        /// <summary>
        /// Celled when enemy has been hit.
        /// </summary>
        public UnityEvent beenHit;

        /// <summary>
        /// Current amount of life for the enemy that other scripts access.
        /// </summary>
        public int CurrentLife
        {
            get
            {
                return currentLife;
            }

            set
            {
                currentLife = value;
            }
        }

        /// <summary>
        /// Max amount of life for the enemy.
        /// </summary>
        public int maxLife;

        /// <summary>
        /// Max amount of life for the enemy that other scripts access.
        /// </summary>
        public int MaxLife
        {
            get
            {
                return maxLife;
            }

            set
            {
                maxLife = value;
            }
        }

        /// <summary>
        /// If enemey can take damage.
        /// </summary>
        public bool canTakeDamage = false;

        /// <summary>
        /// The Protection assigned to the enemy.
        /// </summary>
        public EnemyProtection enemyProtection;

        /// <summary>
        /// Rigidbody that handles physics.
        /// </summary>
        public Rigidbody body;

        /// <summary>
        /// Speed the enemy moves at.
        /// </summary>
        private float speed = 1;

        /// <summary>
        /// Amount of damage the enemy does to the player or destructable object.
        /// </summary>
        public int damageIDo = 1;

        /// <summary>
        /// Sets up the enmies life and reword with new values.
        /// </summary>
        /// <param name="life">Amount to change life.</param>
        /// <param name="rewardAmount">Amount to change reword value</param>
        public void SetLifeAndGold(int life, int rewardAmount)
        {
            CurrentLife = life;
            MaxLife = life;
            rewardValue = rewardAmount;
        }

        /// <summary>
        /// Handles taking damage
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="direction"></param>
        public void TakeDamage(int amount)
        {
            if (canTakeDamage)
            {
                currentLife -= amount;
            }
            if (currentLife <= 0)
            {
                Vanish();
            }
            else {
                beenHit.Invoke();
            }
        }

        /// <summary>
        /// Overload of Take damage to account for player's swipe direction.
        /// </summary>
        /// <param name="amount">Amount of damage</param>
        /// <param name="direction">Direction of swipe</param>
        public void TakeDamage(int amount, EnemyProtection.SwipeDirection direction = EnemyProtection.SwipeDirection.tap)
        {
            if (canTakeDamage)
            {
                currentLife -= amount;
            }
            else
            {
                enemyProtection.SwipedByPlayer(direction);
            }
            if (currentLife <= 0)
            {
                BeenKilled();
            }
            else
            {
                beenHit.Invoke();
            }
        }

        private void Update()
        {
            MoveAlongPath();
        }

        /// <summary>
        /// Moves enemy along path.
        /// </summary>
        public void MoveAlongPath()
        {
            //Want to look at the direction of the new path point but not look down or up. We do this by making the y position the same as the enemy.
            Vector3 newPoint = new Vector3(pathToFollow[currentPathPoint].transform.position.x, this.transform.position.y, pathToFollow[currentPathPoint].transform.position.z);

            transform.LookAt(newPoint);

            body.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);

            GetNextPathPoint(newPoint);
        }

        public void GetNextPathPoint(Vector3 targetPoint)
        {
            float distance = Vector3.Distance(this.transform.position, targetPoint);
            if (distance < acceptableDistance)
            {
                currentPathPoint++;
            }

            if (currentPathPoint >= pathToFollow.Count)
            {
                EndOfPath();
            }
        }

        public abstract void EndOfPath();

        public abstract void BeenKilled();

        public abstract void Vanish();
    }
}

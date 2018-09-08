using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    /// <summary>
    /// Projectiles are files at enemies.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// Amount of damage the projectile does.
        /// </summary>
        public int damage;

        /// <summary>
        /// Speed the projecile moves at.
        /// </summary>
        public float speed = 1.0f;

        /// <summary>
        /// Projectiles target to move towards.
        /// </summary>
        public Transform target;

        /// <summary>
        /// Rigidbody for Projectile.
        /// </summary>
        public Rigidbody projectileBody;

        /// <summary>
        /// Makes sure we do not hit multiple enemies.
        /// </summary>
        public bool hitEnemy;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            LookAndMove();
        }

        /// <summary>
        /// Looks and moves towrds target.
        /// </summary>
        public void LookAndMove()
        {
            if (target != null)
            {
                transform.LookAt(target);
                projectileBody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            }
            else
            {
                WhenIHitSomething(false);
            }
        }

        /// <summary>
        /// Called if we hit another object with a rigidbody and colloder.
        /// </summary>
        /// <param name="collision">Object porjectile hit.</param>
        private void OnCollisionEnter(Collision collision)
        {
            if (!hitEnemy && collision.transform.tag == "Enemy")
            {
                HitAnEnemy(collision.transform.GetComponent<Enemy>());
            }
        }

        /// <summary>
        /// Called if the object we hit is an Enemy
        /// </summary>
        /// <param name="enemy"></param>
        public void HitAnEnemy(Enemy enemy)
        {
            enemy.TakeDamage(damage);
            WhenIHitSomething(true);
            hitEnemy = true;
        }

        /// <summary>
        /// Called when the projectle hits something that would destroy it.
        /// </summary>
        /// <param name="wasEnemy">If it was an enemy the projectile hit</param>
        public void WhenIHitSomething(bool wasEnemy)
        {
            
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyDefense
{
    public class Tower : MonoBehaviour
    {
        /// <summary>
        /// Title of the tower.
        /// </summary>
        public string title;

        /// <summary>
        /// Discription of the tower
        /// </summary>
        public string discription;

        /// <summary>
        /// Price of the tower.
        /// </summary>
        public int price;

        /// <summary>
        /// Icon for the tower.
        /// </summary>
        public Sprite towerIcon;

        /// <summary>
        /// Target the enemy the taower is aiming at.
        /// </summary>
        public Transform target;

        /// <summary>
        /// The part of the tower that turns to face the target.
        /// </summary>
        public Transform turret;

        /// <summary>
        /// Where the projectile is shot from.
        /// </summary>
        public Transform endPoint;

        /// <summary>
        /// The distance the tower can aim and shoot at a target.
        /// </summary>
        public float aimingDistance;

        /// <summary>
        /// The of Projectile the tower fires. 
        /// </summary>
        public Projectile projectile;

        /// <summary>
        /// How fast the tower fires.
        /// </summary>
        public float fireSpeed = 3.0f;

        /// <summary>
        /// How long tower has waited since last show. 
        /// </summary>
        float waitForNextShot;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            LookAtTarget();
        }

        /// <summary>
        /// Looks and follows the target
        /// </summary>
        public void LookAtTarget()
        {
            if (target != null)
            {
                if (Vector3.Distance(turret.transform.position, target.position) > aimingDistance)
                {
                    target = null;
                    return;
                }

                //We don't want the turret to look down, we do this by making the Y axis which works as hieght in the scene set to the same hieght as the turret.
                Vector3 newAimPos = new Vector3(target.position.x, turret.position.y, target.position.z);
                turret.LookAt(newAimPos);
                FireProjectile();
            }
            else
            {
                FindNewTarget();
            }
        }

        /// <summary>
        /// When the tower does not have a taget finds a new one.
        /// </summary>
        public void FindNewTarget()
        {
            //Want to make sure we target the closest enemy to the turret. Defualt size is super far away.
            float closestEnemy = 110.0f;

            //Looking through all enemies in the game. We can do this since we make all enemies a child of EnemySpawner.
            foreach (Transform child in GameController.GetInstance().enemySpawner.emenyContainer)
            {
                //Need to make sure the enemy is close enough to target.
                float distanceAway = Vector3.Distance(turret.position, child.position);
                if (distanceAway < aimingDistance && distanceAway < closestEnemy)
                {
                    closestEnemy = distanceAway;
                    target = child;
                }
            }
        }

        public void FireProjectile()
        {
            if (waitForNextShot < Time.time)
            {
                waitForNextShot = Time.time + fireSpeed;

                Projectile newProjectile = Instantiate(projectile);

                newProjectile.target = target;
                newProjectile.transform.position = endPoint.position;


            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FluffyDefense
{
    /// <summary>
    /// Game Controller oversees the players interactions and the flow of the game.
    /// We use the design pattern Singleton and Mediator for this class. 
    /// I am also infusing a form of Fecade design pattern.
    /// </summary>
    public class GameController : MonoBehaviour
    {

        /// <summary>
        /// This allows us to assign one instance of the GameController for other scripts to call.
        /// </summary>
        private static GameController instance;

        /// <summary>
        /// Node Container.
        /// </summary>
        public NodeContainer nodeContiner;

        /// <summary>
        /// Enemey Spawner.
        /// </summary>
        public EnemySpawner enemySpawner;

        /// <summary>
        /// Games main UI.
        /// </summary>
        public GameUI gameUI;

        /// <summary>
        /// Players stats.
        /// </summary>
        public PlayerStats playerStats;

        /// <summary>
        /// Main menu.
        /// </summary>
        public MainMenu mainMenu;

        /// <summary>
        /// Hold the images for what direction to siwpe and enemy.
        /// </summary>
        public SwipeDirectionDisplay swipeDirectionDisplay;

        /// <summary>
        /// Distance needed to be considered a swipe.
        /// </summary>
        public float swipeDistanceNeeded = 60;

        /// <summary>
        /// Position of where the player taps down.
        /// </summary>
        public Vector2 startTap;

        /// <summary>
        /// The direction the player swipes.
        /// </summary>
        public EnemyProtection.SwipeDirection swipeDirection;

        /// <summary>
        /// The enemy the play is targeting.
        /// </summary>
        public Enemy targetedEnemy;

        /// <summary>
        /// True if there is a wave of enemies.
        /// </summary>
        public bool waveInProgress;

        /// <summary>
        /// Called when a way ends.
        /// </summary>
        public UnityEvent endOfWave;

        /// <summary>
        /// Gets the instance of GameController.
        /// </summary>
        /// <returns>Returns the instance of GameController</returns>
        public static GameController GetInstance()
        {
            return instance;
        }

        // Use this for initialization
        void Awake()
        {
            instance = this;
            ToggleMainMenu(false);
        }

        // Update is called once per frame
        void Update()
        {
            SpawnEnemies();
            GetInputDown();
            GetInputUp();
        }

        /// <summary>
        /// Spawns enemies from enemySpawner script.
        /// </summary>
        public void SpawnEnemies()
        {
            if (waveInProgress) {
                //Checks when the next enemy needs to be spawned.
                if (enemySpawner.currentWaveLength > Time.time)
                {
                    gameUI.UpdateRemainingTime(enemySpawner.currentWaveLength);

                    if (enemySpawner.currentSpawnTime < Time.time) {
                        enemySpawner.SpawnEnemy(enemySpawner.enemiesForLevel[Random.Range(0, enemySpawner.enemiesForLevel.Count)], nodeContiner.finalPath);
                    }
                }

                if (enemySpawner.currentWaveLength < Time.time && enemySpawner.transform.childCount == 0)
                {
                    waveInProgress = false;
                    endOfWave.Invoke();
                }
            }
        }

        /// <summary>
        /// Gets the users clicks or taps
        /// </summary>
        public void GetInputDown()
        {
            //The moment the user presses the mouse or taps on the screen.
            if (Input.GetMouseButtonDown(0))
            {
                startTap = Input.mousePosition;

                CheckObjectITouched();

            }
        }

        /// <summary>
        /// Sees what object is touched.
        /// </summary>
        public void CheckObjectITouched()
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //This causes a lone to come out from where the player is looking to the place the player tapped. It will let you know the first thing it hits.
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.tag == "Enemy")
                {
                    targetedEnemy = hit.transform.GetComponent<Enemy>();
                }
            }
        }

        /// <summary>
        /// Checks if the user tapped or swiped.
        /// </summary>
        public void GetInputUp()
        {
            //Gets the moment the player lifts up on the screen or mouse button.
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endTap = Input.mousePosition;
                // the distance between when the player tapped down and when the player lifted up.
                float distanceMoved = Vector2.Distance(endTap, startTap);
                EnemyProtection.SwipeDirection direction = EnemyProtection.SwipeDirection.up;

                //If the two tap points are far enough apart and if you targeted an enemy.
                if (distanceMoved > swipeDistanceNeeded)
                {
                    
                    //check if the player moved their finger vertical or horzontal
                    if (System.Math.Abs(endTap.y - startTap.y) > (System.Math.Abs(endTap.x - startTap.x)))
                    {
                        //Checks if they moved up or down.
                        if (endTap.y > startTap.y)
                        {
                            direction = EnemyProtection.SwipeDirection.up;
                            //Debug.Log("direction = " + direction + " and distanceMoved = " + distanceMoved);
                        }
                        else
                        {
                            direction = EnemyProtection.SwipeDirection.down;
                            //Debug.Log("direction = " + direction + " and distanceMoved = " + distanceMoved);
                        }
                    }
                    else
                    {
                        //Checks if they moved left or right.
                        if (endTap.x > startTap.x)
                        {
                            direction = EnemyProtection.SwipeDirection.right;
                            //Debug.Log("direction = " + direction + " and distanceMoved = " + distanceMoved);
                        }
                        else
                        {
                            direction = EnemyProtection.SwipeDirection.left;
                            //Debug.Log("direction = " + direction + " and distanceMoved = " + distanceMoved);
                        }
                    }

                }
                else {
                    direction = EnemyProtection.SwipeDirection.tap;
                    //Debug.Log("direction = " + direction + " and distanceMoved = " + distanceMoved);
                }

                if (targetedEnemy != null)
                {
                    targetedEnemy.TakeDamage(1, direction);

                    //Once we send damage, we make it null to refresh the tap process.
                    targetedEnemy = null;
                }


            }
           
        }

        /// <summary>
        /// Called the GetSwipeDirectionSprite function from swipeDirectionDisplay.
        /// </summary>
        /// <param name="swipe">Direction of swipe</param>
        /// <returns>Image for direction of swipe</returns>
        public Sprite GetSwipeDirectionSprite(EnemyProtection.SwipeDirection swipe)
        {
            return swipeDirectionDisplay.GetSwipeDirectionSprite(swipe);
        }

        /// <summary>
        /// Starts teh wave.
        /// </summary>
        public void StartWave()
        {
            enemySpawner.SetUpWave();
            waveInProgress = true;
        }

        /// <summary>
        /// When player takes damage.
        /// </summary>
        public void PlayerTakesDamage(int amount)
        {
            playerStats.TakeDamage(amount);
            gameUI.UpdatePlayersStats();
        }

        /// <summary>
        /// Adds reward to player stats
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public void AddRewaord(int amount)
        {
            Debug.Log("amount " + amount);
            playerStats.AddReward(amount);
            gameUI.UpdatePlayersStats();
        }

        /// <summary>
        /// Toggles the main menu for scene.
        /// </summary>
        /// <param name="value">On or off</param>
        public void ToggleMainMenu(bool value)
        {
            mainMenu.gameObject.SetActive(value);
            if (value)
            {
                Time.timeScale = 0;//Slows the time down to 0 to make it seemed paused.
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}

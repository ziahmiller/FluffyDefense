using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    /// <summary>
    /// Loads the scene in the build matching the number.
    /// </summary>
    /// <param name="number">The scene to load.</param>
    public void LoadALevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}

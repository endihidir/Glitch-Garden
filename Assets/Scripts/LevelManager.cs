using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLevelNextLoadAfter;

    private void Start()
    {
        if (autoLevelNextLoadAfter <= 0)
        {
            Debug.Log("Level auto load disabled.");
        }
        else
        {
            Invoke("LoadNextLevel", autoLevelNextLoadAfter);
        }
        
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel +1);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

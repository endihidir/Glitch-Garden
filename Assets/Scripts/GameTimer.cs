using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public int levelSeconds = 100;
    LevelManager levelManager;
    Slider slider;
    AudioSource audioSource;
    GameObject youWin;

    bool isEndOfLevel = false;
	// Use this for initialization
	void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        FindYouWin();
        youWin.SetActive(false);
    }

    private void FindYouWin()
    {
        youWin = GameObject.Find("You Win");
        if (!youWin)
        {
            Debug.LogError("You Win Label is can not found in the UI panel");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);

        if (timeIsUp && !isEndOfLevel)
        {
            HandleWinCondition();
        }

    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObject();
        audioSource.Play();
        youWin.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObject()
    {
        GameObject[] taggedObjextArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObject in taggedObjextArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    
}

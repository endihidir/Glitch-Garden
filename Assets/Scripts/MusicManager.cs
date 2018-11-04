using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();

    }
    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}

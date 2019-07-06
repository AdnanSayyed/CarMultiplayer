using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public AudioSource otherSource;

    public static SoundManager instance = null;

	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayOtherSound(AudioClip clip)
    {
        otherSource.clip = clip;
        otherSource.Play(0);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play(0);
    }
	
}

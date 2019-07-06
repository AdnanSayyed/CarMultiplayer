using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Selectscript : MonoBehaviour {

    public AudioClip clickClip;   

    /// <summary>
    /// car selection scene
    /// </summary>
    /// <param name="status"></param>
	public void GotoCarscene(string status)
	{
        SoundManager.instance.PlayOtherSound(clickClip);
		GameController.playerStatus = status;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    /// <summary>
    /// go to previouse scene
    /// </summary>
    public void GotoPreviouseScene()
    {
        SoundManager.instance.PlayOtherSound(clickClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}

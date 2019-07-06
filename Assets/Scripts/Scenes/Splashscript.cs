using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Splashscript : MonoBehaviour {

    public GameObject panel;
    public GameObject startBtn;
    public GameObject instructionBtn;
    public AudioClip clickClip;

    // Use this for initialization
    void Start () {
        panel.SetActive(false);
	}

    /// <summary>
    /// go to selection scene
    /// </summary>
	public void GotoSelect()
	{
        SoundManager.instance.PlayOtherSound(clickClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    /// <summary>
    /// instruction window
    /// </summary>
    public void GotoInstruction()
    {
        SoundManager.instance.PlayOtherSound(clickClip);
        panel.SetActive(true);
        GameObject.Find("startbtn").GetComponent<Image>().enabled = false;
        GameObject.Find("startbtn").GetComponentInChildren<Text>().enabled = false;

        GameObject.Find("instructionbtn").GetComponent<Image>().enabled = false;
        GameObject.Find("instructionbtn").GetComponentInChildren<Text>().enabled = false;
    }

    /// <summary>
    /// back to scene from instruction window
    /// </summary>
    public void BackToScene()
    {
        SoundManager.instance.PlayOtherSound(clickClip);
        panel.SetActive(false);
        GameObject.Find("startbtn").GetComponent<Image>().enabled = true;
        GameObject.Find("startbtn").GetComponentInChildren<Text>().enabled = true;

        GameObject.Find("instructionbtn").GetComponent<Image>().enabled = true;
        GameObject.Find("instructionbtn").GetComponentInChildren<Text>().enabled = true;

    }
}

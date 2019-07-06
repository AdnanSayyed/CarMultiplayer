using UnityEngine;
using UnityEngine.SceneManagement;

public class Carscript : MonoBehaviour {

    public AudioClip clickClip;

    /// <summary>
    /// main game scene
    /// </summary>
    /// <param name="carSelect"></param>
	public void GotoGamescene(string carSelect)
	{
		GameController.carSelected = carSelect;
        if (carSelect == "Carone")
        {
            SoundManager.instance.PlayOtherSound(clickClip);
            GameController.materialSelected = "materialOne";
        }
        else
        {
            SoundManager.instance.PlayOtherSound(clickClip);
            GameController.materialSelected = "materialTwo";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// go to previouse scene
    /// </summary>
    public void GotoPreviouseScene()
    {
        SoundManager.instance.PlayOtherSound(clickClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //This object is used to toggle the volume/brightness settings (currently not in-use)
    public CanvasGroup option;

    //Move to first level
    public void startGame()
    {
        SceneManager.LoadScene("Lvl1");
    }

    //Close the Game
    public void quitGame()
    {
        Application.Quit();
    }

    //open option settings (currently not in-use)
    public void Settings()
    {
        option.alpha = 0;
        option.blocksRaycasts = true;

    }

    //Close the option settings (currently not in-use)
    public void ReturnMenu()
    {
        option.alpha = 0;
        option.blocksRaycasts = false;
    }
}

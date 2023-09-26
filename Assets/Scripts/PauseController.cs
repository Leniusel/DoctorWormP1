using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    //For every scene, pause menu is disabled until toggled with ESCAPE key
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //Check for ESCAPE key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                continueGame();
            }
            else 
            {
                pauseGame();
            }
        }
    }

    //Pause Game (include timer, animation, music)
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    //Resume Game
    public void continueGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    //Quit Game and return to Main Menu
    public void quitGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("MenuScene");  
    }

    //Restart Game from the very beginning.
    public void restartGame()
    {
        isPaused = false;
        SceneManager.LoadScene("Lvl1");
        //Code to restart timer (not finished/ please wait for Timer script)
    }

 
}


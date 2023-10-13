using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    //For every scene, pause menu is disabled until toggled with ESCAPE key
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //Check for ESCAPE key
    void Update()
    {
        GameObject keyPad = GameObject.FindGameObjectWithTag("keyPad");
        GameObject slidePuzzle = GameObject.FindGameObjectWithTag("slidePuzzle");
        GameObject clue = GameObject.FindGameObjectWithTag("clue");

        if (Input.GetKeyDown(KeyCode.Escape) &&
            !keyPad.GetComponent<ShowKeyPad>().keyPadIsOn &&
            !slidePuzzle.GetComponent<ShowSlidePuzzle>().slidePuzzleIsOn &&
            !clue.GetComponent<clue1paper>().clueIsOn)
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
        Application.Quit();
    }

    //Restart Game from the very beginning.
    public void restartGame()
    {
        isPaused = false;
        SceneManager.LoadScene("Lvl1");
        //Code to restart timer (not finished/ please wait for Timer script)
    }

 
}


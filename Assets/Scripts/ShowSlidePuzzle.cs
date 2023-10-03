using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSlidePuzzle : MonoBehaviour
{
    public GameObject slidePuzzle;
    public GameObject player;
    public TMP_Text txtItem;
    private bool isOnS;
    public bool slidePuzzleIsOn;

    void Start()
    {
        slidePuzzle.SetActive(false);
        isOnS = false;
        slidePuzzleIsOn = false;
    }

    private void Update()
    {
        GameObject paused = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.E) && isOnS && !slidePuzzleIsOn &&
            !paused.GetComponent<PauseController>().isPaused)
        {
            slidePuzzleIsOn = true;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            txtItem.text = "Press E to exit!";
            slidePuzzle.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && slidePuzzleIsOn)
        {
            slidePuzzleIsOn = false;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;
            txtItem.text = "Press E to use!";
            slidePuzzle.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject slidePuzzle = GameObject.FindGameObjectWithTag("Player");
        if (!slidePuzzle.GetComponent<SlidePuzzelController>().isDone)
        {
            isOnS = true;
            txtItem.text = "Press E to use!";
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnS = false;
        txtItem.text = "";
    }
    public void isDone()
    {
        slidePuzzleIsOn = false;
        txtItem.text = "";
        slidePuzzle.SetActive(false);
        Time.timeScale = 1f;
    }
}

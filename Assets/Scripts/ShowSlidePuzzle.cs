using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSlidePuzzle : MonoBehaviour
{
    public GameObject slidePuzzle;
    public GameObject player;
    public TMP_Text txtItem;
    private bool isOn;
    public bool slidePuzzleIsOn;

    void Start()
    {
        slidePuzzle.SetActive(false);
        isOn = false;
        slidePuzzleIsOn = false;
    }

    private void Update()
    {
        GameObject paused = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.Q) && isOn && !slidePuzzleIsOn &&
            !paused.GetComponent<PauseController>().isPaused)
        {
            slidePuzzleIsOn = true;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            txtItem.text = "Press Q to exit!";
            slidePuzzle.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && slidePuzzleIsOn)
        {
            slidePuzzleIsOn = false;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;
            txtItem.text = "Press Q to use!";
            slidePuzzle.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject slidePuzzle = GameObject.FindGameObjectWithTag("Player");
        if (!slidePuzzle.GetComponent<SlidePuzzelController>().isDone)
        {
            isOn = true;
            txtItem.text = "Press Q to use!";
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isOn = false;
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

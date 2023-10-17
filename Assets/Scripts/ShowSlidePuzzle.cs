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

    public ParticleSystem use;

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
            txtItem.text = "Press E to exit!";
            slidePuzzle.SetActive(true);
            player.GetComponent<PlayerController>().audio.Stop();
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingDown", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingUp", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingRight", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingLeft", false);
            player.transform.Rotate(0, 0, 0);
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && slidePuzzleIsOn)
        {
            slidePuzzleIsOn = false;
            player.GetComponent<PlayerController>().enabled = true;
            txtItem.text = "Press E to use!";
            slidePuzzle.SetActive(false);
            Cursor.visible = false;
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
        Destroy(use);
        Cursor.visible = false;
    }
}

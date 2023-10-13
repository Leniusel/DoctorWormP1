using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowKeyPad : MonoBehaviour
{
    public GameObject keyPad;
    public TMP_Text txtItem;
    private bool isOn;
    public bool keyPadIsOn;
    public GameObject player;

    void Start()
    {
        keyPad.SetActive(false);
        isOn = false;
        keyPadIsOn = false;
    }

    private void Update()
    {
        GameObject paused = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.E) && isOn && !keyPadIsOn &&
            !paused.GetComponent<PauseController>().isPaused)
        {
            keyPadIsOn = true;
            txtItem.text = "Press E to exit!";
            keyPad.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOn && keyPadIsOn)
        {
            keyPadIsOn = false;
            txtItem.text = "Press E to use!";
            keyPad.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject keyPad = GameObject.FindGameObjectWithTag("Player");
        if (!keyPad.GetComponent<keypad>().isDone)
        {
            isOn = true;
            txtItem.text = "Press E to use!";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOn = false;
        txtItem.text = "";
    }

    public void isDone()
    {
        keyPadIsOn = false;
        txtItem.text = "";
        keyPad.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().enabled = true;
    }
}

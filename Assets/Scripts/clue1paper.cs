using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clue1paper : MonoBehaviour
{
    public TMP_Text txtUse;
    public GameObject clue;
    public GameObject player;

    public bool isOn;
    public bool clueIsOn;

    // Start is called before the first frame update
    void Start()
    {
        txtUse.text = "";
        clue.SetActive(false);
        isOn = false;
        clueIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject paused = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.E) && isOn && !clueIsOn &&
            !paused.GetComponent<PauseController>().isPaused)
        {
            clueIsOn = true;
            txtUse.text = "Press E to exit!";
            clue.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOn && clueIsOn)
        {
            clueIsOn = false;
            txtUse.text = "Press E to See!";
            clue.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        txtUse.text = "Press E to See!";
        isOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        txtUse.text = "";
        isOn = false;
    }
}

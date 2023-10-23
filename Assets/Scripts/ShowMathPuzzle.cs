using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMathPuzzle : MonoBehaviour
{
    public GameObject mathPuzzle;
    public GameObject mathPuzzleCol;
    public TMP_Text txtItem;
    private bool isOn;
    public bool mathIsOn;
    public bool Done;
    public GameObject player;

    public ParticleSystem use;

    // Start is called before the first frame update
    void Start()
    {
        Done = false;
        mathPuzzle.SetActive(false);
        isOn = false;
        mathIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject paused = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.E) && isOn && !mathIsOn &&
            !paused.GetComponent<PauseController>().isPaused)
        {
            mathIsOn = true;
            txtItem.text = "Press E to exit!";
            mathPuzzle.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerController>().audio.Stop();
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingDown", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingUp", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingRight", false);
            player.GetComponent<PlayerController>().animator.SetBool("isWalkingLeft", false);
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOn && mathIsOn)
        {
            mathIsOn = false;
            txtItem.text = "Press E to use!";
            mathPuzzle.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            Cursor.visible = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Done)
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
        Done = true;
        mathIsOn = false;
        txtItem.text = "";
        mathPuzzle.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().enabled = true;
        Destroy(use);
        mathPuzzleCol.GetComponent<Collider2D>().enabled = false;
        Cursor.visible = false;
    }
}

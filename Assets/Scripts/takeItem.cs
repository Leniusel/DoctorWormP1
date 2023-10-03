using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class takeItem : MonoBehaviour
{
    public TMP_Text txtItem;
    private bool isOn;

    private void Start()
    {
        txtItem.text = "";
        isOn = false;
    }

    private void Update()
    {
        GameObject pause = GameObject.FindGameObjectWithTag("Player");

        if (pause.GetComponent<PauseController>().isPaused == false)
        {
            Take();
        }
    }

    public void Take()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOn)
        {
            print("Done");
            Destroy(this.gameObject);

            GameObject inventory = GameObject.FindGameObjectWithTag("Player");
            inventory.GetComponent<InventorySystem>().gotItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        txtItem.text = "Press E to take!";
        isOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        txtItem.text = "";
        isOn = false;
    }
}

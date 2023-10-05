using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainDoor : MonoBehaviour
{
    public TMP_Text txtW;
    public TMP_Text txtUse;

    public GameObject winning;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        winning.SetActive(false);
        txtW.text = "";
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.E) && isOn &&
            !player.GetComponent<PauseController>().isPaused)
        {
            if (player.GetComponent<InventorySystem>().keys < 3)
            {
                txtW.text = "You need 3 keys";
            }
            else if (player.GetComponent<InventorySystem>().keys == 3)
            {
                print("Win!");
                winning.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOn = true;
        txtUse.text = "Press E to Open!";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOn = false;
        txtUse.text = "";
        txtW.text = "";
    }
}

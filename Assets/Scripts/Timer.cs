using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float minutes;
    public float seconds;

    public TMP_Text txtTime;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        minutes = 1;
        seconds = 1;

        txtTime.text = "Time left: " + minutes.ToString() + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

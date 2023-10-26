using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scary : MonoBehaviour
{
    public GameObject bed1;
    public GameObject bed2;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        bed1.SetActive(true);
        bed2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

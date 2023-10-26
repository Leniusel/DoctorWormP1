using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLoc : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(true);
        this.GetComponent<Collider2D>().enabled = false;
    }
}

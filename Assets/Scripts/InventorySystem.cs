using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] itmes;
    public TMP_Text txtKeys;
    public int keys;

    // Start is called before the first frame update
    void Start()
    {
        keys = 0;
        txtKeys.text = "Keys: " + keys.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txtKeys.text = "Keys: " + keys.ToString();
    }

    public void gotItem()
    {
        keys++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keypad : MonoBehaviour
{
    public string code;
    public string realCode = "4183";
    public TMP_Text txtCode;

    public GameObject key;
    public GameObject keyPad;
    public bool isDone;

    void Start()
    {
        isDone = false;
        code = "";
        txtCode.text = code;
        key.SetActive(false);
    }

    private void Update()
    {
        txtCode.text = code;
    }

    public void add1()
    {
        if (code.Length < 4)
        {
            code = code + "1";
        }
    }

    public void add2()
    {
        if (code.Length < 4)
        {
            code = code + "2";
        }
    }

    public void add3()
    {
        if (code.Length < 4)
        {
            code = code + "3";
        }
    }

    public void add4()
    {
        if (code.Length < 4)
        {
            code = code + "4";
        }
    }

    public void add5()
    {
        if (code.Length < 4)
        {
            code = code + "5";
        }
    }

    public void add6()
    {
        if (code.Length < 4)
        {
            code = code + "6";
        }
    }

    public void add7()
    {
        if (code.Length < 4)
        {
            code = code + "7";
        }
    }

    public void add8()
    {
        if (code.Length < 4)
        {
            code = code + "8";
        }
    }

    public void add9()
    {
        if (code.Length < 4)
        {
            code = code + "9";
        }
    }

    public void add0()
    {
        if (code.Length < 4)
        {
            code = code + "0";
        }
    }

    public void del()
    {
        if(code.Length > 0)
        {
            code = code.Remove(code.Length - 1);
        }
    }

    public void ent()
    {
        if(code == realCode)
        {
            key.SetActive(true);
            isDone = true;
            keyPad.GetComponent<Collider2D>().enabled = false;
            GameObject Done = GameObject.FindGameObjectWithTag("keyPad");
            Done.GetComponent<ShowKeyPad>().isDone();
        }
        else
        {
            code = "";
            isDone = false;
        }
    }
}

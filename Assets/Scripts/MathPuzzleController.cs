using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MathPuzzleController : MonoBehaviour
{
    
    public int Id;
    private Animator anim;
    public string symbol;
    public TextMeshProUGUI itemText;
    public Image selection;
    private bool selected = false;
    public Sprite icon;

    public GameObject puzzle;


    public void Selected()
    {
        selected = true;
        
        WheelController.symbolID = Id;
    }
    public void DeSelected()
    {
         selected = false;
        //WheelController.symbolID = 0; //set blank
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
        itemText.text = symbol;
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "";
    }


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    public int Convert()
    {
        return int.Parse(symbol);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selection.sprite = icon;
            itemText.text = symbol;
        }
    }
}

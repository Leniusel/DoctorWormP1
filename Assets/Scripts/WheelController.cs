using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    public Animator anim;
    private bool Selected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int symbolID;
    public int idA;
    public int idM;
    public int id;

    public GameObject puzzle;
    // Start is called before the first frame update
    void Start()
    {
        Selected = !Selected;
        anim.SetBool("OpenWheel", true);
    }

    // Update is called once per frame
    void Update()
    {
        //until image assets are available, will be left blank
        switch (symbolID) 
        {
            case 0:
                selectedItem.sprite = noImage;
                break;
            case 1:
                //Debug.Log("Red");
                idA = symbolID;
                break;
            case 2:
                //Debug.Log("Green");
                idA = symbolID;
                break;
            case 3:
                //Debug.Log("Blue");
                idA = symbolID;
                break;
            case 4:
               // Debug.Log("Yellow");
                idA = symbolID;
                break;
            case 5:
                //Debug.Log("Grey");
                idA = symbolID;
                break;
            case 6:
                //Debug.Log("White");
                idA = symbolID;
                break;
            case 7:
                //Debug.Log("Purple");
                idA = symbolID;
                break;
            case 8:
                //Debug.Log("Pink");
                idA = symbolID;
                break;
            case 9:
                //Debug.Log("Orange");
                idA = symbolID;
                break;
            case 10:
                //Debug.Log("Brown");
                idA = symbolID;
                break;
            case 11:
                //Debug.Log("Red");
                idM = symbolID;
                break;
            case 12:
                //Debug.Log("Green");
                idM = symbolID;
                break;
            case 13:
                //Debug.Log("Blue");
                idM = symbolID;
                break;
            case 14:
                //Debug.Log("Yellow");
                idM = symbolID;
                break;
            case 15:
                //Debug.Log("Grey");
                idM = symbolID;
                break;
            case 16:
               // Debug.Log("White");
                idM = symbolID;
                break;
            case 17:
               // Debug.Log("Purple");
                idM = symbolID;
                break;
            case 18:
                //Debug.Log("Pink");
                idM = symbolID;
                break;
            case 19:
               // Debug.Log("Orange");
                idM = symbolID;
                break;
            case 20:
                //Debug.Log("Brown");
                idM = symbolID;
                break;
        }
    }
}

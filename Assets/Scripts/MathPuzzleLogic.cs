using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathPuzzleLogic : MonoBehaviour
{
    private int first, second, third, fourth;
    private int addition, mult;
    
    public int choice1, choice2;

    public TextMeshProUGUI itemText1;
    public TextMeshProUGUI itemText2;
    public TextMeshProUGUI resultAdd;
    public TextMeshProUGUI resultMult;

    public GameObject mathPuzzle;
    public GameObject Add;
    public GameObject Mult;

    // Start is called before the first frame update
    void Start()
    {
        first = Random.Range(0, 10);
        second = Random.Range(0, 10);
        third = Random.Range(0, 10);
        fourth = Random.Range(0, 10);

        addition = first + second + third; //math problem for upright triangle
        mult = first * fourth * third; //math problem for upside-down triangle

        //label text
        itemText1.text = first.ToString();
        itemText2.text = third.ToString();
        resultAdd.text = addition.ToString();
        resultMult.text = mult.ToString();
    }
    /*
    public int getNum()
    {
        choice1 = WheelController.symbolID;
        return choice1;
    }*/

    // Update is called once per frame
    void Update()
    {
        choice1 = Add.GetComponent<WheelController>().idA;
        choice2 = Mult.GetComponent<WheelController>().idM;

     

        if ((choice1 == second) && ((choice2-10) == fourth))
        {
            //close UI and give key
            Debug.Log("Sucess");
            mathPuzzle.SetActive(false);

        }

        else 
        {
            Debug.Log("Try Again");
            //nothing
        }
    }
}

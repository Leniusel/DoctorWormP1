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
    public GameObject key;

    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);

        first = Random.Range(1, 10);
        second = Random.Range(1, 10);
        third = Random.Range(1, 10);
        fourth = Random.Range(1, 10);

        addition = first + second + third; //math problem for upright triangle
        mult = first * fourth * third; //math problem for upside-down triangle

        //label text
        itemText1.text = first.ToString();
        itemText2.text = third.ToString();
        resultAdd.text = addition.ToString();
        resultMult.text = mult.ToString();
    }

    IEnumerator PuzzleOff()
    {
        yield return new WaitForSeconds(10);
    }

    // Update is called once per frame
    void Update()
    {
        choice1 = Add.GetComponent<WheelController>().idA;
        choice2 = Mult.GetComponent<WheelController>().idM;

        //print(choice1 + " " + choice2);

        //label text
        itemText1.text = first.ToString();
        itemText2.text = third.ToString();
        resultAdd.text = addition.ToString();
        resultMult.text = mult.ToString();


        if ((choice1 == second) && (choice2 == (fourth + 10)))
        {
            key.SetActive(true);
            mathPuzzle.SetActive(false);
            Cursor.visible = false;
            GameObject Done = GameObject.FindGameObjectWithTag("math");
            Done.GetComponent<ShowMathPuzzle>().isDone();
        }
    }
}

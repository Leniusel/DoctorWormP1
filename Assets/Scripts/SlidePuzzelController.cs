using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzelController : MonoBehaviour
{

    [SerializeField] private Transform puzzelSpace;
    [SerializeField] private Transform Puzzle;

    private List<Transform> pieces;

    private int emptyLocation;
    public int size;
    

    public GameObject key2;
    public GameObject slidePuzzle;
    public GameObject puzzelObject;
    public GameObject player;


    public bool isDone;

    //Set Puzzle
    private void SetSlidePuzzle(float gapThickness)
    {
        //Dimensions of each tile
        float width = 1 / (float)size;

        //Setting rows and columns for Puzzle in correct positions
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                Transform piece = Instantiate(Puzzle, puzzelSpace);
                pieces.Add(piece);
                
                piece.localPosition = new Vector3(-1 + (2 * width * column) + width,+1 - (2 * width * row) - width, 0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + column}";

                //Create an empty space in Puzzle
                if ((row == size - 1) && (column == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    uv[0] = new Vector2((width * column) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (column + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * column) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (column + 1)) - gap, 1 - ((width * row) + gap));

                    mesh.uv = uv;
                }
            }
        }
    }

    void Start()
    {
        isDone = false;
        key2.SetActive(false);

        //Puzzle size set to 3 x 3
        //size = 3;
        pieces = new List<Transform>();
        SetSlidePuzzle(0.01f);
        Shuffle();
    }


    void Update()
    {
       //Give Key here
        if (Solved() && puzzelObject.active == true)
        {
            key2.SetActive(true);
            //slidePuzzle.SetActive(false);
            puzzelObject.SetActive(false);
            
            slidePuzzle.GetComponent<Collider2D>().enabled = false;
            GameObject Done = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;
        }

        //On player interaction
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (click)
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == click.transform)
                    {
                        //Check if empty space detected on up, down, left, right of chosen tile
                        if (EmptySpaceCheck(i, -size, size)) { break; }
                        if (EmptySpaceCheck(i, +size, size)) { break; }
                        if (EmptySpaceCheck(i, -1, 0)) { break; }
                        if (EmptySpaceCheck(i, +1, size - 1)) { break; }
                    }
                }
            }
        }
    }

    //Checks for empty space within the quad 
    private bool EmptySpaceCheck(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
            emptyLocation = i;
            return true;
        }
        return false;
    }

    //Check if each puzzel piece has return to their initial assigned positions
    private bool Solved()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        isDone = true;
        return true;
    }

    //Shuffle pieces for puzzle
    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while (count < (size * size * size))
        {
            int rnd = Random.Range(0, size * size);
            if (rnd == last) { continue; }
            last = emptyLocation;
            if (EmptySpaceCheck(rnd, -size, size))
            {
                count++;
            }
            else if (EmptySpaceCheck(rnd, +size, size))
            {
                count++;
            }
            else if (EmptySpaceCheck(rnd, -1, 0))
            {
                count++;
            }
            else if (EmptySpaceCheck(rnd, +1, size - 1))
            {
                count++;
            }
        }
    }

}
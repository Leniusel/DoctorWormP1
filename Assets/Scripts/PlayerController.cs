using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D r2b;
    public float speed = 5.0f;
    private GameObject player;

    public Animator animator;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        r2b = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject keyPad = GameObject.FindGameObjectWithTag("keyPad");
        GameObject slidePuzzle = GameObject.FindGameObjectWithTag("slidePuzzle");

        if (!keyPad.GetComponent<ShowKeyPad>().keyPadIsOn ||
            !slidePuzzle.GetComponent<ShowSlidePuzzle>().slidePuzzleIsOn)
        {
            Move();
        }
    }

    public void Move()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingDown", true);
            audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingDown", false);
            audio.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("isWalkingUp", true);
            audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("isWalkingUp", false);
            audio.Stop();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("isWalkingRight", true);
            audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isWalkingRight", false);
            audio.Stop();
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalkingLeft", true);
            audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalkingLeft", false);
            audio.Stop();
        }


        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f);

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

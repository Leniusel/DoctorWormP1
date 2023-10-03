using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D r2d = this.GetComponent<Rigidbody2D>();
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

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f);

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

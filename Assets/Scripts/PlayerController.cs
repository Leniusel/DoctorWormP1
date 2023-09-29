using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject keyPad = GameObject.FindGameObjectWithTag("Player");

        if (!keyPad.GetComponent<ShowKeyPad>().keyPadIsOn)
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

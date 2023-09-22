using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform
    public float smoothSpeed = 0.125f; // Adjust the smoothness of camera movement

    private void Start()
    {
        if (target != null)
        {
            // Set the initial position of the camera to the player's position
            transform.position = target.position + new Vector3(0, 0, -10);
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -10); // Offset the camera in the Z-axis
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

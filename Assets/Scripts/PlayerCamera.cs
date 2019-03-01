using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float verticalSpeed;
    public float followDistance;    // How far back the camera is

    public Transform cameraTarget;  // Where the camera is looking

    public Vector2 verticalBounds;  // How far the player can look up/down

    private float vertAngle;

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void LateUpdate()
    {
        updateCamera();
    }

    // Move the camera
    private void move()
    {
        vertAngle += Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSpeed * -1;

        // Check bounds
    }

    // Update the position/orientation of the camera
    private void updateCamera()
    {
        transform.position = cameraTarget.position - cameraTarget.forward*followDistance;
        transform.LookAt(cameraTarget);
        transform.RotateAround(cameraTarget.position, transform.right, vertAngle);
    }

}

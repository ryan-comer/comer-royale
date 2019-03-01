using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float moveSpeed; // How fast to move
    public float horizontalLookSpeed;   // How fast to turn
    public float jumpHeight;    // How high to jump
    public float gravity;   // Falling speed
    public float maxFallSpeed;  // The maximum speed that the player can fall
    public float sprintModifier;    // Faster when sprinting

    private CharacterController characterController;    // Controls movement
    private Vector3 moveDirection = new Vector3();
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            // Only the local player can control
            return;
        }
        move();
        rotate();
    }

    public override void OnStartLocalPlayer()
    {
        // Setup camera target
        Camera.main.GetComponent<PlayerCamera>().cameraTarget = transform;
    }

    // Get input and move character
    private void move()
    {
        float moveX=0, moveY=0, moveZ=0;
        if (characterController.isGrounded)
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed;
            moveZ = Input.GetAxis("Vertical") * moveSpeed;

            moveDirection = new Vector3(moveX, moveY, moveZ);

            // Transform to local space
            moveDirection = transform.TransformVector(moveDirection);

            // Jumping
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }
        }

        // Gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Update position
        characterController.Move(moveDirection * Time.deltaTime);
    }

    // Rotate the player based on mouse movement
    void rotate()
    {
        float rotation = Input.GetAxis("Mouse X") * horizontalLookSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotation);
    }

}

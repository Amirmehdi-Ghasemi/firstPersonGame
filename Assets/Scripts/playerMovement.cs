using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 10f;
    public float crouchHeight = 0.75f;
    public float crouchTime = 2f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    bool onGround, isCrouching;
    float playerHeight = 3f;
    float crouchTimer = 0;
    Vector3 velocity; 

    void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (onGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        characterController.Move(transform.forward * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && onGround && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && onGround)
        {
            characterController.height = crouchHeight;
            isCrouching = true;
        }
        if (isCrouching)
        {
            crouchTimer += Time.deltaTime;
            if (crouchTimer >= crouchTime)
            {
                characterController.height = playerHeight;
                isCrouching = false;
                crouchTimer = 0;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }
}

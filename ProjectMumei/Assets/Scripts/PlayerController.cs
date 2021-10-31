using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float playerMoveSpeed = 10f;

    [SerializeField]
    private float gravity = -2f;
    
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float jumpHeight = 3f;

    private float groundDistance = 0.4f;

    private bool isGrounded;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerFall();
        CheckGrounded();
        playerJump();
        
    }
    void playerMovement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerMoveSpeed * Time.deltaTime);

    }

    void playerFall()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        Debug.Log(velocity);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
    }

    void playerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  //Physic equation to calculate jump velocity 

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _playerMoveSpeed = 6f;
    [SerializeField] private float _runSpeed = 7.5f;
    [SerializeField] private float _defaultPlayerMoveSpeed;
    [SerializeField] private float _slowWalkspeed = 3;
    [SerializeField] private float _gravity = -2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;
    private float _groundDistance = 0.4f;
    private bool _isGrounded;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _defaultPlayerMoveSpeed = _playerMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        PlayerFall();
        CheckGrounded();
        PlayerJump();
        playerSpeedChange();

    }
    void PlayerMovement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _playerMoveSpeed * Time.deltaTime);

    }

    void PlayerFall()
    {
        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -1f;
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {

            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);  //Physic equation to calculate jump velocity 

        }
    }

    void playerSpeedChange()    // change player's speed if different key pressed
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) == false)
        {
            if (_isGrounded == true)
            {
                _playerMoveSpeed = _runSpeed;
            }

        }else if (Input.GetKey(KeyCode.S))
        {
            _playerMoveSpeed = _slowWalkspeed;
        }
        else
        {
            _playerMoveSpeed = _defaultPlayerMoveSpeed;
        }

    }

}

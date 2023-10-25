using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMOVE : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCool;
    public float airMulti;
    bool readyJump;

    [Header("Crouch")]
    public float crouchSpeed;
    public float crouchYscale;
    public float startYscale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask IsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticleInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        crouching
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyJump = true;

        startYscale = transform.localScale.y;

    }

    private void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, IsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticleInput = Input.GetAxisRaw("Vertical");

        // jump
        if(Input.GetKey(jumpKey) && readyJump && grounded)
        {
            readyJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCool);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z);
        }

    }

    private void StateHandler()
    {
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        if(grounded && Input.GetKey(sprintKey))
        {

            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

        }

        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = MovementState.air;
        }


    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticleInput + orientation.right * horizontalInput;

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMulti, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyJump = true;
    }

}

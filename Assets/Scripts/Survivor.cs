using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Photon.Pun;
using System;

public class Survivor : MonoBehaviour
{
    Rigidbody rb;
    Playercontrols playercontrols;

    public StaminaBar staminaBar;

    public GameObject canvas;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public float runSpeed = 40f;
    public float walkSpeed = 20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 moveDirection;
    bool isGrounded;

    public bool isSprint = false;

    public bool canSprint = true;
    public bool isMoving = false;
    public bool loseStamina = false;

    //private Animator animator;


    public bool canMove = false;
    //public loadCam LoadCam;

    //Timer timer;

    PhotonView view;
    public List<GameObject> playersStuff = new List<GameObject>();

    private void OnEnable()
    {
        canvas.SetActive(false);
    }

    private void Start()
    {
        //animator = GetComponent<Animator>();
        //LoadCam = FindObjectOfType<loadCam>();   
        //timer = FindObjectOfType<Timer>();
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        SetupInputs();
        if (view.IsMine)
        {
            foreach (GameObject stuff in playersStuff)
            {
                stuff.SetActive(true);
                SetupInputs();
            }
        }
        else
        {
            this.enabled = false;
        }

        //timer.TimerOn = true;
        //LoadCam.gameObject.SetActive(false);
    }

    void SetupInputs()
    {
        Debug.Log("setup inputs");

        playercontrols = new Playercontrols();
        playercontrols.Gameplay.Movement.performed += Movement_performed;
        playercontrols.Gameplay.Movement.canceled += Movement_canceled;

        playercontrols.Gameplay.Jump.performed += Jump_performed;

        playercontrols.Gameplay.Sprint.performed += Sprint_performed;

        playercontrols.Gameplay.Sprint.canceled += Sprint_canceled;

        playercontrols.Enable();
    }

    private void Sprint_canceled(InputAction.CallbackContext obj)
    {
        isSprint = false;
    }

    private void Sprint_performed(InputAction.CallbackContext obj)
    {
        isSprint = true;
        //speed = runSpeed;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {


        if (isGrounded)
        {
            Debug.Log("Jumped");
            rb.AddForce(Vector3.up * jumpHeight);
        }
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        moveDirection = Vector2.zero;
        isMoving = false;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        moveDirection = obj.ReadValue<Vector2>();
        isMoving = true;
    }

    void Update()
    {
        GroundCheck();
        RotateCamera();

        if (staminaBar.stamina <= 0)
        {
            canSprint = false;
        }
        else if (staminaBar.stamina >= 1)
        {
            canSprint = true;

        }

        if (canSprint == false)
        {
            isSprint = false;
        }

        if (!isMoving)
        {
            canSprint = false;
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }



    private void MovePlayer()
    {
        if (canMove)
        {
            Vector3 forwardDirection = transform.forward * moveDirection.y;
            Vector3 sidewaysDirection = transform.right * moveDirection.x;

            Vector3 actualDirection = forwardDirection + sidewaysDirection;
            actualDirection *= Time.fixedDeltaTime * speed;

            //animator.SetBool("IsMoving", true);

            if (isSprint)
            {
                if (canSprint)
                {
                    actualDirection *= Time.deltaTime * runSpeed;
                    loseStamina = true;
                }
            }
            else
            {
                loseStamina = false;
            }

            rb.MovePosition(transform.position + actualDirection);
        }
       


    }

    void RotateCamera()
    {

    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}

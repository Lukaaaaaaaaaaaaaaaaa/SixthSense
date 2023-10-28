using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Photon.Pun;
using System;

public class Moinster : MonoBehaviour
{
    public bool attack = false;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;
    public GameObject attackCollider;


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
    public bool canJump = true;

    public bool isDead;

    
    //public bool onAttack = false;

    public Animator animator;

    //public Animator animator2;

    public bool isMonster = false;

    public bool canMove = false;

    public GameObject Dead;
    public GameObject DeadCam;
    //public loadCam LoadCam;

    //Timer timer;

    Moinster monster;

    public GameMan health;


    PhotonView view;
    public List<GameObject> playersStuff = new List<GameObject>();



    private void OnEnable()
    {
        canvas.SetActive(false);

        
    }

    private void Start()
    {
        monster = this;
        //LoadCam = FindObjectOfType<loadCam>();   
        //timer = FindObjectOfType<Timer>();
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        

        if (view.IsMine)
        {
            foreach(GameObject stuff in playersStuff)
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
        playercontrols = new Playercontrols();
        playercontrols.Gameplay.Movement.performed += Movement_performed;
        playercontrols.Gameplay.Movement.canceled += Movement_canceled;

        playercontrols.Gameplay.Jump.performed += Jump_performed;

        playercontrols.Gameplay.Sprint.performed += Sprint_performed;

        playercontrols.Gameplay.Sprint.canceled += Sprint_canceled;

        playercontrols.Enable();

        playercontrols.Gameplay.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacked");
        Attack();
        
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
            canJump = true;
            if (canJump)
            {
                Debug.Log("Jumped");
                rb.AddForce(Vector3.up * jumpHeight);
                canJump = false;
            }
            
            

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
    public void Attack()
    {
        if (CanAttack)
        {
            attackCollider.SetActive(true);
            attack = true;
            CanAttack = false;
            animator.SetBool("onAttack", true);
            StartCoroutine(ResetAttackCoolDown());
        }
       
        //if (!CanAttack)
        //{
        //    animator.SetBool("onAttack", false);
        //}
        
    }

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        animator.SetBool("onAttack", false);
        attackCollider.SetActive(false);
        attack = false;
        CanAttack = true;
    }

    public void SendDamage()
    {
        //view.RPC("SendDamage", RpcTarget.Others);
    }

    public void TakeDamage()
    {
        if (view.IsMine)
        {
            //Take Damage

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && view.IsMine)
        {
            other.gameObject.GetComponent<GameMan>().SendDamage();
            Debug.Log("FUCKINAYYY");
        }




    }

    
    void Update()
    {

        if (Dead.activeInHierarchy)
        {
            DeadPlayer();
        }
        

        GroundCheck();
        RotateCamera();

        

        if (staminaBar.stamina <= 0)
        {
            canSprint = false;
        }
        else if(staminaBar.stamina >= 1)
        {
            canSprint = true;
           
        }

        if(canSprint == false)
        {
            isSprint = false;
        }

        if (!isMoving)
        {
            canSprint = false;
            animator.SetBool("IsMoving", false);
            //animator.SetBool("SurvivorMoving", false);

            //animator2.SetBool("IsMoving", false);
            //animator2.SetBool("SurvivorMoving", false);

        }

        if (isMoving)
        {
            animator.SetBool("IsMoving", true);
          //  animator.SetBool("SurvivorMoving", true);

            //animator2.SetBool("IsMoving", true);
            //animator2.SetBool("SurvivorMoving", true);
        }

   


       

    }

    public void DeadPlayer()
    {
        DeadCam.SetActive(true);
        animator.SetBool("Dead", true);
        //monster.enabled = false;
        canMove = false;
        canSprint = false;
        canJump = false;
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(10);
        health.health = 4;
        DeadCam.SetActive(false);
        Dead.SetActive(false);
        animator.SetBool("Dead", false);
        health.health = 4;
        canMove = true;
        canSprint = true;
        canJump = true;

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

            

 

            if (isSprint)
            {
                if (canSprint)
                {
                    actualDirection *= Time.fixedDeltaTime * runSpeed;
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

    //Update is called once per frame


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (view.IsMine)
    //    {
    //        if (other.gameObject.tag == ("Enemy"))
    //        {
    //            
    //            Debug.Log("AUSSSIEEEEE");
    //        }
    //    }
    //}


}

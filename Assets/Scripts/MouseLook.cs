using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    PhotonView view;

    public bool useController;
    public float mouseSensitivity = 100f;

    [SerializeField] float minView = 25f;
    [SerializeField] Transform playerBody;



  //  public float mouseSensitivity = 100f;


    //public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        view = GetComponent<PhotonView>();
    }
    
   
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X Controller") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y Controller") * mouseSensitivity * Time.deltaTime;
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, minView);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}

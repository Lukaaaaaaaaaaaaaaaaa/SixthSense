using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public UnityEvent winCon;

    public GameObject winCube;

    

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Player"))
        {
            winCube.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            

            Debug.Log("worky");
        }
    }


}

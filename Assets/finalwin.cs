using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalwin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            

            Debug.Log("worky");
        }
        if (collider.gameObject.tag == ("Monster"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



            Debug.Log("worky");
        }
    }
}

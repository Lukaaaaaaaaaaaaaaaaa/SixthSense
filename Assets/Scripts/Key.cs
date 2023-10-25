using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public GameObject key; 
    public UnityEvent pickupKey;

    public KeyManager keyManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Player"))
        {
            keyManager.keys.Add(gameObject);

            key.SetActive(false);
            Debug.Log("worky");
        }

        Debug.Log("coli with + " + collider.gameObject.name);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    public List<GameObject> keys = new List<GameObject>();

    public GameObject door;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keys.Count >= 5)
        {
            Debug.Log("DOORGONE");
            Destroy(door);
            //door sounds
            //door anim?
        }
    }
}

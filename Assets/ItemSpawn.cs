using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>();

    public List<Transform> spawnPos = new List<Transform>();

   
    void Start()
    {
       int randomIndex = Random.Range(1, 3);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

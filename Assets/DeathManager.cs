using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    //public List<GameObject> players = new List<GameObject>();

    public GameObject[] players;

    public Timer timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Dead");

        if(players.Length == 2)
        {
            timer.TimeLeft = 0;
        }
    }


   
}

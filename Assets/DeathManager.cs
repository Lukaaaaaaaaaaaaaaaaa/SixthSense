using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();

    public Timer timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Count == 2)
        {
            timer.TimeLeft = 0;
        }
    }
}

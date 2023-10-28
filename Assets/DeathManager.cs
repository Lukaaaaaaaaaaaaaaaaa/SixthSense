using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();

    public List<DIE> playerDie = new List<DIE>();

    public Timer timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DIE[] die = GameObject.FindObjectsOfType<DIE>();


        for(int i = 0; i < die.Length; i++)
        {
            

            if (die[i].isDead == true)
            {
                playerDie.Add(die[i]);
            }
        }

       
        


        if(players.Count == 2)
        {
            timer.TimeLeft = 0;
        }
    }
}

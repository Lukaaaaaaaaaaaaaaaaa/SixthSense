using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public List<Moinster> players = new List<Moinster>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Count == 2)
        {
            SceneManager.LoadScene(4);
        }
    }
}

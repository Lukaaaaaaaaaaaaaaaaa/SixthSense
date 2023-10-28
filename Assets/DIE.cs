using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{
    public Moinster player;

    public DeathManager deathManager;

    public GameMan health;

    public GameObject playerMan;

    //public bool isDead = false;

    void Start()
    {
        player = GetComponent<Moinster>();
        deathManager = FindObjectOfType<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.health == 0)
        {
            //isDead = true;

            transform.gameObject.tag = "Dead";
            //if (!deathManager.players.Contains(playerMan))
            //{
            //    deathManager.players.Add(playerMan);
            //}
            

        }
    }
}

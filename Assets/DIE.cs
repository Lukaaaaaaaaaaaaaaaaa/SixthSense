using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{
    public Moinster player;

    public DeathManager deathManager;

    void Start()
    {
        player = GetComponent<Moinster>();
        deathManager = FindObjectOfType<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            if (!deathManager.players.Contains(gameObject))
            {
                deathManager.players.Add(gameObject);
            }
            
        }
    }
}

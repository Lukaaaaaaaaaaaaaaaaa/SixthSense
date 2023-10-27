using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{
    Moinster player;

    public DeathManager deathManager;

    void Start()
    {
        player = GetComponent<Moinster>();
        deathManager = FindObjectOfType<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Moinster>().dead)
        {
            deathManager.GetComponent<DeathManager>().players.Add(gameObject.GetComponent<Moinster>());
        }
    }
}

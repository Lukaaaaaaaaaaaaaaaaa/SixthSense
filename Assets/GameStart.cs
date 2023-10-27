using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public static GameStart instance;

    public GameObject loadCam;

    public List<GameObject> players = new List<GameObject>();

    public Timer timer;

    public float playerCount = 3;

    bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        AddMonster();
        AddPlayer();
        */

        if (players.Count == playerCount && gameStarted == false)
        {
            gameStarted = true;
            StartGame();
            loadCam.SetActive(false);
        }

        if(players.Count == 2)
        {
           // players[1].GetComponent<Moinster>()
        }

    }

    public void AddPlayer(GameObject obj)
    {
        players.Add(obj);
    }

    public void StartGame()
    {
        loadCam.SetActive(false);
        timer.TimerOn = true;
        Moinster monster = FindObjectOfType<Moinster>();

        monster.canMove = true;


    }
}

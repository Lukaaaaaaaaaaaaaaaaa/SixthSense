using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject loadCam;

    public List<GameObject> players = new List<GameObject>();

    public Timer timer;

    public float playerCount = 1;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        AddMonster();
        AddPlayer();

        
        if(players.Count == playerCount)
        {
            StartGame();
        }

    }

    public void AddMonster()
    {
        Moinster monster = FindObjectOfType<Moinster>();
        monster.GetComponent<Moinster>().canvas.SetActive(false);
        if (monster.isActiveAndEnabled)
        {
            if (!players.Contains(monster.gameObject))
            {
                players.Add(monster.gameObject);
            }
            
        }
    }

    public void AddPlayer()
    {
        PlayerControls[] playerCharcaters = FindObjectsOfType<PlayerControls>();

        for (int i = 0; i < playerCharcaters.Length; i++)
        {
            players.Add(playerCharcaters[i].gameObject);
        }
    }

    public void StartGame()
    {
        loadCam.SetActive(false);
        timer.TimerOn = true;
        Moinster monster = FindObjectOfType<Moinster>();

        monster.canMove = true;

        monster.canvas.SetActive(true);
    }
}
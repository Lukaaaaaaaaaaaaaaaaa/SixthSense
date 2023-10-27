//16.08.2023 - v1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public float minX;
    public float minY;
    public float minZ;
    public float maxX;
    public float maxY;
    public float maxZ;

    public GameObject playerPrefab;

    public string gameVersion;
    string networkStatus;

    public List<GameObject> playerCount = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    private void OnGUI()
    {
        GUILayout.Label(networkStatus); //Shows the status of the network
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connect to Photon servers
        PhotonNetwork.GameVersion = gameVersion; //Sets game version
        networkStatus = "Connecting to Photon";
    }

    //Gets called when the player has connected to the master
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        networkStatus = "Connected to Master";
        PhotonNetwork.JoinLobby();
    }

    //Gets called when the player has joined a lobby
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        networkStatus = "Joined Lobby";
        PhotonNetwork.JoinRandomOrCreateRoom(); //Either creates or joins a random room

       
    }

    //Gets called when the player has joined a room
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        networkStatus = "Room Joined";
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY));

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Monster", spawnPos, Quaternion.identity);
        }
        if(playerCount.Count == 1)
        {
            PhotonNetwork.Instantiate("Survivor2", spawnPos, Quaternion.identity);   
        }
        if (playerCount.Count == 2)
        {
            PhotonNetwork.Instantiate("Survivor3", spawnPos, Quaternion.identity);
        }



    }


    public void ChooseMonster()
    {
        float monsterPlayer = Random.Range(1, 4);

        

        
        
    }
}

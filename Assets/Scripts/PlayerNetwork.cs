using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetwork : MonoBehaviour
{

    PhotonView photonView;
    public bool isMonster;

    int randomRoll;
    public GameObject character1;
    public GameObject character2;

    // Start is called before the first frame update
    void Start()
    {
        GameStart.instance.AddPlayer(gameObject);
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            //Belongs to the player
            if (isMonster)
            {
                GetComponent<Moinster>().enabled = true;
            }
            else
            {
                GetComponent<Survivor>().enabled = true;
            }

            randomRoll = Random.Range(0, 100);
            SetPlayerCharacter();
        }
        else
        {
            //Belongs to a different player
            if (isMonster)
            {
                GetComponent<Moinster>().enabled = false;
            }
            else
            {
                GetComponent<Survivor>().enabled = false;
            }
        }


    }

    public void SetPlayerCharacter()
    {
        if(randomRoll > 50)
        {
            character1.SetActive(false);
        }
        else
        {
            character2.SetActive(false);
        }

        photonView.RPC("SendPlayerCharacter", RpcTarget.Others, randomRoll);
    }

    [PunRPC]
    public void SendPlayerCharacter(int roll)
    {
        randomRoll = roll;
        if (randomRoll > 50)
        {
            character1.SetActive(false);
        }
        else
        {
            character2.SetActive(false);
        }
    }
}

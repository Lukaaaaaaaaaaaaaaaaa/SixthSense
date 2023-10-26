using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetwork : MonoBehaviour
{

    PhotonView photonView;
    public bool isMonster;

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
}

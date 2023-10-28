using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameMan : MonoBehaviour
{

    PhotonView view;
    public GameObject gameOver, heart0, heart1, heart2, heart3;
    public int health; //static int health;

    public float heath = 3;

    public void SendDamage()
    {
        view.RPC("TakeDamage", RpcTarget.Others);
    }

    [PunRPC]
    public void TakeDamage()
    {
        if (view.IsMine)
            health--;
    }

    // Start is called before the first frame update
    void Start()
    {

        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            health = 3;
            heart0.gameObject.SetActive(true);
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine == false)
            return;

       
        if(health == 0)
        {
            gameOver.gameObject.SetActive(true);
            health = 3;
        }


        //switch (health)
        //{
        //    case 4:
        //        heart0.gameObject.SetActive(true);
        //        heart1.gameObject.SetActive(true);
        //        heart2.gameObject.SetActive(true);
        //        heart3.gameObject.SetActive(true);
        //        break;
        //    case 3:
        //        heart0.gameObject.SetActive(true);
        //        heart1.gameObject.SetActive(true);
        //        heart2.gameObject.SetActive(true);
        //        heart3.gameObject.SetActive(false);
        //        break;
        //    case 2:
        //        heart0.gameObject.SetActive(true);
        //        heart1.gameObject.SetActive(true);
        //        heart2.gameObject.SetActive(true);
        //        heart3.gameObject.SetActive(false);
        //        break;
        //    case 1:
        //        heart0.gameObject.SetActive(true);
        //        heart1.gameObject.SetActive(true);
        //        heart2.gameObject.SetActive(false);
        //        heart3.gameObject.SetActive(false);
        //        break;
        //    case 0:
        //        heart0.gameObject.SetActive(true);
        //        heart1.gameObject.SetActive(true);
        //        heart2.gameObject.SetActive(false);
        //        heart3.gameObject.SetActive(false);
        //        break;
        //    default:
        //        heart0.gameObject.SetActive(false);
        //        heart1.gameObject.SetActive(false);
        //        heart2.gameObject.SetActive(false);
        //        heart3.gameObject.SetActive(false);
        //        gameOver.gameObject.SetActive(true);

        //        break;

        //}




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour
{

    public Moinster player;
    Animator animator;

    public GameMan man;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Moinster>().isMoving)
        {
            animator.SetBool("IsMoving", true);
        }
        else if(!player.GetComponent<Moinster>().isMoving)
        {
            animator.SetBool("IsMoving", false);
        }

        if (man.health == 0)
        {
            animator.SetBool("Dead", true);
        }
        else if (man.health > 0)
        {
            animator.SetBool("Dead", false);
        }
    }
}

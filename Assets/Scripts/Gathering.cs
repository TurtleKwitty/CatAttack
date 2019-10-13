using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    private CircleCollider2D cc;
    private bool player1CanGather = false;
    private bool player2CanGather = false;
    private GameObject player1;
    private GameObject player2;
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(player1 != null && player1CanGather == true && Input.GetButtonDown("GatherPlayer1"))
        {
            Debug.Log(player1.name + " is gathering " + gameObject.name);
        }
        else if (player2 != null && player2CanGather == true && Input.GetButtonDown("GatherPlayer2"))
        {
            Debug.Log(player2.name + " is gathering " + gameObject.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if(collision.gameObject.name == "Player1(Clone)")
            {
                player1CanGather = true;

                if(player1 == null)
                   player1 = collision.gameObject;
            }
            else
            {
                player2CanGather = true;

                if (player1 == null)
                    player2 = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.name == "Player1(Clone)")
            {
                player1CanGather = false;
            }
            else
            {
                player2CanGather = false;
            }
        }
    }
}

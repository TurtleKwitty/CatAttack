using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform trans;
    Transform player;

    public float AttackRange = 1;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 LookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        trans.up = (Vector3)LookAt - trans.position;

        /*if(Vector2.Distance(trans.position, player.position) < AttackRange)
        {
            //TODO: Attack the player here
        }*/
    }
}

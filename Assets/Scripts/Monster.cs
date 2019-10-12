using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform trans;
    Transform player;

    public Collider2D AttackCollider;

    public float AttackRange = 1;
    public float AttackDamage = 1;

    public void Init(Transform player)
    {
        this.player = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 LookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        trans.up = GameManager.Instance.Players[0].transform.position - trans.position;

        RaycastHit2D RaycastResult = Physics2D.Raycast(trans.position, trans.up, AttackRange);
        if(RaycastResult && RaycastResult.collider.gameObject.layer == 10)
        {
            Debug.Log("HIT");
            RaycastResult.collider.gameObject.GetComponent<HealthManager>().Attack(AttackDamage);
        }
    }
}

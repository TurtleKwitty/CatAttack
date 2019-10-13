using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIDestinationSetter))]
public class Monster : MonoBehaviour
{
    Transform trans;
    Transform player;

    public float AttackRange = 1;
    public float AttackDamage = 1;

    public void Init(Transform player)
    {
        this.player = player.transform;
        GetComponent<AIDestinationSetter>().target = player;
    }

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //Vector2 LookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var Diff = trans.position - player.position;
            trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Diff.x, -Diff.y) * Mathf.Rad2Deg);

            Debug.Log(trans.up);
            RaycastHit2D RaycastResult = Physics2D.Raycast(trans.position, trans.up, AttackRange);
            Debug.Log(RaycastResult.transform);
            if (RaycastResult.transform != null && RaycastResult.transform.gameObject.layer == 10)
            {
                Debug.Log("HIT");
                RaycastResult.transform.GetComponent<HealthManager>().Attack(AttackDamage);
            }
        }
    }
}

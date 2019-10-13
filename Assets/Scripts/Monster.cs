using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Monster : MonoBehaviour
{
    Transform trans;
    Transform player;

    public float AttackRange = 1;
    public float AttackDamage = 1;
    public float AttacksPerSecond = 1;

    private float AttackTimer = 0;

    public float speed = 5f;
    public float NextWayPointDistance = 3f;

    Path path;
    Seeker seeker;
    int CurrentWaypoint = 0;
    bool ReachedEnd = false;

    public void Init(Transform player)
    {
        this.player = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;

        GetComponent<AIDestinationSetter>().target = player;
    }

    void Callback(Path p) {
        CurrentWaypoint = 0;
        ReachedEnd = false;
        path = p;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //Vector2 LookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var Diff = trans.position - player.position;
            trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Diff.x, -Diff.y) * Mathf.Rad2Deg);
        }
        
        AttackTimer -= Time.deltaTime;
        Debug.Log(AttackTimer);
        if (AttackTimer <= 0)
        {
            RaycastHit2D RaycastResult = Physics2D.Raycast(trans.position, trans.up, AttackRange);
            if (RaycastResult.collider != null) Debug.Log(RaycastResult.transform.gameObject);
            if (RaycastResult.transform != null && RaycastResult.transform.gameObject.layer == 10)
            {
                Debug.Log("HIT");
                RaycastResult.transform.GetComponent<HealthManager>().Attack(AttackDamage);
            }
            AttackTimer = 1 / AttacksPerSecond;
        }
    }
}

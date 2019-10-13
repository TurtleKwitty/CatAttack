using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11){
            coll.size = new Vector2(3, 3);
            Collider2D[] enemies = new Collider2D[9];
            ContactFilter2D filter = new ContactFilter2D();
            filter.layerMask = LayerMask.GetMask("Enemies");
            for( var i = 0; i <  coll.OverlapCollider(filter, enemies); i++)
            {
                Destroy(enemies[i].gameObject);
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

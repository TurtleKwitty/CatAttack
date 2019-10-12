using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .3f);
        GameObject col = collision.gameObject;

        if (col.tag == "Ennemi")
        {
            // DO SOME SHIT WHEN BULLET TOUCH ENNEMI
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    public float AttackDamage;

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

        if (col.layer == 11)
        {
            col.GetComponent<HealthManager>().Attack(AttackDamage);
        }
    }
}

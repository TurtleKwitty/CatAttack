﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float timeBeforeExplosion = 1.5f;
    private float speed = 5f;
    private bool alreadyBoomed = false;
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Impulse);
        Invoke("Boom", 1.5f);
    }

    //IEnumerator Explosion()
    //{
    //    yield return new WaitForSeconds(timeBeforeExplosion);
    //    GetComponent<CircleCollider2D>().enabled = true;
    //    GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //    Destroy(effect, 1.1f);
    //}

    private void Boom()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject,.4f);
        Destroy(effect, 1.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ennemi")
        {
            Debug.Log("Ennemi hit !");
            Boom();
        }
    }
}
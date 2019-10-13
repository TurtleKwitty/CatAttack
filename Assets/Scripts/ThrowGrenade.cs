using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject grenadePrefab;
    private float reloadTime = 5f;
    private float grenadeSpeed = 5f;
    private bool canThrow = true;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player1(Clone)")
        {
            if (Input.GetButton("GrenadePlayer1") && canThrow == true)
            {
                Throw();
                StartCoroutine(ReloadTime());
            }
        }
        else if (gameObject.name == "Player2(Clone)")
        {
            if (Input.GetButton("GrenadePlayer2") && canThrow == true)
            {
                Throw();
                StartCoroutine(ReloadTime());
            }
        }
    }

    private void Throw()
    {
        GameObject bullet = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator ReloadTime()
    {
        canThrow = false;
        yield return new WaitForSeconds(reloadTime);
        canThrow = true;
    }
}

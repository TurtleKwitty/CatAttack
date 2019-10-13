using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    public float timeBetweenShots;
    private float bulletSpeed = 20f;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player1(Clone)")
        {
            if (Input.GetButton("FirePlayer1") && canShoot == true)
            {
                Shooting();
                StartCoroutine(WaitForShooting());
            }
        }
        else if (gameObject.name == "Player2(Clone)")
        {
            if (Input.GetButton("FirePlayer2") && canShoot == true)
            {
                Shooting();
                StartCoroutine(WaitForShooting());
            }
        }
    }

    private void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        float random = Random.Range(1, 10);
        Debug.Log(random);

        if (random <= 5f)
            AudioManager.PlaySound("laserShot1");
        else
            AudioManager.PlaySound("laserShot2");

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator WaitForShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}

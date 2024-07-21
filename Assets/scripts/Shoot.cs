using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPref;
    [SerializeField] float bulletForce;

    bool isShootAvailable = true;
    float shootTimer = 0;
    [SerializeField] float delaySpeed = 0.1f;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && isShootAvailable)
        {
            Normalshoot();
        }

        if (!isShootAvailable)
        {
            if (shootTimer > delaySpeed)
            {
                shootTimer = 0;
                isShootAvailable = true;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }
    }
    void Normalshoot()
    {
        isShootAvailable = false;

        GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

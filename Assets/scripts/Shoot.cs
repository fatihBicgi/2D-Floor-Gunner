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

    public float FastDelaySpeed = 0.10f;
    public float defaultDelaySpeed = 0.30f; 

    public float delaySpeed;

    WariorMove WariorMove;

    private void Start()
    {
        delaySpeed = defaultDelaySpeed;

        WariorMove = gameObject.GetComponent<WariorMove>();

    }
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && isShootAvailable)
        {
            NormalShoot();
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
    void NormalShoot()
    {
        isShootAvailable = false;

        GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        WariorMove.SetisInvisibleNowFalse();
    }   

}

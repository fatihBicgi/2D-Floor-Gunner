using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPref;
    [SerializeField] float bulletForce;

    public GameObject BoosterGameObject;

    BoxCollider2D collider2D;
    SpriteRenderer spriteRenderer;

    WariorMove wariorMove;

    bool isShootAvailable = true;
    float shootTimer = 0;

    public float FastDelaySpeed = 0.10f;
    public float defaultDelaySpeed = 0.30f; 

    public float delaySpeed;

    private void Start()
    {

        wariorMove = gameObject.GetComponent<WariorMove>();

        delaySpeed = defaultDelaySpeed;

        Booster.BoosterCollected += DoBoosterThings;


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
    }


    void DoBoosterThings()
    {
        collider2D = BoosterGameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = BoosterGameObject.GetComponent<SpriteRenderer>();

        collider2D.enabled = false;
        spriteRenderer.enabled = false;

        if (BoosterGameObject.tag == "ShootBooster")
        {
            delaySpeed = FastDelaySpeed;
            StartCoroutine(BackToDefaultShoots());
            
        }
        if (BoosterGameObject.tag == "SpeedBooster")
        {
            wariorMove.defaultSpeed = 8;

            StartCoroutine(BackToDefaultSpeed());
            
        }               

    }
    IEnumerator BackToDefaultShoots()
    {
        yield return new WaitForSeconds(5);

        delaySpeed = defaultDelaySpeed;

    }
    IEnumerator BackToDefaultSpeed()
    {
        yield return new WaitForSeconds(5);

        wariorMove.defaultSpeed = 6;

    }

}

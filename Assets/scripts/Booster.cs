using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Booster : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Shoot shoot;

    WariorMove wariorMove;

    BoosterSpawner boosterSpawner;
    [SerializeField] GameObject boosterSpawnerObject;

    public BoxCollider2D boxCollider2D;
    public SpriteRenderer spriteRenderer;

    [SerializeField] 
    private int useTime = 5;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shoot = player.gameObject.GetComponent<Shoot>();
        wariorMove = player.GetComponent<WariorMove>();

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(TimeDoneForUse());

        boosterSpawner = boosterSpawnerObject.GetComponent<BoosterSpawner>();

        useTime = HalfOfSpawnSpeed();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {        
            GetComponent<Collider2D>().enabled = false;
            spriteRenderer.enabled = false;

            if (gameObject.tag == "ShootBooster")
            {             
                shoot.delaySpeed = shoot.FastDelaySpeed;
                
                StartCoroutine(BackToDefaultShoots());

            }
            if (gameObject.tag == "SpeedBooster")
            {
                wariorMove.defaultSpeed = 8;             

                StartCoroutine(BackToDefaultSpeed());

            }
        }       

    }
 
    IEnumerator TimeDoneForUse()
    {
        yield return new WaitForSeconds(useTime);

        DestroySelf();

    }
    IEnumerator BackToDefaultShoots()
    {
        yield return new WaitForSeconds(5);

        shoot.delaySpeed = shoot.defaultDelaySpeed;

        DestroySelf();

    }
    IEnumerator BackToDefaultSpeed()
    {
        yield return new WaitForSeconds(5);

        wariorMove.defaultSpeed = 6;

        DestroySelf();
    }
    
    private void DestroySelf()
    {

        Destroy(gameObject);
    }

    private int HalfOfSpawnSpeed()
    {
        return (boosterSpawner.GetdelaySpeed() / 2);
    }


}


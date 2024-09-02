using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAi : MonoBehaviour
{

    [SerializeField]
    private GameObject retry;
    
    GameObject player;
    public bool isPlayerInTerritory;

    bool isEnemyDead = false;

    public GameObject target;
    public float speed = 2f , boostedSpeed = 5f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;

    SuperPower superPower;
    [SerializeField] GameObject superPowerObject;

    [SerializeField]
    float 
        health = 100f, 
        maxHealth = 100f;

    [SerializeField] FloatingHealthBar healthBar;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        superPowerObject = GameObject.Find("Invisible");
        target = GameObject.Find("GunnerPix1");
        retry = GameObject.Find("Retry");


        healthBar = GetComponentInChildren<FloatingHealthBar>();

        healthBar.UpdateHealthBar(health, maxHealth);

        superPower = superPowerObject.GetComponent<SuperPower>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        //health = maxHealth;
    }


    void Update()
    {
        if (PlayerIsVisible())
        {
            EnemyMove();                          

            if (health < (maxHealth / 2) && health > 0 )
            {
                ChangeSpriteColor();
                speed = boostedSpeed;
                              
            }
        }       


    }

    private bool PlayerIsVisible()
    {
        return !(superPower.isPlayerInvisibleNow);
    }

    public void EnemyMove()
    {
       
        if (Vector2.Distance(transform.position, target.transform.position) > attack1Range)
        {
            MoveToPlayer();

        }
        else if (Vector2.Distance(transform.position, target.transform.position) <= attack1Range)
        {
            GameOver();
        }
    }

    private void MoveToPlayer()
    {
        transform.LookAt(target.transform.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }

    private void GameOver()
    {
        Debug.Log("You Lose");

        Time.timeScale = 0;

        retry.GetComponent<UnityEngine.UI.Image>().enabled = true;

        retry.GetComponentInChildren<TextMeshPro>().enabled = true;
    }

    public void TakeDamege(float damageAmount)
    {
        health -= damageAmount;

        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            health = 0;
            isEnemyDead = true;
            StartCoroutine(WaitForDead());
            
        }
    }

    public void ChangeSpriteColor()
    {
        spriteRenderer.color = new Color(0, 1, 0, 1); // green
    }

    public bool GetIsEnemyDead()
    {
        return isEnemyDead;
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);


    }
}


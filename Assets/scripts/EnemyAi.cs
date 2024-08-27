using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class EnemyAi : MonoBehaviour
{

    [SerializeField]
    private GameObject retry;
    
    GameObject player;
    public bool isPlayerInTerritory;

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

            if (health < (maxHealth / 2))

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
            Destroy(gameObject);
        }
    }

    public void ChangeSpriteColor()
    {
        spriteRenderer.color = new Color(0, 1, 0, 1); // green
    }
}


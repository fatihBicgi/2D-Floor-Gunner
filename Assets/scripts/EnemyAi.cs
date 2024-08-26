using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class EnemyAi : MonoBehaviour
{

    [SerializeField]
    private GameObject retry;
    
    GameObject player;
    public bool isPlayerInTerritory;

    public Transform target;
    public float speed = 3f;
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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar = GetComponentInChildren<FloatingHealthBar>();

        healthBar.UpdateHealthBar(health, maxHealth);

        superPower = superPowerObject.GetComponent<SuperPower>();
    }

    void Update()
    {
        if (PlayerIsVisible())
        {
            EnemyMove();
        }

    }

    private bool PlayerIsVisible()
    {
        return !(superPower.isPlayerInvisibleNow);
    }

    public void EnemyMove()
    {
       
        if (Vector2.Distance(transform.position, target.position) > attack1Range)
        {
            MoveToPlayer();

        }
        else if (Vector2.Distance(transform.position, target.position) <= attack1Range)
        {
            GameOver();
        }
    }

    private void MoveToPlayer()
    {
        transform.LookAt(target.position);
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
}


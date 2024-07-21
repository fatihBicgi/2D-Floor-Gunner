using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {     
            MoveToPlayer();       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInTerritory = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInTerritory = false;
        }
    }
    public void MoveToPlayer()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);

        if (Vector2.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else if (Vector2.Distance(transform.position, target.position) <= attack1Range)
        {                  
                Debug.Log("You Lose");
                Time.timeScale = 0;
                retry.GetComponent<Image>().enabled = true;
                retry.GetComponentInChildren<Text>().enabled = true;            
        }
    }
}


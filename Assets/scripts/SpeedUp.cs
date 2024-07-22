using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    WariorMove wariorMove;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wariorMove = player.GetComponent<WariorMove>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            wariorMove.defaultSpeed = 8;
            StartCoroutine(ExampleCoroutine());
        }
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(10);
        wariorMove.defaultSpeed = 6;
    }
}

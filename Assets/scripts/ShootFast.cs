using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFast : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    Shoot shoot;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shoot = player.GetComponent<Shoot>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shoot.delaySpeed = 0.10f;
            StartCoroutine(ExampleCoroutine());
        }
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(10);
        shoot.delaySpeed = 0.20f;
    }
}

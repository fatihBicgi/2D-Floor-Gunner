using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Shoot shoot;

    public static event Action BoosterCollected;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shoot = player.gameObject.GetComponent<Shoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shoot.BoosterGameObject = this.gameObject;
            BoosterCollected?.Invoke();

        }
    }
}

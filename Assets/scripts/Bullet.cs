using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] GameObject hitEffect;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        DestroySelf();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.transform.tag == "Enemy")
        {
            DestroySelf();

        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

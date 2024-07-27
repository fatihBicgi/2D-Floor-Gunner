using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    [SerializeField] EnemyAi enemyAi;

    [SerializeField] float damageAmount = 1;

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
            enemyAi= collision.gameObject.GetComponent<EnemyAi>();      
            
            enemyAi.TakeDamege(damageAmount);

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .3f);
            DestroySelf();

        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

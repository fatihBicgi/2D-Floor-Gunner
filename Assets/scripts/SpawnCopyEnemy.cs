using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCopyEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject copyPrefab;

    [SerializeField]
    private int delaySpeed = 10;

    Animator m_Animator;

    void Start()
    {

        m_Animator = GetComponent<Animator>();
        StartCoroutine(SpawnFrequency());

    }

    IEnumerator SpawnFrequency()
    {
        m_Animator.SetBool("isSpawning", false);

        yield return new WaitForSeconds(delaySpeed);

        m_Animator.SetBool("isSpawning", true);

        Vector3 currentPosition = transform.position;

        Vector3 newPosition = new Vector3(currentPosition.x - 1, currentPosition.y + 1, currentPosition.z);

        yield return new WaitForSeconds(2);
        GameObject Booster =
            Instantiate(copyPrefab, newPosition, gameObject.transform.rotation);



        StartCoroutine(SpawnFrequency());
    }
}

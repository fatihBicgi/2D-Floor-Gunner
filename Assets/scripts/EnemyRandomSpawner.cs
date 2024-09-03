using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject BoosterPrefab, LeftDownSpawnPoint, LeftDownWarning;



    [SerializeField]
    private int delaySpeed = 20;


    void Start()
    {
        StartCoroutine(SpawnFrequency());
    }

    IEnumerator SpawnFrequency()
    {                  
        yield return new WaitForSeconds(delaySpeed);
        LeftDownWarning.SetActive(true);

        StartCoroutine(WaitSeconds());

        StartCoroutine(SpawnFrequency());
    }
    IEnumerator WaitSeconds()
    {

        yield return new WaitForSeconds(3);
        GameObject Booster =
            Instantiate(BoosterPrefab, gameObject.transform.position, gameObject.transform.rotation);
        

    }

    public int GetdelaySpeed()
    {
        return delaySpeed;
    }
}

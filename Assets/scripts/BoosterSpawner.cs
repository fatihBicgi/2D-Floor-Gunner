using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject BoosterPrefab;
 
    private int delaySpeed = 10;

    private bool isAvailable = true;
        
    void Start()
    {
        StartCoroutine(SpawnFrequency());
    }

    IEnumerator SpawnFrequency()
    {
        yield return new WaitForSeconds(delaySpeed);
        GameObject Booster = 
            Instantiate(BoosterPrefab, gameObject.transform.position, gameObject.transform.rotation);

        StartCoroutine(SpawnFrequency());
    }

    public int GetdelaySpeed()
    {
        return delaySpeed;
    }
}

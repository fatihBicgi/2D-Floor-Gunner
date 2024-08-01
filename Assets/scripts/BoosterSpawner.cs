using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject BoosterPrefab;
        
    void Start()
    {
        StartCoroutine(SpawnFrequency());
    }
    IEnumerator SpawnFrequency()
    {
        yield return new WaitForSeconds(20);
        GameObject Booster = 
            Instantiate(BoosterPrefab, gameObject.transform.position, gameObject.transform.rotation);

        StartCoroutine(SpawnFrequency());
    }
}

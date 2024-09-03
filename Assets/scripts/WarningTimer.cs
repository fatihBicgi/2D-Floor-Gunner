using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WarningTimer : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(SpawnFrequency());
    }
    IEnumerator SpawnFrequency()
    {

        yield return new WaitForSeconds(4);

        gameObject.SetActive(false);
    }

    
}

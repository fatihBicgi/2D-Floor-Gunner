using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyEnemyAi : EnemyAi
{
    [SerializeField] int destroyTime = 6;

    void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
  
}

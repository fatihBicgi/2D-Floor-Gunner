using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyEnemyAi : EnemyAi
{
    void Awake()
    {
        Destroy(gameObject,6);
    }
  
}

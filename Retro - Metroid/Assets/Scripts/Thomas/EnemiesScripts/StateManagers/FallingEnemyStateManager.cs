using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemyStateManager : FallingEnemyClass
{

    public FallingEnemyStats fallingEnemyStats;

    
    // Start is called before the first frame update
    void Start()
    {
        health = fallingEnemyStats.enemyHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

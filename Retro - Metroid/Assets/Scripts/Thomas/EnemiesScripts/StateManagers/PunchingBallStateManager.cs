using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBallStateManager : EnemyClass
{
    //identification des stats
    public EnemiesBaseStats stats;
    //private float health;

    EnemyClass enemyClass;
    private RuntimeAnimatorController punchingballanims;


    void Start()
    {
        //récupération des stats du scriptable
        health = stats.enemyHealthPoints;

       
    }

    void Update()
    {
       
    }

}

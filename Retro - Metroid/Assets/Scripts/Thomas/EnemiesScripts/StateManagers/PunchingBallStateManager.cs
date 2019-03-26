using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBallStateManager : MonoBehaviour
{
    //identification des stats
    public EnemiesBaseStats stats;


    private float health;

    private RuntimeAnimatorController punchingballanims;

    private EnemyClass enemyfunctions;


    void Start()
    {
        //récupération des stats du scriptable
        health = stats.enemyHealthPoints;
        punchingballanims = stats.enemyAnimator;

        //récupération des fonctions de EnemyClass
        enemyfunctions = new EnemyClass();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        enemyfunctions.TakeDamages(health, float damage);
    }
}

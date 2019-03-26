using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float health;

    //est virtual car peut être override
    public virtual void TakeDamages( float damage)
    {
        health -= damage;
        Debug.Log(health);
    }

}

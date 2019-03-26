using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass
{

    public void TakeDamages(float health, float damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    internal void TakeDamages(float health, float v, object damage)
    {
        throw new NotImplementedException();
    }
}

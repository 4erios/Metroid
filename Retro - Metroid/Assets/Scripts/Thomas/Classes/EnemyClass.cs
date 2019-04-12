using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass //: MonoBehaviour
{
    public float health;

    //est virtual car peut être override
    public void TakeDamages( float damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    public void Death()
    {
        //Placer le loot ici
        //Destroy(this.gameObject);
    }

}

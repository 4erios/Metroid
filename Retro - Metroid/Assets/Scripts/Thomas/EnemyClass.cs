using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass 
{
    void TakeDamages(float health, float damages)
    {
        health -= damages;
        Debug.Log("damage TAKEN");
    }

}

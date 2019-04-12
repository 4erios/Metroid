using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float health;
    public GameObject loot; // Préfab de loot

    //public float attackRange;
    [HideInInspector]
    public int damages;

    //public LayerMask hurtPlayerLayer;

    //est virtual car peut être override
    public void TakeDamages( float damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    public void Death()
    {
        GameObject objloot;
        objloot = Instantiate(loot, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        Debug.Log("dead!");
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.name == "MyGameObjectTag")
        {
            //to deal damages : PlayerLifeSystem.TakeDamage(damages)
            GetComponent<PlayerLifeSystem>().TakeDamage(damages);
            
        }
    }

}

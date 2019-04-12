using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float health;

    //public float attackRange;
    [HideInInspector]
    public int damages;

    public bool hurt = false; 

    //public LayerMask hurtPlayerLayer;

    //est virtual car peut être override
    public void TakeDamages( float damage)
    {
        health -= damage;
        Debug.Log(health);
        StartCoroutine(HurtCoroutine(0.3f));

    }

    public void Death()
    {
        //Placer le loot ici
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

    private IEnumerator HurtCoroutine (float time)
    {
        hurt = true;
        yield return new WaitForSeconds(time);
        hurt = false;
    }

}

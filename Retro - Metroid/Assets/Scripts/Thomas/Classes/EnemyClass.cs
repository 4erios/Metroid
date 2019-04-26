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
        GameObject objloot;
        objloot = Instantiate(loot, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        Debug.Log("dead!");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //to deal damages : PlayerLifeSystem.TakeDamage(damages)
            collision.GetComponent<PlayerLifeSystem>().TakeDamage(damages);
            
        }
    }

    private IEnumerator HurtCoroutine (float time)
    {
        hurt = true;
        yield return new WaitForSeconds(time);
        hurt = false;
    }

}

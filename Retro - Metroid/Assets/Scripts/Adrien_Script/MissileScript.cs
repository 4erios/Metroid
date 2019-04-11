using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;
    public float duration = 0.1f;
    public Transform MissilePos;
    public float MissileRadius;
    public LayerMask Enemies;
    



    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        

      
        Destroy(gameObject, duration);


    }

    private void Update()
    {

        /*Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(MissilePos.position, MissileRadius);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemies>().TakeDamage(damage);


        }*/



    }

    void OnTriggerEnter2D()
    {

        Destroy(gameObject);

    }

}  

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




    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {



        
       // Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject, duration);


    }

}  

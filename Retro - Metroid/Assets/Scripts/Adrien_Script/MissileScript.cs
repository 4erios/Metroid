using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;
    public float duration = 0.1f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, duration);
        anim.SetTrigger("Explosion");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player")
        {
            if (hitInfo.gameObject.GetComponent<EnemyClass>() != null)
            {
                hitInfo.gameObject.GetComponent<EnemyClass>().TakeDamages(20000);
            }
            Destroy(gameObject);
            anim.SetTrigger("Explosion");
        }
    }
}  

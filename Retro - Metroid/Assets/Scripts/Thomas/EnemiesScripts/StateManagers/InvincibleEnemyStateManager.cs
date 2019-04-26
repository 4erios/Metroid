using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEnemyStateManager : EnemyClass
{
    public EnemiesBaseStats invincibleEnemyStats;

    private float speed;

    public Transform[] nbwaypoints;

    int current = 0;
    float WPradius = 1;
    //private float damages;
    //to deal damages : PlayerLifeSystem.TakeDamage(damage)

    public SpriteRenderer spriteRenderer;

    public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        speed = invincibleEnemyStats.enemySpeed;
        damages = invincibleEnemyStats.enemyDamages;

        enemyTransform = this.gameObject.transform;

        spriteRenderer.flipX = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    

    void Patrol()
    {
        if(Vector2.Distance(nbwaypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            FlipSprite();

            if(current >= nbwaypoints.Length)
            {
                current = 0;
                FlipSprite();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, nbwaypoints[current].transform.position, Time.deltaTime * speed);
    }

    public void FlipSprite()
    {
        if(spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    

}

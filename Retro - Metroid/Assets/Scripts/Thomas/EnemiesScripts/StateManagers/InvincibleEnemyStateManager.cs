using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEnemyStateManager : EnemyClass
{
    public EnemiesBaseStats invincibleEnemyStats;

    private float speed;
    public Transform trajectPointA;
    public Transform trajectPointB;

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

        MoveRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTransform.position.x == trajectPointA.position.x)
        {
            MoveLeft();
            FlipSprite();
        }

        else if (enemyTransform.position.x == trajectPointB.position.x)
        {
            MoveRight();
            FlipSprite();
        }
    }

    public void MoveRight()
    {
        enemyTransform.position = Vector2.Lerp(trajectPointA.position, trajectPointB.position, speed);
    }

    public void MoveLeft()
    {
        enemyTransform.position = Vector2.Lerp(trajectPointB.position, trajectPointA.position, speed);
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

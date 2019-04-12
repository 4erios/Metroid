using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerStateManager : EnemyClass
{
    public EnemiesBaseStats crawlerBaseStats;

    public Transform[] nbwaypoints;
    int current = 0;
    private float speed;
    float WPradius = 1;


    // Start is called before the first frame update
    void Start()
    {
        damages = crawlerBaseStats.enemyDamages;
        health = crawlerBaseStats.enemyHealthPoints;
        speed = crawlerBaseStats.enemySpeed;

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Death();
        }

        CrawlerPatrol();
    }

    void CrawlerPatrol()
    {
        if (Vector2.Distance(nbwaypoints[current].transform.position, transform.position) < WPradius)
            {
                current++;

                if (current >= nbwaypoints.Length)
                {
                    current = 0;
                }
            }
        if (!hurt)
        transform.position = Vector2.MoveTowards(transform.position, nbwaypoints[current].transform.position, Time.deltaTime * speed);
        
    }
}

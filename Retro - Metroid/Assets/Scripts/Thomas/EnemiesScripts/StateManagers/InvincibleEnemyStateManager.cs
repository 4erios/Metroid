using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEnemyStateManager : MonoBehaviour
{
    public EnemiesBaseStats invincibleEnemyStats;
    public EnemyClass enemyClass;

    private float speed;
    public Transform trajectPointA;
    public Transform trajectPointB;

    private float damages;

   


    // Start is called before the first frame update
    void Start()
    {
        speed = invincibleEnemyStats.enemySpeed;

        damages = invincibleEnemyStats.enemyDamages;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            enemyClass.TakeDamages(damages);
        }
    }

    
}

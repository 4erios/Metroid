using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : DamageSystem
{
    [HideInInspector]
    private int lifeMob;

    private void Start()
    {
        lifeMax = lifeMob;
        currentLife = lifeMob;
    }

    void Update()
    {
        readCurentLife = currentLife;

        DeadSystem();
    }

    private void DeadSystem()
    {
        if (currentLife <= 0)
        {
            //Loot Here
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : DamageSystem
{
    [HideInInspector]
    private int lifeMob;
    [SerializeField]
    private GameObject loot; // Préfab de loot

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
            GameObject objloot;
            objloot = Instantiate(loot, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }
}

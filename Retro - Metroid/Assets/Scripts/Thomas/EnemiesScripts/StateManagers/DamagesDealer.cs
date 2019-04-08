using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesDealer : MonoBehaviour
{

    private float damage = 5;
    public EnemyClass enemyClass;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            enemyClass.TakeDamages(damage);
        }
    }
}

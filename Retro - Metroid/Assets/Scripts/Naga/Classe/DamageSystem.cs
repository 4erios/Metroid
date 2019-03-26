using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    //Life
    protected int lifeMax;
    [SerializeField]
    protected int currentLife;
    public int readCurentLife;

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
    }
}

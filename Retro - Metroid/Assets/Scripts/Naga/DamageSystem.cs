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

    //Damage taken
    public int lifeFlux;

    protected void LifeSystem()
    {
        if (lifeFlux != 0)
        {
            currentLife -= lifeFlux;
            lifeFlux = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : DamageSystem
{
    //Stack
    private int maxStack = 0;
    [SerializeField]
    private int stack = 0;
    [HideInInspector]
    public int readPercentStack;

    private void Start()
    {
        lifeMax = 99;
        currentLife = 30;
    }

    private void Update()
    {
        readCurentLife = currentLife;

        ForUIStack();

        StackSystem();

        DeadSystem();
    }


    private void ForUIStack()
    {
        readPercentStack = stack / 10;
    }

    private void StackSystem()
    {
        if (lifeMax < currentLife)
        {
            if (stack < maxStack)
                stack++;
            currentLife = lifeMax;
        }

    }

    private void DeadSystem()
    {
        if (currentLife <= 0)
        {
            stack--;
            currentLife = 99 + currentLife;
        }

        if (stack < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void EnergyTank()
    {
        maxStack++;
        stack++;
        currentLife = 99;
    }
}

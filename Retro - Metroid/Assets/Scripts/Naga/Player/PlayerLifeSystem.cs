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
    public int readStack;
    public int initLife = 30;
    private bool canBeHit = true;

    private void Start()
    {
        lifeMax = 99;
        currentLife = initLife;
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
        readStack = stack;
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
            GameObject.Find("Life Singleton").GetComponent<LifeSingleton>().Dead();
            Destroy(this.gameObject);
        }
    }

    public void EnergyTank()
    {
        maxStack++;
        stack++;
        currentLife = 99;
    }

    public void Energy()
    {
        currentLife += 15;
    }

    public void TakeDamage(int damage)
    {
        if (canBeHit)
        {
            Debug.Log("Oh non! " + damage + " dégats pour Samus");
            currentLife -= damage;
            StartCoroutine(Invincible(2f));
        }
    }

    IEnumerator Invincible(float time)
    {
        canBeHit = false;

        this.gameObject.GetComponent<colorChangeScript>().StartHitEffect(time);
        yield return new WaitForSeconds(time);

        canBeHit = true;
    }
}

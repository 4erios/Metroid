using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLoot : MonoBehaviour
{
    [SerializeField]
    private bool energyTank = false;
    [SerializeField]
    private bool missile = false;
    [SerializeField]
    private bool energy = false;
    [SerializeField]
    private bool skill = false;
    private GameObject player;


    private void Update()
    {
        int countBool = 0;

        if (energyTank)
            countBool++;
        if (missile)
            countBool++;
        if (energy)
            countBool++;
        if (skill)
            countBool++;

        if(countBool != 1)
            Debug.LogError("<b>Trop d'options actives</b>"); // Trop de bool sont true, ce n'est pas normal tricheur!

        countBool = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Affectation();
            Destroy(gameObject);
        }
    }

    private void Affectation()
    {
        if (skill)
            Skill();
        else if (energy)
            Energy();
        else if (missile)
            Missile();
        else if (energyTank)
            EnergyTank();
    }

    private void EnergyTank()
    {
        player.gameObject.GetComponent<PlayerLifeSystem>().EnergyTank();
    }

    private void Missile()
    {
        //player.gameObject.GetComponent<PlayerLifeSystem>().missile++;
    }

    private void Energy()
    {
        player.gameObject.GetComponent<PlayerLifeSystem>().Energy();
    }

    private void Skill()
    {
        //player.gameObject.GetComponent<PlayerLifeSystem>().unlockedSkill(this.gameObject.name);
    }
}

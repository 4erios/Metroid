using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLoot : MonoBehaviour
{
    [SerializeField]
    private bool missile = false;
    [SerializeField]
    private Sprite missileSprite;
    [SerializeField]
    private bool energy = false;
    [SerializeField]
    private Sprite energySprite;
    private GameObject player;
    private int selection; // Chiffre au hasard pour le loot

    private void Start()
    {
        LootSelection();

        if (selection == 6 || selection == 5)
        {
            energy = true;
        }

        else if (selection == 4)
        {
            missile = true;
        }

        else
        {
            Destroy(gameObject);
        }

        SetupSprite();
    }

    private void Update()
    {
        int countBool = 0;

        if (missile)
            countBool++;
        if (energy)
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
        if (energy)
            Energy();
        else if (missile)
            Missile();
    }

    private void Missile()
    {
        //player.gameObject.GetComponent<PlayerLifeSystem>().missile++;
    }

    private void Energy()
    {
        player.gameObject.GetComponent<PlayerLifeSystem>().Energy();
    }

    private void SetupSprite()
    {
        if (energy)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = energySprite;

        else if (missile)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = missileSprite;
    }

    private void LootSelection()
    {
        selection = Random.Range(0, 15);
    }
}

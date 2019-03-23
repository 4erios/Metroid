using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTank : MonoBehaviour
{
    public SkillPointScriptableObject skillElement;
    private string nameObj;
    public string skillName;


    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = skillElement.visuObj;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dedans");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLifeSystem>().EnergyTank();
            Destroy(gameObject);
        }
    }
}

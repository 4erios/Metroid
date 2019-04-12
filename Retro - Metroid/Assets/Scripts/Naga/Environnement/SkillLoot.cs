using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLoot : MonoBehaviour
{
    private bool skill = false;
    private GameObject player;
    [SerializeField]
    private Sprite lootedSprite;
    [SerializeField]
    private string skillName;

    private void Start()
    {
        if (skillName == "")
        {
            Debug.LogError("Change the name by the Skill");
            Debug.Break();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Skill();
            SetupSprite();
        }
    }

    private void Skill()
    {
        //player.gameObject.GetComponent<PlayerLifeSystem>().unlockedSkill(skillName);
    }

    private void SetupSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = lootedSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLoot : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Sprite lootedSprite;
    [SerializeField]
    private string skillName;
    private bool destroyed = false;
    private GameObject skillManager;

    private void Start()
    {
        skillManager = GameObject.Find("Skill Manager Singleton");

        if (skillName == "")
        {
            Debug.LogError("Complete the Skill Name on" + this.gameObject.name);
            Debug.Break();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !destroyed)
        {
            player = collision.gameObject;
            StartCoroutine(Skill());
        }
    }

    IEnumerator Skill()
    {
        destroyed = true;
        player.GetComponent<Freezer>().MisterFreeze();
        skillManager.GetComponent<SkillManager>().UnlockedSkill(skillName);
        yield return new WaitForSeconds(3f);
        player.GetComponent<Freezer>().Barbecue();
        if (skillName == "Boule")
            Destroy(gameObject);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = lootedSprite;
    }
}

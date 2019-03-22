using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointSetup : MonoBehaviour
{
    public SkillPointScriptableObject skillElement;
    private string nameObj;
    public string skillName;


    void Start()
    {
        nameObj = skillElement.nameObj;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = skillElement.visuObj;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            skillName = skillElement.skillName;
            Destroy(gameObject);
        }
    }

}

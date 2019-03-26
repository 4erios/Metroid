using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointSetup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void unlockedSkill(string skillName)
    {

    }
}

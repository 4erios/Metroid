using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Skill Manager Singleton").GetComponent<SkillManager>().GameReset();
            SceneManager.LoadScene(3);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSingleton : MonoBehaviour
{
    #region Démarrage
    public static LifeSingleton manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    #endregion

    private int globalLife = 3;

    public void Dead()
    {
        globalLife--;

        if (globalLife <= 0)
        {
            GameObject.Find("Skill Manager Singleton").GetComponent<SkillManager>().GameReset();
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(2);
        }
    }
}

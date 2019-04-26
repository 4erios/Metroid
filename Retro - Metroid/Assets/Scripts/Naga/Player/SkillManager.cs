using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    #region Démarrage
    public static SkillManager manager;

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

    [SerializeField]
    private bool skillBoule = false;
    [SerializeField]
    private bool skillBombe = false;
    [SerializeField]
    private bool skillMissile = false;
    [SerializeField]
    private bool skillGravity = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(skillBombe || skillGravity || skillBoule || skillMissile)
        {
            Debug.LogError("One or more skill are enable");
            Debug.Break();
        }
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (skillGravity)
                player.GetComponent<MoveJump>().haveGravityBelt = true;

            if (skillMissile)
                player.GetComponent<Chara_Controller_Missile>().enabled = true;

            if (skillBoule)
                player.GetComponent<Player_sphere>().haveSphereMode = true;

            if (skillBombe)
                player.GetComponent<Player_sphere>().haveSphereBomb = true;
        }
    }

    public void UnlockedSkill(string skillName)
    {
        FindObjectOfType<Audio_Manager>().Play("Bonus");

        if (skillName == "Gravity" && !skillGravity)
            skillGravity = true;

        else if (skillName == "Missile" && !skillMissile)
            skillMissile = true;

        else if (skillName == "Boule" && !skillBoule)
            skillBoule = true;

        else if (skillName == "Bombe" && !skillBombe)
            skillBombe = true;
    }

    public void GameReset()
    {
        skillBombe = false;
        skillBoule = false;
        skillGravity = false;
        skillMissile = false;
    }
}

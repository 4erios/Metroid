using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    private bool skillBoule = false;
    [SerializeField]
    private bool skillBombe = false;
    [SerializeField]
    private bool skillMissile = false;
    [SerializeField]
    private bool skillGravity = false;

    private void Start()
    {
        if(skillBombe || skillGravity || skillBoule || skillMissile)
        {
            Debug.LogError("One or more skill are enable");
            Debug.Break();
        }
    }

    void Update()
    {
        if (skillGravity)
            this.gameObject.GetComponent<MoveJump>().haveGravityBelt = true;

        if (skillMissile)
            this.gameObject.GetComponent<Chara_Controller_Missile>().enabled = true;

        if (skillBoule)
            this.gameObject.GetComponent<Player_sphere>().haveSphereMode = true;

        if (skillBombe)
            this.gameObject.GetComponent<Player_sphere>().haveSphereBomb = true;
    }

    public void UnlockedSkill(string skillName)
    {
        if (skillName == "Gravity" && !skillGravity)
            skillGravity = true;

        else if (skillName == "Missile" && !skillMissile)
            skillMissile = true;

        else if (skillName == "Boule" && !skillBoule)
            skillBoule = true;

        else if (skillName == "Bombe" && !skillBombe)
            skillBombe = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public Chara_Controller_Missile missileFire;
    public MoveJump moveJump;
    public Player_sphere bouleScript;
    public Fire fire;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Freeze the player
    /// </summary>
    public void MisterFreeze ()
    {
        anim.SetBool("Boule_State", false);
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsFiring", false);
        anim.SetBool("IsLookingUp", false);
        anim.SetFloat("Speed", 0);
        anim.Play("Player_Idle");
        rb.velocity = Vector2.zero;
        missileFire.enabled = false;
        moveJump.enabled = false;
        bouleScript.enabled = false;
        fire.enabled = false;
    }

    /// <summary>
    /// Unfreeze the player
    /// </summary>
    public void Barbecue ()
    {
        missileFire.enabled = true;
        moveJump.enabled = true;
        bouleScript.enabled = true;
        fire.enabled = true;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            MisterFreeze();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Barbecue();
        }
    }
}

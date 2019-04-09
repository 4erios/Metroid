﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sphere : MonoBehaviour
{
    // Start is called before the first frame update

    /*public BoxCollider2D samus;
    public BoxCollider2D boule;*/
    public bool collision;
    Animator anim;
    public GameObject bombePrefab;
    public Transform bombe;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < -0.1f)
        {
            anim.SetBool("State Boule", true);
            Debug.Log("Je suis en boule");
    
        }


        if (Input.GetAxis("Vertical") > 0.1f)
        {
            anim.SetTrigger("Haut");
            anim.SetBool("State Boule", false);
            Debug.Log("Je me relève");
        }


        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Saut");
            anim.SetBool("State Boule", false);
            Debug.Log("Je voulais sauter");
        }

        if (anim.GetBool("StateBoule") && Input.GetButtonDown("Fire")) {

            Instantiate(bombePrefab, bombe.position, bombe.rotation);

        }
        /*if (((Input.GetAxis("Vertical") > 0.1f) || Input.GetButtonDown("Jump")) && !collision)
            {

            boule.isTrigger = true;
            samus.isTrigger = false;
            Debug.Log("Je redeviens Samus");

        }*/



    }

    private void OnTriggerStay2D(Collider2D samus)
    {
        anim.SetBool("Collision", true);
        Debug.Log("JE TOUCHE");
    }
}

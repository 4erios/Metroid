using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sphere : MonoBehaviour
{
    // Start is called before the first frame update


    public bool collision;
    Animator anim;
    public GameObject bombePrefab;
    public Transform bombePosition;
    public GameObject ExplosionPrefab;
    public Transform CeilingCheck;
    public float Radius = 5f;
    public LayerMask Ground;
    [HideInInspector]
    public bool haveSphereMode = false;
    [HideInInspector]
    public bool haveSphereBomb = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (haveSphereMode)
        {
            // Permet le passage en boule
            if (!MoveJump.inverseGravity)
            {
                if (Input.GetAxis("Vertical") < -0.5f)
                {
                    anim.SetBool("Boule_State", true);
                }

                if (Input.GetAxis("Vertical") > 0.3f && anim.GetBool("Collision") == false)
                {
                    anim.SetTrigger("Haut");
                    anim.SetBool("Boule_State", false);
                }
            }

            else
            {
                if (Input.GetAxis("Vertical") > 0.5f)
                {
                    anim.SetBool("Boule_State", true);
                }

                if (Input.GetAxis("Vertical") < -0.3f && anim.GetBool("Collision") == false)
                {
                    anim.SetTrigger("Haut");
                    anim.SetBool("Boule_State", false);
                }
        }


        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Saut");
            anim.SetBool("Boule_State", false);

        }
    }

        // Permet de poser les bombes
        if (anim.GetBool("Boule_State") == true && Input.GetButtonDown("Fire") && haveSphereBomb)
        {

            Instantiate(bombePrefab, bombePosition.position, bombePosition.rotation);
        }

        // Permet de bloquer la boule si elle détecte des collisions
        /*if (anim.GetBool("Boule_State") && anim.GetBool("Collision"))
        {

            anim.SetBool("Boule State", true);


        }*/

        // Permet de bloquer la boule si elle détecte des collisions
        if (anim.GetBool("Boule_State") == true)
        {
            /*Collider2D[] colliders = Physics2D.OverlapCircleAll(CeilingCheck.position, Radius, Ground);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject && colliders[i].gameObject != null)
                {
                }
            }*/

            if (Physics2D.OverlapCircle(CeilingCheck.position, Radius, Ground))
            {
                anim.SetBool("Collision", true);
                Debug.Log("JE TOUCHE");
            }
            else
            {
                anim.SetBool("Collision", false);
            }

            // Permet d'empêcher à la boule de sauter
            anim.SetBool("IsJumping", false);

        }

    }


   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sphere : MonoBehaviour
{
    // Start is called before the first frame update

    /*public BoxCollider2D samus;
    public BoxCollider2D boule;*/
    public bool collision;
    Animator animator;
    public bool bouleState = false;
    public GameObject bombePrefab;
    public Transform bombe;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < -0.1f)
        {
            animator.SetTrigger("Bas");
            Debug.Log("Je suis en boule");
            bouleState = true;
        }


        if (Input.GetAxis("Vertical") > 0.1f)
        {
            animator.SetTrigger("Haut");
            Debug.Log("Je me relève");
        }


        if(Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Saut");
            Debug.Log("Je voulais sauter");
        }

        if (bouleState == true && Input.GetButtonDown("Fire")) {

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
        animator.SetBool("Collision", true);
        Debug.Log("JE TOUCHE");
    }
}

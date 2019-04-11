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

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < -0.1f)
        {
            anim.SetBool("Boule_State", true);
            Debug.Log("Je suis en boule");
    
        }


        if (Input.GetAxis("Vertical") > 0.1f)
        {
            anim.SetTrigger("Haut");
            anim.SetBool("Boule_State", false);
            Debug.Log("Je me relève");
        }


        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Saut");
            anim.SetBool("Boule_State", false);
            Debug.Log("Je voulais sauter");
        }

        if (anim.GetBool("Boule_State") == true && Input.GetButtonDown("Fire")) {

            Debug.Log("JE CHIE UNE BOMBE");
            Instantiate(bombePrefab, bombePosition.position, bombePosition.rotation);
            //StartCoroutine(TimeBeforeExplosion());

         

        }
    

    }

    private void OnTriggerStay2D(Collider2D samus)
    {
        anim.SetBool("Collision", true);
        Debug.Log("JE TOUCHE");
    }


    IEnumerator TimeBeforeExplosion()
    {

        yield return new WaitForSeconds(1);
        Instantiate(ExplosionPrefab, bombePosition.position, bombePosition.rotation);
    }
}

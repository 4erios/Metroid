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
         
        }


        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Saut");
            anim.SetBool("Boule_State", false);
         
        }

        if (anim.GetBool("Boule_State") == true && Input.GetButtonDown("Fire")) {

        
            Instantiate(bombePrefab, bombePosition.position, bombePosition.rotation);
   
        }

        if (anim.GetBool("Boule_State") && anim.GetBool("Collision"))
        {

            anim.SetBool("Boule State", true);


        }

        if (anim.GetBool("Boule_State") == true)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(CeilingCheck.position, Radius, 8))
            {
                anim.SetBool("Boule_State", true);
            }




        }

    /*private void OnTriggerStay2D(Collider2D samus)
    {
        anim.SetBool("Collision", true);
        Debug.Log("JE TOUCHE");*/
    }


    IEnumerator TimeBeforeExplosion()
    {

        yield return new WaitForSeconds(1);
        Instantiate(ExplosionPrefab, bombePosition.position, bombePosition.rotation);
    }
}
